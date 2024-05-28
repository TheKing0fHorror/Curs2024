using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormDeal : Form
    {
        DataSet dataset1;
        DataSet dataset2;
        string login;

        public AddFormDeal(string login)
        {
            InitializeComponent();
            dataset1 = Open("client");
            var table1Data = dataset1.Tables["client"];
            var comboBoxDataSource1 = table1Data.AsEnumerable().Select(row => row.Field<string>("lastname")).ToList();
            comboBox1.DataSource = comboBoxDataSource1;

            dataset2 = Open("flat");
            var table2Data = dataset2.Tables["flat"];
            var comboBoxDataSource2 = table2Data.AsEnumerable().Select(row => row.Field<Int32?>("number")).ToList();
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
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата конца не может быть раньше начала", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.deal (number) VALUES (@number)", con);
            int nextID = 0;
            DataSet dt3 = Open("deal");
            for (int j = 0; j < dt3.Tables["deal"].Rows.Count; j++)
            {
                for (int i = 0; i < dt3.Tables["deal"].Rows.Count; i++)
                    if (nextID != (int)dt3.Tables["deal"].Rows[i].ItemArray[0])
                        continue;
                    else nextID++;
            }
            command.Parameters.AddWithValue("@number", nextID);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand($"UPDATE defense.deal SET begin = @begin,  pay = @pay, tax = @tax,  compens = @compens, client = @client,  flat = @flat, ends=@ends WHERE number = '{nextID}'", con);
            for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)
            {
                if (comboBox1.Text == dataset1.Tables[0].Rows[i].ItemArray[1].ToString())
                    command.Parameters.AddWithValue("@client", dataset1.Tables[0].Rows[i].ItemArray[0]);
            }
            for (int i = 0; i < dataset2.Tables[0].Rows.Count; i++)
            {
                if (comboBox2.Text == dataset2.Tables[0].Rows[i].ItemArray[3].ToString())
                    command.Parameters.AddWithValue("@flat", dataset2.Tables[0].Rows[i].ItemArray[2]);
            }
            DateTime dt1 = dateTimePicker1.Value;
            DateTime d21 = dateTimePicker2.Value;
            command.Parameters.AddWithValue("@begin", dt1);
            command.Parameters.AddWithValue("@ends", d21);
            command.Parameters.AddWithValue("@compens", Convert.ToDecimal(textBox4.Text));
            command.Parameters.AddWithValue("@pay", Convert.ToDecimal(textBox2.Text));
            command.Parameters.AddWithValue("@tax", Convert.ToDecimal(textBox3.Text));
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в deal", login);
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            decimal compens;
            if (!decimal.TryParse(textBox4.Text, out compens))
            {
                MessageBox.Show("Введите число", "Ошибка");
                return;
            }
            DateTime dtstart = dateTimePicker1.Value;
            DateTime dtend = dateTimePicker2.Value;
            if (dtend < dtstart)
                return;
            textBox2.Text = (Convert.ToDecimal(textBox4.Text) / (dtend-dtstart).Days*30).ToString();
            textBox3.Text = (Convert.ToDecimal(textBox2.Text) / 2).ToString();

        }
    }
}
