using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Models;
using HomeFinance.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeFinance.Controllers
{
    [AllowAnonymous]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        private readonly List<int> YearList;

        private string userName;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            YearList = new List<int>() {
                DateTime.Today.Year,
                DateTime.Today.Year - 1,
                DateTime.Today.Year - 2,
                DateTime.Today.Year - 3,
                DateTime.Today.Year - 4
            };
        }

        public ViewResult Index(ExpenseListViewModel model)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            model.expenseList = _expenseRepository.GetExpensesAll(userName).OrderBy(e => e.ExpenseDate);
            ViewBag.YearList = new SelectList(YearList);

            if (model.searchCategory != null)
            {
                model.expenseList = model.expenseList.Where(e => e.ExpenseCategory == model.searchCategory);
            }
            if (model.searchType != null)
            {
                model.expenseList = model.expenseList.Where(e => e.ExpenseType == model.searchType);
            }
            if (model.searchYear != null)
            {
                model.expenseList = model.expenseList.Where(e => e.ExpenseDate.Year == model.searchYear);
            }
            if (model.searchMonth != null)
            {
                model.expenseList = model.expenseList.Where(e => e.ExpenseDate.Month == (int)model.searchMonth);
            }

            return View(model);
        }

        public ViewResult Details(int Id)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            Expense expense = _expenseRepository.GetExpenseById(Id, userName);
            if (expense == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"Expense with Id = {Id} cannot be found";
                return View("NotFound");
            }
            return View(expense);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            Expense expense = _expenseRepository.GetExpenseById(Id, userName);
            if (expense == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"Expense with Id = {Id} cannot be found";
                return View("NotFound");
            }
            Expense expenseDeleted = _expenseRepository.Delete(Id, userName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            if (ModelState.IsValid)
            {
                expense.UserName = userName;
                Expense newExpense = _expenseRepository.Add(expense);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            Expense expense = _expenseRepository.GetExpenseById(Id, userName);
            if (expense == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"Expense with Id = {Id} cannot be found";
                return View("NotFound");
            }
            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    userName = "abhisheks2@gmail.com";
                }
                else
                {
                    userName = User.Identity.Name;
                }
                expense.UserName = userName;
                Expense updatedExpense = _expenseRepository.Update(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }
    }
}