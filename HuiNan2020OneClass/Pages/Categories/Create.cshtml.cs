using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HuiNan2020OneClass.Pages.Categories
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
        public Category Category { get; set; }
        public string ErrMsg { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_context.Category.FirstOrDefault(m=>m.CategoryName== Category.CategoryName)!=null)
            {
                ErrMsg = "类别重复";

                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
