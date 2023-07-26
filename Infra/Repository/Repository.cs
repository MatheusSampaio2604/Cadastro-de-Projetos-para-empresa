using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext Db;
        protected readonly DbSet<T> DbSet;



        public Repository(DataContext context)
        {
            Db = context;
            DbSet = context.Set<T>();
        }



        public virtual async Task<int> CreateAsync(T entity)
        {
            DbSet.Add(entity);
            return await SaveChangesAsync();
        }



        public virtual async Task<int> EditAsync(T entity)
        {
            DbSet.Attach(entity);
            Db.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }




        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> FindOneAsync(int id)
        {
            var obj = await DbSet.FindAsync(id);
            if (Db.Entry(obj).State == EntityState.Unchanged)
            {
                Db.Entry(obj).State = EntityState.Detached;
                obj = await DbSet.FindAsync(id);
            }
            return obj;
        }


        public async Task<T> FindUserProjectAsync(int Id_Projeto, int Id_Usuario, int Id_Funcao)
        {
            var obj = await DbSet.FindAsync(Id_Projeto, Id_Usuario, Id_Funcao);
            if (Db.Entry(obj).State == EntityState.Unchanged)
            {
                Db.Entry(obj).State = EntityState.Detached;
                obj = await DbSet.FindAsync(Id_Projeto, Id_Usuario, Id_Funcao);
            }

            return obj;
        }


        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }



        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }


        public async Task<int> RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            return await SaveChangesAsync();
        }


   //  public async Task<int> RemoveUserFromProject(int idProject, int idUser)
   //  {
   //      var item = DbSet.Find(idProject, idUser);
   //      DbSet.Remove(item);
   //      return await SaveChangesAsync();
   //  }


        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
