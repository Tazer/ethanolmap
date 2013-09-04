using EthanolMap.Web.Models;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthanolMap.Web.Controllers
{
    public class HomeController : RavenController
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}