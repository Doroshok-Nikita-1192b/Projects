using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class Tank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Penetration { get; set; }
        public int DPM { get; set; }
        public int ViewRange { get; set; }
        public int Cost { get; set; }


        [ForeignKey("Nation_id")]
        public Nation Nation { get; set; }
        [ForeignKey("Tank_type_id")]
        public TankType TankType { get; set; }

        [DisplayName("Nation")]
        public int Nation_id { get; set; }
        [DisplayName("Tank type")]
        public int Tank_type_id { get; set; }
    }
}
