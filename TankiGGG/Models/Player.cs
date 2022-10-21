using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }

        public int WinningPercentage { get; set; }
        public int AverageDamageDealt { get; set; }
    }
}
