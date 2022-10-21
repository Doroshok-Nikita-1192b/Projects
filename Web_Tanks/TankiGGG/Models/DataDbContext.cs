using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<TankType> tankTypes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<U_Perk> U_Perks { get; set; }
    }
}
