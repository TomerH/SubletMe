using SubletMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.ViewModels
{
    public class SubletItemViewModel
    {
        public IEnumerable<Apartment> Apartments { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
