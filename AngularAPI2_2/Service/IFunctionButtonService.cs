using AngularAPI2_2.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAPI2_2.Service
{
    public interface IFunctionButtonService
    {
        List<FunctionButton> GetFunctionButtonsByType(FunctionGroupType Type);
    }
    public enum FunctionGroupType
    {
        Function = 1,
        Sale = 2,
        DataSetting = 3,
        Report = 4
    }
}
