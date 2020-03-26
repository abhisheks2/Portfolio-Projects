using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HomeFinance.Controllers
{
    [AllowAnonymous]
    public class ExpenseLimitController : Controller
    {
        private readonly IExpenseLimitRepository _expenseLimitRepository;
        private string userName;

        public ExpenseLimitController(IExpenseLimitRepository expenseLimitRepository)
        {
            _expenseLimitRepository = expenseLimitRepository;
        }

        public ViewResult Index()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            IEnumerable<ExpenseLimit> model = _expenseLimitRepository.GetExpenseLimitsAll(userName);
            return View(model);
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
            ExpenseLimit expenseLimit = _expenseLimitRepository.GetExpenseLimitById(Id, userName);
            if (expenseLimit == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"ExpenseLimit with Id = {Id} cannot be found";
                return View("NotFound");
            }
            ExpenseLimit expenseLimitDeleted = _expenseLimitRepository.Delete(Id, userName);
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
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    userName = "abhisheks2@gmail.com";
                }
                else
                {
                    userName = User.Identity.Name;
                }
                IEnumerable<ExpenseLimit> expenseLimits = _expenseLimitRepository.GetExpenseLimitsAll(userName);
                var result = expenseLimits.SingleOrDefault(el => el.ExpenseType == expenseLimit.ExpenseType);
                if (result == null)
                {
                    expenseLimit.UserName = userName;
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
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = "abhisheks2@gmail.com";
            }
            else
            {
                userName = User.Identity.Name;
            }
            ExpenseLimit expenseLimit = _expenseLimitRepository.GetExpenseLimitById(Id, userName);
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
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    userName = "abhisheks2@gmail.com";
                }
                else
                {
                    userName = User.Identity.Name;
                }
                expenseLimit.UserName = userName;
                ExpenseLimit updatedexpenseLimit = _expenseLimitRepository.Update(expenseLimit);
                return RedirectToAction("Index");
            }
            return View(expenseLimit);
        }
    }
}