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
        public DateTime CreatedAt { get; set; }

        public BaseUnitEntity()
        {
            this.Id = Guid.NewGuid().ToString();

            CreatedAt = DateTime.Now;
        }
    }
}
