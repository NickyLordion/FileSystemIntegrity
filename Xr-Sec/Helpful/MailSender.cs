using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Xr_Sec.Model;
using System.Net;

namespace Xr_Sec.Helpful
{
    class MailSender
    {
        private MailAddress From = new MailAddress("fromemail@yandex.ru"); //указать адрес отправки письма
        private MailAddress To = new MailAddress("toemail@yandex.ru");//указать адрес получателя письма
        private SmtpClient smtp;

        public MailSender()
        {
            smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("fromemail@yandex.ru", "somepass");//указать учётные данные ящика отправки
            smtp.EnableSsl = true; //включить шифрование
        }

        public void MailSend(FileDataRecord data)
        {
            MailMessage message = new MailMessage(From, To) //в Subject можно поменять тему письма, а в Body -- содержание
            {
                Subject = data.FileName,
                Body = $"Файл с идентификатором {data.Id} был изменён в {data.CreationTime}, " +
                $"текущий хэш файла: {data.HashSum}"                
            };           
            smtp.Send(message);
        }
    }
}
