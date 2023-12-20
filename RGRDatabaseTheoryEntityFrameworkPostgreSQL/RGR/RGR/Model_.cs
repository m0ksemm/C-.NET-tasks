using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using RGR.DataModels;

namespace RGR
{
    public class InventoryContext : DbContext
    {
        public DbSet<Cities> City { get; set; }
        public DbSet<Manuf> Manufacturer { get; set; }
        public DbSet<Categ> Category { get; set; }
        public DbSet<Prod> Product { get; set; }
        public DbSet<WarehouseProduct> WarehousesProducts { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=Inventory;Username=postgres;Password=011427223");
        }
    }
    public class Model_
    {
        InventoryContext InventoryContext { get; set; }
        public Model_() 
        {
            InventoryContext = new InventoryContext();
        }

        #region ProductMethods
        public List<Prod> GetAllProducts()
        {
            var prod = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\" ORDER BY \"Id\" ASC ");
            
            return prod.ToList();
        }
        public int InputProduct(Prod prod)
        {
            int cat_id = -1;
            int man_id = -1;

            var cat = InventoryContext.Database.SqlQuery<Categ>($"Select * from \"Category\"");
            foreach (Categ c in cat)
            {
                if (c.Name == prod.Category)
                    cat_id = c.Id;
            }
            var man = InventoryContext.Database.SqlQuery<Manuf>($"Select * from \"Manufacturer\"");
            foreach (Manuf m in man)
            {
                if (m.Name == prod.Manufacturer)
                    man_id = m.Id;
                
            }
            if (cat_id == -1)
                return 3;
            if (man_id == -1)
                return 2;

            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\"");
            foreach (Prod p in pr)
            {
                ids.Add(p.Id);
            }
           
            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"Product\" VALUES ('{maxId}', '{prod.Name}', '{prod.Vendor_code}','{prod.Serial_number}','{prod.Delivery_date}', {prod.Quantity}, {man_id}, {cat_id})";

            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }
        public int DeleteProduct(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\"");
            foreach (Prod p in pr)
            {
                ids.Add(p.Id);
            }

            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"Product\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch(Exception ex)
            {
                return 2;
            }
        }
        public int EditProduct(Prod prod, int id)
        {
            int cat_id = -1;
            int man_id = -1;

            var cat = InventoryContext.Database.SqlQuery<Categ>($"Select * from \"Category\"");
            foreach (Categ c in cat)
            {
                if (c.Name == prod.Category)
                    cat_id = c.Id;
            }
            var man = InventoryContext.Database.SqlQuery<Manuf>($"Select * from \"Manufacturer\"");
            foreach (Manuf m in man)
            {
                if (m.Name == prod.Manufacturer)
                    man_id = m.Id;

            }
            if (cat_id == -1)
                return 3;
            if (man_id == -1)
                return 2;
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\"");
            foreach (Prod p in pr)
            {
                ids.Add(p.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"Product\" SET \"Name\"='{prod.Name}', \"Vendor_code\"='{prod.Vendor_code}', \"Serial_number\"='{prod.Serial_number}', \"Delivery_date\"='{prod.Delivery_date}', \"Quantity\"={prod.Quantity}, \r\n\"Manufacturer_Id\"={man_id}, \"Category_Id\"={cat_id} where \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                return 1;
            }
            else return 0;
        }
        public List<Prod> ProductSearchName(string key)
        {
            var pr = InventoryContext.Product.FromSqlRaw(
        @"SELECT ""Product"".""Id"", 
          ""Product"".""Name"" AS Name, 
          ""Product"".""Vendor_code"" AS Vendor_code, 
          ""Product"".""Serial_number"" AS Serial_number, 
          ""Product"".""Delivery_date"" AS Delivery_date, 
          ""Product"".""Quantity"" AS Quantity, 
          ""Manufacturer"".""Name"" AS Manufacturer, 
          ""Category"".""Name"" AS Category 
       FROM ""Product"", ""Manufacturer"", ""Category"" 
       WHERE ""Product"".""Manufacturer_Id"" = ""Manufacturer"".""Id"" 
          AND ""Product"".""Category_Id"" = ""Category"".""Id"" 
          AND ""Product"".""Name"" LIKE '%'||{0}||'%'", key);

            return pr.ToList();
        }
        public List<Prod> ProductSearchVendorCode(string key)
        {
            var pr = InventoryContext.Product.FromSqlRaw(
        @"SELECT ""Product"".""Id"", 
          ""Product"".""Name"" AS Name, 
          ""Product"".""Vendor_code"" AS Vendor_code, 
          ""Product"".""Serial_number"" AS Serial_number, 
          ""Product"".""Delivery_date"" AS Delivery_date, 
          ""Product"".""Quantity"" AS Quantity, 
          ""Manufacturer"".""Name"" AS Manufacturer, 
          ""Category"".""Name"" AS Category 
       FROM ""Product"", ""Manufacturer"", ""Category"" 
       WHERE ""Product"".""Manufacturer_Id"" = ""Manufacturer"".""Id"" 
          AND ""Product"".""Category_Id"" = ""Category"".""Id"" 
          AND ""Product"".""Vendor_code"" LIKE '%'||{0}||'%'", key);

            return pr.ToList();
        }
        public List<Prod> ProductSearchSerialNumber(string key)
        {
            var pr = InventoryContext.Product.FromSqlRaw(
        @"SELECT ""Product"".""Id"", 
          ""Product"".""Name"" AS Name, 
          ""Product"".""Vendor_code"" AS Vendor_code, 
          ""Product"".""Serial_number"" AS Serial_number, 
          ""Product"".""Delivery_date"" AS Delivery_date, 
          ""Product"".""Quantity"" AS Quantity, 
          ""Manufacturer"".""Name"" AS Manufacturer, 
          ""Category"".""Name"" AS Category 
       FROM ""Product"", ""Manufacturer"", ""Category"" 
       WHERE ""Product"".""Manufacturer_Id"" = ""Manufacturer"".""Id"" 
          AND ""Product"".""Category_Id"" = ""Category"".""Id"" 
          AND ""Product"".""Serial_number"" LIKE '%'||{0}||'%'", key);

            return pr.ToList();
        }
        public List<Prod> ProductSearchQuantity(int min, int max)
        {
            var pr = InventoryContext.Product.FromSqlRaw(
        @"SELECT ""Product"".""Id"", 
          ""Product"".""Name"" AS Name, 
          ""Product"".""Vendor_code"" AS Vendor_code, 
          ""Product"".""Serial_number"" AS Serial_number, 
          ""Product"".""Delivery_date"" AS Delivery_date, 
          ""Product"".""Quantity"" AS Quantity, 
          ""Manufacturer"".""Name"" AS Manufacturer, 
          ""Category"".""Name"" AS Category 
       FROM ""Product"", ""Manufacturer"", ""Category"" 
       WHERE ""Product"".""Manufacturer_Id"" = ""Manufacturer"".""Id"" 
          AND ""Product"".""Category_Id"" = ""Category"".""Id"" 
          AND ""Product"".""Quantity"" <= {0} AND ""Product"".""Quantity"" >= {1}", max, min);

            return pr.ToList();
        }

        #endregion

        #region ManufacturerMethods
        public List<Manuf> GetAllManufacturers()
        {
            var prod = InventoryContext.Database.SqlQuery<Manuf>($"Select * from \"Manufacturer\" ORDER BY \"Id\" ASC ");
            return prod.ToList();
        }

        public int InputManufacturer(Manuf man)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Manuf>($"SELECT * FROM \"Manufacturer\"");
            foreach (Manuf m in pr)
            {
                if (m.Name == man.Name)
                    return 0;
            }

            foreach (Manuf m in pr)
            {
                ids.Add(m.Id);
            }
            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"Manufacturer\" VALUES ('{maxId}', '{man.Name}')";
            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }
        public int EditManufacturer(Manuf manuf, int id)
        {
            List<int> ids = new List<int>();
            var man = InventoryContext.Database.SqlQuery<Manuf>($"Select * FROM \"Manufacturer\"");
            foreach (Manuf m in man)
            {
                if (m.Name == manuf.Name)
                    return 2;
                ids.Add(m.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"Manufacturer\" SET \"Name\"='{manuf.Name}' WHERE \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
                return 1;
            }
            else return 0;
        }
        public int DeleteManufacturer(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Manuf>($"SELECT * FROM \"Manufacturer\"");
            foreach (Manuf m in pr)
            {
                ids.Add(m.Id);
            }
            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"Manufacturer\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        public List<Manuf> ManufacturerSearch(string key)
        {
            var cats = InventoryContext.Manufacturer.FromSqlRaw(
            @"SELECT * 
            FROM ""Manufacturer"" 
            WHERE ""Manufacturer"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        #endregion

        #region CategoryMethods
        public List<Categ> GetAllCategories()
        {
            var cats = InventoryContext.Database.SqlQuery<Categ>($"Select * from \"Category\" ORDER BY \"Id\" ASC ");
            return cats.ToList();
        }

        public int InputCategory(Categ cat)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Categ>($"SELECT * FROM \"Category\"");
            foreach (Categ c in pr)
            {
                if (c.Name == cat.Name)
                    return 0;
            }

            foreach (Categ c in pr)
            {
                ids.Add(c.Id);
            }
            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"Category\" VALUES ('{maxId}', '{cat.Name}')";
            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }
        public int EditCategory(Categ cat, int id)
        {
            List<int> ids = new List<int>();
            var ct = InventoryContext.Database.SqlQuery<Categ>($"Select * FROM \"Category\"");
            foreach (Categ c in ct)
            {
                if (c.Name == cat.Name)
                    return 2;
                ids.Add(c.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"Category\" SET \"Name\"='{cat.Name}' WHERE \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
                return 1;
            }
            else return 0;
        }
        public int DeleteCategory(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Categ>($"SELECT * FROM \"Category\"");
            foreach (Categ c in pr)
            {
                ids.Add(c.Id);
            }

            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"Category\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch(Exception ex)
            {
                return 2;
            }
        }
        public List<Categ> CategorySearch(string key)
        {
            var cats = InventoryContext.Category.FromSqlRaw(
            @"SELECT * 
            FROM ""Category"" 
            WHERE ""Category"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        #endregion

        #region CityMethods
        public List<Cities> GetAllCities()
        {
            var cts = InventoryContext.Database.SqlQuery<Cities>($"Select * from \"City\" ORDER BY \"Id\" ASC ");
            return cts.ToList();
        }

        public int InputCity(Cities cts)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Cities>($"SELECT * FROM \"City\"");
            foreach (Cities c in pr)
            {
                if (c.Name == cts.Name)
                    return 0;
            }

            foreach (Cities c in pr)
            {
                ids.Add(c.Id);
            }
            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"City\" VALUES ('{maxId}', '{cts.Name}')";
            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }
        public int EditCity(Cities cat, int id)
        {
            List<int> ids = new List<int>();
            var ct = InventoryContext.Database.SqlQuery<Cities>($"Select * FROM \"City\"");
            foreach (Cities c in ct)
            {
                if (c.Name == cat.Name)
                    return 2;
                ids.Add(c.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"City\" SET \"Name\"='{cat.Name}' WHERE \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
                return 1;
            }
            else return 0;
        }
        public int DeleteCity(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Cities>($"SELECT * FROM \"City\"");
            foreach (Cities c in pr)
            {
                ids.Add(c.Id);
            }

            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"City\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        public List<Cities> CitiesSearch(string key)
        {
            var cats = InventoryContext.City.FromSqlRaw(
            @"SELECT * 
            FROM ""City"" 
            WHERE ""City"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        #endregion

        #region WarehouseMethods
        public List<Warehouse> GetAllWarehouses()
        {

            var wrh = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC ");

            return wrh.ToList();
        }
        public int InputWarehouse(Warehouse warehouse)
        {
            int city_id = -1;

            var ct = InventoryContext.Database.SqlQuery<Cities>($"Select * from \"City\" ORDER BY \"Id\" ASC ");
            foreach (Cities c in ct)
            {
                if (c.Name == warehouse.City)
                    city_id = c.Id;
            }

            if (city_id == -1)
                return 2;


            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC");
            foreach (Warehouse w in pr)
            {
                ids.Add(w.Id);
            }

            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"Warehouse\" VALUES ('{maxId}', '{warehouse.Name}', '{city_id}','{warehouse.Square_area}','{warehouse.Address}')";

            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }

        public int DeleteWarehouse(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC");
            foreach (Warehouse w in pr)
            {
                ids.Add(w.Id);
            }

            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"Warehouse\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        public int EditWarehouse(Warehouse warehouse, int id)
        {
            int city_id = -1;

            var ct = InventoryContext.Database.SqlQuery<Cities>($"Select * from \"City\"");
            foreach (Cities c in ct)
            {
                if (c.Name == warehouse.City)
                    city_id = c.Id;
            }

            if (city_id == -1)
                return 2;

            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC");
            foreach (Warehouse w in pr)
            {
                ids.Add(w.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"Warehouse\" SET \"Name\"='{warehouse.Name}', \"City_Id\"='{city_id}', \"Square_area\"='{warehouse.Square_area}', \"Address\"='{warehouse.Address}' where \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                return 1;
            }
            else return 0;
        }

        public List<Warehouse> WarehouseSearchName(string key)
        {
            var cats = InventoryContext.Warehouses.FromSqlRaw(
                @"SELECT ""Warehouse"".""Id"",
                ""Warehouse"".""Name"" as Name, ""City"".""Name"" as City, 
                ""Warehouse"".""Square_area"" as Square_area, 
                ""Warehouse"".""Address"" as Address FROM ""Warehouse"", 
                ""City"" WHERE  ""Warehouse"".""City_Id"" = ""City"".""Id""
                AND ""Warehouse"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        public List<Warehouse> WarehouseSearchAddress(string key)
        {
            var cats = InventoryContext.Warehouses.FromSqlRaw(
                @"SELECT ""Warehouse"".""Id"",
                ""Warehouse"".""Name"" as Name, ""City"".""Name"" as City, 
                ""Warehouse"".""Square_area"" as Square_area, 
                ""Warehouse"".""Address"" as Address FROM ""Warehouse"", 
                ""City"" WHERE  ""Warehouse"".""City_Id"" = ""City"".""Id""
                AND ""Warehouse"".""Address"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }

        public List<Warehouse>  WarehouseSearchQuantity(double min, double max)
        {
            var cats = InventoryContext.Warehouses.FromSqlRaw(
                @"SELECT ""Warehouse"".""Id"",
                ""Warehouse"".""Name"" as Name, ""City"".""Name"" as City, 
                ""Warehouse"".""Square_area"" as Square_area, 
                ""Warehouse"".""Address"" as Address FROM ""Warehouse"", 
                ""City"" WHERE  ""Warehouse"".""City_Id"" = ""City"".""Id""
                AND ""Warehouse"".""Square_area"" <= {0} 
                AND ""Warehouse"".""Square_area"" >= {0}", min, max);

            return cats.ToList();
        }
        #endregion

        #region WarehouseProductMethods
        public List<WarehouseProduct> GetAllWarehousesProducts()
        {

            var prod = InventoryContext.Database.SqlQuery<WarehouseProduct>($"Select \"Warehouses_Products\".\"Id\", \"Warehouse\".\"Name\" as Warehouse, \"Product\".\"Name\" as Product from \"Warehouse\", \"Product\", \"Warehouses_Products\" where \"Warehouses_Products\".\"Warehouse_Id\"=\"Warehouse\".\"Id\" and \"Warehouses_Products\".\"Product_Id\"=\"Product\".\"Id\" ORDER BY \"Id\" ASC ");

            return prod.ToList();
        }
        public int InputWarehouseProduct(WarehouseProduct prod)
        {
            int war_id = -1;
            int prod_id = -1;
            ///
            var war = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC ");
            foreach (Warehouse w in war)
            {
                if (w.Name == prod.Warehouse)
                    war_id = w.Id;
            }
            var prd = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\" ORDER BY \"Id\" ASC");
            foreach (Prod p in prd)
            {
                if (p.Name == prod.Product)
                    prod_id = p.Id;

            }
            if (war_id == -1)
                return 2;
            if (prod_id == -1)
                return 3;

            List<int> ids = new List<int>();
            var wpr = InventoryContext.Database.SqlQuery<WarehouseProduct>($"Select \"Warehouses_Products\".\"Id\", \"Warehouse\".\"Name\" as Warehouse, \"Product\".\"Name\" as Product from \"Warehouse\", \"Product\", \"Warehouses_Products\" where \"Warehouses_Products\".\"Warehouse_Id\"=\"Warehouse\".\"Id\" and \"Warehouses_Products\".\"Product_Id\"=\"Product\".\"Id\" ORDER BY \"Id\" ASC");
            foreach (WarehouseProduct wp in wpr)
            {
                ids.Add(wp.Id);
            }

            int maxId = ids.Max(id => id) + 1;

            var sqlQuery = $"INSERT INTO \"Warehouses_Products\" VALUES ('{maxId}', '{war_id}', '{prod_id}')";

            int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);
            return 1;
        }

        public int DeleteWarehouseProduct(int id)
        {
            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<WarehouseProduct>($"Select \"Warehouses_Products\".\"Id\", \"Warehouse\".\"Name\" as Warehouse, \"Product\".\"Name\" as Product from \"Warehouse\", \"Product\", \"Warehouses_Products\" where \"Warehouses_Products\".\"Warehouse_Id\"=\"Warehouse\".\"Id\" and \"Warehouses_Products\".\"Product_Id\"=\"Product\".\"Id\" ORDER BY \"Id\" ASC");
            foreach (WarehouseProduct p in pr)
            {
                ids.Add(p.Id);
            }

            try
            {
                if (ids.Contains(id))
                {
                    var sqlQuery = $"DELETE from \"Warehouses_Products\" WHERE \"Id\" = {id};";
                    int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                    return 1;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }


        public int EditWarehouseProduct(WarehouseProduct prod, int id)
        {
            int war_id = -1;
            int prod_id = -1;
            ///
            var war = InventoryContext.Database.SqlQuery<Warehouse>($"Select \"Warehouse\".\"Id\", \"Warehouse\".\"Name\" as Name, \"City\".\"Name\" as City, \"Warehouse\".\"Square_area\" as Square_area, \"Warehouse\".\"Address\" as Address from \"Warehouse\", \"City\" \nwhere  \"Warehouse\".\"City_Id\" = \"City\".\"Id\" \nORDER BY \"Id\" ASC ");
            foreach (Warehouse w in war)
            {
                if (w.Name == prod.Warehouse)
                    war_id = w.Id;
            }
            var prd = InventoryContext.Database.SqlQuery<Prod>($"Select \"Product\".\"Id\", \"Product\".\"Name\" as Name, \"Product\".\"Vendor_code\" as Vendor_code, \"Product\".\"Serial_number\" as Serial_number, \"Product\".\"Delivery_date\" as Delivery_date, \"Product\".\"Quantity\" as Quantity,\"Manufacturer\".\"Name\" as Manufacturer, \"Category\".\"Name\" as Category\r\nfrom \"Product\", \"Manufacturer\", \"Category\" where  \"Product\".\"Manufacturer_Id\" = \"Manufacturer\".\"Id\" and \"Product\".\"Category_Id\" = \"Category\".\"Id\" ORDER BY \"Id\" ASC");
            foreach (Prod p in prd)
            {
                if (p.Name == prod.Product)
                    prod_id = p.Id;

            }
            if (war_id == -1)
                return 2;
            if (prod_id == -1)
                return 3;

            List<int> ids = new List<int>();
            var pr = InventoryContext.Database.SqlQuery<WarehouseProduct>($"Select \"Warehouses_Products\".\"Id\", \"Warehouse\".\"Name\" as Warehouse, \"Product\".\"Name\" as Product from \"Warehouse\", \"Product\", \"Warehouses_Products\" where \"Warehouses_Products\".\"Warehouse_Id\"=\"Warehouse\".\"Id\" and \"Warehouses_Products\".\"Product_Id\"=\"Product\".\"Id\" ORDER BY \"Id\" ASC");
            foreach (WarehouseProduct p in pr)
            {
                ids.Add(p.Id);
            }

            if (ids.Contains(id))
            {
                var sqlQuery = $"UPDATE \"Warehouses_Products\" SET \"Warehouse_Id\"='{war_id}', \"Product_Id\"='{prod_id}' WHERE \"Id\" = {id};";
                int numberOfRowInserted = InventoryContext.Database.ExecuteSqlRaw(sqlQuery);

                return 1;
            }
            else return 0;
        }
        public List<WarehouseProduct> WarehouseProductSearchW(string key)
        {
            var cats = InventoryContext.WarehousesProducts.FromSqlRaw(
                @"Select ""Warehouses_Products"".""Id"", ""Warehouse"".""Name"" as Warehouse, ""Product"".""Name"" as Product from ""Warehouse"", ""Product"", ""Warehouses_Products"" WHERE ""Warehouses_Products"".""Warehouse_Id""=""Warehouse"".""Id"" AND ""Warehouses_Products"".""Product_Id""=""Product"".""Id"" AND ""Warehouse"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        public List<WarehouseProduct> WarehouseProductSearchP(string key)
        {
            var cats = InventoryContext.WarehousesProducts.FromSqlRaw(
                @"Select ""Warehouses_Products"".""Id"", ""Warehouse"".""Name"" as Warehouse, ""Product"".""Name"" as Product from ""Warehouse"", ""Product"", ""Warehouses_Products"" WHERE ""Warehouses_Products"".""Warehouse_Id""=""Warehouse"".""Id"" AND ""Warehouses_Products"".""Product_Id""=""Product"".""Id"" AND ""Product"".""Name"" LIKE '%'||{0}||'%'", key);

            return cats.ToList();
        }
        #endregion
    }
}
