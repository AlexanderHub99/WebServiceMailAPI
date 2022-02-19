using Microsoft.EntityFrameworkCore;
using WebServiceMailAPI.Models;

namespace WebServiceMailAPI.Context
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Контекст базы данных. Указываем модель данных для EF.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Mail> StoryMail { get; set; } = null!;

    }
}
