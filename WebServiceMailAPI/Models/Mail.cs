using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebServiceMailAPI.Models
{
    /// <summary>
    /// Модель таблице в  базе данных .
    /// </summary>
    [Table("StoryMail")]
    public class Mail
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Subject")]
        public string Subject { get; set; }
        [Column("Body")]
        public string Body { get; set; }
        [Column("Recipients")]
        public string Recipients { get; set; }
        [Column("Result")]
        public string Result { get; set; }  
        [Column("FailedMessage")]
        public string? FailedMessage { get; set; }

    }
}
