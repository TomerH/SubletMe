using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SubletMe.Core.Models
{
    public class City : BaseUnitEntity
    {
        public string CityId { get; set; }
        public string Name_He { get; set; }
        public string Name_En { get; set; }
    }
}
