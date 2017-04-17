using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SchoolStructure
{
    public class School
    {
        [Key]
        public short Id { get; set; }

        [MaxLength(64)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public List<SchoolYear> Years { get; set; }
    }
}
