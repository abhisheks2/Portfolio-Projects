using System;
using System.ComponentModel.DataAnnotations;

namespace HomeFinance.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public CategoryEnum ExpenseCategory { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public TypeEnum ExpenseType { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [DataType(DataType.Currency)]
        public double ExpenseAmount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; } 
        
        [MaxLength(200, ErrorMessage = "Max 200 characters")]
        public string ExpenseDetails { get; set; }
    }
}
