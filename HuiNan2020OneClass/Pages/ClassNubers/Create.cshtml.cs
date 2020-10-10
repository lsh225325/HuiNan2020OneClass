using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.ClassNubers
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
            return Page();
        }

        [BindProperty]
        public ClassNuber ClassNuber { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClassNuber.Add(ClassNuber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
