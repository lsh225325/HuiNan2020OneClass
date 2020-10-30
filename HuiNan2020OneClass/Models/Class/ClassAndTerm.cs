using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HuiNan2020OneClass
{
    public class ClassAndTerm : Base
    {
        //班级

        /// <summary>
        /// 班号
        /// </summary>
        public int ClassNuberID { get; set; }
        public ClassNuber ClassNuber { get; set; }


        /// <summary>
        /// 年级
        /// </summary>
        public int GradeID { get; set; }
        public Grade Grade { get; set; }


        /// <summary>
        /// 学年
        /// </summary>
        public int SchoolTermID { get; set; }

        public SchoolTerm SchoolTerm { get; set; }


        /// <summary>
        /// 学期号，1-18期
        /// </summary>
        [Range(1, 18)]
        public int TermNuber { get; set; } = 1;


        /// <summary>
        /// 班级名称：一年级1班,自动生成
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// 默认是当前班级
        /// </summary>
        public bool IsCurrentClass { get; set; }

        /*
        public string FullName
        {
            get
            {
                return Grade.GradeName  + ClassNuber.ClassNuberName + ", " + SchoolTerm.Name;
            }
        }
        */

        public ICollection<ClassAndStudent> ClassAndStudents { get; set; }
    }
}
