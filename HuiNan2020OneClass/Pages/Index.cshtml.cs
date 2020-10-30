using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HuiNan2020OneClass.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, AppContext context)
        {
            _context = context;
            _logger = logger;
        }




        public string? DefualtClass { get; set; }
        public decimal TotalIncom { get; set; }
        public decimal TotalEpx { get; set; }
        public decimal NetMoney { get; set; }


        public int TotalCount { get; set; }
        public int TotalCountIncome { get; set; }
        public List<InputModel> inputModels { get; set; }

        public List<string> categorylist { get; set; }


        public JsonResult Json { get; set; }

        public void OnGet()
        {

            var iscc = _context.ClassAndTerm.FirstOrDefault(m => m.IsCurrentClass == true);


            if (iscc != null)
            {
                DefualtClass = iscc.Name;
            }
            else
            {
                DefualtClass = "一年级1班";
            }



            var Exps = from m in _context.Exp
                       where m.IsDelete == false
                       select m;

            if (Exps.Count() == 0)
            {
                return;
            }

            var Icomes = from m in _context.ClassIncome
                         where m.IsDelete == false
                         select m;

            if (Icomes.Count() == 0)
            {
                return;
            }

            TotalEpx = Exps.Sum(m => m.Money);
            TotalCount = Exps.Count();
            TotalIncom = _context.ClassIncome.Sum(m => m.Money);
            TotalCountIncome = _context.ClassIncome.Count();
            NetMoney = TotalIncom - TotalEpx;

            inputModels = _context.Exp.GroupBy(m => m.classAndTerm.Name)
                 .Select(
                                 g => (new InputModel
                                 {
                                     Name = g.Key,//key,就是上面的统计指标
                                     Count = g.Count(),
                                     Money = g.Sum(item => item.Money)
                                 }
                            )).OrderByDescending(m => m.Money)
                 .ToList();

            //////        


            var js = new
            {
                Category = inputModels.Select(x => x.Name).ToList(),
                Money = inputModels.Select(p => p.Money).ToList()
            };


            //最后调用相关函数将List转换为Json
            //因为我们需要返回category和series、legend多个对象 这里我们自己在new一个新的对象来封装这两个对象
            Json = new JsonResult(js);
            categorylist = inputModels.Select(x => x.Name).ToList();


        }

        public class InputModel
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public decimal Money { get; set; }
        }
    }
}
