using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        // GET
        public IActionResult Index(string q)
        {
            var viewModel = new PersonIndexViewModel();
            SetupBaseViewModel(viewModel);

            viewModel.Personer = _dbContext.Personer
                .Where(r => q == null || r.Name.Contains(q) || r.PersonalNumber.Contains(q))
                .Select(person => new PersonViewModel
                {
                    Id = person.Id,
                    Name = person.Name,
                    EmailAddress = person.EmailAddress,
                    PersonalNumber = person.PersonalNumber
                }).ToList();

            return View(viewModel);
        }



        public IActionResult Edit(int Id)
        {
            var viewModel = new PersonEditViewModel();
            SetupBaseViewModel(viewModel);

            var dbPerson = _dbContext.Personer.Include(r=>r.VaccineringsFas).First(r => r.Id == Id);

            viewModel.Id = dbPerson.Id;
            viewModel.Name = dbPerson.Name;
            viewModel.EmailAddress = dbPerson.EmailAddress;
            viewModel.PersonalNumber = dbPerson.PersonalNumber;
            viewModel.City = dbPerson.City;
            viewModel.PostalCode = dbPerson.PostalCode;
            viewModel.PreliminaryNextVaccinDate = dbPerson.PreliminaryNextVaccinDate;
            viewModel.StreetAddress = dbPerson.StreetAddress;
            
            viewModel.SelectedVaccineringsFasId = dbPerson.VaccineringsFas.Id;
            viewModel.AllaVaccineringsFaser = GetAllVaccineringsFaserAsListItems(); 

            return View(viewModel);
        }

        private List<SelectListItem> GetAllVaccineringsFaserAsListItems()
        {
            var list = new List<SelectListItem>();
            list.AddRange(_dbContext.VaccineringsFaser.Select(r=>new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }));
            return list;

        }
    }
}