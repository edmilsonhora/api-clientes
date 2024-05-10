using ESH_Barbearia.DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.DataAccess.Contextos
{
    public class MyContext : DbContext
    {

        public MyContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BarbeariaTeste;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
