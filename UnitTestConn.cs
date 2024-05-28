using Npgsql;

namespace Tests1
{
    [TestClass]
    public class UnitTestConn
    {
        [TestMethod]
    public void TestConnection_Passed()
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
        npgsqlConnection.Open();
    }

    [TestMethod]
    public void TestConnection_Failed()
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection($"Server=localhost_;Port=5432;User ID=postgres;Password=670670;Database=curs;");
        npgsqlConnection.Open();
    }
    }
}