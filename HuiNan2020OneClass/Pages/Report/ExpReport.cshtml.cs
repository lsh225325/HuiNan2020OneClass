using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuiNan2020OneClass.Pages.Report
{
    public class ExpreportModel : PageModel
    {
        private readonly AppContext _context;

        public ExpreportModel(AppContext context)
        {
            _context = context;
        }

        public IList<Exp> Exp { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList GetCategorys { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GetCategory { get; set; }

        public SelectList GetClasses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GetClass { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        [Display(Name = "日期")]
        public DateTime? FirstTime { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        [Display(Name = "日期")]
        public DateTime? LastTime { get; set; }




        public async Task OnGetAsync()
        {
            IQueryable<string> GetCategorysQuery = from m in _context.Exp
                                                   orderby m.Category.CategoryName
                                                   select m.Category.CategoryName;

            IQueryable<string> GetClassesQuery = from m in _context.Exp
                                                 orderby m.classAndTerm.Name
                                                 select m.classAndTerm.Name;







            var ExpQuery = from m in _context.Exp
                           where (m.IsDelete == false)
                           select m;


            if (LastTime != null)
            {
                ExpQuery = ExpQuery.Where(m => m.ReData <= LastTime);
            }
            if (FirstTime != null)
            {
                ExpQuery = ExpQuery.Where(m => m.ReData >= FirstTime);
            }
            if (!string.IsNullOrEmpty(GetCategory))
            {
                ExpQuery = ExpQuery.Where(m => m.Category.CategoryName == GetCategory);
            }
            if (!string.IsNullOrEmpty(GetClass))

            {
                ExpQuery = ExpQuery.Where(m => m.classAndTerm.Name == GetClass);

            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                ExpQuery = ExpQuery.Where(x => x.Rdmark.Contains(SearchString));
            }



            GetCategorys = new SelectList(await GetCategorysQuery.Distinct().ToListAsync());
            GetClasses = new SelectList(await GetClassesQuery.Distinct().ToListAsync());


            Exp = await ExpQuery.OrderByDescending(m => m.ReData)
                .Include(e => e.Category)
                .Include(e => e.classAndTerm)
                .ToListAsync();



        }
    }
}
