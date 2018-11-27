using FastSchool.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastSchool.Interface
{
    public interface IUserBLL : IBaseBLL
    {
        Task<bool> ContainsAsync(User user);
    }
}
