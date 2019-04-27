using AngularAPI2_2.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAPI2_2.Service
{
    public interface IUserService
    {
        User FindUserByAccount(string Account);
        bool CheckPassword(User User, string Password);
    }
}
