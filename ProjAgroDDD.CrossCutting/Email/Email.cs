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

        /// <summary>
        /// Função para notificar erros na aplicação.
        /// </summary>
        /// <returns></returns>
        public static bool Send(string remetente, /*List<string> anexos, */string assunto, string mensagem, string destinatarios/*List<string> destinatarios*/)
        {

            bool result = false;

            try
            {
                SmtpClient oSmtp = new SmtpClient();
                NetworkCredential basicCredential =   new NetworkCredential("pfneto@gmail.com", "040982070680");
                oSmtp.Host = "smtp.gmail.com";
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

                // Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
              /*  if (anexos.Count > 0)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        oMensagem.Attachments.Add(anexado);
                    }
                }
                */
                oMensagem.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                oMensagem.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                oSmtp.Send(oMensagem);

                result = true;


            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }
    }
}
