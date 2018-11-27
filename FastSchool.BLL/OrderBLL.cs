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
    public class OrderBLL : BaseBLL, IOrderBLL
    {
        public OrderBLL(DbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="commodity"></param>
        /// <returns></returns>
        public async Task<bool> CreateOrderAsync(Order order, Commodity commodity)
        {
            commodity.IsDelete = true;
            DbContext.Update(commodity);
            await DbContext.AddAsync(order);
            var result = await DbContext.SaveChangesAsync();
            return result > 0;
        }

        //public async Task<Order> GetOrderIncludeEntiyAsync(Expression<Func<Order, bool>> whereLanbda, Expression<Func<Order, object>>[] expressions)
        //{

        //    var result = DbContext.Set<Order>().AsNoTracking().IgnoreQueryFilters().Where(whereLanbda);
        //    foreach (var item in expressions)
        //    {
        //        result = result.Include(item);
        //    }
        //    /*.Include(expression).ToList();*/
        //    return await result.FirstOrDefaultAsync();
        //    //await DbContext.Set<Order>().AsNoTracking().Where(whereLanbda).Include(expressions.FirstOrDefault()).IgnoreQueryFilters().FirstOrDefaultAsync();
        //}
    }
}
