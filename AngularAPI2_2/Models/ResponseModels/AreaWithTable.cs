using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;

namespace AngularAPI2_2.Models.ResponseModels
{
    public class AreaWithTables
    {
        public Area Area { get; set; }
        public List<Table> Tables { get; set; }
    }
}
