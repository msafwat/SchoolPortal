using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SchoolYear
    {
        [Key]
        public short YearId { get; set; }
        public Year Year { get; set; }

        [Key]
        public short SchoolId { get; set; }
        public School School { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
