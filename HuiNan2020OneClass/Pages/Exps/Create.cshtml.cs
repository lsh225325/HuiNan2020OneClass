using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.Exps
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
        ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Exp Exp { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exp.Add(Exp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
