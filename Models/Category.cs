using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJSProjectWithCore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool? IsAvailable { get; set; } = false;
        public DateTime? EntryDate { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        
    }
}
