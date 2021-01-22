using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class FaserController : BaseController
    {

        public FaserController(ApplicationDbContext dbContext) 
            :base(dbContext)

        {
        }

        // GET
        public IActionResult Index(string q)
        {
            var viewModel = new FaserIndexViewModel();
            SetupBaseViewModel(viewModel);

            viewModel.Faser = _dbContext.VaccineringsFaser
                .Where(r => q == null || r.Name.Contains(q))
                .Select(dbVacc => new FaserIndexViewModel.FasViewModel
                {
                    Id = dbVacc.Id,
                    Name = dbVacc.Name
                }).ToList();

            return View(viewModel);
        }


        public IActionResult Edit(int Id)
        {
            var viewModel = new VaccineringsFasEditViewModel();
            SetupBaseViewModel(viewModel);

            var dbPerson = _dbContext.VaccineringsFaser.First(r => r.Id == Id);

            viewModel.Id = dbPerson.Id;
            viewModel.Name = dbPerson.Name;
            viewModel.Comment = dbPerson.Description;

            return View(viewModel);
        }

    }
}