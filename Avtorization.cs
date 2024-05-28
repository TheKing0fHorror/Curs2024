using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Форма
{
    public partial class Avtorization : Form
    {
        NpgsqlConnection con;

        public Avtorization()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form form3 = new Registation();
            this.Hide();
            form3.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var adapter = new NpgsqlDataAdapter(new NpgsqlCommand("SELECT * FROM defense.avtorization", con));
            var dataset1 = new DataSet();
            adapter.Fill(dataset1, "avtorization");
            DataTable dt = dataset1.Tables[0];
            string password = "";
            short key = 0x00012;
            foreach (char s in textBox2.Text)
                password += (char)(s ^ key);
            bool check = false;
            foreach (DataRow item in dt.Rows)
            {
                if (item.ItemArray[0].ToString() == textBox1.Text & item.ItemArray[6].ToString() == password)
                {
                    check = true;
                    this.Hide();
                    List<string> showlist = new List<string>();
                    List<string> updetalist = new List<string>();
                    foreach (string s in item.ItemArray[7].ToString().Split())
                        showlist.Add(s);
                    foreach (string s in item.ItemArray[8].ToString().Split())
                        updetalist.Add(s);
                    MainForm form1 = new MainForm(showlist, updetalist, textBox1.Text);
                    if (item.ItemArray[5].ToString() == "Админ")
                        form1.Admin();
                    Program.LoadToJournal($"Вход пользователя", textBox1.Text);
                    form1.ShowDialog();
                    this.Close();
                }
                else check = false;
            }
            if (!check)
                MessageBox.Show("Неправильно введен логин или пароль.", "Ошибка ввода");
        }
    }
}
