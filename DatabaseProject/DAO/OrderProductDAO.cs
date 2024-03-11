using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject.DAO
{
    /// <summary>
    /// Data Access Object (DAO) for handling operations related to order products in the database.
    /// </summary>
    public class OrderProductDAO : IDAO<OrderProduct>
    {
        /// <inheritdoc />
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
                    Convert.ToInt32(reader[3].ToString())
                );
                yield return orderProduct;
            }
            reader.Close();
        }

        /// <inheritdoc />
        public void Add(OrderProduct orderProduct)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("INSERT INTO orderProduct (order__id, product_id, quantity) VALUES (@order__id, @product_id, @quantity)", connection);
            command.Parameters.Add(new SqlParameter("@order__id", orderProduct.OrderId));
            command.Parameters.Add(new SqlParameter("@product_id", orderProduct.ProductId));
            command.Parameters.Add(new SqlParameter("@quantity", orderProduct.Quantity));
            command.ExecuteNonQuery();
            Console.WriteLine("Order product added");
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM orderProduct WHERE id = @orderProductId", connection))
            {
                command.Parameters.AddWithValue("@orderProductId", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Order item is being removed");
                }
                else
                {
                    Console.WriteLine("Order item with this id was not found.");
                    return;
                }
            }

            SqlCommand deleteCmd = null;
            using (deleteCmd = new SqlCommand("DELETE FROM orderProduct WHERE id = @ID", connection))
            {
                deleteCmd.Parameters.AddWithValue("@ID", id);
                deleteCmd.ExecuteNonQuery();
            }

            Console.WriteLine("Order item has been successfully removed");
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM orderProduct", connection);
            command.ExecuteNonQuery();
        }
    }
}
