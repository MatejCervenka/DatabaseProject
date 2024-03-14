using System.Data.SqlClient;

namespace DatabaseProject.importCSV;

public class SupplierImport
{
    public void Import()
    {
        SqlConnection connection = DatabaseSingleton.GetInstance();
        
        const string csvFilePath = @"D:\SCHOOL\C3c\PV\DATABASE\DatabaseProject\DatabaseProject\csv\suppliers.csv";

        using var transaction = connection.BeginTransaction();
        try
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    using var command = new SqlCommand("INSERT INTO supplier (name_) VALUES (@name_)", connection, transaction);
                    command.Parameters.AddWithValue("@name_", values[1]);
                    command.ExecuteNonQuery();
                }
            }

            transaction.Commit();
            Console.WriteLine("Data inserted successfully.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Error inserting data: " + ex.Message);
        }
    }
}