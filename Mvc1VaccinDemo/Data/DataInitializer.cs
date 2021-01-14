using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mvc1VaccinDemo.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedVaccins(dbContext); //Color, Län , kommuner
        }

        private static void SeedVaccins(ApplicationDbContext dbContext)
        {
            var vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "COVID-19 Vaccine AstraZeneca");
            if (vaccin == null)
                dbContext.Vacciner.Add( new Vaccin
                {
                    Supplier = "AstraZeneca och Oxford University",
                    Namn = "COVID-19 Vaccine AstraZeneca",
                    EuOkStatus = null,
                    Type = Vaccin.VaccinType.Vector
                } );

            vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "Comirnaty");
            if (vaccin == null)
                dbContext.Vacciner.Add(new Vaccin
                {
                    Supplier = "Pfizer/BioNTech",
                    Namn = "Comirnaty",
                    EuOkStatus = new DateTime(2020,12,21),
                    Type = Vaccin.VaccinType.mRNA
                });

            vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "Covid-19 Vaccine Moderna");
            if (vaccin == null)
                dbContext.Vacciner.Add(new Vaccin
                {
                    Supplier = "Moderna",
                    Namn = "Covid-19 Vaccine Moderna",
                    EuOkStatus = new DateTime(2021, 1, 6),
                    Type = Vaccin.VaccinType.mRNA
                });

            dbContext.SaveChanges();
        }
    }
}
