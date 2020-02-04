using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Data
{
    public interface IRepository
    {
        bool IsEmpty<T>() where T : class;
        Task<List<T>> GetAll<T>() where T : class;
        Task<T> Get<T>(int id) where T : class;
        Task Add<T>(T entity) where T : class;
        Task AddRange<T>(params T []entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(T entity) where T : class;
    }
}
