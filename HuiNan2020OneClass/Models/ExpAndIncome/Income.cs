using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class Income:Base
    {
        /// <summary>
        /// 班费收入
        /// </summary>

        public int IncomeTimeID { get; set; }
        public IncomeTime IncomeTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "日期")]
        public DateTime ReData { get; set; }

        [Required]
        [Display(Name = "备注")]
        public string Rdmark { get; set; }

        [Required]
        [Display(Name = "金额")]
        public decimal Money { get; set; }

        [Required]
        [Display(Name = "类别")]
        public int CategoryID { get; set; }


        [Display(Name = "类别")]
        public Category Category { get; set; }


    }
}
