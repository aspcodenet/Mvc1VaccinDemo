using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["AllaFaser"] = _dbContext.VaccineringsFaser
                .Select(dbVacc => new FaserIndexViewModel.FasViewModel
                {
                    Id = dbVacc.Id,
                    Name = dbVacc.Name
                }).ToList();

            base.OnActionExecuting(context);
        }

    }
}