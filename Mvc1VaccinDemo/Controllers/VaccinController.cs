using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class VaccinController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VaccinController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET
        public IActionResult Index()
        {
            var viewModel = new VaccinIndexViewModel();

            viewModel.Vacciner = _dbContext.Vacciner.Select(dbVacc => new VaccinViewModel
            {
                Id = dbVacc.Id,
                Supplier = dbVacc.Supplier,
                Name = dbVacc.Namn
            }).ToList();
            
            return View(viewModel);
        }
    }
}