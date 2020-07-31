using BallooningMelbourne.Models;
using BallooningMelbourne.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BallooningMelbourne.Controllers
{
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
        //public ActionResult Location()
        //{
        //    return View();
        //}
        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        public ActionResult Events()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model, HttpPostedFileBase emailAttachment)
        {
            ViewBag.Message = "Your admin page.";
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, emailAttachment);

                    ViewBag.Result = "Email has been sent.";

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
        //public ActionResult Send_Email(SendEmailViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            String toEmail = model.ToEmail;
        //            String subject = model.Subject;
        //            String contents = model.Contents;

        //            EmailSender es = new EmailSender();
        //            es.Send(toEmail, subject, contents);

        //            ViewBag.Result = "Email has been sent.";

        //            ModelState.Clear();

        //            return View(new SendEmailViewModel());
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    return View();
        //}


        public ActionResult Send_Email1()
        {
            return View(new SendEmailViewModel1());
        }

      


        [HttpPost]
        public ActionResult Send_Email1(SendEmailViewModel1 model, HttpPostedFileBase emailAttachment)
        {
            ViewBag.Message = "Your admin page.";
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail1 = model.ToEmail1;
                    String toEmail2 = model.ToEmail2;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    EmailSender1 es = new EmailSender1();
                    es.Send1(toEmail1, toEmail2, subject, contents, emailAttachment);

                    ViewBag.Result = "Email has been sent.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel1());
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


        public ActionResult Send_Email2()
        {
            return View(new SendEmailViewModel2());
        }
        [HttpPost]
        public ActionResult Send_Email2(SendEmailViewModel2 model, HttpPostedFileBase emailAttachment)
        {
            ViewBag.Message = "Your admin page.";
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail1 = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    EmailSender2 es = new EmailSender2();
                    es.Send2(toEmail1, subject, contents, emailAttachment);

                    ViewBag.Result = "Email has been sent.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel2());
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }



        public ActionResult Send_Email3()
        {
            var reff = db1.AspNetUsers.ToList();
            if(reff!=null)
            {
                ViewBag.usersList = reff.Select(N => new SelectListItem { Text = N.Email, Value = N.Email.ToString() });
            }
            return View(new SendEmailViewModel());
        }

   

        [HttpPost]
        public ActionResult Send_Email3(SendEmailViewModel model, HttpPostedFileBase emailAttachment)
        {
            ViewBag.Message = "Your admin page.";
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    EmailSender3 es = new EmailSender3();
                    es.Send(toEmail, subject, contents, emailAttachment);

                    ViewBag.Result = "Email has been sent.";

                    ModelState.Clear();
                    var reff = db1.AspNetUsers.ToList();
                    if (reff != null)
                    {
                        ViewBag.usersList = reff.Select(N => new SelectListItem { Text = N.Email, Value = N.Email.ToString() });
                    }
                    return View(new SendEmailViewModel());

                 
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        private AdminEventModel db1 = new AdminEventModel();

        // GET: bookings

        public ActionResult Viewnormal()
        {
            //var userId = User.Identity.GetUserId();
            var adminEventtables = db1.AdminEventtables.ToList();
            return View(adminEventtables);
           // return View();
        }

        private BookingModel db2 = new BookingModel();
        public ActionResult Location()
        {
            return View(db2.Locations.ToList());
        }

        public ActionResult charts1()
        {
            return View();
        }

        public ActionResult PDFGeneration()
        {
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderUrlAsPdf("https://localhost:44341/Home/Viewnormal");
            PDF.SaveAs("C:/Users/visha/OneDrive/Desktop/first.pdf");
            return View();
        }

    }
}