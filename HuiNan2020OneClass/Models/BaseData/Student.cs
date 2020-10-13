using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class Student:Base
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [Display(Name = "姓名")]

        public string Name { get; set; }
        
        
        [Required]
        [Display(Name = "性别")]
        public Sex Sex { get; set; }

        [Required]
        [Display(Name = "入学时间")]
        [DataType(DataType.Date)] //显示日期格式
        public DateTime EnrollmentTime { get; set; }


        [Display(Name = "班级")]
        public int GradeClassID { get; set; }


        //[Display(Name = "班级")]
        //public GradeClass GradeClass { get; set; }

        [Required]
        [Display(Name = "生日")]
        [DataType(DataType.Date)] //显示日期格式
        public DateTime Borthday { get; set; }


        [Display(Name = "头像")]
        public string Pic { get; set; }


        [Display(Name = "电话")]
        public string Phone { get; set; }

        [Display(Name = "微信")]
        public string Weixin { get; set; }

        [Display(Name = "qq")]
        public string QQ { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        public string Email { get; set; }

        [Display(Name = "身份证")]
        public string Ident { get; set; }

    }
}
