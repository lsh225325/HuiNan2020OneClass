using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class GradeClass:Base
    {
        public int ClassNuberID { get; set; }
        public ClassNuber ClassNuber { get; set; }



        public int GradeID { get; set; }        
        public Grade Grade { get; set; }


        /// <summary>
        /// 班级名称：一年级1班,自动生成
        /// </summary>
        public string ClassName { get; set; }


        /// <summary>
        /// 开班时间YYMM
        /// </summary>
        public string EnrollmentYYMM { get; set; }  

        /// <summary>
        /// 是否当前班级，默认为是，只能有一个是，当设置为一个是时，删除其他的
        /// </summary>
        public bool IsCurrentClass { get; set; }

    }
}
