﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

namespace HuiNan2020OneClass.Pages.ClassNubers
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<ClassNuber> ClassNuber { get;set; }

        public async Task OnGetAsync()
        {
            ClassNuber = await _context.ClassNuber.ToListAsync();
        }
    }
}
