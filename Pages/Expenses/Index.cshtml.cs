using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseLogger.Data;
using ExpenseLogger.Models;

namespace ExpenseLogger.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly ExpenseLogger.Data.AppDbContext _context;

        public IndexModel(ExpenseLogger.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Expense> Expenses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Expenses = await _context.Expenses.ToListAsync();
        }
    }
}
