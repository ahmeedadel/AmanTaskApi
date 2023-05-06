using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Email
    {

        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string displayName { get; set; }
        [Required]
        public int port { get; set; }
        [Required]
        public string host { get; set; }
    }
}
