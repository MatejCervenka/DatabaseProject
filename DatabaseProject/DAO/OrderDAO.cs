using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class OrderDAO
{
    public Order GetById(int id)
    {
        Order order = null;
        SqlConnection connection = DatabaseSingleton.GetInstance();
        // 1. declare command object with parameter
        using SqlCommand command = new SqlCommand("SELECT * FROM order_ WHERE id = @Id", connection);
        // 2. define parameters used in command 
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@Id";
        param.Value = id;

        // 3. add new parameter to command object
        command.Parameters.Add(param);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            order = new Order(
                Convert.ToInt32(reader[0].ToString()),
                Convert.ToDateTime(reader[1].ToString()),
                Convert.ToBoolean(reader[2].ToString())
            );
        }

        reader.Close();
        return order;
    }

    public IEnumerable<Order> GetAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("SELECT * FROM order_", connection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var order = new Order(
                Convert.ToInt32(reader[0].ToString()),
                Convert.ToDateTime(reader[1].ToString()),
                Convert.ToBoolean(reader[2].ToString())
            );
            yield return order;
        }

        reader.Close();
    }

    public void Insert(Order order)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using var sqlCommand = command = new SqlCommand("INSERT INTO order_ (orderDate, isShipped) VALUES (@orderDate, @isShipped)", connection);
        command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
        command.Parameters.Add(new SqlParameter("@isShipped", order.IsShipped));
        command.ExecuteNonQuery();
        //zjistim id posledniho vlozeneho zaznamu
        command.CommandText = "Select @@Identity";
        order.Id = Convert.ToInt32(command.ExecuteScalar());
    }

    public void Delete(Order order)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("ALTER TABLE order_ DROP COLUMN id", connection);
        command.Parameters.Add(new SqlParameter("@id", order.Id));
        command.ExecuteNonQuery();
        order.Id = 10;
    }

    public void Update(Order order)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using (command = new SqlCommand("UPDATE order_ SET orderDate = @orderDate, isShipped = @isShipped" +
                                        "WHERE id = @id", connection))
        {
            command.Parameters.Add(new SqlParameter("@id", order.Id));
            command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
            command.Parameters.Add(new SqlParameter("@isShipped", order.IsShipped));
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("DELETE FROM order_", connection);
        command.ExecuteNonQuery();
    }
}