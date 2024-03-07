using System.Data.SqlClient;
using DatabaseProject.Entities;

namespace DatabaseProject;

public class ProductDAO
{
    public void Save(Product product)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();

        SqlCommand command = null;

        if (product.ID < 1)
        {
            using var sqlCommand = command = new SqlCommand("INSERT INTO product (Name, Price) VALUES (@Name, @Price)", conn);
            command.Parameters.Add(new SqlParameter("@Name", product.Name));
            command.Parameters.Add(new SqlParameter("@Price", product.Price));
            command.ExecuteNonQuery();
            //zjistim id posledniho vlozeneho zaznamu
            command.CommandText = "Select @@Identity";
            product.ID = Convert.ToInt32(command.ExecuteScalar());
        }
        else
        {
            using (command = new SqlCommand("UPDATE Osoby SET jmeno = @jmeno, prijmeni = @prijmeni " +
                                            "WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", product.ID));
                command.Parameters.Add(new SqlParameter("@Name", product.Name));
                command.Parameters.Add(new SqlParameter("@Price", product.Price));
                command.ExecuteNonQuery();
            }
        }
    }
}