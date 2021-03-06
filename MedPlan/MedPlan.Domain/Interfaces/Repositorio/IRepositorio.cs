using MedPlan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedPlan.Domain.Interfaces.Repositorio
{
    public interface IRepositorio<T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(Guid id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);

        Task<int> SaveChanges();
    }
}
