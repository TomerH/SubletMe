using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.Models
{
    public class Request : BaseUnitEntity
    {
        public string Kind { get; set; }
        public string Rooms { get; set; }
    }
}
