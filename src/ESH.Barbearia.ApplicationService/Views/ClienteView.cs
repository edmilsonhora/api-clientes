using ESH.Barbearia.ApplicationService.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.ApplicationService.Views
{
    public class ClienteView : IView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }

    public interface IClienteFacade : IFacadeBase<ClienteView>
    {
        bool VerificaSeClienteJahExiste(string cpf);
    }
    
}
