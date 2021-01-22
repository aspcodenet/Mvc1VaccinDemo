using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mvc1VaccinDemo.Data;
using Mvc1VaccinDemo.ViewModels;

namespace Mvc1VaccinDemo.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected void SetupBaseViewModel(BaseViewModel model)
        {
            model.AllaFaser = _dbContext.VaccineringsFaser
                .Select(dbVacc => new FaserIndexViewModel.FasViewModel
                {
                    Id = dbVacc.Id,
                    Name = dbVacc.Name
                }).ToList();
        }

    }
}