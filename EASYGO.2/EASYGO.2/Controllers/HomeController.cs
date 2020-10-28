using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EASYGO._2.Models;
using EASYGO.Utils;

namespace EASYGO._2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    //var attachment = Request.Files["attachment"];
                    //if (attachment.ContentLength > 0)
                    //{
                    //    String path = Path.Combine(Server.MapPath("~/Content/Attachment"), attachment.FileName);
                    //    attachment.SaveAs(path);


                    //    EmailSender1 es = new EmailSender1();
                    //    es.SendWithAttachment(toEmail, subject, contents, path, attachment.FileName);
                    //}
                    //else
                    //{

                    EmailSender1 es = new EmailSender1();
                    es.Send(toEmail, subject, contents);
                    //}



                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }


    }
}