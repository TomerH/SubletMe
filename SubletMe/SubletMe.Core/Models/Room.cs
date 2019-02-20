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
        [Range(0, 100)]
        public string Roommates { get; set; }
    }
}
