using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Year
    {
        [Key]
        public short id { get; set; }

        [MaxLength(16)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public List<SchoolYear> Schools { get; set; }
    }
}
