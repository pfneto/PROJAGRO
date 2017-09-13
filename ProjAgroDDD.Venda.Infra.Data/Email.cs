using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Email
    {
        /// <summary>
        /// Função para notificar erros na aplicação.
        /// </summary>
        /// <returns></returns>
        public static bool Send(string remetente, List<string> anexos, string assunto, string mensagem, List<string> destinatarios)
        {

            bool result = false;

            try
            {
                SmtpClient oSmtp = new SmtpClient();
                oSmtp.Host = "pod51028.outlook.com";
                oSmtp.EnableSsl = true;

                MailMessage oMensagem = new MailMessage();

                oMensagem.From = new MailAddress( remetente + @"@teadit.com.br");
                foreach (string destinatario in destinatarios)
                {
                    oMensagem.To.Add(destinatario);
                }

                oMensagem.Priority = MailPriority.Normal;
                oMensagem.Subject = assunto;
                oMensagem.IsBodyHtml = true;

                oMensagem.Body = mensagem;

                // Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
                if (anexos.Count > 0)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        oMensagem.Attachments.Add(anexado);
                    }
                }

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
