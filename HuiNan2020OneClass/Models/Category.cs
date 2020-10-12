using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class Category:Base
    {
        /// <summary>
        /// 收支类别
        /// </summary>
        [Required]
        [Display(Name = "类别")]
        public string CategoryName { get; set; }


        /// <summary>
        /// 收支方向
        /// </summary>
        [Required]
        [Display(Name = "收支")]
        public IncomOrExpense IncomOrExp { get; set; }

    }
}
