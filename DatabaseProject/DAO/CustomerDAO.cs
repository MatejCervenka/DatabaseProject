using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class CustomerDAO
{
    public Customer? GetById(int id)
    {
        Customer customer = null;
        SqlConnection connection = DatabaseSingleton.GetInstance();
        // 1. declare command object with parameter
        using SqlCommand command = new SqlCommand("SELECT * FROM customer WHERE id = @Id", connection);
        // 2. define parameters used in command 
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@Id";
        param.Value = id;

        // 3. add new parameter to command object
        command.Parameters.Add(param);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            customer = new Customer(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString()
            );
        }
        reader.Close();
        return customer;
    }

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

    public void Insert(Customer customer)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using var sqlCommand = command = new SqlCommand("INSERT INTO customer (name_) VALUES (@name_)", connection);
        command.Parameters.Add(new SqlParameter("@name_", customer.Name));
        command.ExecuteNonQuery();
        //zjistim id posledniho vlozeneho zaznamu
        command.CommandText = "Select @@Identity";
        customer.Id = Convert.ToInt32(command.ExecuteScalar());
    }

    public void Delete(Customer customer)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("ALTER TABLE customer DROP COLUMN id", connection);
        command.Parameters.Add(new SqlParameter("@id", customer.Id));
        command.ExecuteNonQuery();
        customer.Id = 10;
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