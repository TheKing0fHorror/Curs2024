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
    public class UnitTestUsers
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
        NpgsqlCommand npgsqlCommand;
        NpgsqlDataAdapter npgsqlAdapter;
        public DataTable datatable;

        [TestMethod]
        public void DeleteUser()
        {
            string query = "DELETE FROM  scheme.users WHERE userid=  (?)";
            npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
            npgsqlCommand.Parameters.Add("?");
            npgsqlConnection.Open();
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close();
        }
        [TestMethod]
        public void UpdateUsser()
        {
            string query = "UPDATE scheme.users SET date_password=(?) WHERE userid=  (?)";
            npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
            npgsqlCommand.Parameters.Add("?");
            npgsqlCommand.Parameters.Add("?");
            npgsqlConnection.Open();
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close();
        }
        string GetData(string text)
        {
            string query = text;
            npgsqlAdapter = new NpgsqlDataAdapter(query, npgsqlConnection);
            npgsqlConnection.Open();
            datatable = new System.Data.DataTable();
            npgsqlAdapter.Fill(datatable);
            npgsqlConnection.Close();
            return datatable.Rows[0]["userid"].ToString();
        }
        [TestMethod]
        public void FalseDeleteUser()
        {
            string query = "DELETE FROM  scheme.users WHERE userid=  (?)";
            npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
            npgsqlCommand.Parameters.Add("?");
            npgsqlConnection.Open();
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close();
            Assert.AreEqual($"237", GetData($"select userid from scheme.users where userid={237}").ToString());
        }

    }
}
