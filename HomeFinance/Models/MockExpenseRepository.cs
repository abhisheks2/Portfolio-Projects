using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Models
{
    public class MockExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expenseList;

        public MockExpenseRepository()
        {
            _expenseList = new List<Expense>()
            {
                new Expense() {ExpenseID=1, ExpenseCategory=CategoryEnum.Fixed, ExpenseType=TypeEnum.Rent, ExpenseAmount=500.0, ExpenseDate=System.DateTime.Today, ExpenseDetails="Home Rent", UserName = "abhisheks2@gmail.com"},
                new Expense() {ExpenseID=2, ExpenseCategory=CategoryEnum.Variable, ExpenseType=TypeEnum.Fuel, ExpenseAmount=200.0, ExpenseDate=System.DateTime.Today, ExpenseDetails="Shell Birmingham", UserName = "abhisheks2@gmail.com"},
                new Expense() {ExpenseID=3, ExpenseCategory=CategoryEnum.Variable, ExpenseType=TypeEnum.Grocery, ExpenseAmount=50.5, ExpenseDate=System.DateTime.Today, ExpenseDetails="Tesco Birmingham", UserName = "abhisheks2@gmail.com"}
            };
        }

        public Expense Add(Expense expense)
        {
            expense.ExpenseID = _expenseList.Max(e => e.ExpenseID) + 1;
            _expenseList.Add(expense);
            return expense;
        }

        public Expense Delete(int Id, string userName)
        {
            Expense expense = _expenseList.FirstOrDefault(e => e.ExpenseID == Id && e.UserName == userName);
            if (expense != null)
            {
                _expenseList.Remove(expense);
            }
            return expense;
        }

        public Expense GetExpenseById(int Id, string userName)
        {
            return _expenseList.FirstOrDefault(e => e.ExpenseID == Id && e.UserName == userName);
        }

        public IEnumerable<Expense> GetExpensesAll(string userName)
        {
            return _expenseList.Where(e => e.UserName == userName);
        }

        public Expense Update(Expense expenseChanges)
        {
            Expense expense = _expenseList.FirstOrDefault(e => e.ExpenseID == expenseChanges.ExpenseID);
            if (expense != null)
            {
                expense.ExpenseCategory = expenseChanges.ExpenseCategory;
                expense.ExpenseType = expenseChanges.ExpenseType;
                expense.ExpenseDate = expenseChanges.ExpenseDate;
                expense.ExpenseAmount = expenseChanges.ExpenseAmount;
                expense.ExpenseDetails = expenseChanges.ExpenseDetails;
            }
            return expense;
        }
    }
}
