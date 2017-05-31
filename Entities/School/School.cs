using Entities.CustomAttributes;
using Entities.SchoolStakeholders;
using GlobalizationResources;
using GlobalizationResources.Resources.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.School
{
    public class School
    {
        [Key]
        public short Id { get; set; }

        [MaxLength(128)]
        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Validations))]
        [LocalizedDisplayName(ResourcesType.Schools, "SchoolName")]
        public string NameEn { get; set; }

        [MaxLength(128)]
        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Validations))]
        [LocalizedDisplayName(ResourcesType.Schools, "SchoolName")]
        public string NameAr { get; set; }

        public bool IsActive { get; set; }

        //public List<Curriculum.Curriculum> Curriculums { get; set; }

        //public List<Teacher> Teachers { get; set; }

        //public List<Student> Students { get; set; }
    }
}
