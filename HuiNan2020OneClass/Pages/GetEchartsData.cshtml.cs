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
                                     Name = g.Key,//key,���������ͳ��ָ��
                                     Count = g.Count(),
                                     Money = g.Sum(item => item.Money)
                                 }
                            )).OrderByDescending(m => m.Money).ToList();



            var js = new
            {
                Category = rls.Select(x => x.Name).ToList(),
                Money = rls.Select(p => p.Money).ToList()
            };


            //��������غ�����Listת��ΪJson
            //��Ϊ������Ҫ����category��series��legend������� ���������Լ���newһ���µĶ�������װ����������
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

