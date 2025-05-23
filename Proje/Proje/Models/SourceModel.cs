using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class SourceModel
    {
        [Key]
        public int Id { get; set; }
        public string? teams{ get; set; }
        public string? version { get; set; }
        public DateTime updateTime{ get; set; }
        public string? type { get; set; }
        public string? description { get; set; }
    }
}
