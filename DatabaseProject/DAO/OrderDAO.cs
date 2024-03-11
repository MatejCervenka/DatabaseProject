using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject.DAO
{
    /// <summary>
    /// Data Access Object (DAO) for handling operations related to orders in the database.
    /// </summary>
    public class OrderDAO
    {
        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>An IEnumerable of Order objects representing all orders in the database.</returns>
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

        /// <summary>
        /// Adds a new order to the database.
        /// </summary>
        /// <param name="order">The Order object to be added to the database.</param>
        public void Add(Order order)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using var sqlCommand = command = new SqlCommand("INSERT INTO order_ (orderDate, isShipped) VALUES (@orderDate, @isShipped)", connection);
            command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
            command.Parameters.Add(new SqlParameter("@isShipped", order.IsShipped));
            command.ExecuteNonQuery();
            Console.WriteLine("Order added");
        }

        /// <summary>
        /// Deletes an order from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the order to be deleted.</param>
        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM order_ WHERE id = @orderId", connection))
            {
                command.Parameters.AddWithValue("@orderId", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Product is being used in orderProduct. Cannot delete.");
                    return;
                }
            }

            SqlCommand deleteCmd = null;
            using (deleteCmd = new SqlCommand("DELETE FROM order_ WHERE id = @ID"))
            {
                deleteCmd.Parameters.AddWithValue("@ID", id);
                deleteCmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order has been successfully removed");
        }

        /// <summary>
        /// Updates an existing order in the database.
        /// </summary>
        /// <param name="order">The Order object containing updated information.</param>
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

        /// <summary>
        /// Deletes all orders from the database.
        /// </summary>
        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM order_", connection);
            command.ExecuteNonQuery();
        }
    }
}
