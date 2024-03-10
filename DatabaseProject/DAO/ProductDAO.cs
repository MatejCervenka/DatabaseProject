using System.Data.SqlClient;
using System.Globalization;
using CsvHelper;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class ProductDAO : IDAO<Product>
{
    
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

    public void DeleteAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("DELETE FROM product", connection);
        command.ExecuteNonQuery();
    }

    /*static void ImportDataFromCsv(SqlConnection connection, string filePath, string tableName, Action<Product> insertMethod)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Configuration.HasHeaderRecord = true;
            csv.Read();
            csv.ReadHeader();

            if (csv.Context.HeaderRecord.Contains(tableName))
            {
                // Read data only for the specified table
                var records = csv.GetRecords<Product>().ToList();
                foreach (var record in records)
                {
                    insertMethod(record);
                }
            }
        }
    }

    static List<Product> ReadCsvFile(string filePath, string tableName)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Configuration.HasHeaderRecord = true;
            csv.Read();
            csv.ReadHeader();

            if (csv.Context.HeaderRecord.Contains(tableName))
            {
                // Read data only for the specified table
                return csv.GetRecords<Product>().ToList();
            }

            return new List<Product>();
        }
    }*/
}