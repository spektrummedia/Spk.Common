using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spk.Common.Mailing.MailBuilder;

namespace Spk.Common.Mailing.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Components()
        {

            var mailBuilder = new MailBuilder.MailBuilder();

            var mail = mailBuilder.BuildEmail(new MailModel());

            ViewBag.Mail = mail;

            return View("Empty");
        }

        public ActionResult EmailSimple()
        {
            return View("Empty");

        }

        public ActionResult EmailWithCols()
        {
            return View("Empty");
        }

        public ActionResult EmailComplex()
        {
            return View("Empty");

        }
    }
}
