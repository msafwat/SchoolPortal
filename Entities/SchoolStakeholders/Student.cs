using Entities.Curriculum;
using Entities.School;
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
        
        public int Code { get; set; }

        [Required]
        [MaxLength(16)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(16)]
        public string MiddledName { get; set; }

        [Required]
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

        [Required]
        public string Passport { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }

        //public List<Parent> Parents { get; set; }

        //public List<Student> BrothersAndSisters { get; set; }

        //public List<SchoolCurriculumStudent> SchoolCurriculums { get; set; }
    }
}
