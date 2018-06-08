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

        // GET: First/logType
        public ActionResult Logs(String logType) {
            return View(new Logs(logType));
        }

        // GET: First/Config
        public ActionResult Config() {
            return View(new Config());
        }

        // GET: First/DeleteFolder
        [HttpGet]
        public ActionResult DeleteFolder(string folder) {
            return View((object)folder);
        }

        [HttpPost]
        public void DeleteFolder(string folder, bool confirm = false) {
            if(confirm && new Config().Folders.Contains(folder)) {
                new DeleteFolder(folder).SendDelete();
            }
        }

        // GET: First/DeleteImage
        [HttpGet]
        public ActionResult DeleteImage(string path, string image) {
            Dictionary<String, String> imageInfo = new Dictionary<String, String>() { { "path", path }, { "image", image } };
            return View(imageInfo);
        }

        [HttpPost]
        public void DeleteImage(string image, bool confirm = false) {
            if(confirm) {
                new DeleteImage(image).Delete();
            }
        }

        // GET: First/ViewImage
        public ActionResult ViewImage(string path, string image) {
            Dictionary<String, String> imageInfo = new Dictionary<String, String>() { { "path", path }, { "image", image } };
            return View(imageInfo);
        }


        // GET: First/Photos
        public ActionResult Photos() {
            return View(new Photos());
        }
    }
}
