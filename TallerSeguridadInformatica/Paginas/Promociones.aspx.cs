using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TallerSeguridad.ControladoraWeb;
using Sentry;
using Sentry.AspNet;
namespace TallerSeguridadInformatica.Paginas
{
    public partial class Promociones : System.Web.UI.Page
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
        ControladoraWeb unaControladora = new ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["userId"] == null)
            {
                Response.Redirect("~/Paginas/Ingreso.aspx");
            }
        }

        protected void altaPromocion(object sender, EventArgs e)
        {
            if (titulo.Text == "" || desc.Text == "" || preO.Text == "" || preP.Text == "" || descuento.Text == "" || img.HasFile == false || dtlls.Text == "" || condic.Text == "")
            {
                lblMensaje.Text = "Ingrese todos los datos.";
            }
            else
            {
                string Titulo = HttpUtility.HtmlEncode(titulo.Text);
                string Desc = HttpUtility.HtmlEncode(desc.Text);
                double PreO = double.Parse(HttpUtility.HtmlEncode(preO.Text));
                double PreP = double.Parse(HttpUtility.HtmlEncode(preP.Text));
                int Descuento = int.Parse(HttpUtility.HtmlEncode(descuento.Text));
                string Imagen = "";
                if (img.HasFile)
                {
                    img.SaveAs(Server.MapPath("~/BookImg/") + System.IO.Path.GetFileName(img.FileName));
                    string linkPath = HttpContext.Current.Server.MapPath("~/BookImg/") + System.IO.Path.GetFileName(img.FileName);

                    byte[] imageArray = File.ReadAllBytes(linkPath);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                    Imagen = base64ImageRepresentation.ToString();

                }

            string Detalles = HttpUtility.HtmlEncode(dtlls.Text);
            string Condicion = HttpUtility.HtmlEncode(condic.Text);
               
                
                if (unaControladora.altaPromocion(Titulo, Desc, PreO, PreP, Descuento, Imagen, Detalles, Condicion))
            {
                lblMensaje.Text = "Promocion creada con exito!!";
            }
            else
            {
                lblMensaje.Text = "No se pudo crear la Promocion!!";
            }

        }

        }
    }
}