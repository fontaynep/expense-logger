using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseLogger.Data;
using ExpenseLogger.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpenseLogger.Pages.Expenses
    {
    public class CreateModel : PageModel
    {
        private readonly ExpenseLogger.Data.AppDbContext _context;

        public CreateModel(ExpenseLogger.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; } = new Expense();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
            {
            Console.WriteLine($"DEBUG Expense: {Expense.Description}, {Expense.Amount}, {Expense.Category}, {Expense.Date}");

            if (!ModelState.IsValid)
                {
                Console.WriteLine("ModelState is invalid.");
                foreach (var state in ModelState)
                    {
                    foreach (var error in state.Value.Errors)
                        {
                        Console.WriteLine($"Model Error - {state.Key}: {error.ErrorMessage}");
                        }
                    }
                return Page();
                }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            }



        }
    }
