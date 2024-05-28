using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests1
{
[TestClass]
public class UnitTestHouse
{
    NpgsqlConnection npgsqlConnection = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
    NpgsqlCommand npgsqlCommand;
    NpgsqlDataAdapter npgsqlAdapter;
    public DataTable datatable;

    [TestMethod]
    public void TestHouse()
    {
        string query = "INSERT INTO  scheme.bank (/*bankid,*/bankname) VALUES (?)";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.Add("?");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
    }
    [TestMethod]
    public void TestInserting()
    {
        string query = "INSERT INTO  scheme.bank (/*bankid,*/bankname) VALUES (?)";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.Add("?");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"Осон", GetData($"select bankname from scheme.bank where bankid={25}", "bankname").ToString());

    }

    [TestMethod]
    public void TestSelectHouse()
    {
        string query = $"select bankname from scheme.bank where bankid={1}";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"Сбербанк", GetData($"select bankname from scheme.bank where bankid={1}", "bankname").ToString());

    }

    [TestMethod]
    public void TestDeleteHouse()
    {
        string query = "DELETE FROM  scheme.bank WHERE bankid=  (?)";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.Add("?");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
    }

    [TestMethod]
    public void TestFalseDeleteHouse()
    {
        string query = "DELETE FROM  scheme.bank WHERE bankid=  (?)";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.Add("?");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"40", GetData($"select bankid={40} from scheme.bank", "bankid").ToString());

    }

    [TestMethod]
    public void UpdateHouse()
    {
        string query = "UPDATE scheme.bank SET bankname=(?) WHERE bankid=  (?)";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.Add("?");
        npgsqlCommand.Parameters.Add("?");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
    }
    string GetData(string text, string column)
    {
        string query = text;
        npgsqlAdapter = new NpgsqlDataAdapter(query, npgsqlConnection);
        npgsqlConnection.Open();
        datatable = new System.Data.DataTable();
        npgsqlAdapter.Fill(datatable);
        npgsqlConnection.Close();
        return datatable.Rows[0][$"{column}"].ToString();
    }
}

}
