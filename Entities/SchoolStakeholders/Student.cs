using Entities.SchoolStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SchoolStakeholders
{
    public class Student : User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(16)]
        public string FirstName { get; set; }

        [MaxLength(16)]
        public string MiddledName { get; set; }

        [MaxLength(16)]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return new StringBuilder()
                    .Append(FirstName)
                    .Append(" ")
                    .Append(MiddledName)
                    .Append(" ")
                    .Append(LastName)
                    .ToString();
            }
        }

        public DateTime BirthDate { get; set; }

        public List<SchoolCurriculumStudent> SchoolCurriculums { get; set; }
    }
}
