using Clothes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.DB
{
    class ClothesContext : DbContext
    {
        public ClothesContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ClothesContext>(null);
        }
        public DbSet<Stuff> Clothes { get; set; }
    }
}
