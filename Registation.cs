using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Форма
{
    public partial class Registation : Form
    {
        public Registation()
        {
            InitializeComponent();
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
            command = new NpgsqlCommand("INSERT INTO defense.avtorization (lastname, firstname, secondname, databirth, post, login, password) VALUES (@lastname, @firstname, @secondname, @databirth, @post, @login, @password)", con);
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
            string password = "";
            short key = 0x00012;
            foreach (char s in textBox7.Text)
                password += (char)(s ^ key);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            this.Hide();
            MainForm form1 = new MainForm(new List<string>(), new List<string>(), textBox6.Text);
            Program.LoadToJournal("Регистрация пользователя", textBox6.Text);
            form1.ShowDialog();
            this.Close();
        }
    }
}
