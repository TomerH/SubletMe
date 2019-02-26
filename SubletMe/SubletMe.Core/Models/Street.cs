using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.Models
{
    public class Street : BaseUnitEntity
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string StreetId { get; set; }
        public string Name_He { get; set; }
    }
}
