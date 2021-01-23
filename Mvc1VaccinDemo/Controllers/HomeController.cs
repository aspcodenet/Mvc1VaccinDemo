using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc1VaccinDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            SetupBaseViewModel();

            viewModel.AntalGjordaVaccineringar = _dbContext.Vaccineringar.Count();
            viewModel.AntalGodkandaVaccin = _dbContext.Vacciner.Count(r=>r.EuOkStatus != null);
            viewModel.NumberOfPersons = _dbContext.Personer.Count();
            viewModel.NumberOfSuppliers = _dbContext.Suppliers.Count();
            var senast = _dbContext.Vacciner.OrderByDescending(r => r.EuOkStatus).Take(1).First();
            viewModel.SenastGodkand = senast.EuOkStatus.Value;
            viewModel.SenastGodkandVaccin = senast.Namn;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
