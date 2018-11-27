using FastSchool.Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastSchool.Interface
{
    public interface IOrderBLL : IBaseBLL
    {
        Task<bool> CreateOrderAsync(Order order, Commodity commodity);

        //Task<Order> GetOrderIncludeEntiyAsync(Expression<Func<Order, bool>> whereLanbda, Expression<Func<Order, object>>[] expressions);
    }
}
