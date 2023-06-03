using System;
using Microsoft.EntityFrameworkCore;
using TechStoreLibrary.Models.Data;
using TechStoreLibrary.Models.Entities;

namespace TechStore.Models.Data
{
	public class SeedData
	{
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Computers and Laptops"
                    },
                    new Category
                    {
                        Name = "Computer peripherals"
                    },
                    new Category
                    {
                        Name = "Smartphones and gadgets"
                    },
                    new Category
                    {
                        Name = "Accessories"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

