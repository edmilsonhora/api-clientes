using ESH.Barbearia.DataAccess.Contextos;
using ESH.Barbearia.DataAccess.Repositories;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.DataAccess
{
    public class Repository : IRepository
    {
        private MyContext _context;
        public Repository()
        {
            _context = new MyContext();
        }

        private IClienteRepository _clientes;
        public IClienteRepository Clientes => _clientes ?? (_clientes = new ClienteRepository(_context));

        public void Rollback()
        {
            _clientes = null;
            _context = new MyContext();
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }
    }
}
