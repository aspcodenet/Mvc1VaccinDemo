using System;
using System.Collections.Generic;
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
            
            viewModel.Faser = _dbContext.VaccineringsFaser
                .Where(r => q == null || r.Name.Contains(q))
                .Select(dbVacc => new FaserIndexViewModel.FasViewModel
                {
                    Id = dbVacc.Id,
                    Name = dbVacc.Name
                }).ToList();

            return View(viewModel);
        }


        public IActionResult New()
        {
            var viewModel = new VaccineringsFasNewViewModel();
            


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(VaccineringsFasNewViewModel viewModel)
        {
            //viewModel.Name
            bool redanFinnsIDatabasen = _dbContext.VaccineringsFaser.Any(r=>r.Name == viewModel.Name);
            
            if (redanFinnsIDatabasen)
                ModelState.AddModelError("Name", "Namnet upptaget");

            if (ModelState.IsValid)
            {
                var fas = new VaccineringsFas();
                _dbContext.VaccineringsFaser.Add(fas);
                fas.Name = viewModel.Name;
                fas.Description = viewModel.Comment;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }





        public IActionResult Edit(int Id)
        {
            var viewModel = new VaccineringsFasEditViewModel();

            var dbPerson = _dbContext.VaccineringsFaser.First(r => r.Id == Id);

            viewModel.Id = dbPerson.Id;
            viewModel.Name = dbPerson.Name;
            viewModel.Comment = dbPerson.Description;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int Id, VaccineringsFasEditViewModel viewModel)
        {
            //try
            //{
            //    new DateTime(viewModel.Year, viewModel.Month, viewModel.Day);
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("Day","Det där blev ju inget datum ju");
            //}

            if (ModelState.IsValid)
            {
                var fas = _dbContext.VaccineringsFaser.First(r => r.Id == Id);
                fas.Name = viewModel.Name;
                fas.Description = viewModel.Comment;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}