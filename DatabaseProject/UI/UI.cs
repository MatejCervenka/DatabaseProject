using DatabaseProject.DAO;
using DatabaseProject.Entities;

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
                        // Removes an order from the database.
                        foreach (var o in orderDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of order you want removed:");
                        string orderId = Console.ReadLine();
                        orderDao.Delete(Convert.ToInt32(orderId));
                        break;
                    case "7":
                        // Remove a product from the database.
                        foreach (var o in productDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of product you want removed:");
                        string productId = Console.ReadLine();
                        productDao.Delete(Convert.ToInt32(productId));
                        break;

                    case "8":
                        // Remove an ordered product from the database.
                        foreach (var o in orderProductDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of order product you want removed:");
                        string orderProductId = Console.ReadLine();
                        orderProductDao.Delete(Convert.ToInt32(orderProductId));
                        break;

                    case "9":
                        // Remove a supplier from the database.
                        foreach (var o in supplierDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of supplier you want removed:");
                        string supplierId = Console.ReadLine();
                        supplierDao.Delete(Convert.ToInt32(supplierId));
                        break;

                    case "10":
                        // Remove a customer from the database.
                        foreach (var o in customerDao.GetAll())
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("Enter id of customer you want removed:");
                        string customerId = Console.ReadLine();
                        customerDao.Delete(Convert.ToInt32(customerId));
                        break;

                    case "11":
                        // Display all orders in the database.
                        foreach (var s in orderDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "12":
                        // Display all products in the database.
                        foreach (var s in productDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "13":
                        // Display all ordered products in the database.
                        foreach (var s in orderProductDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "14":
                        // Display all suppliers in the database.
                        foreach (var s in supplierDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "15":
                        // Display all customers in the database.
                        foreach (var s in customerDao.GetAll())
                        {
                            Console.WriteLine(s);
                        }
                        break;

                    case "16":
                        // Delete all orders from the database based on user confirmation.
                        string choiceDelOrders = "";
                        Console.WriteLine("Do you want to delete all orders? (yes/no)");
                        choiceDelOrders = Console.ReadLine();
                        if (choiceDelOrders == "yes")
                        {
                            orderDao.DeleteAll();
                        }
                        break;

                    case "17":
                        // Delete all products from the database based on user confirmation.
                        string choiceDelProducts = "";
                        Console.WriteLine("Do you want to delete all products? (yes/no)");
                        choiceDelProducts = Console.ReadLine();
                        if (choiceDelProducts == "yes")
                        {
                            productDao.DeleteAll();
                        }
                        break;

                    case "18":
                        // Delete all ordered products from the database based on user confirmation.
                        string choiceDelOrderProducts = "";
                        Console.WriteLine("Do you want to delete all ordered products? (yes/no)");
                        choiceDelOrderProducts = Console.ReadLine();
                        if (choiceDelOrderProducts == "yes")
                        {
                            orderProductDao.DeleteAll();
                        }
                        break;

                    case "19":
                        // Delete all suppliers from the database based on user confirmation.
                        string choiceDelSuppliers = "";
                        Console.WriteLine("Do you want to delete all suppliers? (yes/no)");
                        choiceDelSuppliers = Console.ReadLine();
                        if (choiceDelSuppliers == "yes")
                        {
                            supplierDao.DeleteAll();
                        }
                        break;

                    case "20":
                        // Delete all customers from the database based on user confirmation.
                        string choiceDelCustomers = "";
                        Console.WriteLine("Do you want to delete all customers? (yes/no)");
                        choiceDelCustomers = Console.ReadLine();
                        if (choiceDelCustomers == "yes")
                        {
                            customerDao.DeleteAll();
                        }
                        break;
                    case "21":
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