using SeguridadInformatica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using TallerSeguridad.ControladoraWeb;
using TallerSeguridadInformatica.Dominio;
using System.Text;
using Sentry;
using Sentry.AspNet;

namespace TallerSeguridadInformatica.Paginas
{
    public partial class Ingreso : System.Web.UI.Page
    {
        private IDisposable _sentry;

        protected void Application_Start()
        {
            // Initialize Sentry to capture AppDomain unhandled exceptions and more.
            _sentry = SentrySdk.Init(o =>
            {
                o.AddAspNet();
                o.Dsn = "https://f5937a6994f141c3bcdf5ca3a0920bec@o1363943.ingest.sentry.io/6657399";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100%
                // of transactions for performance monitoring.
                // We recommend adjusting this value in production
                o.TracesSampleRate = 1.0;
            });
        }

        // Global error catcher
        protected void Application_Error() => Server.CaptureLastError();

        protected void Application_BeginRequest()
        {
            Context.StartSentryTransaction();
        }

        protected void Application_EndRequest()
        {
            Context.FinishSentryTransaction();
        }

        protected void Application_End()
        {
            // Flushes out events before shutting down.
            _sentry?.Dispose();
        }

        ControladoraWeb controladora = new ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void inicioSesion(object sender, EventArgs e)
        {
            if(usuario.Text == "" || contrasenia.Text == "")
            {
                lblMensaje.Text = "Complete todos los datos.";
            }
            else
            {
                List<IntentosFallidos> listaIntFall = controladora.listarIntentos();
                List<Usuario> listaUsuarios = controladora.listarUsuarios();
                string Nombre = usuario.Text;
                string Contraseña = "";
                byte[] bytes = Encoding.Unicode.GetBytes(contrasenia.Text);
                SHA256Managed hashstring = new SHA256Managed();
                byte[] hash = hashstring.ComputeHash(bytes);
                foreach (byte x in hash)
                {
                    Contraseña += String.Format("{0:x2}", x);
                }
                int cont = 0;
                foreach (Usuario unUsuario in listaUsuarios)
                {
                    if (unUsuario.Nombre == Nombre)
                    {
                        foreach (IntentosFallidos intFall in listaIntFall)
                        {
                            if (intFall.IdUsuario == unUsuario.Id)
                            {
                                cont++;
                            }
                        }
                    }
                }
                if (cont == 5)
                {
                    lblMensaje.Text = "Maximo de intentos permitidos, intente mas tarde.";
                }
                if (cont < 5)
                {

                    foreach (Usuario unUsuario in listaUsuarios)
                    {
                        if (unUsuario.Nombre == Nombre)
                        {
                            if (unUsuario.Contraseña == Contraseña)
                            {
                                if(controladora.altaAudit(unUsuario.Id, "Un usuario ah ingresado"))
                                {
                                    System.Web.HttpContext.Current.Session["userId"] = unUsuario.Id;
                                    

                                    Response.Redirect("~/Paginas/Promociones.aspx");
                                } 
                            }
                            else
                            {
                                if (controladora.altaIntentos(unUsuario.Id))
                                {
                                    lblMensaje.Text = "No se pudo iniciar sesion.";
                                }
                            }
                        }
                    }
                    lblMensaje.Text = "No se pudo iniciar sesion.";
                }
            }
            
        }
    }
}