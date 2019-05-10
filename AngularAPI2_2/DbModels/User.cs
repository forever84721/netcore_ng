using System;
using System.Collections.Generic;

namespace AngularAPI2_2.DbModels
{
    public partial class User
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime SetupTime { get; set; }
        public string ShopId { get; set; }
    }
}
