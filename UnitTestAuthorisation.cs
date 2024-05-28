using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Форма;

namespace Tests1
{
[TestClass]
public class UnitTestAuthorisation
{
    NpgsqlConnection npgsqlConnection = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
    NpgsqlCommand npgsqlCommand;
    NpgsqlDataAdapter npgsqlAdapter;
    public DataTable datatable;

    [TestMethod]
    public void TestAuthorization_Passed1()
    {
        string query = $"SELECT login = @Login, password = @Password FROM authorization WHERE lastname = Шиляев";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.AddWithValue("@Login", "admin");
        npgsqlCommand.Parameters.AddWithValue("@Password", "admin");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"admin123", GetUser($"SELECT password FROM authorization WHERE lastname = Шиляев").ToString());
    }

    [TestMethod]
    public void TestAuthorization_Failed1()
    {
        string query = $"SELECT login = @Login, password = @Password FROM authorization WHERE lastname = Шиляев";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.AddWithValue("@Login", "admin");
        npgsqlCommand.Parameters.AddWithValue("@Password", "admin123");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"admin321", GetUser($"SELECT login = @Login, password = @Password FROM authorization WHERE lastname = Шиляев").ToString());
    }

    [TestMethod]
    public void TestAuthorization_Passed2()
    {
        string query = $"SELECT login = @Login, password = @Password FROM authorization WHERE lastname = Шиляев";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.AddWithValue("@Login", "admin");
        npgsqlCommand.Parameters.AddWithValue("@Password", "admin123");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"admin", GetLogin($"SELECT login FROM users WHERE id = {2}").ToString());
    }

    [TestMethod]
    public void TestAuthorization_Failed2()
    {
        string query = $"SELECT login = @Login, password = @Password FROM authorization WHERE lastname = Шиляев";
        npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
        npgsqlCommand.Parameters.AddWithValue("@Login", "new_admin");
        npgsqlCommand.Parameters.AddWithValue("@Password", "adminqwe");
        npgsqlConnection.Open();
        npgsqlCommand.ExecuteNonQuery();
        npgsqlConnection.Close();
        Assert.AreEqual($"new_admin", GetLogin($"SELECT login FROM users WHERE id = {2}").ToString());
    }

    string GetLogin(string text)
    {
        string query = text;
        npgsqlAdapter = new NpgsqlDataAdapter(query, npgsqlConnection);
        npgsqlConnection.Open();
        datatable = new DataTable();
        npgsqlAdapter.Fill(datatable);
        npgsqlConnection.Close();
        return datatable.Rows[0]["login"].ToString();
    }

    string GetUser(string text)
    {
        string query = text;
        npgsqlAdapter = new NpgsqlDataAdapter(query, npgsqlConnection);
        npgsqlConnection.Open();
        datatable = new DataTable();
        npgsqlAdapter.Fill(datatable);
        npgsqlConnection.Close();
        return datatable.Rows[0]["password"].ToString();
    }
}
}
