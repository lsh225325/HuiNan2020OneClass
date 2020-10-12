using HuiNan2020OneClass.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class SchoolTerm:Base
    {
        [Display(Name = "学年")]
        [Range(2020, 2050)]
        public int SchoolYear { get; set; }

        public int SemesterID { get; set; }
        public Semester Semester { get; set; }


        public string Name { get; set; }

        
    }
}
