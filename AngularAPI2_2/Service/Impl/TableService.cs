﻿using System;
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
        public List<AreaWithTables> GetAreaWithTables()
        {
            var model = new List<AreaWithTables>();
            foreach (var area in context.Area.ToList())
            {
                var areawithtable = new AreaWithTables
                {
                    Area = area,
                    Tables = context.Table.Where(a => a.AreaId.Equals(area.AreaId)).ToList()
                };
                model.Add(areawithtable);
            }
            return model;
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