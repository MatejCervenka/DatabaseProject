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
            
            if (!IsOrderValid(orderProduct.OrderId))
            {
                Console.WriteLine("Invalid Order ID. Order does not exist.");
                return;
            }
            
            if (!IsProductValid(orderProduct.ProductId))
            {
                Console.WriteLine("Invalid Product ID. Product does not exist.");
                return;
            }

            using var command = new SqlCommand("INSERT INTO orderProduct (order__id, product_id, quantity) VALUES (@order__id, @product_id, @quantity)", connection);
            command.Parameters.Add(new SqlParameter("@order__id", orderProduct.OrderId));
            command.Parameters.Add(new SqlParameter("@product_id", orderProduct.ProductId));
            command.Parameters.Add(new SqlParameter("@quantity", orderProduct.Quantity));
            command.ExecuteNonQuery();
            Console.WriteLine("Order product added");
        }

        // Method to check if the order ID is valid
        private bool IsOrderValid(int orderId)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            using var command = new SqlCommand("SELECT COUNT(*) FROM order_ WHERE id = @orderId", connection);
            command.Parameters.AddWithValue("@orderId", orderId);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        // Method to check if the product ID is valid
        private bool IsProductValid(int productId)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            using var command = new SqlCommand("SELECT COUNT(*) FROM product WHERE id = @productId", connection);
            command.Parameters.AddWithValue("@productId", productId);
            int count = (int)command.ExecuteScalar();
            return count > 0;
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

            if (!IsOrderValid(orderProduct.OrderId))
            {
                Console.WriteLine("Invalid Order ID. Order does not exist.");
                return;
            }
            
            if (!IsProductValid(orderProduct.ProductId))
            {
                Console.WriteLine("Invalid Product ID. Product does not exist.");
                return;
            }
            
            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE orderProduct SET order__id = @order__id, product_id = @product_id, quantity = @quantity " +
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

        public OrderProduct? GetById(int id)
        {
            OrderProduct orderProduct = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();
            using SqlCommand command = new SqlCommand("SELECT * FROM orderProduct WHERE id = @id", connection);

            command.Parameters.Add(new SqlParameter("@id", id));
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderProduct = new OrderProduct(
                    Convert.ToInt32(reader[0].ToString()),
                    Convert.ToInt32(reader[1].ToString()),
                    Convert.ToInt32(reader[2].ToString()),
                    Convert.ToInt32(reader[3].ToString())
                );
            }
            reader.Close();

            return orderProduct;
        }
    }
}
