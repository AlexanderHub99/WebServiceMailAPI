#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceMailAPI.Context;
using WebServiceMailAPI.Models;
using WebServiceMailAPI.MailManager;

namespace WebServiceMailAPI.Controllers
{
    /// <summary>
    /// Контролер Mails API.
    /// [Route("api/[controller]")]- указывает маршрут к контроллеру и функциям API.
    /// [ApiController] - подключает схемы поведения API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class mailsController : ControllerBase
    {
        /// <summary>
        /// Переменная для работы с базой данных . Хранит таблицу из БД и функционал для изменения наследованный от EF.
        private readonly ApplicationContext _context;
        /// <summary>
        /// Получение контекста БД и его запись .
        /// </summary>
        /// <param name="context"></param>
        public mailsController(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Метод контроллера отвечает  на GET: api/mails , отдает всю модель ДБ в виде json.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> GetStoryMail()
        {
            return await _context.StoryMail.ToListAsync();
        }
        /// <summary>
        /// Метод контроллера получает объект полученные по API по  POST: api/mails.
        /// В ответ отправляет код статуса.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Mail>> PostMail(ModelJSONAdd modelJSON)
        {
            MailManager.MailManager _RobotMail = new MailManager.MailManager();
            return await _RobotMail.AddDB(modelJSON, _context);
        }
    }
}
