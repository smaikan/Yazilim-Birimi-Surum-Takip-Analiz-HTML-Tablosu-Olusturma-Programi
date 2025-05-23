using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class source
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? teams { get; set; }
        public string? version { get; set; }
        public DateTime updateTime  { get; set; }
        public string? type { get; set; }
        public string? description { get; set; }
    }
}
