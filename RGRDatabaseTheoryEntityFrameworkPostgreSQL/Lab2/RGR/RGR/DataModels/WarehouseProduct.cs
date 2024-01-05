using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.DataModels
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public int Warehouse_Id {get; set;}
        public int Product_Id { get; set; }
    }
}
