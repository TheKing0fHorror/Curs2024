using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormGo : Form
    {
        DataSet dataset1;
        string login;
        public AddFormGo(string login)
        {
            InitializeComponent();
            dataset1 = Open("deal");
            var table1Data = dataset1.Tables["deal"];
            var comboBoxDataSource1 = table1Data.AsEnumerable().Select(row => row.Field<Int32>("number")).ToList();
            comboBox1.DataSource = comboBoxDataSource1;
            this.login = login;
        }
        DataSet Open(string tableName)
        {
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var query = "SELECT * FROM defense." + tableName;
            var command = new NpgsqlCommand(query, con);
            var adapter = new NpgsqlDataAdapter(command);
            DataSet dt = new DataSet();
            adapter.Fill(dt, tableName);
            return dt;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label3.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                label3.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            if (checkBox1.Checked == false && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.go (number) VALUES (@number)", con);
            int nextID = 0;
            DataSet dt3 = Open("go");
            for (int j = 0; j < dt3.Tables["go"].Rows.Count; j++)
            {
                for (int i = 0; i < dt3.Tables["go"].Rows.Count; i++)
                    if (nextID != (int)dt3.Tables["go"].Rows[i].ItemArray[2])
                        continue;
                    else nextID++;
            }
            command.Parameters.AddWithValue("@number", nextID);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand($"UPDATE defense.go SET time=@time, date=@date, deal=@deal, doc=@doc, falses=@falses WHERE number = '{nextID}'", con);
            command.Parameters.AddWithValue("@time", dateTimePicker2.Value.TimeOfDay);
            DateTime dt = dateTimePicker1.Value;
            command.Parameters.AddWithValue("@date", dt);
            command.Parameters.AddWithValue("@deal", Convert.ToInt32(comboBox1.Text));
            command.Parameters.AddWithValue("@doc", textBox1.Text);
            command.Parameters.AddWithValue("@falses", checkBox1.Checked);
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в go", login);

            this.Close();
        }
    }
}
