using Microsoft.EntityFrameworkCore.Query.Internal;
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

        public decimal EveryoneMoney { get; set; }

        public decimal TotalMoney { get; set; }

        public int ClassAndTermID { get; set; }
        public ClassAndTerm classAndTerm { get; set; }

        public ICollection<Income> Incomes { get; set; }


    }
}
