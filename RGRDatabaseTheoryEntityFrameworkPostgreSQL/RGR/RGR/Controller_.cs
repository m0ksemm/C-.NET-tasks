using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RGR;


namespace RGR
{
    internal class Controller_
    {
        InventoryContext bc = new InventoryContext();
        Model_ model = new Model_();
        View_ view = new View_();

        public void Show()
        {
            view.ShowAllProducts(model.GetAllProducts());
        }

        public void Run()
        {
            int choice = -1;
            while (choice != 0)
            {
                view.Menu();
                string t = Console.ReadLine();
                choice = t == "" ? 0 : Convert.ToInt32(t);

                if (choice == 0)
                    break;
                else if (choice == 1)
                {
                    int choice2 = -1;
                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());

                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllProducts(model.GetAllProducts());
                            view.Done();
                        }
                        else if (choice2 == 2)
                        {
                            int result = model.InputProduct(view.ProductInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 2)
                                view.ErrorMessage("You have entered the manufacturer which is not present\n  in table \"Manufacturer\". Add this manufacturer there firstly ");
                            else if (result == 3)
                                view.ErrorMessage("You have entered the category which is not present\n  in table \"Category\". Add this category there firstly ");
                        }

                        else if (choice2 == 3)
                        {
                            view.Message("Which product do you want to edit? (Choose Id)");
                            view.ShowAllProducts(model.GetAllProducts());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditProduct(view.ProductInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You have entered the manufacturer which is not present\n  in table \"Manufacturer\". Add this manufacturer there firstly ");
                            else if (result == 3)
                                view.ErrorMessage("You have entered the category which is not present\n  in table \"Category\". Add this category there firstly ");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of a product that you want to delete:");
                            view.ShowAllProducts(model.GetAllProducts());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteProduct(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5) 
                        {
                            view.ProductSearchMenu();
                            string t2 = Console.ReadLine();
                            int choice3 = t2 == "" ? 0 : Convert.ToInt32(t2);

                            if (choice3 == 1)
                            {
                                view.ShowAllProducts(model.ProductSearchName(view.ProductNameSearch()));
                                view.Done();
                            }
                            else if (choice3 == 2)
                            {
                                view.ShowAllProducts(model.ProductSearchVendorCode(view.ProductSearchVendorCode()));
                                view.Done();
                            }
                            else if(choice3 == 3)
                            {
                                view.ShowAllProducts(model.ProductSearchSerialNumber(view.ProductSearchSerialNumber()));
                                view.Done();
                            }
                            else if(choice3 == 4)
                            {
                                view.Message("Enter minimum quantity:");
                                int min = Convert.ToInt32(Console.ReadLine());
                                view.Message("Enter maximum quantity:");
                                int max = Convert.ToInt32(Console.ReadLine());
                                view.ShowAllProducts(model.ProductSearchQuantity(min, max));
                                view.Done();
                            }
                        }
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }
                else if (choice == 2)
                {
                    int choice2 = -1;

                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());
                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllCategories(model.GetAllCategories());
                            view.Done();
                        }
                        else if (choice2 == 2)
                        {
                            int result = model.InputCategory(view.CategoryInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("This category is already in the table! ");
                        }
                        else if (choice2 == 3)
                        {
                            view.Message("Which Category do you want to edit? (Choose Id)");
                            view.ShowAllCategories(model.GetAllCategories());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditCategory(view.CategoryInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("This category is already in the table!");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of the manufacturer that you want to delete:");
                            view.ShowAllCategories(model.GetAllCategories());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteCategory(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5) 
                        {
                            view.ShowAllCategories(model.CategorySearch(view.CategorySearch()));
                            view.Done();
                        }
                            
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }
                else if (choice == 3)
                {
                    int choice2 = -1;

                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());
                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllCities(model.GetAllCities());
                            view.Done();
                        }
                        else if (choice2 == 2)
                        {
                            int result = model.InputCity(view.CityInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("This city is already in the table! ");
                        }
                        else if (choice2 == 3)
                        {
                            view.Message("Which City do you want to edit? (Choose Id)");
                            view.ShowAllCities(model.GetAllCities());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditCity(view.CityInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("This city is already in the table!");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of the City that you want to delete:");
                            view.ShowAllCities(model.GetAllCities());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteCity(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5)
                        {
                            view.ShowAllCities(model.CitiesSearch(view.CitySearch()));
                            view.Done();
                        }
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }

                else if (choice == 4)
                {
                    int choice2 = -1;

                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());
                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllManufacturers(model.GetAllManufacturers());
                            view.Done();
                        }
                        else if (choice2 == 2) 
                        {
                            int result = model.InputManufacturer(view.ManufacturerInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("This manufacturer is already in the table! ");
                        }
                        else if (choice2 == 3)
                        {
                            view.Message("Which Manufacturer do you want to edit? (Choose Id)");
                            view.ShowAllManufacturers(model.GetAllManufacturers());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditManufacturer(view.ManufacturerInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("This manufacturer is already in the table!");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of the manufacturer that you want to delete:");
                            view.ShowAllManufacturers(model.GetAllManufacturers());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteManufacturer(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5)
                        {
                            view.ShowAllManufacturers(model.ManufacturerSearch(view.ManufacturerSearch()));
                            view.Done();
                        }
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }

                else if (choice == 5)
                {
                    int choice2 = -1;
                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());

                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllWarehouses(model.GetAllWarehouses());
                            view.Done();
                        }
                        else if (choice2 == 2)
                        {
                            int result = model.InputWarehouse(view.WarehouseInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 2)
                                view.ErrorMessage("You have entered the city which is not present\n  in table \"City\". Add this city there firstly ");
                        }

                        else if (choice2 == 3)
                        {
                            view.Message("Which warehouse do you want to edit? (Choose Id)");
                            view.ShowAllWarehouses(model.GetAllWarehouses());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditWarehouse(view.WarehouseInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You have entered the warehouse which is not present\n  in table \"Manufacturer\". Add this manufacturer there firstly ");
                            else if (result == 3)
                                view.ErrorMessage("You have entered the warehouse which is not present\n  in table \"Category\". Add this category there firstly ");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of a warehouse that you want to delete:");
                            view.ShowAllWarehouses(model.GetAllWarehouses());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteWarehouse(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5)
                        {
                            view.WarehouseSearchMenu();
                            string t2 = Console.ReadLine();
                            int choice3 = t2 == "" ? 0 : Convert.ToInt32(t2);

                            if (choice3 == 1)
                            {
                                view.ShowAllWarehouses(model.WarehouseSearchName(view.WarehouseNameSearch()));
                                view.Done();
                            }
                            else if (choice3 == 2)
                            {
                                view.Message("Enter minimum square area:");
                                double min = Convert.ToDouble(Console.ReadLine());
                                view.Message("Enter maximum square area:");
                                double max = Convert.ToDouble(Console.ReadLine());
                                view.ShowAllWarehouses(model.WarehouseSearchQuantity(min, max));
                                view.Done();
                            }
                            else if (choice3 == 3)
                            {
                                view.ShowAllWarehouses(model.WarehouseSearchAddress(view.WarehouseAddressSearch()));
                                view.Done();
                            }
                        }
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }
                else if (choice == 6)
                {
                    int choice2 = -1;
                    while (choice2 != 0)
                    {
                        view.TableMenu();
                        choice2 = Convert.ToInt32(Console.ReadLine());

                        if (choice2 == 0)
                            break;
                        else if (choice2 == 1)
                        {
                            view.ShowAllWarehousesProducts(model.GetAllWarehousesProducts());
                            view.Done();
                        }
                        else if (choice2 == 2)
                        {
                            int result = model.InputWarehouseProduct(view.WarehouseProductInput());
                            if (result == 1)
                                view.Done();
                            else if (result == 2)
                                view.ErrorMessage("You have entered the warehouse which is not present\n  in table \"Warhouse\". Add this manufacturer there firstly ");
                            else if (result == 3)
                                view.ErrorMessage("You have entered the product which is not present\n  in table \"Product\". Add this category there firstly ");
                        }
                        else if (choice2 == 3)
                        {
                            view.Message("Which row with warehouse and product do you want to edit? (Choose Id)");
                            view.ShowAllWarehousesProducts(model.GetAllWarehousesProducts());
                            int id = Convert.ToInt32(Console.ReadLine());

                            int result = model.EditWarehouseProduct(view.WarehouseProductInput(), id);
                            if (result == 1)
                                view.Done();
                            else if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You have entered the warehouse which is not present\n  in table \"Warehouse\". Add this manufacturer there firstly ");
                            else if (result == 3)
                                view.ErrorMessage("You have entered the product which is not present\n  in table \"Product\". Add this category there firstly ");
                        }
                        else if (choice2 == 4)
                        {
                            view.Message("Enter ID of a raw with warehouse and product that you want to delete:");
                            view.ShowAllWarehousesProducts(model.GetAllWarehousesProducts());
                            int id = Convert.ToInt32(Console.ReadLine());
                            int result = model.DeleteWarehouseProduct(id);
                            if (result == 0)
                                view.ErrorMessage("There is no such Id in this table. Try again ");
                            else if (result == 2)
                                view.ErrorMessage("You can not delete this row because it \n  has connections with the fields of oter tables ");
                            else view.Done();
                        }
                        else if (choice2 == 5) 
                        {

                            view.WarehouseProductSearchMenu();
                            string t2 = Console.ReadLine();
                            int choice3 = t2 == "" ? 0 : Convert.ToInt32(t2);

                            if (choice3 == 1)
                            {
                                view.ShowAllWarehousesProducts(model.WarehouseProductSearchW(view.WarehouseProductSearchW()));
                                view.Done();
                            }
                            else if (choice3 == 2)
                            {
                                view.ShowAllWarehousesProducts(model.WarehouseProductSearchP(view.WarehouseProductSearchP()));
                                view.Done();
                            }
                        }
                        else view.ErrorMessage("You have entered wrong value! ");
                    }
                }
            } 
        }
    }
}
