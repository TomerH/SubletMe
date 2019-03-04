using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.Models
{
    public class Room : BaseUnitEntity
    {
        public string UserId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public string Description { get; set; }
        public string Accessories { get; set; }
        public string AirConditioner { get; set; }
        public string Balcony { get; set; }
        [Range(0, 999999999)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public string Roommates { get; set; }
        public bool HotList { get; set; }
    }
}
