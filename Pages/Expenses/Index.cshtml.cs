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

        public IList<Expense> Expenses { get; set; } = default!;

        // This will grab the value from the search box (URL query)
        [BindProperty(SupportsGet = true)]
        public string? SearchString
            {
            get; set;
            }

        public async Task OnGetAsync()
            {
            // Start with all expenses
            var query = _context.Expenses.AsQueryable();

            // If the user typed something in the search box, filter it
            if (!string.IsNullOrWhiteSpace(SearchString))
                {
                query = query.Where(e => EF.Functions.Like(e.Description.ToLower(), $"%{SearchString.ToLower()}%"));
                }


            // Execute the query and return the list
            Expenses = await query.ToListAsync();
            }
        }
    }
