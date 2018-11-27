using FastSchool.Interface;
using FastSchool.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastSchool.BLL
{
    public class CommodityBLL : BaseBLL, ICommodityBLL
    {
        public CommodityBLL(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
