using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;
using AngularAPI2_2.Models.ResponseModels;

namespace AngularAPI2_2.Service.Impl
{
    public class TableService : ITableService, IDisposable
    {
        private bool disposedValue = false;
        private TestContext context;
        public TableService(TestContext context)
        {
            this.context = context;
        }
        public List<AreaWithTables> GetAreaWithTables(string ShopId)
        {
            var model = new List<AreaWithTables>();
            foreach (var area in context.Area.Where(a => a.ShopId.Equals(ShopId)).ToList())
            {
                var areawithtable = new AreaWithTables
                {
                    Area = area,
                    Tables = context.Table.Where(a => a.ShopId.Equals(ShopId) && a.AreaId.Equals(area.AreaId)).ToList()
                };
                model.Add(areawithtable);
            }
            return model;
        }
        public BaseResponse UpdateTables(List<AreaWithTables> data)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                foreach (var area in data)
                {
                    context.Table.UpdateRange(area.Tables);
                }
                context.SaveChanges();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.ToString();
            }
            return response;
        }
        ~TableService()
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
