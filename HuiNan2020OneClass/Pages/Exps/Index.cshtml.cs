using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Exps
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<Exp> Exp { get;set; }

        public async Task OnGetAsync()
        {
            Exp = await _context.Exp.OrderByDescending(m=>m.ReData)
                .Include(e => e.Category)
                .Include(e => e.classAndTerm)
                .ToListAsync();
        }
    }
}
