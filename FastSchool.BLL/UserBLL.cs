using FastSchool.Interface;
using FastSchool.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastSchool.BLL
{
    public class UserBLL : BaseBLL, IUserBLL
    {
        public UserBLL(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ContainsAsync(User user)
        {
            return await base.DbSet<User>().ContainsAsync(user);
        }
    }
}
