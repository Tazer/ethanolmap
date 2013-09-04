using EthanolMap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthanolMap.Web.Controllers
{
    public class StationController : RavenController
    {
        public JsonResult GetAll()
        {
            var stations = RavenSession.Query<Station>().ToList();

            return Json(stations);
        }

        public JsonResult Save(Station station)
        {
            RavenSession.Store(station);
            return Json(new { success = true });
        }
    }
}