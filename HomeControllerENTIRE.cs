using PSV01.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PSV01.UI.MVC.Controllers
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Email(ContactViewModel contact)
        {
            var body = string.Format("Name: {0}<br />Email: {1}<br />Message: {2}",
                contact.Name,
                contact.Email,
                contact.Message);
            var message = new MailMessage();
            message.To.Add(new MailAddress("damrobre@gmail.com"));
            message.From = new MailAddress("no-reply@brentondev.com");
            message.Subject = "MESSAGE FROM PERSONAL SITE";
            message.Body = string.Format(body, contact.Name, contact.Email, contact.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "no-reply@brentondev.com",
                    Password = "???????????"
                };
                smtp.Credentials = credential;
                smtp.Host = "mail.brentondev.com";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(message);
            }

            return View("Index");
           
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

