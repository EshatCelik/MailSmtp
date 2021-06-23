using System;
using System.Net.Mail;
using System;
using System.Net;
using System.Threading;
using SIPSorcery.SIP;
using SIPSorcery.SIP.App;
using SIPSorcery.Sys;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            SmtpClient client = new SmtpClient();
            client.Port = 587;                                                                                     // Genelde 587 ve 25 portları kullanılmaktadır.
            client.Host = "smtp.live.com";                                                                           // Hostunuzun smtp için mail domaini.
            client.EnableSsl = true;                                                                               // Güvenlik ayarları, host'a ve gönderilen server'a göre değişebilir.
            client.Timeout = 10000;                                                                                 // Milisaniye cinsten timeout
            client.DeliveryMethod = SmtpDeliveryMethod.Network;                                                  // Mailin yollanma methodu
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("gönderenin mail adresi", "şifre");    // Burada hangi hesabı kullanarak mail yollayacaksanız onun ayarlarını yapmanız gerekiyor
            MailMessage mm = new MailMessage();                                                             
            mm.To.Add("gönderilen adres ");
            mm.From =new MailAddress("gönderenin adresi");
            mm.Subject = "subject";
            mm.Body = "Test ";
            mm.IsBodyHtml = true;                                                                               // True: Html olarak Gönderme, False: Text olarak Gönderme
            mm.BodyEncoding = UTF8Encoding.UTF8;                                                                      // UTF8 encoding ayarı
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;                                    // Hata olduğunda uyarı ver 
            client.Send(mm);                                                                                       // Mail yolla
        }

    }
}
