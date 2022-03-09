using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "...";
string dogName = "Idefix";

using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", sqlConnection))
    {
        //
        // Add new SqlParameter to the command.
        //
        command.Parameters.Add(new SqlParameter("Name", dogName));

        //
        // Read in the SELECT results.
        //
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int weight = reader.GetInt32(0);
            string name = reader.GetString(1);
            string breed = reader.GetString(2);
            Console.WriteLine("Weight = {0}, Name = {1}, Breed = {2}", weight, name, breed);
        }
    }





    using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", sqlConnection))
    {
        //
        // Add new SqlParameter to the command.
        //
        command.Parameters.Add(new SqlParameter("Name", dogName));

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);


        DataRow currentRow = dt.Rows[0];
        int id = Convert.ToInt32(currentRow["Id"]);
        
        //dt.Columns
        //dt.Rows

       //SqlDAtaAdapter kann auch ein Schema zurück geben. 

    }
} //Verbindung wird hier abgebaut sql.Dispose()
