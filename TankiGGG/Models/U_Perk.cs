using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class U_Perk
    {
        [Key]
        public int Id { get; set; }
        public string PerkName { get; set; }
        public string Description { get; set; }
    }
}
