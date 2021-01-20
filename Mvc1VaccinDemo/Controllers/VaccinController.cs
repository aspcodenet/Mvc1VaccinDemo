using System.Collections.Generic;
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


        //
        // Vaccin/Index 
        public IActionResult Index(string q)
        {
            var viewModel = new VaccinIndexViewModel();

            viewModel.Vacciner = _dbContext.Vacciner.Include(r=>r.Supplier)
                .Where(r => q == null || r.Namn.Contains(q))
                .Select(dbVacc => new VaccinViewModel
            {
                Id = dbVacc.Id,
                Supplier = dbVacc.Supplier.Name,
                Name = dbVacc.Namn
            }).ToList();
            
            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new VaccinNewViewModel();
            viewModel.Types = GetTypeSelectListItems();

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
            viewModel.Types = GetTypeSelectListItems();

            return View(viewModel);
        }


        /*
            if (ModelState.IsValid)
            {
                //ALLT ÄR OK!!!
                //Spara i databas...
                //kanske redirect to index
            }
            return View(viewModel);
         
         *
         */

        //namn=varde&namn2=varde&namn3=varde
        [HttpPost]
        public IActionResult Edit(int Id, VaccinEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbVaccin = _dbContext.Vacciner.Include(p => p.Supplier)
                    .First(r => r.Id == Id);
                dbVaccin.Namn = viewModel.Namn;
                dbVaccin.Type = (Vaccin.VaccinType) viewModel.Type;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }



        List<SelectListItem> GetTypeSelectListItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem("Okänd", "0"));
            list.Add(new SelectListItem("mRNA", "1"));
            list.Add(new SelectListItem("Vector", "2"));
            return list;
        }



    }
}