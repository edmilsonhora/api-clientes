using ESH.Barbearia.DataAccess.Contextos;
using ESH_Barbearia.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.Barbearia.DataAccess
{
    internal class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly MyContext _context;
        public AbstractRepository(MyContext context)
        {
            _context = context;
        }

        public void Excluir(T entity)
        {
            _context.Remove<T>(entity);
        }

        public T ObterPor(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> ObterTodos()
        {
            return _context.Set<T>().ToList();
        }

        public void Salvar(T entity)
        {
            if(entity.Id.Equals(0))
            {
                _context.Set<T>().Add(entity);
            }
        }
    }
}
