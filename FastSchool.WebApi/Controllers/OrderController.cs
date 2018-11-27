using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastSchool.Interface;
using FastSchool.Model;
using FastSchool.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastSchool.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderBLL OrderBLL { get; }
        public OrderController(IOrderBLL orderBLL)
        {
            OrderBLL = orderBLL;
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            var entiys = OrderBLL.GetEntiysInclude(
                whereExpressions: u => u.User.UserName.Equals(userName),
                expressions: new System.Linq.Expressions.Expression<Func<Order, object>>[]
                { u => u.Commodity })
                .OrderByDescending(u => u.CreateDateTime)
                .IgnoreQueryFilters();     //IgnoreQueryFilters()取消全局过滤

            //OrderBLL.GetALLEntiyByWhere<Order>(u => u.User.UserName.Equals(userName)).IgnoreQueryFilters();  //暂时有问题，导航属性Commodity查不出，暂时不知道原因

            var list = new List<ViewModelOrder>();
            foreach (var item in entiys)
            {
                var resultModel = new ViewModelOrder
                {
                    UserName = item.User.UserName,
                    SendUserName = item.SendUser.UserName,
                    OrderNumber = item.OrderNumber,
                    OrderState = item.OrderState,
                    Code = item.Code,
                };
                list.Add(resultModel);
            }
            //获取订单的action
            return new JsonResult(list);
        }

        /// <summary>
        /// 获取单个订单
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetOrderByCode) + "/{code}")]
        public async Task<IActionResult> GetOrderByCode(Guid code)
        {
            var entiys = await OrderBLL.GetEntiysInclude(whereExpressions: o => o.Code.Equals(code), expressions: new System.Linq.Expressions.Expression<Func<Order, object>>[] {
                o => o.Commodity,
                o => o.User,
                o => o.SendUser }).IgnoreQueryFilters().FirstOrDefaultAsync();

            var result = new ViewModelOrderInfo
            {
                Code = entiys.Code,
                OrderNumber = entiys.OrderNumber,
                OrderState = entiys.OrderState,
                SendUserName = entiys.SendUser.UserName,
                UserName = entiys.User.UserName,
                EnumExpressType = entiys.Commodity.EnumExpressType,
                PickUpAddress = entiys.Commodity.PickUpAddress,
                PickUpCode = entiys.Commodity.PickUpCode,
                Ponus = entiys.Commodity.Ponus.ToString("F2"),
                Remarks = entiys.Commodity.Remarks,
                Sendaddress = entiys.Commodity.Sendaddress
            };

            //获取订单的action
            return new JsonResult(result);
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <returns></returns>
        [HttpPost("{code}/{userName}")]
        public async Task<string> Post(Guid code, string userName)
        {
            var entiy = await OrderBLL.GetEntiyAsync<Commodity>(u => u.Code.Equals(code));
            var thisUser = await OrderBLL.GetEntiyAsync<User>(u => u.UserName.Equals(userName));
            if (entiy == null && thisUser == null)
                return default;
            var order = new Order
            {
                Commodity = entiy,
                OrderState = Model.Enum.EnumOrderState.待处理,
                SendUser = entiy.User,
                User = thisUser,
            };
            var b = await OrderBLL.CreateOrderAsync(order, entiy);
            return b ? "ok" : default;
        }
    }
}