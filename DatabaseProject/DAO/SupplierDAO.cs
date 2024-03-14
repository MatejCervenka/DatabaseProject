using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject.DAO
{
    /// <summary>
    /// Data Access Object (DAO) for handling operations related to suppliers in the database.
    /// </summary>
    public class SupplierDAO : IDAO<Supplier>
    {
        /// <inheritdoc />
        public IEnumerable<Supplier> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("SELECT * FROM supplier", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var supplier = new Supplier(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString()
                );
                yield return supplier;
            }
            reader.Close();
        }

        /// <inheritdoc />
        public void Add(Supplier supplier)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("INSERT INTO supplier (name_) VALUES (@name_)", connection);
            command.Parameters.Add(new SqlParameter("@name_", supplier.Name));
            command.ExecuteNonQuery();
            Console.WriteLine("Supplier added");
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM supplier WHERE id = @supplierId", connection))
            {
                command.Parameters.AddWithValue("@supplierId", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Supplier is being removed");
                }
                else
                {
                    Console.WriteLine("Supplier with this id was not found.");
                    return;
                }
            }

            SqlCommand deleteCmd = null;
            using (deleteCmd = new SqlCommand("DELETE FROM supplier WHERE id = @ID", connection))
            {
                deleteCmd.Parameters.AddWithValue("@ID", id);
                deleteCmd.ExecuteNonQuery();
            }

            Console.WriteLine("Supplier has been successfully removed");
        }

        /// <inheritdoc />
        public void Update(Supplier supplier)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE supplier SET name_ = @name_" +
                                            "WHERE id = @id", connection))
            {
                command.Parameters.Add(new SqlParameter("@id", supplier.Id));
                command.Parameters.Add(new SqlParameter("@name_", supplier.Name));
                command.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM supplier", connection);
            command.ExecuteNonQuery();
        }

        public Supplier? GetById(int id)
        {
            Supplier supplier = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();
            using SqlCommand command = new SqlCommand("SELECT * FROM supplier WHERE id = @id", connection);

            command.Parameters.Add(new SqlParameter("@id", id));
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                supplier = new Supplier(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString()
                );
            }
            reader.Close();

            return supplier;
        }
    }
}
