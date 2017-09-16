using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EmailController
{
    public static class Email
    {
        public static ICredentialsByHost Credential { get; private set; }

     
        public static bool Send(string remetente, /*List<string> anexos, */string assunto, string mensagem, string destinatarios/*List<string> destinatarios*/)
        {

            bool result = false;

            try
            {
                SmtpClient oSmtp = new SmtpClient();
                NetworkCredential basicCredential =   new NetworkCredential("pfneto@hotmail.com", "jcdes01JC#");
                oSmtp.Host = "smtp.live.com";
                oSmtp.Port = 587;
                oSmtp.EnableSsl = true;
                oSmtp.Credentials = basicCredential;





                MailMessage oMensagem = new MailMessage();

               oMensagem.From = new MailAddress( remetente);
               // foreach (string destinatario in destinatarios)
               // {
                    oMensagem.To.Add(destinatarios);
               // }

                oMensagem.Priority = MailPriority.Normal;
                oMensagem.Subject = assunto;
                oMensagem.IsBodyHtml = true;

                oMensagem.Body = mensagem;


                oMensagem.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                oMensagem.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                oSmtp.Send(oMensagem);

                result = true;
            //return result;

               }
               catch (Exception ex)
               {

                   result = false;
               }

               return result;
           }
        }
}
