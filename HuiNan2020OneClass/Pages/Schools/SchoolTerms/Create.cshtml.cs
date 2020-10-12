using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HuiNan2020OneClass;
using System.ComponentModel.DataAnnotations;

namespace HuiNan2020OneClass.Pages.Schools.SchoolTerms
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
            ViewData["SemesterID"] = new SelectList(_context.Semester, "ID", "SemesterName");
            return Page();
        }

        
        

        /// <summary>
        /// 开始的年份
        /// </summary>
        [BindProperty]
        [Range(2020, 2050)]
        public int BeginYear { get; set; } = 2020;

        /// <summary>
        /// 结束的年份
        /// </summary>
        [BindProperty]
        [Range(2020,2050)]
        public int EndYear { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMsg { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (BeginYear<2020||EndYear>2050||BeginYear>EndYear)
            {
                ErrMsg = "开始或结束日期有错，起止日期区间为2020-2050";
                return Page();
            }


            //var senesterNames = _context.Semester.Select(m => m.SemesterName).ToList();
            var senester = _context.Semester.ToList();

            for ( int i = BeginYear;i<= EndYear;i++)
            {
                for (int x=0;x<= senester.Count()-1;x++)
                {
                    

                    var schoolterm = new SchoolTerm();
                    schoolterm.Name = i + senester[x].SemesterName;
                    schoolterm.SchoolYear = i;
                    schoolterm.SemesterID = senester[x].ID;

                    _context.SchoolTerm.Add(schoolterm);

                }

            }

            //_context.SchoolTerm.Add(SchoolTerm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
