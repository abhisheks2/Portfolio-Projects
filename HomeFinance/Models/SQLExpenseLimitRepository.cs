using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Models
{
    public class SQLExpenseLimitRepository : IExpenseLimitRepository
    {
        private readonly AppDbContext context;

        public SQLExpenseLimitRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ExpenseLimit Add(ExpenseLimit expenseLimit)
        {
            context.ExpenseLimits.Add(expenseLimit);
            context.SaveChanges();
            return expenseLimit;
        }

        public ExpenseLimit Delete(int Id, string userName)
        {
            ExpenseLimit expenseLimit = context.ExpenseLimits.SingleOrDefault(el => el.Id == Id && el.UserName == userName);
            if (expenseLimit != null)
            {
                context.ExpenseLimits.Remove(expenseLimit);
                context.SaveChanges();
            }
            return expenseLimit;
        }

        public ExpenseLimit GetExpenseLimitById(int Id, string userName)
        {
            return context.ExpenseLimits.SingleOrDefault(el => el.Id == Id && el.UserName == userName);
        }

        public IEnumerable<ExpenseLimit> GetExpenseLimitsAll(string userName)
        {
            return context.ExpenseLimits.Where(el => el.UserName == userName);
        }

        public ExpenseLimit Update(ExpenseLimit expenseLimit)
        {
            context.Entry(expenseLimit).State = EntityState.Modified;
            context.SaveChanges();
            return expenseLimit;
        }
    }
}
