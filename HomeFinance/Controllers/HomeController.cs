using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Models;
using HomeFinance.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HomeFinance.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IExpenseLimitRepository _expenseLimitRepository;
        private readonly IExpenseRepository _expenseRepository;
        private List<DashboardViewModel> model;
        private string userName;
        public HomeController(IExpenseLimitRepository expenseLimitRepository, IExpenseRepository expenseRepository)
        {
            _expenseLimitRepository = expenseLimitRepository;
            _expenseRepository = expenseRepository;
            model = new List<DashboardViewModel>();
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            List<Expense> expenses = _expenseRepository.GetExpensesAll(userName).ToList();
            IEnumerable<ExpenseLimit> expenseLimitList = _expenseLimitRepository.GetExpenseLimitsAll(userName);
            foreach (var expenseLimit in expenseLimitList)
            {
                DashboardViewModel viewModel = new DashboardViewModel();
                viewModel.expType = expenseLimit.ExpenseType;
                viewModel.monthlyLimit = expenseLimit.Limit;
                viewModel.currentSpend = expenses.Where(e => e.ExpenseType == expenseLimit.ExpenseType && e.ExpenseDate.Month == DateTime.Now.Month).Select(e => e.ExpenseAmount).Sum();
                if (viewModel.currentSpend > viewModel.monthlyLimit)
                {
                    viewModel.ragStatus = "red";
                }
                else if (viewModel.currentSpend == viewModel.monthlyLimit)
                {
                    viewModel.ragStatus = "orange";
                }
                else
                {
                    viewModel.ragStatus = "green";
                }
                model.Add(viewModel);
            }
            model = model.OrderBy(m => m.expType).ToList();
            return View(model);
        }
    }
}