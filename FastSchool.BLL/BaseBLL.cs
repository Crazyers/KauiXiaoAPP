using FastSchool.Interface;
using FastSchool.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastSchool.BLL
{
    public class BaseBLL : IBaseBLL, IDisposable
    {
        protected virtual DbContext DbContext { get; set; }
        public BaseBLL(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// 释放DbContext资源
        /// </summary>
        public virtual void Dispose()
        {
            DbContext.Dispose();
        }

        /// <summary>
        /// 添加一组数据
        /// </summary>
        /// <param name="entiys"></param>
        /// <returns>返回添加成功的条数</returns>
        public virtual async Task<int> AddRangeAsync(IEnumerable<object> entiys)
        {
            DbContext.AddRange(entiys);
            var result = await DbContext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddAsync<T>(T t) where T : BaseModel
        {
            var entiy = DbContext.AddAsync(t);
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 删除实体，软删除！！
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync<T>(T t) where T : BaseModel
        {
            DbContext.Entry(t).State = EntityState.Deleted;
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 通过id查找实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync<T>(Guid id) where T : BaseModel
        {
            var entiy = await DbContext.FindAsync<T>(id);
            if (entiy == null)
                return default;
            entiy = entiy.IsDelete == false ? entiy : default;
            return entiy;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync<T>(T t) where T : BaseModel
        {
            DbContext.Update(t);
            //DbContext.Entry(t).State = EntityState.Modified;
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> GetALLEntiy<T>() where T : BaseModel
        {
            return DbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// 通过id删除，软删除！！！
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteByIdAsync<T>(Guid id) where T : BaseModel
        {
            var entiy = await FindAsync<T>(id);
            entiy.IsDelete = true;
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns>成功的条数</returns>
        public virtual async Task<int> SaveChangesAsync()
        {
            int result = await DbContext.SaveChangesAsync();
            return result;
        }

        public virtual DbSet<T> DbSet<T>() where T : BaseModel
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="whereLanbda">lambda过滤条件</param>
        /// <returns></returns>
        public virtual async Task<T> GetEntiyAsync<T>(Expression<Func<T, bool>> whereLanbda) where T : BaseModel
        {
            var entiy = await DbContext.Set<T>().Where(whereLanbda).FirstOrDefaultAsync();
            return entiy;
        }

        /// <summary>
        /// 主外键表联合查询
        /// </summary>
        /// <typeparam name="T">主键表类型</typeparam>
        /// <param name="expressions">外键表的查询表达式</param>
        /// <param name="whereExpressions">where条件</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetEntiysInclude<T>(Expression<Func<T, object>>[] expressions, Expression<Func<T, bool>> whereExpressions = null)
       where T : BaseModel
        {
            var entiys = whereExpressions == null ? DbContext.Set<T>() : DbContext.Set<T>().Where(whereExpressions);
            foreach (var item in expressions)
            {
                if (item != null)
                    entiys = entiys.Include(item);
            }
            return entiys;
        }

        ///// <summary>
        ///// 查询单个实体以及所有导航属性
        ///// </summary>
        ///// <typeparam name="T">主表类型</typeparam>
        ///// <param name="whereLanbda">筛选的表达式</param>
        ///// <param name="expressions">外键表集合</param>
        ///// <returns>单个实体</returns>
        //public async Task<T> GetEntiyIncludeAsync<T>(
        //    Expression<Func<T, bool>> whereLanbda,
        //    Expression<Func<T, object>>[] expressions)
        //    where T : BaseModel
        //{

        //    var result = DbContext.Set<T>().AsNoTracking().Where(whereLanbda);
        //    foreach (var item in expressions)
        //    {
        //        result = result.Include(item);
        //    }
        //    /*.Include(expression).ToList();*/
        //    return await result.FirstOrDefaultAsync();
        //    //await DbContext.Set<Order>().AsNoTracking().Where(whereLanbda).Include(expressions.FirstOrDefault()).IgnoreQueryFilters().FirstOrDefaultAsync();
        //}

        ///// <summary>
        ///// 筛选
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="S"></typeparam>
        ///// <param name="whereExpressions"></param>
        ///// <param name="expressions"></param>
        ///// <returns></returns>
        //public virtual IIncludableQueryable<T, S> GetEntiyWhereAndInclude<T, S>(Expression<Func<T, bool>> whereExpressions, Expression<Func<T, S>>[] expressions)
        //    where T : BaseModel
        //    where S : BaseModel
        //{
        //    var entiys = DbContext.Set<T>().Where(whereExpressions);
        //    IIncludableQueryable<T, S> result = null;

        //    foreach (var item in expressions)
        //    {
        //        if (item != null)
        //            result = entiys.Include(item);
        //    }
        //    return result ?? default;
        //}

        /// <summary>
        /// 添加过滤实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetALLEntiyByWhere<T>(Expression<Func<T, bool>> whereExpression) where T : BaseModel
        {
            return DbContext.Set<T>().Where(whereExpression);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="OrderLambda">排序的表达式数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="isEsc">是否降序排序</param>
        /// <returns>返回查询到的集合和总页数</returns>
        public virtual (IQueryable<T>, int) GetEntiyByPage<T, S>(
            Expression<Func<T, S>> OrderLambda,
            int pageIndex = 1,
            int pageSize = 10,
            bool isEsc = true)
            where T : BaseModel
        {
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            var entiys = DbContext.Set<T>();

            //查询总页数
            var pageCout = Math.Max(entiys.Count() + pageSize - 1 / pageSize, 1);

            //筛选并分页查询
            var relust = entiys.Skip((pageSize * pageIndex) - pageSize).Take(pageSize);

            //排序
            relust = isEsc ? relust.OrderByDescending(OrderLambda) : relust.OrderBy(OrderLambda);

            return (relust, pageCout);
        }
    }
}
