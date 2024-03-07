using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class SupplierDAO : IDAO<Supplier>
{
    public Supplier? GetById(int id)
    {
        Supplier supplier = null;
        SqlConnection connection = DatabaseSingleton.GetInstance();
        // 1. declare command object with parameter
        using SqlCommand command = new SqlCommand("SELECT * FROM supplier WHERE id = @Id", connection);
        // 2. define parameters used in command 
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@Id";
        param.Value = id;

        // 3. add new parameter to command object
        command.Parameters.Add(param);
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

    public void Insert(Supplier supplier)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        using var sqlCommand = command = new SqlCommand("INSERT INTO supplier (name_) VALUES (@name_)", connection);
        command.Parameters.Add(new SqlParameter("@name_", supplier.Name));
        command.ExecuteNonQuery();
        //zjistim id posledniho vlozeneho zaznamu
        command.CommandText = "Select @@Identity";
        supplier.Id = Convert.ToInt32(command.ExecuteScalar());
    }

    public void Delete(Supplier supplier)
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("ALTER TABLE product DROP COLUMN id", connection);
        command.Parameters.Add(new SqlParameter("@id", supplier.Id));
        command.ExecuteNonQuery();
        supplier.Id = 10;
    }

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

    public void DeleteAll()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();

        using SqlCommand command = new SqlCommand("DELETE FROM supplier", connection);
        command.ExecuteNonQuery();
    }
}