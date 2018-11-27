using FastSchool.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastSchool.Interface
{
    public interface IBaseBLL
    {
        Task<bool> AddAsync<T>(T t) where T : BaseModel;
        Task<int> AddRangeAsync(IEnumerable<object> entiys);
        Task<bool> UpdateAsync<T>(T t) where T : BaseModel;
        Task<T> FindAsync<T>(Guid id) where T : BaseModel;
        Task<T> GetEntiyAsync<T>(Expression<Func<T, bool>> expressions) where T : BaseModel;

        IQueryable<T> GetEntiysInclude<T>(Expression<Func<T, object>>[] expressions, Expression<Func<T, bool>> whereExpressions = null)
      where T : BaseModel;

        IQueryable<T> GetALLEntiy<T>() where T : BaseModel;
        IQueryable<T> GetALLEntiyByWhere<T>(Expression<Func<T, bool>> expressions)
            where T : BaseModel;

        (IQueryable<T>, int) GetEntiyByPage<T, S>(
            Expression<Func<T, S>> OrderLambda,
            int pageIndex,
            int pageSize,
            bool isEsc = true)
            where T : BaseModel;

        Task<bool> DeleteAsync<T>(T t) where T : BaseModel;
        Task<bool> DeleteByIdAsync<T>(Guid id) where T : BaseModel;
        DbSet<T> DbSet<T>() where T : BaseModel;
        Task<int> SaveChangesAsync();

        //Task<T> GetEntiyIncludeAsync<T>(
        //    Expression<Func<T, bool>> whereLanbda,
        //    Expression<Func<T, object>>[] expressions)
        //    where T : BaseModel;
    }
}
