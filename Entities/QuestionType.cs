using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class QuestionType
    {
        [Key]
        public short Id{ get; set; }

        [Required, MaxLength(16)]
        public string NameEn { get; set; }

        [Required, MaxLength(16)]
        public string NameAr { get; set; }
    }
}