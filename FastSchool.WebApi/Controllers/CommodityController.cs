using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FastSchool.Interface;
using FastSchool.Model;
using FastSchool.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastSchool.WebApi.Controllers
{
    /// <summary>
    /// 商品的控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommodityController : ControllerBase
    {
        public ICache Cache { get; }
        public ICommodityBLL CommodityBLL { get; }
        public CommodityController(ICache cache, ICommodityBLL commodityBLL)
        {
            Cache = cache;
            CommodityBLL = commodityBLL;
        }

        /// <summary>
        /// 获取所有最新信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entiy = CommodityBLL.GetEntiysInclude(
                new Expression<Func<Commodity, object>>[] { u => u.User }).OrderByDescending(u => u.CreateDateTime);
            var list = new List<ViewModelCommodity>();
            foreach (var item in entiy)
            {
                list.Add(new ViewModelCommodity
                {
                    Code = item.Code,
                    Consignee = item.Consignee,
                    EnumExpressType = item.EnumExpressType,
                    PickUpAddress = item.PickUpAddress,
                    PickUpCode = item.PickUpCode,
                    Ponus = item.Ponus.ToString("f2"),
                    Remarks = item.Remarks,
                    Sendaddress = item.Sendaddress,
                    UserName = item.User.UserName,
                });
            }
            return new JsonResult(list);
        }

        /// <summary>
        /// 通过ID获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var entiy = await CommodityBLL.FindAsync<Commodity>(Id);
            return new JsonResult(entiy);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Post([FromBody]ViewModelCommodity commodity)
        {
            var error = "error";
            var userName = commodity.UserName?.Trim();
            if (string.IsNullOrWhiteSpace(userName))
                return error;
            var user = await CommodityBLL.GetEntiyAsync<User>(u => u.UserName.Equals(userName));
            if (user == null)
                return error;
            var model = new Commodity
            {
                Consignee = commodity.Consignee,
                EnumExpressType = commodity.EnumExpressType,
                PickUpAddress = commodity.PickUpAddress,
                PickUpCode = commodity.PickUpCode,
                Sendaddress = commodity.Sendaddress,
                Remarks = commodity.Remarks,
                Ponus = Convert.ToDecimal(commodity.Ponus),
                LastEitDateTime = DateTime.Now,
                User = user,
            };
            var b = await CommodityBLL.AddAsync(model);
            return b ? "ok" : "error";
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]ViewModelCommodity commodity)
        {
            return default;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            var b = await CommodityBLL.DeleteByIdAsync<Commodity>(id);
            return b ? "ok" : "error";
        }
    }
}