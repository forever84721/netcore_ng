using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;
using AngularAPI2_2.Models.ResponseModels;

namespace AngularAPI2_2.Service
{
    public interface ITableService
    {
        List<AreaWithTables> GetAreaWithTables(string ShopId);
        BaseResponse UpdateTables(List<AreaWithTables> data);
    }
}
