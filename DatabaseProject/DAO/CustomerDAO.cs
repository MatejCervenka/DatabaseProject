using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class CustomerDAO : IDAO<Customer>
{

    public IEnumerable<Customer> GetAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("SELECT * FROM customer", connection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var customer = new Customer(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString()
            );
            yield return customer;
        }
        reader.Close();
    }

    public void Add(Customer customer)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();
        
        SqlCommand command = null;

        using var sqlCommand = command = new SqlCommand("INSERT INTO customer (name_) VALUES (@name_)", connection);
        command.Parameters.Add(new SqlParameter("@name_", customer.Name));
        command.ExecuteNonQuery();
        Console.WriteLine("Customer added");
    }

    public void Delete(int id)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();
        SqlCommand command = null;


        using (command = new SqlCommand("SELECT * FROM customer WHERE id = @customerId", connection))
        {
            command.Parameters.AddWithValue("@customerId", id);
        }

        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {

                Console.WriteLine("Customer is being removed");
            }
            else
            {
                Console.WriteLine("Customer with this id was not found.");
                return;
            }
        }

        SqlCommand deleteCmd = null;
        using (deleteCmd = new SqlCommand("DELETE FROM customer WHERE id = @ID", connection))
        {
            deleteCmd.Parameters.AddWithValue("@ID", id);
            deleteCmd.ExecuteNonQuery();
        }

        Console.WriteLine("Customer has been successfully removed");
    }

    public void Update(Customer customer)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using (command = new SqlCommand("UPDATE customer SET name_ = @name_" + "WHERE id = @id", connection))
        {
            command.Parameters.Add(new SqlParameter("@id", customer.Id));
            command.Parameters.Add(new SqlParameter("@name_", customer.Name));
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("DELETE FROM customer", connection);
        command.ExecuteNonQuery();
    }
}