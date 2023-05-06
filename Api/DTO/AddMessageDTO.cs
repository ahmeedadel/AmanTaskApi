using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.DTO
{
    public class AddMessageDTO
    {
        [Required]
        [StringLength(50)]

        public string Subject { get; set; }

        [Required]
        public string MessageContent { get; set; }
    }
}
