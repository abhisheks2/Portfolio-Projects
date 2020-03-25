using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Models
{
    public interface IExpenseLimitRepository
    {
        ExpenseLimit GetExpenseLimitById(int Id, string userName);
        IEnumerable<ExpenseLimit> GetExpenseLimitsAll(string userName);
        ExpenseLimit Add(ExpenseLimit expenseLimit);
        ExpenseLimit Update(ExpenseLimit expenseLimit);
        ExpenseLimit Delete(int Id, string userName);
    }
}
