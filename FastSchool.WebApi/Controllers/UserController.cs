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

namespace FastSchool.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBLL UserBLL { get; }
        public UserController(IUserBLL userBLL)
        {
            UserBLL = userBLL;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            var entiy = await UserBLL.GetEntiyAsync<User>(u => u.UserName.Equals(userName));
            var user = new ViewModelUser
            {
                Phone = entiy.Phone,
                UserName = entiy.UserName,
                FullName = entiy.FullName,
                SchoolNumber = entiy.SchoolNumber,
                UserPwd = entiy.UserPwd,
            };
            //用户名 / 姓名 / 学号 / 手机号
            return new JsonResult(user);
        }

        public IActionResult Post()
        {
            return default;
        }

        /// <summary>
        /// 修改个人资料
        /// </summary>
        /// <param name="viewModelUser"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<string> Put([FromBody]ViewModelUser viewModelUser)
        {
            //修改个人资料
            //接收：姓名 / 学号 / 手机号
            var user = await UserBLL.GetEntiyAsync<User>(u => u.UserName.Equals(viewModelUser.UserName));
            if (user == null)
            {
                return "error";
            }
            if (!string.IsNullOrWhiteSpace(viewModelUser.FullName))
                user.FullName = viewModelUser.FullName;
            if (viewModelUser.SchoolNumber != default)
                user.SchoolNumber = viewModelUser.SchoolNumber;
            if (viewModelUser.Phone != default)
                user.Phone = viewModelUser.Phone;
            var b = await UserBLL.UpdateAsync(user);
            return b ? "ok" : "error";
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(EitPwd) + "/{oldPwd}")]
        public async Task<IActionResult> EitPwd(string oldPwd, [FromBody]ViewModelUser viewModelUser)
        {
            //修改个人密码
            //接收：新密码
            var user = await UserBLL.GetEntiyAsync<User>(u => u.UserName.Equals(viewModelUser.UserName));
            if (user == null)
            {
                return NotFound("非法请求");
                return new JsonResult(new ResultModel<string>(-1, "密码错误"));
            }
            if (!user.UserPwd.Equals(oldPwd))
            {
                return Ok("原密码错误");
            }
            user.UserPwd = viewModelUser.UserPwd;
            var b = await UserBLL.UpdateAsync(user);
            return b ? Ok("ok") : Ok("error");
        }


        public IActionResult Delete()
        {
            return default;
        }

    }
}