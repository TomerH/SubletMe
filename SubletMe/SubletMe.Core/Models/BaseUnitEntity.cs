using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.Core.Models
{
    public class BaseUnitEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
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

        public BaseUnitEntity()
        {
            this.Id = Guid.NewGuid().ToString();

            CreatedAt = DateTime.Now;
        }
    }
}
