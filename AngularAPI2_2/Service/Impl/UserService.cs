using AngularAPI2_2.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAPI2_2.Service.Impl
{
    public class UserService : IUserService, IDisposable
    {
        private bool disposedValue = false;
        private TestContext context;
        public UserService(TestContext context)
        {
            this.context = context;
        }
        public User FindUserByAccount(string Account)
        {
            var u = context.User.Where(a => a.Account.Equals(Account)).ToList();
            if (u.Count() != 0)
            {
                return u.First();
            }
            return null;
        }
        public bool CheckPassword(User User, string Password)
        {
            var PasswordHash = Utility.Utility.PasswordEncoding(Password);
            return User.Password.Equals(PasswordHash);
        }

        ~UserService()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;
                //if ()
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                    // 例如，可以將綁定的事件解除
                }
                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。
            }
        }
    }
}
