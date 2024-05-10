using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Barbearia.DomainModel.Model
{
    public abstract class EntityBase
    {
        protected StringBuilder RegrasQuebradas = new StringBuilder();
        public int Id { get; set; }

        public virtual void Validar()
        {
            if(RegrasQuebradas.Length > 0)
            {
                throw new ApplicationException(RegrasQuebradas.ToString());
            }
        }

        protected void CampoTextoObrigatorio(string nomeCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                RegrasQuebradas.Append($"O campo {nomeCampo} é obrigatório.{Environment.NewLine}");
            }
        }
    }

    public interface IRepositoryBase<T> where T : EntityBase { 
    
        void Salvar(T entity);
        T ObterPor(int id);
        List<T> ObterTodos();
        void Excluir(T entity);
    }
}
