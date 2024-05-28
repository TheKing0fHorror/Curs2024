using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormHouse : Form
    {
        DataSet dataset1;
        string login;
        public AddFormHouse(string login)
        {
            InitializeComponent();
            Open("street");
            var table1Data = dataset1.Tables["street"];
            var comboBoxDataSource1 = table1Data.AsEnumerable().Select(row => row.Field<string>("name")).ToList();
            comboBox4.DataSource = comboBoxDataSource1;
            this.login = login;
        }
        void Open(string tableName)
        {
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var query = "SELECT * FROM defense." + tableName;
            var command = new NpgsqlCommand(query, con);
            var adapter = new NpgsqlDataAdapter(command);
            dataset1 = new DataSet();
            adapter.Fill(dataset1, tableName);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text)|| string.IsNullOrEmpty(comboBox3.Text)
            || string.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            Open("house");
            for (int i = 0; i< dataset1.Tables[0].Rows.Count; i++)
            {
                if (dataset1.Tables[0].Rows[i].ItemArray[0].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Такой номер дома уже существует", "Ошибка");
                    return;
                }
            }
            Open("street");
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            try
            {
                var command = new NpgsqlCommand("INSERT INTO defense.house (number) VALUES (@number)", con);
                command.Parameters.AddWithValue("@number", textBox1.Text);
                command.ExecuteNonQuery();
                command = new NpgsqlCommand($"UPDATE defense.house SET street = @street, type = @type, lock = @lock, floors = @floors, doortype =@doortype WHERE number = '{textBox1.Text}'", con);
                for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)
                {
                    if (comboBox4.Text == dataset1.Tables[0].Rows[i].ItemArray[1].ToString())
                        command.Parameters.AddWithValue("@street", dataset1.Tables[0].Rows[i].ItemArray[0]);
                }
                command.Parameters.AddWithValue("@type", comboBox1.Text);
                command.Parameters.AddWithValue("@lock", checkBox2.Checked);
                command.Parameters.AddWithValue("@floors", Convert.ToInt32(textBox2.Text));
                command.Parameters.AddWithValue("@doortype", comboBox3.Text);
                command.ExecuteNonQuery();
                con.Close();
                Program.LoadToJournal("Добавлена запись в house", login);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Что-то пошло не так", "Ошибка"); }
        }
    }
}
