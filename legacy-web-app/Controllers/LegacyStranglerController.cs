using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace legacy_web_app.Controllers
{
    public class LegacyStranglerController : Controller
    {
        protected LegacyStranglerConfig LegacyStranglerConfig = LegacyStranglerConfig.Instance;

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.ViewBag.LegacyStranglerConfig = LegacyStranglerConfig;
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
