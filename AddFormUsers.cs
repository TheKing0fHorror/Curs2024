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
    public partial class AddFormUsers : Form
    {
        string login;
        public AddFormUsers(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string values = "";
            foreach (var st in checkedListBox1.CheckedItems)
                values += st + " ";
            textBox4.Text = values;
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string values = "";
            foreach (var st in checkedListBox2.CheckedItems)
                values += st + " ";
            textBox4.Text = values;
            textBox5.Text = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text)
                || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("SELECT * FROM defense.avtorization", con);
            var adapter = new NpgsqlDataAdapter(command);
            var dataset1 = new DataSet();
            adapter.Fill(dataset1, "avtorization");
            DataTable dt = dataset1.Tables[0];
            foreach (DataRow item in dt.Rows)
                if (item.ItemArray[0].ToString() == textBox6.Text)
                {
                    MessageBox.Show("Этот логин уже используется, выберете другой", "ОШИБКА");
                    return;
                }
            command = new NpgsqlCommand("INSERT INTO defense.avtorization (lastname, firstname, secondname, databirth, post, login, password, tablesshow, tableupdate) VALUES (@lastname, @firstname, @secondname, @databirth, @post, @login, @password, @tablesshow, @tableupdate)", con);
            command.Parameters.AddWithValue("@lastname", textBox1.Text);
            command.Parameters.AddWithValue("@firstname", textBox2.Text);
            command.Parameters.AddWithValue("@secondname", textBox3.Text);
            DateTime datet = dateTimePicker1.Value;
            if (datet.Year > 2010)
            {
                MessageBox.Show("Вы слишком молоды, отказано в доступе!", "Ошибка");
                return;
            }
            command.Parameters.AddWithValue("@databirth", datet);
            command.Parameters.AddWithValue("@post", comboBox1.Text);
            command.Parameters.AddWithValue("@login", textBox6.Text);
            command.Parameters.AddWithValue("@tablesshow", textBox4.Text);
            command.Parameters.AddWithValue("@tableupdate", textBox5.Text);
            string password = "";
            short key = 0x00012;
            foreach (char s in textBox7.Text)
                password += (char)(s ^ key);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            Program.LoadToJournal("Добавлена запись в avtorization", login);

            this.Close();
        }
    }
}
