using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Models
{
    public interface IExpenseRepository
    {
        Expense GetExpenseById(int Id, string userName);
        IEnumerable<Expense> GetExpensesAll(string userName);
        Expense Add(Expense expense);
        Expense Update(Expense expense);
        Expense Delete(int Id, string userName);
    }
}
