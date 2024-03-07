using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class ProductDAO : IDAO<Product>
{
    public Product? GetById(int id)
    { 
        Product product = null;
        SqlConnection connection = DatabaseSingleton.GetInstance();
        // 1. declare command object with parameter
        using SqlCommand command = new SqlCommand("SELECT * FROM product WHERE id = @Id", connection);
        // 2. define parameters used in command 
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@Id";
        param.Value = id;

        // 3. add new parameter to command object
        command.Parameters.Add(param);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            product = new Product(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString(),
                Convert.ToDouble(reader[2].ToString())
            );
        }
        reader.Close();
        return product;
    }

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

    public void Insert(Product product)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using var sqlCommand = command = new SqlCommand("INSERT INTO product (name_, price) VALUES (@name_, @price)", connection);
        command.Parameters.Add(new SqlParameter("@name_", product.Name));
        command.Parameters.Add(new SqlParameter("@price", product.Price));
        command.ExecuteNonQuery();
        //zjistim id posledniho vlozeneho zaznamu
        command.CommandText = "Select @@Identity";
        product.Id = Convert.ToInt32(command.ExecuteScalar());
    }
    
    public void Delete(Product product)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("ALTER TABLE product DROP COLUMN id", connection);
        command.Parameters.Add(new SqlParameter("@id", product.Id));
        command.ExecuteNonQuery();
        product.Id = 10;
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

}