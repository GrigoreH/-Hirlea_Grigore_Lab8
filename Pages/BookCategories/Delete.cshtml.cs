﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hirlea_Grigore_Lab8.Data;
using Hirlea_Grigore_Lab8.Models;

namespace Hirlea_Grigore_Lab8.Pages.BookCategories
{
    public class DeleteModel : PageModel
    {
        private readonly Hirlea_Grigore_Lab8.Data.Hirlea_Grigore_Lab8Context _context;

        public DeleteModel(Hirlea_Grigore_Lab8.Data.Hirlea_Grigore_Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookCategory = await _context.BookCategory
                .Include(b => b.Book)
                .Include(b => b.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (BookCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookCategory = await _context.BookCategory.FindAsync(id);

            if (BookCategory != null)
            {
                _context.BookCategory.Remove(BookCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
