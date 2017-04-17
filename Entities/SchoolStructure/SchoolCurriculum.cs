using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SchoolStructure
{
    public class SchoolCurriculum
    {
        [Key]
        public CurriculumGrade CurriculumGrade { get; set; }

        [Key]
        public SchoolYear SchoolYear { get; set; }
    }
}
