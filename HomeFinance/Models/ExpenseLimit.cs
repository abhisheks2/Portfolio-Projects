using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Models
{
    public class ExpenseLimit
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public CategoryEnum ExpenseCategory { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public TypeEnum ExpenseType { get; set; }

        [Required(ErrorMessage = "Limit is required")]
        [DataType(DataType.Currency)]
        public int Limit { get; set; }

    }
}
