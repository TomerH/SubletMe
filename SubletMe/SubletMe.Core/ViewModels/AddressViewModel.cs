using SubletMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.ViewModels
{
    public class AddressViewModel
    {
        public City Cities { get; set; }
        public Street Streets { get; set; }
    }
}
