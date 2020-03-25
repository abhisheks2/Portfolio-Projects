using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeFinance.Models;

namespace HomeFinance.ViewModels
{
    public class DashboardViewModel
    {
        public TypeEnum expType { get; set; }
        public string ragStatus { get; set; }
        public double monthlyLimit { get; set; }
        public double currentSpend { get; set; }
    }
}
