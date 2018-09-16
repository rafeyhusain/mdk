using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace model
{
    class CarDbInitializer : CreateDatabaseIfNotExists<CarDbContext>
    {
        protected override void Seed(CarDbContext context)
        {
            base.Seed(context);
        }
    }
}

