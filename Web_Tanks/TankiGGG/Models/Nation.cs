using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
