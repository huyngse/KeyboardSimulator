using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class KeySetting
    {
        public int Id { get; set; }
        public char Key { get; set; }
        // hold || press || heat activation
        public string Type { get; set; } = "";
        // millisecond
        public int Delay { get; set; }
        public int? HoldInterval { get; set; } = 0;
        public int? HeatCD { get; set; } = 10;
        public int RandomIndex { get; set; } = 1;
        public float Weight { get; set; }
        public int SettingGroupId { get; set; }
        public SettingGroup? SettingGroup { get; set; }
    }
}
