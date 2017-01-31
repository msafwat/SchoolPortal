using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public Question Question { get; set; }
    }
}
