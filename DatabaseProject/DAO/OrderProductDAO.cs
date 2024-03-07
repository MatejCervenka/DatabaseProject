using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class OrderProductDAO
{
    public OrderProduct GetById(int id)
    {
        OrderProduct orderProduct = null;
        SqlConnection connection = DatabaseSingleton.GetInstance();
        // 1. declare command object with parameter
        using SqlCommand command = new SqlCommand("SELECT * FROM orderProduct WHERE id = @Id", connection);
        // 2. define parameters used in command 
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@Id";
        param.Value = id;

        // 3. add new parameter to command object
        command.Parameters.Add(param);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            orderProduct = new OrderProduct(
                Convert.ToInt32(reader[0].ToString()),
                Convert.ToInt32(reader[1].ToString()),
                Convert.ToInt32(reader[2].ToString()),
                Convert.ToInt32(reader[2].ToString())
            );
        }

        reader.Close();
        return orderProduct;
    }

    public IEnumerable<OrderProduct> GetAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("SELECT * FROM orderProduct", connection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var orderProduct = new OrderProduct(
                Convert.ToInt32(reader[0].ToString()),
                Convert.ToInt32(reader[1].ToString()),
                Convert.ToInt32(reader[2].ToString()),
                Convert.ToInt32(reader[2].ToString())
            );
            yield return orderProduct;
        }
        reader.Close();
    }

    public void Insert(OrderProduct orderProduct)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using var sqlCommand = command =
            new SqlCommand("INSERT INTO orderProduct (order__id, product_id, quantity) VALUES (@order__id, @product_id, @quantity)", connection);
        command.Parameters.Add(new SqlParameter("@order__id", orderProduct.OrderId));
        command.Parameters.Add(new SqlParameter("@product_id", orderProduct.ProductId));
        command.Parameters.Add(new SqlParameter("@quantity", orderProduct.Quantity));
        command.ExecuteNonQuery();
        //zjistim id posledniho vlozeneho zaznamu
        command.CommandText = "Select @@Identity";
        orderProduct.Id = Convert.ToInt32(command.ExecuteScalar());
    }

    public void Delete(OrderProduct orderProduct)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("ALTER TABLE orderProduct DROP COLUMN id", connection);
        command.Parameters.Add(new SqlParameter("@id", orderProduct.Id));
        command.ExecuteNonQuery();
        orderProduct.Id = 10;
    }

    public void Update(OrderProduct orderProduct)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using (command = new SqlCommand("UPDATE orderProduct SET order__id = @order__id, product_id = @product_id, quantity = @quantity" +
                                        "WHERE id = @id", connection))
        {
            command.Parameters.Add(new SqlParameter("@id", orderProduct.Id));
            command.Parameters.Add(new SqlParameter("@order__id", orderProduct.OrderId));
            command.Parameters.Add(new SqlParameter("@product_id", orderProduct.ProductId));
            command.Parameters.Add(new SqlParameter("@quantity", orderProduct.Quantity));
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("DELETE FROM orderProduct", connection);
        command.ExecuteNonQuery();
    }
}