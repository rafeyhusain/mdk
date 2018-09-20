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
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Door> Doors { get; set; }
    }
}
