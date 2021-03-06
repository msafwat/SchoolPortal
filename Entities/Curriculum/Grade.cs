﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Curriculum
{
    public class Grade
    {
        [Key]
        public short Id { get; set; }

        [MaxLength(32)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
