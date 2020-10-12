using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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
        
        
        public void OnGet()
        {
            var iscc = _context.GradeClass.FirstOrDefault(m => m.IsCurrentClass == true);
            if(iscc!=null)
            {
                DefualtClass = iscc.ClassName;
            }
            else
            {
                DefualtClass = "一年级1班";
            }
            



        }
    }
}
