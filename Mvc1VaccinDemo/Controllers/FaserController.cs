using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class FaserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FaserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET
        public IActionResult Index(string q)
        {
            var viewModel = new FaserIndexViewModel();

            viewModel.Faser = _dbContext.VaccineringsFaser
                .Where(r => q == null || r.Name.Contains(q))
                .Select(dbVacc => new FaserIndexViewModel.FasViewModel
                {
                    Id = dbVacc.Id,
                    Name = dbVacc.Name
                }).ToList();

            return View(viewModel);
        }
    }
}