using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HuiNan2020OneClass
{
    public class ClassIncome : Base
    {
        /// <summary>
        /// 班费收取说明
        /// </summary>

        /// <summary>
        /// 学期
        /// </summary>
        public int ClassAndTermID { get; set; }
        public ClassAndTerm classAndTerm { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "日期")]
        public DateTime ReData { get; set; }

        [Required]
        [Display(Name = "说明")]
        public string Rdmark { get; set; }

        /// <summary>
        /// 每人金额
        /// </summary>
        public decimal EveryoneMoney { get; set; } = 0;

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// 共计金额
        /// </summary>
        public decimal Money { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Student> students { get; set; }

    }
}
