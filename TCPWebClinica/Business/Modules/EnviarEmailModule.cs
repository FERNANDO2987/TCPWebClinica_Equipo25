using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
     public class EnviarEmailModule : IEnviarMailModule
    {

        private MailMessage _mailMessage;
        private SmtpClient _smtpClient;

        public EnviarEmailModule()
        {
            _smtpClient = new SmtpClient();
            _smtpClient.Credentials = new NetworkCredential("programadoressomos404@gmail.com", "opwlysytyzcqgagv");
            _smtpClient.EnableSsl = true;
            _smtpClient.Port = 587;
            _smtpClient.Host = "smtp.gmail.com";

        }

        public void ArmarCorreo(string emailDestino,string asunto, string cuerpo)
        {
            _mailMessage = new MailMessage();
            _mailMessage.From = new MailAddress("noresponder@programacion");
            _mailMessage.To.Add(emailDestino);
            _mailMessage.Subject = asunto;
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Body = "<h1>Usted a solicitado un Turno </h1> <br>Hola, te escribo por el turno solicitado";
        }

        public void EnviarEmail()
        {
            try
            {
                _smtpClient.Send(_mailMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
