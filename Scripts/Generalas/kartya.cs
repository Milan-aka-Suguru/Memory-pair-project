using Godot;
using System.Data;
public partial class kartya : Node
{
	private MySQLManager dbManager;
	private Helloworld db;
	public override void _Ready()
	{
		dbManager = new MySQLManager("localhost", "kartyak", "root", "");
		Godot.GD.Print(dbManager.Connect());
		Godot.GD.Print("anyád");
		//// Example query
		//DataTable result = dbManager.ExecuteQuery("SELECT * FROM kartyak");
		//foreach (DataRow row in result.Rows)
		//{
			//foreach (var item in row.ItemArray)
			//{
				//GD.Print(item.ToString());
			//}
		//}

		dbManager.Disconnect();
	}
}
