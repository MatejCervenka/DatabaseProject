using System.Data.SqlClient;
using System.Globalization;
using CsvHelper;
using DatabaseProject.Entities;

namespace DatabaseProject.DAO
{
    /// <summary>
    /// Data Access Object (DAO) for handling operations related to products in the database.
    /// </summary>
    public class ProductDAO : IDAO<Product>
    {
        /// <inheritdoc />
        public IEnumerable<Product> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("SELECT * FROM product", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString(),
                    Convert.ToDouble(reader[2].ToString())
                );
                yield return product;
            }
            reader.Close();
        }

        /// <inheritdoc />
        public void Add(Product product)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using var sqlCommand = command = new SqlCommand("INSERT INTO product (name_, price) VALUES (@name_, @price)", connection);
            command.Parameters.Add(new SqlParameter("@name_", product.Name));
            command.Parameters.Add(new SqlParameter("@price", product.Price));
            command.ExecuteNonQuery();
            Console.WriteLine("Product added");
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM orderProduct WHERE product_id = @productId", connection))
            {
                command.Parameters.AddWithValue("@productId", id);
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
            using (deleteCmd = new SqlCommand("DELETE FROM product WHERE id = @ID", connection))
            {
                deleteCmd.Parameters.AddWithValue("@ID", id);
                deleteCmd.ExecuteNonQuery();
            }

            Console.WriteLine("Product has been successfully removed");
        }

        /// <inheritdoc />
        public void Update(Product product)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE product SET name_ = @name_, price = @price " +
                                            "WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", product.Id));
                command.Parameters.Add(new SqlParameter("@name_", product.Name));
                command.Parameters.Add(new SqlParameter("@price", product.Price));
                command.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM product", connection);
            command.ExecuteNonQuery();
        }

        /* Uncomment and implement if needed
        /// <summary>
        /// Imports data from a CSV file into the product table using the specified insert method.
        /// </summary>
        /// <param name="connection">The SqlConnection instance.</param>
        /// <param name="filePath">The path to the CSV file.</param>
        /// <param name="tableName">The name of the table in the CSV file.</param>
        /// <param name="insertMethod">The method used to insert product records.</param>
        private static void ImportDataFromCsv(SqlConnection connection, string filePath, string tableName, Action<Product> insertMethod)
        {
            // Implementation goes here
        }

        /// <summary>
        /// Reads data from a CSV file for the specified table and returns a list of products.
        /// </summary>
        /// <param name="filePath">The path to the CSV file.</param>
        /// <param name="tableName">The name of the table in the CSV file.</param>
        /// <returns>A list of products read from the CSV file.</returns>
        private static List<Product> ReadCsvFile(string filePath, string tableName)
        {
            // Implementation goes here
            return new List<Product>();
        }
        */
    }
}
