using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;
using System.Security.Cryptography.X509Certificates;

namespace HuiNan2020OneClass.Pages.Classes
{
    public class CreateModel : PageModel
    {
        private readonly AppContext _context;
       

        public CreateModel(AppContext context)
        {
            _context = context;
        }



        public IActionResult OnGet()
        {
        ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ClassNuberName");
        ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "GradeName");
            return Page();
        }

        [BindProperty]
        public GradeClass GradeClass { get; set; }

        
        public string ErrMsg { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var gradename = _context.Grade.FirstOrDefault(m => m.ID == GradeClass.GradeID);
            var classnubername= _context.ClassNuber.FirstOrDefault(m => m.ID == GradeClass.ClassNuberID);
            GradeClass.ClassName = gradename.GradeName + classnubername.ClassNuberName;

            if(_context.GradeClass.FirstOrDefault(X=>X.ClassName== GradeClass.ClassName)!=null)
            {                
                ErrMsg = "年级重复";
                ViewData["ClassNuberID"] = new SelectList(_context.ClassNuber, "ID", "ClassNuberName");
                ViewData["GradeID"] = new SelectList(_context.Grade, "ID", "GradeName");
                return Page();

            }

            _context.GradeClass.Add(GradeClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
