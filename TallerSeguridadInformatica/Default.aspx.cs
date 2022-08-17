using Sentry.AspNet;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TallerSeguridadInformatica
{
    public partial class _Default : Page
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}