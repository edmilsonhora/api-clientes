using ESH.Barbearia.ApplicationService.Views;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.ApplicationService.Adapters
{
    public static class ClienteAdapter
    {
        public static List<ClienteView> ConvertToView(this List<Cliente> lista)
        {
            var novaLista = new List<ClienteView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToview());
            }

            return novaLista;
        }

        public static ClienteView ConvertToview(this Cliente item)
        {
            if (item == null) return new ClienteView();

            return new ClienteView()
            {
                Id = item.Id,
                Cpf = item.Cpf,
                Nome = item.Nome
            };
        }
    }
}
