using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Barbearia.DomainModel.Model
{
    public interface IRepository
    {
        void SaveChanges();
        void Rollback();
        IClienteRepository Clientes { get; }        
    }
}
