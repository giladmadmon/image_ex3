using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageService.WebApplication.Models;
using ImageService.Communication.Singleton;
using System.Threading;

namespace ImageService.WebApplication.Controllers {
    public class FirstController : Controller {
        // GET: First
        public ActionResult Index() {
            return View(new ImageWeb());
        }

        [HttpGet]
        public ActionResult ImageWeb() {
            return View();
        }

        [HttpGet]
        public JObject GetEmployee() {
            JObject data = new JObject();
            data["FirstName"] = "Kuky";
            data["LastName"] = "Mopy";
            return data;
        }

        // GET: First/Details
        public ActionResult Logs(String logType) {
            return View(new Logs(logType));
        }

        // GET: First/Config
        public ActionResult Config() {
            return View(new Config());
        }

        // GET: First/Delete
        public ActionResult Delete(string folder) {
            return View((object)folder);
        }
    }
}
