using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<List<T>> AddRange(List<T> entities);
        Task<T> GetById(int Id);
        Task<List<T>> GetAll();
        Task<T> Remove(int Id);
        Task<List<T>> RemoveRange(List<T> entities);
    }
}
