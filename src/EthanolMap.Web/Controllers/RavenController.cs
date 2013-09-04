using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthanolMap.Web.Controllers
{
    public abstract class RavenController : Controller
    {
        public static IDocumentStore DocumentStore
        {
            get
            {
                return new DocumentStore
                {
                    Url = "https://ibis.ravenhq.com/databases/Codespark-ethanolmap",
                    ApiKey = "5a17ebbd-fd5b-4d9c-90ec-b01107c96c39"
                }.Initialize();
            }
        }

        public IDocumentSession RavenSession { get; protected set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RavenSession = DocumentStore.OpenSession();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (RavenSession)
            {
                if (filterContext.Exception != null)
                    return;

                if (RavenSession != null)
                    RavenSession.SaveChanges();
            }
        }

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }


        protected new JsonResult Json(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}