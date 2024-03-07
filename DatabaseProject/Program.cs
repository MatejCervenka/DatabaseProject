using DatabaseProject.Entities;

namespace DatabaseProject;

class Program
{
    static void Main(string[] args)
    {
        ProductDAO productDao = new ProductDAO();
        SupplierDAO supplierDao = new SupplierDAO();
        CustomerDAO customerDao = new CustomerDAO();
        OrderDAO orderDao = new OrderDAO();
        OrderProductDAO orderProductDao = new OrderProductDAO();

        /*
        Product product = new Product("rizek", 2.90);
        productDao.Insert(product);
        Console.WriteLine("Id of new student " + product.Id);
        
        Product product2 = new Product("smazak", 5.90);
        productDao.Insert(product);
        Console.WriteLine("Id of new student " + product.Id);*/
        
        /*productDao.DeleteAll();*/
        
        /*dao.Delete(product);*/

        foreach (var s in productDao.GetAll())
        {
            Console.WriteLine(s);
        }
        
        /*
        Product product = new Product("rizek", 2.90);
        productDao.Insert(product);
        Console.WriteLine("Id of new student " + product.Id);

        Product product2 = new Product("smazak", 5.90);
        productDao.Insert(product);
        Console.WriteLine("Id of new student " + product.Id);*/
        
        /*productDao.DeleteAll();*/
        
        /*dao.Delete(product);*/
        
        
    }
}