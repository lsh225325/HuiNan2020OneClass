using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Students
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
        ViewData["GradeClassID"] = new SelectList(_context.GradeClass, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
