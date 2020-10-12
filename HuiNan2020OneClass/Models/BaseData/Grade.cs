using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass
{
    public class Grade : Base
    {
        /// <summary>
        /// 年级名称，一年级，二年级
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 阶段，小学，初中
        /// </summary>
        public Level Level { get; set; }
    }
}
