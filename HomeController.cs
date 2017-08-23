

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


       
