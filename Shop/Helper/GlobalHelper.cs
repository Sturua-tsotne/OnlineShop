using System;
using System.Text;

namespace WebApplication1.Helper
{
    public class GlobalHelper
    {

        public static string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string MD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder Md5 = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    Md5.Append(hashBytes[i].ToString("X2"));
                }
                return Md5.ToString();
            }
        }

        //public static bool SendMail( string Mail ,string subject, string body ,bool isHtml = false)
        //{
        //    try
        //    {
        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        mail.IsBodyHtml = isHtml;
        //        mail.From = new System.Net.Mail.MailMessage("tsotne.sturua@gimail.com");
        //        mail.To.Add(Mail);
        //        mail.Subject = subject;
        //        mail.Body = body;

        //        System.Net.Mail.SmtpClient smtpServer = new System.Net.Mail.SmtpClient(Creditionals.smtpserver);
        //    }

        //}

    }
}