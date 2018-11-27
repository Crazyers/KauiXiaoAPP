using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastSchool.Interface;
using FastSchool.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public ICommodityBLL CommodityBLL { get; }
        public TestController(ICommodityBLL commodityBLL)
        {
            CommodityBLL = commodityBLL;
        }
        [HttpGet]
        public string Get()
        {
            return "这是一个测试的Action";
        }

        /// <summary>
        /// 添加测试数据的action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var entiy = await CommodityBLL.GetEntiyAsync<User>(u => u.UserName.Equals("admin"));
            if (entiy == null)
            {
                await CommodityBLL.AddAsync(new User
                {
                    FullName = "QXB",
                    UserName = "admin",
                    UserPwd = "admin",
                    Phone = 13407892099,
                    SchoolNumber = long.Parse("2016" + Common.RandomNumber.GetRandomNumber(7).ToString())
                });
            }

            await CommodityBLL.AddAsync(new User
            {
                FullName = "QXB",
                UserName = "hehe",
                UserPwd = "123456",
                Phone = 13407892099,
                SchoolNumber = long.Parse("2016" + Common.RandomNumber.GetRandomNumber(7).ToString())
            });
            if (id.Equals(3))
            {
                var user = await CommodityBLL.GetEntiyAsync<User>(u => u.UserName.Equals("admin"));
                var listEntiys = new List<Commodity>
                {
                    new Commodity {
                        Consignee ="蓝华健",
                        EnumExpressType = Model.Enum.EnumExpressType.EMS, PickUpAddress="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(8),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院11栋606",
                        Remarks ="手机号:13401234567",
                        User =user },

                    new Commodity {
                        Consignee ="李建军",
                        EnumExpressType = Model.Enum.EnumExpressType.EMS,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(6),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院11栋605",
                        Remarks ="手机号:134022223333",
                        User =user },

                    new Commodity { Consignee="黎海兰",
                        EnumExpressType = Model.Enum.EnumExpressType.中通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(8),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院3栋402",
                        Remarks ="手机号:134033334444",
                        User =user },

                    new Commodity { Consignee="周巧敏",
                        EnumExpressType = Model.Enum.EnumExpressType.圆通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院4栋201",
                        Remarks ="手机号:134044445555",
                        User =user },

                    new Commodity { Consignee="肖乐乐",
                        EnumExpressType = Model.Enum.EnumExpressType.中通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院4栋201",
                        Remarks ="手机号:134055556666",
                        User =user },

                    new Commodity { Consignee="朱慧敏",
                        EnumExpressType = Model.Enum.EnumExpressType.圆通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院6栋711",
                        Remarks ="手机号:134066669523",
                        User =user },

                    new Commodity { Consignee="黄凤琳",
                        EnumExpressType = Model.Enum.EnumExpressType.天天快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院2栋613",
                        Remarks ="手机号:134025879652",
                        User =user },

                    new Commodity { Consignee="吴丽花",
                        EnumExpressType = Model.Enum.EnumExpressType.天天快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院7栋603",
                        Remarks ="手机号:134036524789",
                        User =user },

                    new Commodity { Consignee="黎丽华",
                        EnumExpressType = Model.Enum.EnumExpressType.汇通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院9栋108",
                        Remarks ="手机号:134096523658",
                        User =user },

                    new Commodity { Consignee="李丽萍",
                        EnumExpressType = Model.Enum.EnumExpressType.汇通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院4栋705",
                        Remarks ="手机号:134001245896",
                        User =user },

                    new Commodity { Consignee="欧金玲",
                        EnumExpressType = Model.Enum.EnumExpressType.中通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院9栋608",
                        Remarks ="手机号:134085246932",
                        User =user },

                    new Commodity { Consignee="李志鹏",
                        EnumExpressType = Model.Enum.EnumExpressType.顺丰快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院12栋413",
                        Remarks ="手机号:134098565489",
                        User =user },

                    new Commodity { Consignee="黄显栩",
                        EnumExpressType = Model.Enum.EnumExpressType.邮政包裹,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院7栋403",
                        Remarks ="手机号:134020145852",
                        User =user },

                    new Commodity { Consignee="谭健",
                        EnumExpressType = Model.Enum.EnumExpressType.汇通快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院3栋807",
                        Remarks ="手机号:134014785236",
                        User =user },

                    new Commodity { Consignee="黄运",
                        EnumExpressType = Model.Enum.EnumExpressType.邮政包裹,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院11栋409",
                        Remarks ="手机号:134085741258",
                        User =user },

                    new Commodity { Consignee="覃奔",
                        EnumExpressType = Model.Enum.EnumExpressType.韵达快递,
                        PickUpAddress ="广西柳州市鱼峰区柳州职业技术学院坡下A区菜鸟驿站",
                        PickUpCode =Common.RandomNumber.GetRandomNumber(7),
                        Ponus =Common.RandomNumber.GetRandomNumber(2),
                        Sendaddress ="柳州职业技术学院6栋307",
                        Remarks ="手机号:13405829962",
                        User =user },
                };
                var r = await CommodityBLL.AddRangeAsync(listEntiys);
                return $"成功插入{r}条数据";
            }
            return "没有成功！";
        }
    }
}