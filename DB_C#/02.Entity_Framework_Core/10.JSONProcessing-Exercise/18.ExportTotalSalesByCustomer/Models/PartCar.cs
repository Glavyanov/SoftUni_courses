using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Models
{
    public class PartCar
    {
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
