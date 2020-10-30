using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace HuiNan2020OneClass.Pages
{
    public class GetEchartsDataModel : PageModel
    {

        private readonly AppContext _context;
        public GetEchartsDataModel(AppContext context)
        {
            _context = context;

        }



        public JsonResult OnGet()
        {
            List<InputModel> rls = _context.Exp.GroupBy(m => m.classAndTerm.Name)
                        .Select(
                                 g => (new InputModel
                                 {
                                     Name = g.Key,//key,就是上面的统计指标
                                     Count = g.Count(),
                                     Money = g.Sum(item => item.Money)
                                 }
                            )).OrderByDescending(m => m.Money).ToList();



            var js = new
            {
                Category = rls.Select(x => x.Name).ToList(),
                Money = rls.Select(p => p.Money).ToList()
            };


            //最后调用相关函数将List转换为Json
            //因为我们需要返回category和series、legend多个对象 这里我们自己在new一个新的对象来封装这两个对象
            JsonResult json = new JsonResult(js);
            return json;




        }
        public class InputModel
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public decimal Money { get; set; }
        }


    }


}

