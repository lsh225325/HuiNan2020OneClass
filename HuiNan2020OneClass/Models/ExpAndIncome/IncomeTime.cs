using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class IncomeTime : Base
    {
        public DateTime Year { get; set; }

        public string SchoolSeason { get; set; }



        [Display(Name = "学季")]
        public string Name
        {
            get
            {
                return Year.Year.ToString() + SchoolSeason;
            }

        }
    }
}
