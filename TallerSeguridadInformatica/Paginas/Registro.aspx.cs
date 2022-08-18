using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SeguridadInformatica.Dominio;
using TallerSeguridad.ControladoraWeb;
using Sentry;
using Sentry.AspNet;

namespace TallerSeguridadInformatica.Paginas
{
    public partial class Registro : System.Web.UI.Page
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

        protected void registro(object sender, EventArgs e)
        {
            if (usuario.Text == "" || contrasenia.Text == "")
            {
                lblMensaje.Text = "Complete todos los datos.";
            }
            else
            {
                if (contrasenia.Text.Length < 16)
                {
                    lblMensaje.Text = "La contraseña debe ser mayor a 16 caracteres";
                }
                else
                {
                    List<Usuario> listaUsuarios = controladora.listarUsuarios();
                    string Nombre = HttpUtility.HtmlEncode(usuario.Text);
                    string Contraseña = "";
                    byte[] bytes = Encoding.Unicode.GetBytes(HttpUtility.HtmlEncode(contrasenia.Text));
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
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        if (controladora.altaUsuario(Nombre, Contraseña))
                        {
                            Response.Redirect("~/Paginas/Ingreso.aspx");
                        }
                        else
                        {
                            lblMensaje.Text = "Error al registrarse";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Error al registrarse";
                    }
                }
                
            }
            

        }
    }
}