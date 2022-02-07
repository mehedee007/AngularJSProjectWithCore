using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJSProjectWithCore.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
