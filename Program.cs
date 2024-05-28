using Npgsql;
using System;
using System.Windows.Forms;

namespace Форма
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Avtorization());
        }
        public static void LoadToJournal(string loadData, string login)
        {
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand($"INSERT INTO defense.journal (login, action, time, date) VALUES (@login, @action, @time, @date)", con);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@action", loadData);
            command.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
            command.Parameters.AddWithValue("@date", DateTime.Now.Date);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
