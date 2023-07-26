using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{ 
    public interface IRepository<T> : IDisposable where T : class

    {

        Task<int> CreateAsync(T entity);

        Task<int> EditAsync(T entity);

        Task<IEnumerable<T>> FindAllAsync();

        Task<T> FindOneAsync(int id);

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);

        Task<int> RemoveAsync(T entity);

     


        Task<T> FindUserProjectAsync(int Id_Projeto, int Id_Usuario, int Id_Funcao);

 //       Task<int> RemoveUserFromProject(int idProject, int idUser);

    }






}
