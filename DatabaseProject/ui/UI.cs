using DatabaseProject.DAO;
using DatabaseProject.Entities;
using DatabaseProject.importCSV;

namespace DatabaseProject
{
    /// <summary>
    /// Represents the user interface (UI) for interacting with the database.
    /// </summary>
    public class UI
    {
        /// <summary>
        /// Starts the user interface, allowing users to perform various actions on the database.
        /// </summary>
        public static void Start()
        {
            var menu = new UIMenu();
            var customerDao = new CustomerDAO();
            var orderDao = new OrderDAO();
            var orderProductDao = new OrderProductDAO();
            var productDao = new ProductDAO();
            var supplierDao = new SupplierDAO();
            var customerImport = new CustomerImport();
            var supplierImport = new SupplierImport();

            do
            {
                menu.Print();
                Console.WriteLine("Choose:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Add a new order to the database.
                        var order = new Order();

                        Console.WriteLine("Enter a date and time (yyyy-MM-dd):");
                        order.OrderDate = Convert.ToDateTime(Console.ReadLine());
                        if (order.OrderDate > DateTime.Now)
                        {
                            order.IsShipped = false;
                        }
                        else
                        {
                            order.IsShipped = true;
                        }

                        orderDao.Add(order);
                        break;
                    case "2":
                        // Add a new product to the database.
                        var product = new Product();

                        Console.WriteLine("Enter a name of the product: ");
                        product.Name = Console.ReadLine();

                        Console.WriteLine("Enter price of the product: ");
                        product.Price = Convert.ToDouble(Console.ReadLine());

                        productDao.Add(product);
                        break;
                    case "3":
                        /// Adds a new ordered product to the database.
                        var orderProduct = new OrderProduct();

                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Enter id of order: ");
                        orderProduct.OrderId = Convert.ToInt32(Console.ReadLine());

                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Enter id of product: ");
                        orderProduct.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter quantity of product on order: ");
                        orderProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                        orderProductDao.Add(orderProduct);
                        break;
                    case "4":
                        // Adds a new supplier to the database.
                        var supplier = new Supplier();

                        Console.WriteLine("Enter a name for supplier:");
                        supplier.Name = Console.ReadLine();

                        supplierDao.Add(supplier);
                        break;
                    case "5":
                        // Adds a new customer to the database.
                        var customer = new Customer();

                        Console.WriteLine("Enter a name for customer:");
                        customer.Name = Console.ReadLine();

                        customerDao.Add(customer);
                        break;
                    case "6":
                        // Updates an order
                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter the id of the order you want to update:");
                        if (int.TryParse(Console.ReadLine(), out var orderId))
                        {

                            Order orderToUpdate = orderDao.GetById(orderId);
                            if (orderToUpdate != null)
                            {
                                Console.WriteLine("Current Order Details:");
                                Console.WriteLine(orderToUpdate);

                                Console.WriteLine("Enter new order date (yyyy-MM-dd HH:mm:ss):");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newOrderDate))
                                {
                                    orderToUpdate.OrderDate = newOrderDate;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format. Order date not updated.");
                                }

                                Console.WriteLine("Is the order shipped? (true/false):");
                                if (bool.TryParse(Console.ReadLine(), out bool isShipped))
                                {
                                    orderToUpdate.IsShipped = isShipped;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Order shipping status not updated.");
                                }

                                orderDao.Update(orderToUpdate);
                            }
                        }
                        break;
                    case "7":
                        // Updates a product
                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter the id of the product you want to update:");
                        if (int.TryParse(Console.ReadLine(), out var productId))
                        {

                            Product productToUpdate = productDao.GetById(productId);
                            if (productToUpdate != null)
                            {
                                Console.WriteLine($"Current Product Details: {productToUpdate}");
                                
                                Console.WriteLine("Enter new product name:");
                                string newName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newName))
                                {
                                    productToUpdate.Name = newName;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid name. Product name will remain unchanged.");
                                }

                                Console.WriteLine("Enter new product price:");
                                if (double.TryParse(Console.ReadLine(), out double newPrice))
                                {
                                    productToUpdate.Price = newPrice;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid price. Product price will remain unchanged.");
                                }
                                productDao.Update(productToUpdate);
                            }
                        }
                        break;
                    case "8":
                        // Updates an ordered product
                        foreach (var o in orderProductDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter the id of the ordered product you want to update:");
                        if (int.TryParse(Console.ReadLine(), out var orderProductId))
                        {

                            OrderProduct orderProductToUpdate = orderProductDao.GetById(orderProductId);
                            if (orderProductToUpdate != null)
                            {
                                Console.WriteLine($"Current Ordered Product Details: {orderProductToUpdate}");
                                
                                foreach (var o in orderDao.GetAll())
                                {
                                    Console.WriteLine(o);
                                }

                                Console.WriteLine("Enter new Order ID:");
                                orderProductToUpdate.OrderId = Convert.ToInt32(Console.ReadLine());

                                foreach (var o in productDao.GetAll())
                                {
                                    Console.WriteLine(o);
                                }

                                Console.WriteLine("Enter new Product ID:");
                                orderProductToUpdate.ProductId = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter new Quantity: ");
                                orderProductToUpdate.Quantity = Convert.ToInt32(Console.ReadLine());
                                
                                orderProductDao.Update(orderProductToUpdate);
                            }
                        }
                        break;
                    case "9":
                        // Updates a supplier
                        foreach (var o in supplierDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter the id of the supplier you want to update:");
                        if (int.TryParse(Console.ReadLine(), out var supplierId))
                        {

                            Supplier supplierToUpdate = supplierDao.GetById(supplierId);
                            if (supplierToUpdate != null)
                            {
                                Console.WriteLine($"Current Supplier Details: {supplierToUpdate}");
                                
                                Console.WriteLine("Enter new supplier name:");
                                string newName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newName))
                                {
                                    supplierToUpdate.Name = newName;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid name. Supplier name will remain unchanged.");
                                }
                                supplierDao.Update(supplierToUpdate);
                            }
                        }
                        break;
                    case "10":
                        // Updates a customer
                        foreach (var o in customerDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter the id of the customer you want to update:");
                        if (int.TryParse(Console.ReadLine(), out var customerId))
                        {

                            Customer customerToUpdate = customerDao.GetById(customerId);
                            if (customerToUpdate != null)
                            {
                                Console.WriteLine($"Current Customer Details: {customerToUpdate}");
                                
                                Console.WriteLine("Enter new customer name:");
                                string newName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newName))
                                {
                                    customerToUpdate.Name = newName;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid name. Customer name will remain unchanged.");
                                }
                                customerDao.Update(customerToUpdate);
                            }
                        }
                        break;
                    case "11":
                        // Removes an order from the database.
                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of order you want removed:");
                        string orderID = Console.ReadLine();
                        orderDao.Delete(Convert.ToInt32(orderID));
                        break;
                    case "12":
                        // Remove a product from the database.
                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of product you want removed:");
                        string productID = Console.ReadLine();
                        productDao.Delete(Convert.ToInt32(productID));
                        break;

                    case "13":
                        // Remove an ordered product from the database.
                        foreach (var o in orderProductDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of order product you want removed:");
                        string orderProductID = Console.ReadLine();
                        orderProductDao.Delete(Convert.ToInt32(orderProductID));
                        break;

                    case "14":
                        // Remove a supplier from the database.
                        foreach (var o in supplierDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of supplier you want removed:");
                        string supplierID = Console.ReadLine();
                        supplierDao.Delete(Convert.ToInt32(supplierID));
                        break;

                    case "15":
                        // Remove a customer from the database.
                        foreach (var o in customerDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of customer you want removed:");
                        string customerID = Console.ReadLine();
                        customerDao.Delete(Convert.ToInt32(customerID));
                        break;

                    case "16":
                        // Display all orders in the database.
                        foreach (var s in orderDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "17":
                        // Display all products in the database.
                        foreach (var s in productDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "18":
                        // Display all ordered products in the database.
                        foreach (var s in orderProductDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "19":
                        // Display all suppliers in the database.
                        foreach (var s in supplierDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "20":
                        // Display all customers in the database.
                        foreach (var s in customerDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "21":
                        // Delete all orders from the database based on user confirmation.
                        string choiceDelOrders = "";
                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Do you want to delete all orders? (yes/no)");
                        choiceDelOrders = Console.ReadLine();
                        if (choiceDelOrders == "yes")
                        {
                            orderDao.DeleteAll();
                        }
                        break;

                    case "22":
                        // Delete all products from the database based on user confirmation.
                        string choiceDelProducts = "";
                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Do you want to delete all products? (yes/no)");
                        choiceDelProducts = Console.ReadLine();
                        if (choiceDelProducts == "yes")
                        {
                            productDao.DeleteAll();
                        }
                        break;

                    case "23":
                        // Delete all ordered products from the database based on user confirmation.
                        string choiceDelOrderProducts = "";
                        foreach (var o in orderProductDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Do you want to delete all ordered products? (yes/no)");
                        choiceDelOrderProducts = Console.ReadLine();
                        if (choiceDelOrderProducts == "yes")
                        {
                            orderProductDao.DeleteAll();
                        }
                        break;

                    case "24":
                        // Delete all suppliers from the database based on user confirmation.
                        string choiceDelSuppliers = "";
                        foreach (var o in supplierDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Do you want to delete all suppliers? (yes/no)");
                        choiceDelSuppliers = Console.ReadLine();
                        if (choiceDelSuppliers == "yes")
                        {
                            supplierDao.DeleteAll();
                        }
                        break;

                    case "25":
                        // Delete all customers from the database based on user confirmation.
                        string choiceDelCustomers = "";
                        foreach (var o in customerDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("Do you want to delete all customers? (yes/no)");
                        choiceDelCustomers = Console.ReadLine();
                        if (choiceDelCustomers == "yes")
                        {
                            customerDao.DeleteAll();
                        }
                        break;
                    case "26":
                        // List all tables in the database
                        Console.WriteLine("All orders:");
                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("All products:");
                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        
                        Console.WriteLine("All ordered products:");
                        foreach (var o in orderProductDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        
                        Console.WriteLine("All suppliers:");
                        foreach (var o in supplierDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        
                        Console.WriteLine("All customers:");
                        foreach (var o in customerDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }
                        break;
                    case "27":
                        customerImport.Import();
                        break;
                    case "28":
                        supplierImport.Import();
                        break;
                    case "29":
                        // Quit the application.
                        Console.WriteLine("Quitting");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }
            } while (true);
        }
    }
}