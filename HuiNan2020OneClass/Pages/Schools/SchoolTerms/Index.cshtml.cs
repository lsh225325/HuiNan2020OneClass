using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Schools.SchoolTerms
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<SchoolTerm> SchoolTerm { get;set; }

        public async Task OnGetAsync()
        {
            SchoolTerm = await _context.SchoolTerm
                .Include(s => s.Semester).ToListAsync();
        }
    }
}
