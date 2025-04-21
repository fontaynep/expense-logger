using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseLogger.Data;
using ExpenseLogger.Models;

namespace ExpenseLogger.Pages_Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly ExpenseLogger.Data.AppDbContext _context;

        public DetailsModel(ExpenseLogger.Data.AppDbContext context)
        {
            _context = context;
        }

        public Expense Expense { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FirstOrDefaultAsync(m => m.Id == id);

            if (expense is not null)
            {
                Expense = expense;

                return Page();
            }

            return NotFound();
        }
    }
}
