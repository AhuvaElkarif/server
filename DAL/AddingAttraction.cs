using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddingAttraction
    {
        public attraction Attraction { get; set; }
        public List<period> PeriodsList { get; set; }
        public List<image> ImagesList { get; set; }
        public List<equipment> EquipmentsList { get; set; }
        public user Manager { get; set; }
    }
}
