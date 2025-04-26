using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseLogger.Models
    {
    public class Expense
        {
        public int Id
            {
            get; set;
            }

        [Required]
        [Display(Name = "Expense Description")]

        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Category")]

        public string Category { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Amount ($)")]

        public decimal Amount
            {
            get; set;
            }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date
            {
            get; set;
            }

        //public string Category{get; set;}
        

    }
}
