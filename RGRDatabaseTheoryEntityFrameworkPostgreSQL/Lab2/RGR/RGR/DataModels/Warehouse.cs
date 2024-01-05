using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.DataModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int City_Id { get; set; }
        public double Square_area {  get; set; }
        public string Address {  get; set; }
    }
}
