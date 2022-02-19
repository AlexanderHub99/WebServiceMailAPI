using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Text.Json;
using System.Text.RegularExpressions;
using WebServiceMailAPI.Context;
using WebServiceMailAPI.Controllers;
using WebServiceMailAPI.Models;
using WebServiceMailAPI.SMTP;

namespace WebServiceMailAPI.MailManager
{

    public class MailManager : ControllerBase
    {
        /// <summary>
        /// Конфигурирует модель ДБ и добавляет .
        /// Отправляет ответ .
        /// </summary>
        /// <param name="modelJSON">Пришедшая модель по API</param>
        /// <param name="_context">Контекст ДБ</param>
        /// <returns></returns>
        public async Task<ActionResult<Mail>> AddDB(ModelJSONAdd modelJSON, ApplicationContext _context)
        {
            Mail mail1 = new Mail();
            mail1.Subject = modelJSON.Subject;
            mail1.Body = modelJSON.Body;
            mail1.Recipients = ParserStringArray(modelJSON.Recipients);
            mail1.FailedMessage = SendMessagesMail(modelJSON).ToString();
            mail1.Result = DateTime.Today.ToString("d") + " Ok";

            _context.StoryMail.Add(mail1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMail", new { id = mail1.Id }, mail1);
        }
        /// <summary>
        /// Отправляет сообщение и проверяет правильность введённых Mails.
        /// В ответ отправляет ошибку 
        /// </summary>
        /// <param name="modelJSON"></param>
        /// <returns></returns>
        public string SendMessagesMail(ModelJSONAdd modelJSON)
        {
            for (int i = 0; i < modelJSON.Recipients!.Length; ++i)
            {
                try
                {
                    MailAddress from = new MailAddress("agames1448@gmail.com", "Вот как-то так и не как иначе :D");
                    MailAddress to = new MailAddress(modelJSON.Recipients[i].ToString());
                    MailMessage messages = new MailMessage(from, to);
                    messages.Subject = modelJSON.Subject;
                    messages.Body = modelJSON.Body;

                    SmtpClient smtpClient = СonfigurationSMTP.SmtpClient();
                    smtpClient.SendMailAsync(messages);
                }
                catch
                {
                    return "Не верный Mail:  " + modelJSON.Recipients[i].ToString();
                }
            }
            return NoContent().ToString();
        }
        /// <summary>
        /// Превращает  массив строк в строку формата json и отправляет ее в ответ.
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public static string ParserStringArray(string[] stringArray)
        {
            string jsonString = JsonSerializer.Serialize(stringArray);
            return jsonString;
        }
    }
}

