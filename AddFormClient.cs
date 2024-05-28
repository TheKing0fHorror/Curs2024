using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormClient : Form
    {
        DataSet dataset1;
        DataSet dataset2;
        string login;
        public AddFormClient(string login)
        {
            InitializeComponent();
            dataset1 = Open("street");
            var table1Data = dataset1.Tables["street"];
            var comboBoxDataSource1 = table1Data.AsEnumerable().Select(row => row.Field<string>("name")).ToList();
            comboBox1.DataSource = comboBoxDataSource1;

            dataset2 = Open("house");
            var table2Data = dataset2.Tables["house"];
            var comboBoxDataSource2 = table2Data.AsEnumerable().Select(row => row.Field<string>("number")).ToList();
            comboBox2.DataSource = comboBoxDataSource2;     
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox3.Text)
            || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            int phonenumb;
            if (textBox4.Text.Length != 11 && !int.TryParse(textBox4.Text, out phonenumb))
            {
                MessageBox.Show("Некорректный формат номера телефона", "Ошибка");
                return;
            }
            if (!int.TryParse(textBox5.Text, out phonenumb))
            {
                MessageBox.Show("Некорректный формат номера квартиры" +
                    "", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.client (number) VALUES (@number)", con);
            int nextID = 0;
            DataSet dt3 = Open("client");
            for (int j = 0; j < dt3.Tables["client"].Rows.Count; j++)
            {
                for (int i = 0; i < dt3.Tables["client"].Rows.Count; i++)
                    if (nextID != (int)dt3.Tables["client"].Rows[i].ItemArray[0])
                        continue;
                    else nextID++;
            }
            command.Parameters.AddWithValue("@number", nextID);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand($"UPDATE defense.client SET lastname = @lastname, firstname = @firstname, secondname = @secondname, phonenumb = @phonenumb,  street = @street, house = @house,  floor = @floor WHERE number = '{nextID}'", con);
            for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)
            {
                if (comboBox1.Text == dataset1.Tables[0].Rows[i].ItemArray[1].ToString())
                    command.Parameters.AddWithValue("@street", dataset1.Tables[0].Rows[i].ItemArray[0]);
            }
            for (int i = 0; i < dataset2.Tables[0].Rows.Count; i++)
            {
                if (comboBox2.Text == dataset2.Tables[0].Rows[i].ItemArray[0].ToString())
                    command.Parameters.AddWithValue("@house", dataset2.Tables[0].Rows[i].ItemArray[0]);
            }
            command.Parameters.AddWithValue("@lastname", textBox1.Text);
            command.Parameters.AddWithValue("@firstname", textBox2.Text);
            command.Parameters.AddWithValue("@secondname", textBox3.Text);
            command.Parameters.AddWithValue("@phonenumb", textBox4.Text);
            command.Parameters.AddWithValue("@floor", Convert.ToInt32(textBox5.Text));
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в client", login);
            this.Close();
        }
    }
}
