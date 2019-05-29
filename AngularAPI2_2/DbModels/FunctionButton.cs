using System;
using System.Collections.Generic;

namespace AngularAPI2_2.DbModels
{
    public partial class FunctionButton
    {
        public int FunctionGroupId { get; set; }
        public int FunctionButtonId { get; set; }
        public string DisplayText { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public int Seq { get; set; }
        public bool? Visible { get; set; }
    }
}
