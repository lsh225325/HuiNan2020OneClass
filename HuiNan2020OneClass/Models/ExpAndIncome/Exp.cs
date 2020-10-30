using System;
using System.ComponentModel.DataAnnotations;

namespace HuiNan2020OneClass
{
    public class Exp : Base
    {

        public int classAndTermID { get; set; }
        public ClassAndTerm classAndTerm { get; set; }

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

        [Display(Name = "经办人")]
        public string JBR { get; set; }
    }
}
