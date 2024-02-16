using System;
using System.Data;
using MySql.Data.MySqlClient;
using Godot;
public class MySQLManager
{
	private string connectionString;
	private MySqlConnection connection;

	public MySQLManager(string server, string database, string username, string password)
	{
		connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
		connection = new MySqlConnection(connectionString);
	}

	public string Connect()
	{
		try
		{
			connection.Open();
			return("Connected to MySQL database.");
		}
		catch (Exception ex)
		{
			return("Error: " + ex.Message);
		}
	}

	public DataTable ExecuteQuery(string query)
	{
		DataTable dataTable = new DataTable();
		try
		{
			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataAdapter adapter = new MySqlDataAdapter(command);
			adapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error executing query: " + ex.Message);
		}
		return dataTable;
	}

	public void Disconnect()
	{
		if (connection != null && connection.State != ConnectionState.Closed)
		{
			connection.Close();
			Console.WriteLine("Disconnected from MySQL database.");
		}
	}
}
