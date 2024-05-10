using ESH.Barbearia.ApplicationService.Facades;
using ESH.Barbearia.ApplicationService.Views;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.ApplicationService
{
    public class Facade : IFacade
    {
        private readonly IRepository _repository;
        public Facade(IRepository repository)
        {
            _repository = repository;
        }

        private IClienteFacade _clientes;
        public IClienteFacade Clientes => _clientes ?? (_clientes = new ClienteFacade(_repository));

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void RollBack()
        {
            _repository.Rollback();
        }
    }
}
