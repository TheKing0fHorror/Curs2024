using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormStreet : Form
    {
        int nextID = 0;
        DataSet dataset1;
        string login;
        public AddFormStreet(DataSet dt, string login)
        {
            InitializeComponent();
            this.dataset1 = dt;
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.street (id, name, pris, queue) VALUES (@id, @name, @pris, @queue)", con);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@pris", textBox2.Text);
            command.Parameters.AddWithValue("@queue", checkBox1.Checked);
            for (int j = 0; j < dataset1.Tables["Street"].Rows.Count; j++)
            {
                for (int i = 0; i < dataset1.Tables["Street"].Rows.Count; i++)
                    if (nextID != (int)dataset1.Tables["Street"].Rows[i].ItemArray[0])
                        continue;
                    else nextID++;
            }
            command.Parameters.AddWithValue("@id", nextID);
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в street", login);

            this.Close();
        }
    }
}
