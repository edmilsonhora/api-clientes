using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Barbearia.DomainModel.Model
{
    public class Cliente :EntityBase
    {
        
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoTextoObrigatorio(nameof(Cpf), Cpf);

            base.Validar();
        }
    }

    public interface IClienteRepository : IRepositoryBase<Cliente> {

        bool ClienteJahExiste(string cpf);
    }
}
