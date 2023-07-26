using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApp<TViewModel, TModel>

     where TViewModel : class

     where TModel : class

    {

        Task<TModel> FindByIdAsync(int id);

        Task<TViewModel> FindOneAsync(int id);

        Task<TViewModel> EditAsync(TViewModel entity);

        Task<IEnumerable<TViewModel>> WhereAsync(Expression<Func<TModel, bool>> predicate);

        Task<IEnumerable<TViewModel>> FindAllAsync();

        Task<TModel> CreateAsync(TViewModel viewModel);

        //Task<int> RemoveAsync(TModel model);

    }

    public interface IApp<TModel>

    where TModel : class

    {

        Task<IEnumerable<TModel>> WhereAsync(Expression<Func<TModel, bool>> predicate);

        Task<IEnumerable<TModel>> FindAllAsync();

        Task<TModel> FindByIdAsync(int id);

        Task<TModel> FindOneAsync(int id);

        Task<TModel> CreateAsync(TModel viewModel);

        Task<TModel> EditAsync(TModel viewModel);

        //Task<int> RemoveAsync(TModel model);

    }






}
