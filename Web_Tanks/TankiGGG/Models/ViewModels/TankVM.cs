using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankiGGG.Models.ViewModels
{
    public class TankVM
    {
        public Tank Tank {get;set;}

        public IEnumerable<SelectListItem> TDDNation { get; set; }
        public IEnumerable<SelectListItem> TDDTank_type { get; set; }

    }
}
