using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeFinance.Models;

namespace HomeFinance.ViewModels
{
    public class ExpenseListViewModel
    {
        public CategoryEnum? searchCategory { get; set; }
        public TypeEnum? searchType { get; set; }
        public int? searchYear { get; set; }
        public MonthEnum? searchMonth { get; set; }
        public IEnumerable<Expense> expenseList { get; set; }
    }
}
