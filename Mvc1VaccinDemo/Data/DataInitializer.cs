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
            SeedSuppliers(dbContext);
            SeedVaccins(dbContext); //Color, Län , kommuner
        }

        private static void SeedSuppliers(ApplicationDbContext dbContext)
        {
            var supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "AstraZeneca och Oxford University");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier {Name = "AstraZeneca och Oxford University" });

            supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "Pfizer/BioNTech");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier { Name = "Pfizer/BioNTech" });

            supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "Moderna");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier { Name = "Moderna" });

            dbContext.SaveChanges();

        }

        private static void SeedVaccins(ApplicationDbContext dbContext)
        {
            var vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "COVID-19 Vaccine AstraZeneca");
            if (vaccin == null)
                dbContext.Vacciner.Add( new Vaccin
                {
                    Supplier = dbContext.Suppliers.First(r=>r.Name ==  "AstraZeneca och Oxford University"),
                    Namn = "COVID-19 Vaccine AstraZeneca",
                    EuOkStatus = null,
                    Type = Vaccin.VaccinType.Vector
                } );
            else
            {
                vaccin.Supplier = dbContext.Suppliers.First(r => r.Name == "AstraZeneca och Oxford University");
            }

            vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "Comirnaty");
            if (vaccin == null)
                dbContext.Vacciner.Add(new Vaccin
                {
                    Supplier = dbContext.Suppliers.First(r => r.Name == "Pfizer/BioNTech"),
                    Namn = "Comirnaty",
                    EuOkStatus = new DateTime(2020,12,21),
                    Type = Vaccin.VaccinType.mRNA
                });
            else
            {
                vaccin.Supplier = dbContext.Suppliers.First(r => r.Name == "Pfizer/BioNTech");
            }

            vaccin = dbContext.Vacciner.FirstOrDefault(r => r.Namn == "Covid-19 Vaccine Moderna");
            if (vaccin == null)
                dbContext.Vacciner.Add(new Vaccin
                {
                    Supplier = dbContext.Suppliers.First(r => r.Name == "Moderna"),
                    Namn = "Covid-19 Vaccine Moderna",
                    EuOkStatus = new DateTime(2021, 1, 6),
                    Type = Vaccin.VaccinType.mRNA
                });
            else
            {
                vaccin.Supplier = dbContext.Suppliers.First(r => r.Name == "Moderna");
            }

            dbContext.SaveChanges();
        }
    }
}
