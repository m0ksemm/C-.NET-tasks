using System;
using System.Collections;
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
        public DbSet<WarehouseProduct> Warehouses_Products { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=Inventory;Username=postgres;Password=011427223");
        }
    }
    public class Model_
    {
        InventoryContext inventoryContext { get; set; }
        public Model_() 
        {
            inventoryContext = new InventoryContext();
        }

        #region ProductMethods
        public List<Prod> GetAllProducts()
        {
            List<Prod> products = inventoryContext.Product.ToList();

            return products;
        }
        public int InputProduct(Prod prod)
        {
            try
            {
                inventoryContext.Product.Add(prod);
                inventoryContext.SaveChanges();
                return 1;
            }
            catch 
            {
                return 2;
            }
        }
        public int DeleteProduct(int id)
        {
            try 
            {
                Prod? prod = inventoryContext.Product.FirstOrDefault(o => o.Id == id);
                if (prod == null)
                    return 0;
                inventoryContext.Product.Remove(prod);
                inventoryContext.SaveChanges();
                return 1;
            }
            catch 
            {
                return 2;
            }
        }
        public int EditProduct(Prod prod, int id)
        {
            var recordToUpdate = inventoryContext.Product.Find(id);

            if (recordToUpdate != null)
            {
                try 
                {
                    recordToUpdate.Name = prod.Name;
                    recordToUpdate.Vendor_code = prod.Vendor_code;
                    recordToUpdate.Serial_number = prod.Serial_number;
                    recordToUpdate.Delivery_date = prod.Delivery_date;
                    recordToUpdate.Quantity = prod.Quantity;
                    recordToUpdate.Manufacturer_Id = prod.Manufacturer_Id;
                    recordToUpdate.Category_Id = prod.Category_Id;

                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }
        public List<Prod> ProductSearchName(string key)
        {
            var searchResults = inventoryContext.Product
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }
        public List<Prod> ProductSearchVendorCode(string key)
        {
            var searchResults = inventoryContext.Product
                .Where(e => e.Vendor_code.Contains(key))
                .ToList();

            return searchResults.ToList();
        }
        public List<Prod> ProductSearchSerialNumber(string key)
        {
            var searchResults = inventoryContext.Product
                .Where(e => e.Serial_number.Contains(key))
                .ToList();

            return searchResults.ToList();
        }
        public List<Prod> ProductSearchQuantity(int min, int max)
        {
            var searchResults = inventoryContext.Product
                .Where(e => e.Quantity >= min && e.Quantity <= max)
                .ToList();

            return searchResults.ToList();
        }

        #endregion

        #region ManufacturerMethods
        public List<Manuf> GetAllManufacturers()
        {
            List<Manuf> list = inventoryContext.Manufacturer.ToList();

            return list;
        }

        public int InputManufacturer(Manuf man)
        {
            List<int> ids = new List<int>();
            List<Manuf> list = inventoryContext.Manufacturer.ToList();
            foreach (Manuf m in list)
            {
                if (m.Name == man.Name)
                    return 0;
            }
            foreach (Manuf m in list)
            {
                ids.Add(m.Id);
            }
            man.Id = ids.Max(id => id) + 1;

            inventoryContext.Manufacturer.Add(man);
            inventoryContext.SaveChanges();

            return 1;
        }
        public int EditManufacturer(Manuf manuf, int id)
        {
            var recordToUpdate = inventoryContext.Manufacturer.Find(id);

            if (recordToUpdate != null)
            {
                recordToUpdate.Name = manuf.Name;
                recordToUpdate.Id = id;

                inventoryContext.SaveChanges();
                return 1;
            }
            else return 0;
        }
        public int DeleteManufacturer(int id)
        {
            var recordToDelete = inventoryContext.Manufacturer.Find(id);

            if (recordToDelete != null) 
            {
                try 
                {
                    inventoryContext.Manufacturer.Remove(recordToDelete);
                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch 
                {
                    return 2;
                }
            }
            else return 0;
        }
        public List<Manuf> ManufacturerSearch(string key)
        {
            var searchResults = inventoryContext.Manufacturer
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }
        #endregion

        #region CategoryMethods
        public List<Categ> GetAllCategories()
        {
            List<Categ> list = inventoryContext.Category.ToList();

            return list;
        }

        public int InputCategory(Categ cat)
        {
            List<int> ids = new List<int>();
            List<Categ> list = inventoryContext.Category.ToList();
            foreach (Categ m in list)
            {
                if (m.Name == cat.Name)
                    return 0;
            }
            foreach (Categ m in list)
            {
                ids.Add(m.Id);
            }
            cat.Id = ids.Max(id => id) + 1;

            inventoryContext.Category.Add(cat);
            inventoryContext.SaveChanges();

            return 1;
        }
        public int EditCategory(Categ cat, int id)
        {
            var recordToUpdate = inventoryContext.Category.Find(id);

            if (recordToUpdate != null)
            {
                recordToUpdate.Name = cat.Name;
                recordToUpdate.Id = id;

                inventoryContext.SaveChanges();
                return 1;
            }
            else return 0;
        }
        public int DeleteCategory(int id)
        {
            var recordToDelete = inventoryContext.Category.Find(id);

            if (recordToDelete != null)
            {
                try
                {
                    inventoryContext.Category.Remove(recordToDelete);
                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }
        public List<Categ> CategorySearch(string key)
        {
            var searchResults = inventoryContext.Category
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }



        
        #endregion

        #region CityMethods
        public List<Cities> GetAllCities()
        {
            List<Cities> list = inventoryContext.City.ToList();

            return list;
        }

        public int InputCity(Cities man)
        {
            List<int> ids = new List<int>();
            List<Cities> list = inventoryContext.City.ToList();
            foreach (Cities m in list)
            {
                if (m.Name == man.Name)
                    return 0;
            }
            foreach (Cities m in list)
            {
                ids.Add(m.Id);
            }
            man.Id = ids.Max(id => id) + 1;

            inventoryContext.City.Add(man);
            inventoryContext.SaveChanges();

            return 1;
        }
        public int EditCity(Cities city, int id)
        {
            var recordToUpdate = inventoryContext.City.Find(id);

            if (recordToUpdate != null)
            {
                recordToUpdate.Name = city.Name;
                recordToUpdate.Id = id;

                inventoryContext.SaveChanges();
                return 1;
            }
            else return 0;
        }
        public int DeleteCity(int id)
        {
            var recordToDelete = inventoryContext.City.Find(id);

            if (recordToDelete != null)
            {
                try
                {
                    inventoryContext.City.Remove(recordToDelete);
                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }
        public List<Cities> CitiesSearch(string key)
        {
            var searchResults = inventoryContext.City
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }

        #endregion

        #region WarehouseMethods
        public List<Warehouse> GetAllWarehouses()
        {
            List<Warehouse> warehouses = inventoryContext.Warehouse.ToList();
            return warehouses;
        }
        public int InputWarehouse(Warehouse warehouse)
        {
            List<int> ids = new List<int>();
            List<Warehouse> warehouses = inventoryContext.Warehouse.ToList();
            foreach (Warehouse w in warehouses)
            {
                ids.Add(w.Id);
            }
            warehouse.Id = ids.Max(id => id) + 1;
            try
            {
                inventoryContext.Warehouse.Add(warehouse);
                inventoryContext.SaveChanges();
                return 1;
            }
            catch 
            {
                return 2;
            }
        }
        public int DeleteWarehouse(int id)
        {
            var recordToDelete = inventoryContext.Warehouse.Find(id);

            if (recordToDelete != null)
            {
                try
                {
                    inventoryContext.Warehouse.Remove(recordToDelete);
                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }
        public int EditWarehouse(Warehouse warehouse, int id)
        {
            var recordToUpdate = inventoryContext.Warehouse.Find(id);

            if (recordToUpdate != null)
            {
                try
                {
                    recordToUpdate.Name = warehouse.Name;
                    recordToUpdate.City_Id = warehouse.City_Id;
                    recordToUpdate.Square_area = warehouse.Square_area;
                    recordToUpdate.Address = warehouse.Address;

                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }

        public List<Warehouse> WarehouseSearchName(string key)
        {
            var searchResults = inventoryContext.Warehouse
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }
        public List<Warehouse> WarehouseSearchAddress(string key)
        {
            var searchResults = inventoryContext.Warehouse
                .Where(e => e.Name.Contains(key))
                .ToList();

            return searchResults.ToList();
        }

        public List<Warehouse>  WarehouseSearchSquareArea(double min, double max)
        {
            var searchResults = inventoryContext.Warehouse
                .Where(e => e.Square_area >= min && e.Square_area <= max)
                .ToList();

            return searchResults.ToList();
        }
        #endregion

        #region WarehouseProductMethods
        public List<WarehouseProduct> GetAllWarehousesProducts()
        {

            List<WarehouseProduct> list = inventoryContext.Warehouses_Products.ToList();

            return list;
        }
        public int InputWarehouseProduct(WarehouseProduct prod)
        {

            List<int> ids = new List<int>();
            List<WarehouseProduct> list = inventoryContext.Warehouses_Products.ToList();
            foreach (WarehouseProduct wp in list)
            {
                ids.Add(wp.Id);
            }
            try
            {
                prod.Id = ids.Max(id => id) + 1;
                inventoryContext.Warehouses_Products.Add(prod);
                inventoryContext.SaveChanges();
                return 1;
            }
            catch 
            {
                return 0;
            }
            
        }

        public int DeleteWarehouseProduct(int id)
        {
            var recordToDelete = inventoryContext.Warehouses_Products.Find(id);

            if (recordToDelete != null)
            {
                try
                {
                    inventoryContext.Warehouses_Products.Remove(recordToDelete);
                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }


        public int EditWarehouseProduct(WarehouseProduct warprod, int id)
        {
            var recordToUpdate = inventoryContext.Warehouses_Products.Find(id);

            if (recordToUpdate != null)
            {
                try
                {
                    recordToUpdate.Warehouse_Id = warprod.Warehouse_Id;
                    recordToUpdate.Product_Id = warprod.Product_Id;

                    inventoryContext.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else return 0;
        }
        public List<WarehouseProduct> WarehouseProductSearchW(int warId)
        {
            var searchResults = inventoryContext.Warehouses_Products
                .Where(e => e.Warehouse_Id == warId)
                .ToList();

            return searchResults.ToList();
        }
        public List<WarehouseProduct> WarehouseProductSearchP(int prodId)
        {
            var searchResults = inventoryContext.Warehouses_Products
                .Where(e => e.Product_Id == prodId)
                .ToList();

            return searchResults.ToList();
        }
        #endregion
    }
}
