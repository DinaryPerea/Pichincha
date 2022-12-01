using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T Entity);
        Task<T> Update(T Entity);

        Task<T> FindById(Expression<Func<T, bool>> Id);
        Task<bool> Remove(T Entity);
        Task<int> SaveChanger();
    }
}
