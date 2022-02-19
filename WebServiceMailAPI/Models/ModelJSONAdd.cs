
namespace WebServiceMailAPI.Models
{
    /// <summary>
    /// Модель для получения по API json .
    /// </summary>
    public class ModelJSONAdd
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public  string[]? Recipients { get; set; }
    }
}
