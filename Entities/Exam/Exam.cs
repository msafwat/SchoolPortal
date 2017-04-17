using Entities.QuestionsBank;
using Entities.SchoolStakeholders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exam
{
    public class Exam
    {
        [Key]
        public int ID { get; set; }

        public int Title { get; set; }

        public int Duration { get; set; }

        public List<Question> Questions { get; set; }

        public List<Student> Students { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime LastModifiedDateTime { get; set; }
    }
}
