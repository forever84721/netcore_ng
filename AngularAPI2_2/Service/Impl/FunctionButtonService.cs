using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;

namespace AngularAPI2_2.Service.Impl
{
    public class FunctionButtonService : IFunctionButtonService, IDisposable
    {
        private bool disposedValue = false;
        private readonly WebPOSContext context;
        public FunctionButtonService(WebPOSContext context)
        {
            this.context = context;
        }
        public List<FunctionButton> GetFunctionButtonsByType(FunctionGroupType Type)
        {
            return context.FunctionButton.Where(a => a.FunctionGroupId == (int)Type).ToList();
        }
        ~FunctionButtonService()
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
