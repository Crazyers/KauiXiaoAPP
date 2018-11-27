using FastSchool.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace FastSchool.BLL
{
    public class AccountBLL : BaseBLL, IAccountBLL
    {
        public AccountBLL(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
