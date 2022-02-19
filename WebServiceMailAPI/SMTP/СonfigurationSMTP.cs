using System.Net;
using System.Net.Mail;


namespace WebServiceMailAPI.SMTP
{
    /// <summary>
    /// Конфигуратор SMTP
    /// </summary>
    public static class СonfigurationSMTP
    {
        /// <summary>
        /// Почта отправителя .
        /// </summary>
        private const string MyGmail = "sasha98765432189878@gmail.com";
        /// <summary>
        /// Пароль почты отправителя .
        /// </summary>
        private const string MyPasswordGmail = "QWERTYhgfdsa1234567654321";

        /// <summary>
        /// Настройки SMTP Client .
        /// </summary>
        public static SmtpClient SmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(MyGmail, MyPasswordGmail);

            return smtpClient;
        }

    }
}
