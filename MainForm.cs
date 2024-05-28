using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Форма
{
    public partial class MainForm : Form
    {
        string login;
        NpgsqlConnection con;
        DataSet dataset1;
        string thisTableName;
        string thisData;
        string oldData;
        List<string> showList = new List<string>();
        List<string> updateList = new List<string>();
        Dictionary<string, string> tablesnames = new Dictionary<string, string>()
        {
            {"Улицы", "street" },
            {"Клиенты", "client" },
            {"Дома", "house" },
            {"Квартиры", "flat" },
            {"Вызовы", "go" },
            {"Сделки", "deal" },
            {"Экипажи", "command" },
        };
        public MainForm(List<string> showList, List<string> updateList, string login)
        {
            InitializeComponent();
            foreach (string s in showList)
            {
                foreach (var t in tablesnames)
                {
                    if (s == t.Key)
                        this.showList.Add(t.Value);
                }
            }
            foreach (string s in updateList)
            {
                foreach (var t in tablesnames)
                {
                    if (s == t.Key)
                        this.updateList.Add(t.Value);
                }
            }

            this.login = login;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            con.Open();
        }
        public void Admin()
        {
            button3.Enabled = true;
            button3.Visible = true;
            showList.Add("avtorization");
            updateList.Add("avtorization");
        }
        private void openclienttable_Click(object sender, EventArgs e) =>Open("client");
        private void opendealtable_Click(object sender, EventArgs e) => Open("deal");
        private void OpenGoTable_Click(object sender, EventArgs e) => Open("go");
        private void OpenHouseTable_Click(object sender, EventArgs e) => Open("house");
        private void OpenStreetTable_Click(object sender, EventArgs e) => Open("street");
        private void OpenFlatTable_Click(object sender, EventArgs e) => Open("flat");
        private void OpenCommandTable_Click(object sender, EventArgs e) => Open("command");
        void Open(string tableName)
        {
            button2.Enabled = true; button2.Visible = true;
            excel.Visible = true; excel.Enabled = true;
            word.Visible = true; word.Enabled = true;
            textBox1.Visible = true; textBox1.Enabled = true;
            bool breaks = CheckPropertiesShow(tableName);
            bool update = CheckPropertiesUpdate(tableName);
            if (!breaks)
            {
                button2.Visible = false; button2.Enabled = false;
                excel.Visible = false; excel.Enabled = false;
                word.Visible = false; word.Enabled = false;
                textBox1.Visible = false; textBox1.Enabled = false;
                dataGridView1.ReadOnly = true;
                MessageBox.Show("У вас нет прав на просмотр данной таблицы", "Нет прав");
                return;
            }
            if (update)
                dataGridView1.ReadOnly = false;
            else
            {
                button2.Visible = false; button2.Enabled = false;
                button2.Visible = false; button2.Enabled = false;
                dataGridView1.ReadOnly = true;
            }
            var query = "SELECT * FROM defense." + tableName;
            var command = new NpgsqlCommand(query, con);
            var adapter = new NpgsqlDataAdapter(command);
            dataset1 = new DataSet();
            adapter.Fill(dataset1, tableName);
            dataGridView1.DataSource = dataset1.Tables[tableName];
            dataGridView1.Refresh();
            Translate();
            thisTableName = tableName;
            if (thisTableName != "avtorization")
            {
                groupBox1.Visible = false;
                groupBox1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form addForm = null;
            if (thisTableName == "street")
                addForm = new AddFormStreet(dataset1, login);
            if (thisTableName == "house")
                addForm = new AddFormHouse(login);
            if (thisTableName == "client")
                addForm = new AddFormClient(login);
            if (thisTableName == "flat")
                addForm = new AddFormFlat(login);
            if (thisTableName == "go")
                addForm = new AddFormGo(login);
            if (thisTableName == "deal")
                addForm = new AddFormDeal(login);
            if (thisTableName == "command")
                addForm = new AddFormCommand(login);
            if (thisTableName == "avtorization")
                addForm = new AddFormUsers(login);

            this.Hide();
            if (addForm != null)
                addForm.ShowDialog();
            this.Show();
            Open(thisTableName);
        }
        bool CheckPropertiesShow(string tablename)
        {
            bool breaks = false;
            foreach (string s in showList)
                if (s != tablename)
                    breaks = false;
                else
                {
                    breaks = true;
                    break;
                }
            return breaks;
        }
        bool CheckPropertiesUpdate(string tablename)
        {
            bool update = false;
            foreach (string s in updateList)
                if (s != tablename)
                    update = false;
                else
                {
                    update = true;
                    break;
                }
            return update;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!CheckPropertiesUpdate(thisTableName))
                return;
            string keyname = KeyName();
            string key = "";
            string newValue = dataGridView1.CurrentCell.Value.ToString();
            if (string.IsNullOrEmpty(newValue))
                return;
            string columnName = dataGridView1.CurrentCell.OwningColumn.Name;
            foreach (DataGridViewCell cell in dataGridView1.CurrentCell.OwningRow.Cells)
                if (cell.OwningColumn.Name == keyname)
                {
                    if (dataGridView1.CurrentCell != cell)
                        key = cell.Value.ToString();
                    else key = thisData;
                }
            NpgsqlConnection conn = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            conn.Open();
            var command1 = new NpgsqlCommand($"UPDATE defense.{thisTableName} SET {columnName} = '{newValue}' WHERE {keyname} = '{key}'", conn);
            try
            {
                command1.ExecuteNonQuery();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введен неверный тип данных", "Ошибка");
            }
            Program.LoadToJournal($"Запись изменена в {thisTableName}, значение столбца {columnName} для записи {key} изменено с {oldData} на {newValue}", login);
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dataGridView1.CurrentCell.Value.ToString())) ;
            thisData = dataGridView1.CurrentCell.Value.ToString();
        }
        string KeyName()
        {
            string keyname = "";
            switch (thisTableName)
            {
                case "street":
                    keyname = "id";
                    break;
                case "avtorization":
                    keyname = "login";
                    break;
                case "client":
                    keyname = "number";
                    break;
                case "command":
                    keyname = "number";
                    break;
                case "deal":
                    keyname = "number";
                    break;
                case "flat":
                    keyname = "id";
                    break;
                case "go":
                    keyname = "number";
                    break;
                case "house":
                    keyname = "number";
                    break;
            }
            return keyname;
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CheckPropertiesUpdate(thisTableName))
                return;
            string keyname = KeyName();
            string key = "";
            string newValue = dataGridView1.CurrentCell.Value.ToString();
            string columnName = dataGridView1.CurrentCell.OwningColumn.Name;
            foreach (DataGridViewCell cell in dataGridView1.CurrentRow.Cells)
                if (cell.OwningColumn.Name == keyname)
                {
                    if (dataGridView1.CurrentCell != cell)
                        key = cell.Value.ToString();
                    else key = thisData;
                }
            NpgsqlConnection conn = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            conn.Open();
            try
            {
                var command1 = new NpgsqlCommand($"DELETE FROM defense.{thisTableName} WHERE {keyname} = '{key}'", conn);
                command1.ExecuteNonQuery();
                Program.LoadToJournal($"Удалена запись из {thisTableName}, со значением ключевого поля {key}", login);
            }
            catch (Exception ex) { MessageBox.Show("Непредвиденная ошибка", ex.Message); }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open("avtorization");
            groupBox1.Visible = true;
            groupBox1.Enabled = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string values = "";
            foreach (var st in checkedListBox1.CheckedItems)
                values += st + " ";
            dataGridView1.CurrentRow.Cells[7].Value = values;
            string keyname = KeyName();
            string key = "";
            string newValue = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            string columnName = dataGridView1.CurrentCell.OwningColumn.Name;
            foreach (DataGridViewCell cell in dataGridView1.CurrentCell.OwningRow.Cells)
                if (cell.OwningColumn.Name == keyname)
                {
                    if (dataGridView1.CurrentCell != cell)
                        key = cell.Value.ToString();
                    else key = thisData;
                }
            NpgsqlConnection conn = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            conn.Open();
            var command1 = new NpgsqlCommand($"UPDATE defense.{thisTableName} SET tablesshow = '{newValue}' WHERE {keyname} = '{key}'", conn);
            try
            {
                command1.ExecuteNonQuery();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введен неверный тип данных", "Ошибка");
            }
            Program.LoadToJournal($"Изменены права пользователя {key}, на {values}", login);
            conn.Close();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string values = "";
            foreach (var st in checkedListBox2.CheckedItems)
                values += st + " ";
            dataGridView1.CurrentRow.Cells[8].Value = values;
            string keyname = KeyName();
            string key = "";
            string newValue = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string columnName = dataGridView1.CurrentCell.OwningColumn.Name;
            foreach (DataGridViewCell cell in dataGridView1.CurrentCell.OwningRow.Cells)
                if (cell.OwningColumn.Name == keyname)
                {
                    if (dataGridView1.CurrentCell != cell)
                        key = cell.Value.ToString();
                    else key = thisData;
                }
            NpgsqlConnection conn = new NpgsqlConnection($"Server=localhost;Port=5432;User ID=postgres;Password=670670;Database=curs;");
            conn.Open();
            var command1 = new NpgsqlCommand($"UPDATE defense.{thisTableName} SET tableupdate = '{newValue}' WHERE {keyname} = '{key}'", conn);
            try
            {
                command1.ExecuteNonQuery();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введен неверный тип данных", "Ошибка");
            }
            Program.LoadToJournal($"Изменены права пользователя {key}, на {values}", login);
            conn.Close();
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckPropertiesUpdate(thisTableName))
                return;
            if (dataGridView1.Columns.Count == 9)
            {
                if (dataGridView1.Columns[7].Name == "tablesshow" && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[7].Value != null)
                {
                    string[] v = dataGridView1.CurrentRow.Cells[7].Value.ToString().Split(' ');
                    foreach (string s in v)
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            if (s == checkedListBox1.Items[i].ToString())
                            {
                                checkedListBox1.SetItemChecked(i, true);
                                break;
                            }
                    v = dataGridView1.CurrentRow.Cells[8].Value.ToString().Split();
                    foreach (string s in v)
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            if (s == checkedListBox2.Items[i].ToString())
                            {
                                checkedListBox2.SetItemChecked(i, true);
                                break;
                            }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CheckPropertiesUpdate(thisTableName))
                return;
            if (dataGridView1.Columns.Count == 9)
            {
                if (dataGridView1.Columns[7].Name == "tablesshow" && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[7].Value != null)
                {
                    string[] v = dataGridView1.CurrentRow.Cells[7].Value.ToString().Split(' ');
                    foreach (string s in v)
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            if (s == checkedListBox1.Items[i].ToString())
                            {
                                checkedListBox1.SetItemChecked(i, true);
                                break;
                            }
                    v = dataGridView1.CurrentRow.Cells[8].Value.ToString().Split();
                    foreach (string s in v)
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            if (s == checkedListBox2.Items[i].ToString())
                            {
                                checkedListBox2.SetItemChecked(i, true);
                                break;
                            }
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldData = dataGridView1.CurrentCell.Value.ToString();
        }

        private void otchot_Click(object sender, EventArgs e)
        {

            this.Show();
            Open(thisTableName);
            OtchyotCreator.CreateWord(dataGridView1);
        }

        private void клиентыToolStripMenuItem_Click_1(object sender, EventArgs e) => openclienttable_Click(sender, e);
        private void сделкиToolStripMenuItem_Click(object sender, EventArgs e) => opendealtable_Click(sender, e);
        private void вызовыToolStripMenuItem_Click(object sender, EventArgs e) => OpenGoTable_Click(sender, e);
        private void квартирыToolStripMenuItem_Click(object sender, EventArgs e) => OpenFlatTable_Click(sender, e);
        private void экипажиToolStripMenuItem_Click(object sender, EventArgs e) => OpenCommandTable_Click(sender, e);
        private void улицыToolStripMenuItem_Click_1(object sender, EventArgs e) => OpenStreetTable_Click(sender, e);
        private void домаToolStripMenuItem_Click(object sender, EventArgs e) => OpenHouseTable_Click(sender, e);
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Разработать прикладное программное обеспечение деятельности отдела вневедомственной охраны квартир. Этот отдел обеспечивает электронную охрану квартир граждан в одном районе города. Для установки \r\nохранной сигнализации требуется наличие квартирного телефона. Один гражданин может заключить договор на охрану нескольких квартир. Из-за ложных срабатываний сигнализации возможно несколько выездов патрульных экипажей по одной квартире. На владельца квартиры, вовремя не отключившего сигнализацию после своего прихода домой, налагается штраф, величина которого оговаривается при заключении договора охраны. Если отдел вневедомственной охраны не уберег имущество владельца квартиры, то он выплачивает пострадавшему заранее оговоренную сумму. От величины этой суммы зависит размер ежемесячной оплаты за охрану квартиры.");

        private void wordToolStripMenuItem_Click(object sender, EventArgs e) => OtchyotCreator.CreateWord(dataGridView1);

        private void excelToolStripMenuItem_Click(object sender, EventArgs e) => OtchyotCreator.CreateExcel(dataGridView1);

        private void word_Click(object sender, EventArgs e) => OtchyotCreator.CreateWord(dataGridView1);

        private void excel_Click(object sender, EventArgs e) => OtchyotCreator.CreateExcel(dataGridView1);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Open(thisTableName);
                return;
            }
            var query = $"SELECT * FROM defense." + thisTableName;
            string where = $" WHERE ";
            System.Collections.IList list = dataGridView1.Columns;
            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewColumn column = (DataGridViewColumn)list[i];
                if (column.ValueType == typeof(string))
                {
                    where += $"{column.Name} ";
                    where += $"LIKE \'{textBox1.Text}%\' ";
                    where += "OR ";
                }
                if (column.ValueType == typeof(Int32))
                {
                    int chis;
                    if (int.TryParse(textBox1.Text, out chis))
                    {
                        where += $"{column.Name} ";
                        where += $"= \'{chis}\' ";
                        where += "OR ";
                    }
                    else continue;
                }
                if (column.ValueType == typeof(Decimal))
                {
                    decimal chis;
                    if (decimal.TryParse(textBox1.Text, out chis))
                    {
                        where += $"{column.Name} ";
                        where += $"= \'{chis}\' ";
                        where += "OR ";
                    }
                    else continue;
                }
                if (column.ValueType == typeof(DateTime))
                {
                    DateTime chis;
                    if (DateTime.TryParse(textBox1.Text, out chis))
                    {
                        where += $"{column.Name} ";
                        where += $"= \'{chis}\' ";
                        where += "OR ";
                    }
                    else continue;
                }
            }
            where = where.TrimEnd(new char[] { ' ', 'O', 'R' });
            if (where == " WHERE") return;
            query += where;
            var command = new NpgsqlCommand(query, con);
            var adapter = new NpgsqlDataAdapter(command);
            dataset1 = new DataSet();
            
            adapter.Fill(dataset1, thisTableName);
            dataGridView1.DataSource = dataset1.Tables[thisTableName];
            dataGridView1.Refresh();
        }
        void Translate()
        {
            List<string> translate = new List<string>();
            using (StreamReader sr = new StreamReader(@"translate.txt"))
            {
                string str = sr.ReadLine();
                while (str != null)
                {
                    translate.Add(str);
                    str = sr.ReadLine();
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                foreach (var str in translate)
                {
                    string[] translated = str.Split('_');
                    if (column.Name == translated[0])
                    {
                        column.HeaderText = translated[1];
                        break;
                    }
                }
            }
        }
    }
}
