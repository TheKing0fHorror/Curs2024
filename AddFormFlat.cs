using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Форма
{
    public partial class AddFormFlat : Form
    {
        DataSet dataset1;
        string login;
        public AddFormFlat(string login)
        {
            InitializeComponent();
            dataset1 = Open("house");
            var table1Data = dataset1.Tables["house"];
            var comboBoxDataSource1 = table1Data.AsEnumerable().Select(row => row.Field<string>("number")).ToList();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            if (checkBox1.Checked && string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            NpgsqlConnection con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
            var command = new NpgsqlCommand("INSERT INTO defense.flat (id) VALUES (@id)", con);
            int nextID = 0;
            DataSet dt3 = Open("flat");
            for (int j = 0; j < dt3.Tables["flat"].Rows.Count; j++)
            {
                for (int i = 0; i < dt3.Tables["flat"].Rows.Count; i++)
                    if (nextID != (int)dt3.Tables["flat"].Rows[i].ItemArray[1])
                        continue;
                    else nextID++;
            }
            Bitmap b = (Bitmap)pictureBox1.Image;
            byte[] image = new byte[b.Height*b.Width];
            using (var ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                image = ms.ToArray();
            }


            command.Parameters.AddWithValue("@id", nextID);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand($"UPDATE defense.flat SET house = @house, number =@number, balcon = @balcon, balcontype = @balcontype, plan = @plan WHERE id = '{nextID}'", con);
            command.Parameters.AddWithValue("@number", Convert.ToInt32(textBox1.Text));
            command.Parameters.AddWithValue("@house", comboBox1.Text);
            command.Parameters.AddWithValue("@balcon", checkBox1.Checked);
            command.Parameters.AddWithValue("@balcontype", comboBox2.Text);
            command.Parameters.AddWithValue("@plan", image);
            command.ExecuteNonQuery();
            con.Close();
            Program.LoadToJournal("Добавлена запись в flat", login);

            this.Close();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                label4.Enabled = false;
                label4.Visible = false;
                comboBox2.Enabled = false;
                comboBox2.Visible = false;
            }
            else
            {
                label4.Enabled = true;
                label4.Visible = true;
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            var openfile = new OpenFileDialog();
            openfile.Filter = "JPEG, PNG (*.jpg, *.png)|*.jpg";
            if (openfile.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = new Bitmap(openfile.FileName);

        }
    }
}
