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
        public string Description
            {
            get; set;
            }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount
            {
            get; set;
            }

        [DataType(DataType.Date)]
        public DateTime Date
            {
            get; set;
            }

        public string Category
            {
            get; set;
            }
        public string? Description { get; set; }
        public string? Category { get; set; }


    }
}
