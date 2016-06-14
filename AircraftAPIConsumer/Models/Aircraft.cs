using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AircraftAPIConsumer.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int Hp { get; set; }
        public int Cruise { get; set; }
        public int Climb { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int Price { get; set; }
    }
}