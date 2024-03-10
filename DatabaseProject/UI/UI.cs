using DatabaseProject.Entities;

namespace DatabaseProject;

public class UI
{
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
                    var product = new Product();

                    Console.WriteLine("Enter a name of the product: ");
                    product.Name = Console.ReadLine();

                    Console.WriteLine("Enter price of the product: ");
                    product.Price = Convert.ToDouble(Console.ReadLine());

                    productDao.Add(product);
                    break;
                case "3":
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
                    var supplier = new Supplier();

                    Console.WriteLine("Enter a name for supplier:");
                    supplier.Name = Console.ReadLine();
                    
                    supplierDao.Add(supplier);   
                    break;
                case "5":
                    var customer = new Customer();

                    Console.WriteLine("Enter a name for customer:");
                    customer.Name = Console.ReadLine();
                    
                    customerDao.Add(customer);   
                    break;
                case "6":
                    foreach (var o in orderDao.GetAll())
                    {
                        Console.WriteLine(o);
                    }

                    Console.WriteLine("Enter id of order you want removed:");
                    string orderId = Console.ReadLine();
                    orderDao.Delete(Convert.ToInt32(orderId));
                    break;
                case "7":
                    foreach (var o in productDao.GetAll())
                    { 
                        Console.WriteLine(o);
                    }
                    
                    Console.WriteLine("Enter id of product you want removed:");
                    string productId = Console.ReadLine();
                    productDao.Delete(Convert.ToInt32(productId));
                    break;
                case "8":
                    foreach (var o in orderProductDao.GetAll())
                    {
                        Console.WriteLine(o);
                    }

                    Console.WriteLine("Enter id of order product you want removed:");
                    string orderProductId = Console.ReadLine();
                    orderProductDao.Delete(Convert.ToInt32(orderProductId));
                    break;
                case "9":
                    foreach (var o in supplierDao.GetAll())
                    {
                        Console.WriteLine(o);
                    }

                    Console.WriteLine("Enter id of supplier you want removed:");
                    string supplierId = Console.ReadLine();
                    orderProductDao.Delete(Convert.ToInt32(supplierId));
                    break;
                case "10":
                    foreach (var o in customerDao.GetAll())
                    {
                        Console.WriteLine(o);
                    }

                    Console.WriteLine("Enter id of order product you want removed:");
                    string customerId = Console.ReadLine();
                    orderProductDao.Delete(Convert.ToInt32(customerId));
                    break;
                case "11":
                    foreach (var s in orderDao.GetAll())
                    {
                        Console.WriteLine(s);
                    }
                    break;
                case "12":
                    foreach (var s in productDao.GetAll()) 
                    { 
                        Console.WriteLine(s);
                    }
                    break;
                case "13":
                    foreach (var s in orderProductDao.GetAll())
                    { 
                        Console.WriteLine(s);
                    }
                    break;
                case "14":
                    foreach (var s in supplierDao.GetAll())
                    { 
                        Console.WriteLine(s);
                    }
                    break;
                case "15":
                    foreach (var s in customerDao.GetAll())
                    { 
                        Console.WriteLine(s);
                    }
                    break;
                case "16":
                    string choiceDelOrders = "";
                    Console.WriteLine("Do you want to delete all orders? (yes/no)");
                    choiceDelOrders = Console.ReadLine();
                    if (choiceDelOrders == "yes")
                    {
                        orderDao.DeleteAll();
                    }
                    break; 
                case "17":
                    string choiceDelProducts = "";
                    Console.WriteLine("Do you want to delete all products? (yes/no)");
                    choiceDelProducts = Console.ReadLine();
                    if (choiceDelProducts == "yes")
                    {
                        productDao.DeleteAll();
                    }
                    break;
                case "18":
                    string choiceDelOrderProducts = "";
                    Console.WriteLine("Do you want to delete all ordered products? (yes/no)");
                    choiceDelProducts = Console.ReadLine();
                    if (choiceDelOrderProducts == "yes")
                    {
                        orderProductDao.DeleteAll();
                    }
                    break;
                case "19":
                    string choiceDelSuppliers = "";
                    Console.WriteLine("Do you want to delete all suppliers? (yes/no)");
                    choiceDelSuppliers = Console.ReadLine();
                    if (choiceDelSuppliers == "yes")
                    {
                        orderProductDao.DeleteAll();
                    }
                    break;
                case "20":
                    string choiceDelCustomers = "";
                    Console.WriteLine("Do you want to delete all customers? (yes/no)");
                    choiceDelCustomers = Console.ReadLine();
                    if (choiceDelCustomers == "yes")
                    {
                        orderProductDao.DeleteAll();
                    }
                    break;
                case "21":
                    Console.WriteLine("Quiting");
                    Environment.Exit(0);

                    break;
                default:
                    Console.WriteLine("Not valid option");
                    break;
            }

        } while (true);
    }
}