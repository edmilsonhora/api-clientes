using ESH.Barbearia.DataAccess.Contextos;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.DataAccess.Repositories
{
    internal class ClienteRepository : AbstractRepository<Cliente>, IClienteRepository
    {
        private readonly MyContext _context;
        public ClienteRepository(MyContext context):base(context)
        {
            _context = context;
        }

        public bool ClienteJahExiste(string cpf)
        {
            return _context.Clientes.Any(p => p.Cpf.Equals(cpf));
        }
                
    }
}
