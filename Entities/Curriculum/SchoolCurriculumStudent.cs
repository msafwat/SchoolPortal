using Entities.SchoolStakeholders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Curriculum
{
    public class SchoolCurriculumStudent
    {
        [Key]
        public int SchoolCurriculumId { get; set; }
        public SchoolCurriculum SchoolCurriculum { get; set; }

        [Key]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
