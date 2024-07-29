using Oracle.ManagedDataAccess.Client;

using (OracleConnection conn = new OracleConnection("data source=abc;password=bac;user id=cda;"))
{
    try
    {
        using (OracleCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connection opened successfully.");

            cmd.CommandText = "select * from get_view";

            using (OracleDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                    Console.WriteLine(reader.GetValue(1));
            }
        }
    }
    catch (OracleException ex) { Console.WriteLine($"Oracle error occurred: {ex.Message}"); }
    catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
}

Console.ReadLine();
