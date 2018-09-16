using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace model
{
    public class CarDbContext : DbContext
    {
        public CarDbContext() : base()
        {
            Database.SetInitializer<CarDbContext>(new CarDbInitializer());
        }

        public DbSet<Car> Cars { get; set; }
    }
}
