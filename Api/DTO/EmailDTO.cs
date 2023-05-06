using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class EmailDTO
    {
        [Required]
        public List<string> Emails { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageContent { get; set; }
    }
}
