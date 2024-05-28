using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormCommand : Form
    {
        DataSet dataSet;
        string login;
        public AddFormCommand(string login)
        {
            InitializeComponent();
            dataSet = Open("Go");
            var table2Data = dataSet.Tables[0];
            var comboBoxDataSource2 = table2Data.AsEnumerable().Select(row => row.Field<Int32>("number")).ToList();
            comboBox1.DataSource = comboBoxDataSource2;
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
        private void AddFormCommand_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.command (number) VALUES (@number)", con);
            int nextID = 0;
            DataSet dt3 = Open("go");
            for (int j = 0; j < dt3.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < dt3.Tables[0].Rows.Count; i++)
                    if (nextID != (int)dt3.Tables[0].Rows[i].ItemArray[2])
                        continue;
                    else nextID++;
            }
            command.Parameters.AddWithValue("@number", nextID);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand($"UPDATE defense.command SET chief = @chief, car = @car, go = @go WHERE number = '{nextID}'", con);
            command.Parameters.AddWithValue("@chief", textBox1.Text);
            command.Parameters.AddWithValue("@car", textBox2.Text);
            command.Parameters.AddWithValue("@go", Convert.ToInt32(comboBox1.Text));
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в command",login);
            this.Close();
        }
    }
}
