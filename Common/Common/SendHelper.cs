using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Common
{
   public class SendHelper
    {
        //qq邮箱发送
        public static void Send()
        {  
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "a1207988466@qq.com"));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "2377417860@qq.com"));
            message.Subject = "星期天去哪里玩？";//标题
          
            message.Body = new TextPart("plain") { Text = "我想去故宫玩，如何" };   //内容

            //内容为html的时候可以选择这种方式

            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = @"<b>This is bold and this is <i>italic</i></b>";
            //message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                // Note: since we don't have an OAuth2 token, disable  
                // the XOAUTH2 authentication mechanism.  
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Connect("smtp.qq.com", 25, false);//("smtp.friends.com", 587, false); qq:smtp.qq.com   25    163 :smtp.163.com   25

                // Note: only needed if the SMTP server requires authentication
                var mailFromAccount = "a1207988466@qq.com";
                var mailPassword = "cuklfinqargmjefj";
                client.Authenticate(mailFromAccount, mailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static void TestSendMailDemo()
        {
            var message = new MimeKit.MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "2377417860@qq.com"));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "a1207988466@qq.com"));
            message.Subject = "This is a Test Mail";
            var plain = new MimeKit.TextPart("plain")
            {
                Text = @"不好意思，我在测试程序，Sorry！"
            }; 
            // now create the multipart/mixed container to hold the message text and the
            // image attachment  
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.live.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                var mailFromAccount = "2377417860@qq.com";
                var mailPassword = "lys970612";
                client.Authenticate(mailFromAccount, mailPassword);

                client.Send(message);
                client.Disconnect(true);
            } 
        }
    }
}
