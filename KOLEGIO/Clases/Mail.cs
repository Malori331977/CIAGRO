using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Data;
using System.Net.Mime;
using System.Data.SqlClient;

namespace KOLEGIO
{
    public class Mail
    {
       
        /// <param name="entityMail">Entity Class, Mail Model Entity</param>
        /// <returns>Boolean</returns>
        
        public static String mailFrom { get; set; }
        public static String mailTo { get; set; }
        public static String mailSubject { get; set; }
        public static String mailBody { get; set; }
       
        public static Boolean IsHtmlFormat { get; set; }
        public static String smtpHostServer { get; set; }
        public static String credentialUserName { get; set; }
        public static String credentialUserPassword { get; set; }
        public static Boolean isSslEnable { get; set; }
        public static int port { get; set; }
        public static List<ClsMailModeCopy> _mailccList = new List<ClsMailModeCopy>();
        public static List<byte[]> adjuntos = new List<byte[]>();
        public static List<string> nombreAdjuntos = new List<string>();
        public static bool soporte = false;

        public static Boolean SendMail(ref string error)
        {
            try
            {
                using (MailMessage mm = new MailMessage(mailFrom, mailTo))
                {
                    mm.Subject = mailSubject;
                    mm.Body = mailBody;

                    foreach (var ccLine in _mailccList)
                    {
                         if (ccLine.mailCopyTo != null)
                        {
                            string[] correos = ccLine.mailCopyTo.Split(',');

                            for (int i = 0; i < correos.Length; i++)
                                mm.CC.Add(new MailAddress(correos[i].Trim()));
                        }
                    }
                        


                    for (int i = 0; i < adjuntos.Count; i++)
                    {
                        if (!soporte)
                        {
                            MemoryStream memoryStream = new MemoryStream(adjuntos[i]);
                            var attachment = new System.Net.Mail.Attachment(memoryStream, nombreAdjuntos[i]);
                            mm.Attachments.Add(attachment);
                        }
                        else
                        {
                            string attachmentPath = nombreAdjuntos[i].Split('>')[1];
                            Attachment inline = new Attachment(attachmentPath);
                            inline.ContentDisposition.Inline = true;
                            inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                            inline.ContentId = nombreAdjuntos[i].Split('>')[0];
                            if (nombreAdjuntos[i].Split('>')[0].ToUpper().Contains(".JPG"))
                                inline.ContentType.MediaType = "image/jpg";
                            else
                                inline.ContentType.MediaType = MediaTypeNames.Text.Html;

                            inline.ContentType.Name = Path.GetFileName(attachmentPath);
                            mm.Attachments.Add(inline);
                        }
                    }


                    mm.IsBodyHtml = IsHtmlFormat;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = smtpHostServer;
                    NetworkCredential credential = new NetworkCredential();
                    credential.UserName = credentialUserName;
                    credential.Password = credentialUserPassword;
                    if (credentialUserName == "ND")
                        smtp.UseDefaultCredentials = false;
                    else
                        smtp.UseDefaultCredentials = true;

                    smtp.Credentials = credential;

                    if (port != 0)
                        smtp.Port = port;

                    if (isSslEnable)
                        smtp.EnableSsl = isSslEnable;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mm.Body,
                            Encoding.UTF8, MediaTypeNames.Text.Html);
                    string path = AppDomain.CurrentDomain.BaseDirectory;

                    for (int i = 1; i < 6; i++)
                    {
                        if (mailBody.Contains("IMAGEN" + i))
                        {
                            LinkedResource img = new LinkedResource(path + "\\imagenes\\IMAGEN" + i + ".jpg",MediaTypeNames.Image.Jpeg);
                            img.ContentId = "IMAGEN" + i;
                            htmlView.LinkedResources.Add(img);
                            mm.AlternateViews.Add(htmlView);
                        }
                    }

                    if (mailBody.Contains("IMAGENPDF"))
                    {
                        LinkedResource img = new LinkedResource(path + "\\Imagenes\\imagenPDFEnvio.jpg", MediaTypeNames.Image.Jpeg);
                        img.ContentId = "IMAGENPDF";
                        htmlView.LinkedResources.Add(img);
                        mm.AlternateViews.Add(htmlView);
                    }

                    //if (mailTo.Contains(";"))
                    //{
                    //    mailTo = mailTo.Replace(";", ",");
                    //}

                    smtp.Send(mm);
                }
                return true;
            }
            catch (Exception ex)
            {
                error = "No es posible envíar el mail\n" + ex.Message + " Inner: " + ex.InnerException;
                return false;
            }
        }

        public static void limpiar()
        {
            mailFrom = "";
            mailTo = "";
            mailSubject = "";
            mailBody = "";
            IsHtmlFormat = false;
            smtpHostServer = "";
            credentialUserName = "";
            credentialUserPassword = "";
            isSslEnable = false;
            soporte = false;
            port = 0;
            _mailccList.Clear();
            adjuntos.Clear();
            nombreAdjuntos.Clear();
        }
    }

    public class ClsMailModeCopy
    {
        public String mailCopyTo { get; set; }
        public String mailCopyToName { get; set; }
    }
}
