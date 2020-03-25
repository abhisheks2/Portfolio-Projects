using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Models
{
    public class SQLExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext context;

        public SQLExpenseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Expense Add(Expense expense)
        {
            context.Expenses.Add(expense);
            context.SaveChanges();
            return expense;
        }

        public Expense Delete(int Id, string userName)
        {
            Expense expense = context.Expenses.SingleOrDefault(e => e.UserName == userName && e.ExpenseID == Id);
            if (expense != null)
            {
                context.Expenses.Remove(expense);
                context.SaveChanges();
            }
            return expense;

        }

        public Expense GetExpenseById(int Id, string userName)
        {
            return context.Expenses.SingleOrDefault(e => e.UserName == userName && e.ExpenseID == Id);
        }

        public IEnumerable<Expense> GetExpensesAll(string userName)
        {
            return context.Expenses.Where(e => e.UserName == userName);
        }

        public Expense Update(Expense expense)
        {
            context.Entry(expense).State = EntityState.Modified;
            context.SaveChanges();
            return expense;
        }
    }
}
