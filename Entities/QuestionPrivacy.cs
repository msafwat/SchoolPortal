using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class QuestionPrivacy
    {
        [Key]
        public short Id { get; set; }

        [Required, MaxLength(16)]
        public string NameEn { get; set; }

        [Required, MaxLength(16)]
        public string NameAr { get; set; }
    }
}
