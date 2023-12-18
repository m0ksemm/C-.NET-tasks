using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.DataModels
{
    public class Prod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vendor_code { get; set; }
        public string Serial_number { get; set; }
        public DateOnly Delivery_date { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
    }

}
