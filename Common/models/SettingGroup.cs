using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.models
{
    public class SettingGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<KeySetting> Settings { get; set; } = [];
    }
}
