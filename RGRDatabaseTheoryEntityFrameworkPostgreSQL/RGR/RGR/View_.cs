using Microsoft.EntityFrameworkCore;
using RGR.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public class View_
    {
        #region Base 
        public void Menu()
        {
            Console.WriteLine("Inventarization of the warehouse\n ");
            Console.WriteLine("Choose the table: ");
            string[] tables = new string[6] { "Product", "Category", "City", "Manufacturer", "Warehouse", "Warehouse_product" };

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(i + 1 + ". " + tables[i]);
            }

            Console.WriteLine("Enter 0 to exit\n ");
        }
        public void TableMenu()
        {
            string[] options = new string[5] { "Show all", "Input", "Edit", "Delete", "Search" };
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" " + (i + 1).ToString() + ". " + options[i]);
            }

            Console.WriteLine("Enter 0 to exit\n ");
        }
        public void ErrorMessage(string message)
        {
            Console.WriteLine("  " + message);

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }
        public void Message(string message)
        {
            Console.WriteLine("  " + message);
        }
        public void Done()
        {
            Console.WriteLine("  Operation is successful! \n  Press any key to continue\n");
            Console.ReadKey();
        }
        #endregion
        #region Products
        public void ShowAllProducts(List<Prod> Products)
        {
            foreach (Prod p in Products)
            {
                Console.WriteLine("{0,3}|{1,25}|{2,10}|{3,10}|{4,10}|{5,7}|{6,15}|{7,15}", p.Id, p.Name, p.Vendor_code, p.Serial_number, Convert.ToString(p.Delivery_date), p.Quantity, p.Manufacturer, p.Category);
            }
        }
        public Prod ProductInput()
        {
            Prod prod = new Prod();
            Console.WriteLine("  Enter the data about new product: ");
            Console.Write("  Name:  ");
            prod.Name = Console.ReadLine();
            //
            Console.Write("  Vendor Code:  ");
            prod.Vendor_code = Console.ReadLine();
            //
            Console.Write("  Serial Number:  ");
            prod.Serial_number = Console.ReadLine();
            //
            Console.Write("  Delivery Date:  ");
            prod.Delivery_date = DateOnly.FromDateTime(Convert.ToDateTime(Console.ReadLine()));
            //
            Console.Write("  Quantity:  ");
            prod.Quantity = Convert.ToInt32(Console.ReadLine());
            //
            Console.Write("  Manufacturer:  ");
            prod.Manufacturer = Console.ReadLine();
            //
            Console.Write("  Category:  ");
            prod.Category = Console.ReadLine();
            //
            return prod;
        }
        public void ProductSearch()
        {
            Console.WriteLine("  SEARCH");

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }
        
        #endregion
        /// ////////////////////////////////////////////////////////// 
        /// ///////////////////////////////////////////////////////////////


        public void ShowAllManufacturers(List<Manuf> manufs)
        {
            foreach (Manuf m in manufs)
            {
                Console.WriteLine("{0,3}|{1,15}", m.Id, m.Name);
            }
        }
        public Manuf ManufacturerInput()
        {
            Manuf man = new Manuf();
            Console.WriteLine("  Enter the name of new manufacturer: ");
            Console.Write("  Name:  ");
            man.Name = Console.ReadLine();
           
            return man;
        }

        public void ManufacturerSearch()
        {
            Console.WriteLine("  SEARCH");

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }

        ////////////
        public void ShowAllCategories(List<Categ> cats)
        {
            foreach (Categ c in cats)
            {
                Console.WriteLine("{0,3}|{1,15}", c.Id, c.Name);
            }
        }
        public Categ CategoryInput()
        {
            Categ cat = new Categ();
            Console.WriteLine("  Enter the name of new category: ");
            Console.Write("  Name:  ");
            cat.Name = Console.ReadLine();

            return cat;
        }

        public void CategorySearch()
        {
            Console.WriteLine("  SEARCH");

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }



        ////////////
        public void ShowAllCities(List<Cities> cts)
        {
            foreach (Cities c in cts)
            {
                Console.WriteLine("{0,3}|{1,15}", c.Id, c.Name);
            }
        }
        public Cities CityInput()
        {
            Cities cts = new Cities();
            Console.WriteLine("  Enter the name of new city: ");
            Console.Write("  Name:  ");
            cts.Name = Console.ReadLine();

            return cts;
        }

        public void CitySearch()
        {
            Console.WriteLine("  SEARCH");

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }





        // // // // // // 


        public void ShowAllWarehouses(List<Warehouse> warehouses)
        {
            foreach (Warehouse w in warehouses)
            {
                Console.WriteLine("{0,3}|{1,15}|{2,15}|{3,5}|{4,25}", w.Id, w.Name, w.City, w.Square_area,  w.Address);
            }
        }
        public Warehouse WarehouseInput()
        {
            Warehouse w = new Warehouse();
            Console.WriteLine("  Enter the data about new warehouse: ");
            Console.Write("  Name:  ");
            w.Name = Console.ReadLine();
            //
            Console.Write("  City:  ");
            w.City = Console.ReadLine();
            //
            Console.Write("  Square area:  ");
            w.Square_area = Convert.ToDouble(Console.ReadLine());
            //
            Console.Write("  Address:  ");
            w.Address = Console.ReadLine();
            //

            return w;
        }
        public void WarehouseSearch()
        {
            Console.WriteLine("  SEARCH");

            Console.WriteLine("  Press any key to continue\n");
            Console.ReadKey();
        }
    }
}
