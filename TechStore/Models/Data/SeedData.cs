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

            string imagePath1 = "wwwroot/images/CategoryPage/gaming-PC-or-gaming-laptop.jpeg";
            byte[] imageData1 = File.ReadAllBytes(imagePath1);

            string imagePath2 = "wwwroot/images/CategoryPage/computer_peripherals.jpeg";
            byte[] imageData2 = File.ReadAllBytes(imagePath2);

            string imagePath3 = "wwwroot/images/CategoryPage/smartphones-and-gadgets.jpeg";
            byte[] imageData3 = File.ReadAllBytes(imagePath3);

            string imagePath4 = "wwwroot/images/CategoryPage/accessories.jpeg";
            byte[] imageData4 = File.ReadAllBytes(imagePath4);

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Computers and Laptops",
                        Image = imageData1
                    },
                    new Category
                    {
                        Name = "Computer peripherals",
                        Image = imageData2
                    },
                    new Category
                    {
                        Name = "Smartphones and gadgets",
                        Image = imageData3
                    },
                    new Category
                    {
                        Name = "Accessories",
                        Image = imageData4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

