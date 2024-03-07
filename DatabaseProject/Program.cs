using DatabaseProject.Entities;

namespace DatabaseProject;

class Program
{
    static void Main(string[] args)
    {
        var productDao = new ProductDAO();
        var supplierDao = new SupplierDAO();
        var customerDao = new CustomerDAO();
        var orderDao = new OrderDAO();
        var orderProductDao = new OrderProductDAO();

        Console.WriteLine("Products: ");
        // var product = new Product("rizek", 2.90);
        // productDao.Insert(product);
        // Console.WriteLine("Id of new product " + product.Id);
        //
        // var product2 = new Product("smazak", 5.90);
        // productDao.Insert(product2);
        // Console.WriteLine("Id of new product " + product2.Id);
        
        productDao.DeleteAll();
        
        /*productDao.Delete(product);*/

        foreach (var s in productDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("Suppliers: ");
        // var supplier = new Supplier("Jakub");
        // supplierDao.Insert(supplier);
        // Console.WriteLine("Id of new supplier " + supplier.Id);
        //
        // var supplier2 = new Supplier("Honza");
        // supplierDao.Insert(supplier2);
        // Console.WriteLine("Id of new supplier " + supplier2.Id);
        
        supplierDao.DeleteAll();
        
        /*supplierDao.Delete(supplier);*/
        
        foreach (var s in supplierDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("Customers: ");
        // var customer = new Customer("Tomáš");
        // customerDao.Insert(customer);
        // Console.WriteLine("Id of new customer " + customer.Id);
        //
        // var customer2 = new Customer("Lukáš");
        // customerDao.Insert(customer2);
        // Console.WriteLine("Id of new customer " + customer2.Id);
        
        customerDao.DeleteAll();
        
        /*customerDao.Delete(customer);*/
        
        foreach (var s in customerDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("Orders: ");
        // var order = new Order(new DateTime(2020, 1, 5), true);
        // orderDao.Insert(order);
        // Console.WriteLine("Id of new order " + order.Id);
        //
        // var order2 = new Order(new DateTime(2019, 12, 10), false);
        // orderDao.Insert(order2);
        // Console.WriteLine("Id of new order " + order2.Id);
        
        orderDao.DeleteAll();
        
        /*orderDao.Delete(order);*/
        
        foreach (var s in orderDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("OrderProducts: ");
        // var orderProduct = new OrderProduct(2, 13, 1);
        // orderProductDao.Insert(orderProduct);
        // Console.WriteLine("Id of new orderProduct " + orderProduct.Id);
        //
        // var orderProduct2 = new OrderProduct(1, 14, 2);
        // orderProductDao.Insert(orderProduct2);
        // Console.WriteLine("Id of new orderProduct " + orderProduct2.Id);
        
        orderProductDao.DeleteAll();
        
        /*orderProductDao.Delete(orderProduct);*/
        
        foreach (var s in orderProductDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
    }
}