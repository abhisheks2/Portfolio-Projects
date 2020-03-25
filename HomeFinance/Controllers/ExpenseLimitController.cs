using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeFinance.Controllers
{
    public class ExpenseLimitController : Controller
    {
        private readonly IExpenseLimitRepository _expenseLimitRepository;

        public ExpenseLimitController(IExpenseLimitRepository expenseLimitRepository)
        {
            _expenseLimitRepository = expenseLimitRepository;
        }

        public ViewResult Index()
        {
            IEnumerable<ExpenseLimit> model = _expenseLimitRepository.GetExpenseLimitsAll(User.Identity.Name);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            ExpenseLimit expenseLimit = _expenseLimitRepository.GetExpenseLimitById(Id, User.Identity.Name);
            if (expenseLimit == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"ExpenseLimit with Id = {Id} cannot be found";
                return View("NotFound");
            }
            ExpenseLimit expenseLimitDeleted = _expenseLimitRepository.Delete(Id, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseLimit expenseLimit)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ExpenseLimit> expenseLimits = _expenseLimitRepository.GetExpenseLimitsAll(User.Identity.Name);
                var result = expenseLimits.SingleOrDefault(el => el.ExpenseType == expenseLimit.ExpenseType);
                if (result == null)
                {
                    expenseLimit.UserName = User.Identity.Name;
                    ExpenseLimit newexpenseLimit = _expenseLimitRepository.Add(expenseLimit);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", $"Limit already exists for {expenseLimit.ExpenseType}");
                }
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            ExpenseLimit expenseLimit = _expenseLimitRepository.GetExpenseLimitById(Id, User.Identity.Name);
            if (expenseLimit == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"ExpenseLimit with Id = {Id} cannot be found";
                return View("NotFound");
            }
            return View(expenseLimit);
        }

        [HttpPost]
        public IActionResult Edit(ExpenseLimit expenseLimit)
        {
            if (ModelState.IsValid)
            {
                expenseLimit.UserName = User.Identity.Name;
                ExpenseLimit updatedexpenseLimit = _expenseLimitRepository.Update(expenseLimit);
                return RedirectToAction("Index");
            }
            return View(expenseLimit);
        }
    }
}