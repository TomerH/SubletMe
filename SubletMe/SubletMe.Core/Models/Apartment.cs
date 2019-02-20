using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.Models
{
    public class Apartment : BaseUnitEntity
    {
        [Range(0, 100)]
        public string Floors { get; set; }
        [Range(0, 100)]
        public string Rooms { get; set; }
    }
}
