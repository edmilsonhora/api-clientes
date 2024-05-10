using ESH.Barbearia.ApplicationService.Adapters;
using ESH.Barbearia.ApplicationService.Views;
using ESH.Barbearia.DataAccess;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.ApplicationService.Facades
{
    public class ClienteFacade : IClienteFacade
    {
        private readonly IRepository _repository;
        public ClienteFacade(IRepository repository)
        {
            _repository = repository;            
        }
        public void Excluir(int id)
        {
            var obj = _repository.Clientes.ObterPor(id);
            if(obj != null)
            {
                _repository.Clientes.Excluir(obj);
            }
        }
        public ClienteView ObterPor(int id)
        {
            return _repository.Clientes.ObterPor(id).ConvertToview();
        }
        public List<ClienteView> ObterTodos()
        {
            return _repository.Clientes.ObterTodos().ConvertToView();
        }
        public void Salvar(ClienteView view)
        {
            var obj = view.Id == 0 ? new Cliente() : _repository.Clientes.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Cpf = view.Cpf;

            obj.Validar();

            _repository.Clientes.Salvar(obj);
        }
        public bool VerificaSeClienteJahExiste(string cpf)
        {
            return _repository.Clientes.ClienteJahExiste(cpf);
        }
    }
}
