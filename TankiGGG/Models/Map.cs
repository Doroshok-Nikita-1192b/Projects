using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public string MapName { get; set; }

    }
}
