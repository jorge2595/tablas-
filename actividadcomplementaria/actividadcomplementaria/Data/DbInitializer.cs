using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using actividadcomplementaria.Models;

namespace actividadcomplementaria.Data
{
    public class DbInitializer
    {
        public static void Initialize(actividadcomplementariaContext context)
        {
            context.Database.EnsureCreated();
            if (context.area.Any())
            {
                return;
            }
            var area = new area[]
            {

            };
            foreach (area a in area)
            {
                context.area.Add(a);
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
