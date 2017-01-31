using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CurriculumGrade
    {
        [Key]
        public short CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

        [Key]
        public short GradeId { get; set; }
        public School Grade { get; set; }
    }
}
