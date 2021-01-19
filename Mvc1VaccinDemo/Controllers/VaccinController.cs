using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

            //var list = _dbContext.Vacciner.ToList();
            //var list2 = _dbContext.Vacciner.Include(r=>r.Supplier).ToList();


            viewModel.Vacciner = _dbContext.Vacciner.Include(r=>r.Supplier)
                .Select(dbVacc => new VaccinViewModel
            {
                Id = dbVacc.Id,
                Supplier = dbVacc.Supplier.Name,
                Name = dbVacc.Namn
            }).ToList();
            
            return View(viewModel);
        }

        public IActionResult Edit(int Id)
        {
            var viewModel = new VaccinEditViewModel();

            var dbVaccin = _dbContext.Vacciner.Include(p=>p.Supplier).First(r => r.Id == Id);

            viewModel.Id = dbVaccin.Id;
            viewModel.EuOkStatus = dbVaccin.EuOkStatus;
            viewModel.Namn = dbVaccin.Namn;
            viewModel.Supplier = dbVaccin.Supplier.Name;
            viewModel.Type = (int)dbVaccin.Type;
            viewModel.Types.Add(new SelectListItem("Okänd", "0"));
            viewModel.Types.Add(new SelectListItem("mRNA", "1"));
            viewModel.Types.Add(new SelectListItem("Vector", "2"));

            return View(viewModel);
        }



    }
}