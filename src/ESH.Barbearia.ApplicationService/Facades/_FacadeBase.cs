using ESH.Barbearia.ApplicationService.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.ApplicationService.Facades
{
    public interface IFacade
    {
        void SaveChanges();
        void RollBack();
        IClienteFacade Clientes { get; }
    }

    public interface IFacadeBase<T> where T : IView
    {
        void Salvar(T view);
        T ObterPor(int id);
        List<T> ObterTodos();
        void Excluir(int id);
    }
}
