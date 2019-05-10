using System;
using System.Collections.Generic;

namespace AngularAPI2_2.DbModels
{
    public partial class Table
    {
        public string ShopId { get; set; }
        public string AreaId { get; set; }
        public string TableId { get; set; }
        public string TableName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Shape { get; set; }
    }
}
