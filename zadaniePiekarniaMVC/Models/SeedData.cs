using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using zadaniePiekarniaMVC.Data;
using System;
using System.Linq;

namespace zadaniePiekarniaMVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new zadaniePiekarniaMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<zadaniePiekarniaMVCContext>>()))
            {
                
                if (context.Piekarnia.Any())
                {
                    return;   
                }
                context.Piekarnia.AddRange(
                    new Piekarnia
                    {
                        Nazwa = "Rogal maślany",
                        Rodzaj = "Przekąska słodka",
                        Cena = 12,
                        
                    },
                    new Piekarnia
                    {
                        Nazwa = "Paluszki solone",
                        Rodzaj = "Przekąska słona",
                        Cena = 5,
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
