namespace Форма
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openclienttable = new System.Windows.Forms.Button();
            this.opendealtable = new System.Windows.Forms.Button();
            this.OpenGoTable = new System.Windows.Forms.Button();
            this.OpenFlatTable = new System.Windows.Forms.Button();
            this.OpenStreetTable = new System.Windows.Forms.Button();
            this.OpenHouseTable = new System.Windows.Forms.Button();
            this.OpenCommandTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вызовыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квартирыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экипажиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.домаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.word = new System.Windows.Forms.Button();
            this.excel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openclienttable
            // 
            this.openclienttable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openclienttable.Location = new System.Drawing.Point(1060, 52);
            this.openclienttable.Name = "openclienttable";
            this.openclienttable.Size = new System.Drawing.Size(131, 36);
            this.openclienttable.TabIndex = 5;
            this.openclienttable.Text = "Клиенты";
            this.openclienttable.UseVisualStyleBackColor = true;
            this.openclienttable.Click += new System.EventHandler(this.openclienttable_Click);
            // 
            // opendealtable
            // 
            this.opendealtable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opendealtable.Location = new System.Drawing.Point(1254, 52);
            this.opendealtable.Name = "opendealtable";
            this.opendealtable.Size = new System.Drawing.Size(131, 36);
            this.opendealtable.TabIndex = 6;
            this.opendealtable.Text = "Сделки";
            this.opendealtable.UseVisualStyleBackColor = true;
            this.opendealtable.Click += new System.EventHandler(this.opendealtable_Click);
            // 
            // OpenGoTable
            // 
            this.OpenGoTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenGoTable.Location = new System.Drawing.Point(1254, 94);
            this.OpenGoTable.Name = "OpenGoTable";
            this.OpenGoTable.Size = new System.Drawing.Size(131, 36);
            this.OpenGoTable.TabIndex = 7;
            this.OpenGoTable.Text = "Выезды";
            this.OpenGoTable.UseVisualStyleBackColor = true;
            this.OpenGoTable.Click += new System.EventHandler(this.OpenGoTable_Click);
            // 
            // OpenFlatTable
            // 
            this.OpenFlatTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFlatTable.Location = new System.Drawing.Point(1060, 178);
            this.OpenFlatTable.Name = "OpenFlatTable";
            this.OpenFlatTable.Size = new System.Drawing.Size(131, 36);
            this.OpenFlatTable.TabIndex = 10;
            this.OpenFlatTable.Text = "Квартиры";
            this.OpenFlatTable.UseVisualStyleBackColor = true;
            this.OpenFlatTable.Click += new System.EventHandler(this.OpenFlatTable_Click);
            // 
            // OpenStreetTable
            // 
            this.OpenStreetTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenStreetTable.Location = new System.Drawing.Point(1060, 94);
            this.OpenStreetTable.Name = "OpenStreetTable";
            this.OpenStreetTable.Size = new System.Drawing.Size(131, 36);
            this.OpenStreetTable.TabIndex = 9;
            this.OpenStreetTable.Text = "Улицы";
            this.OpenStreetTable.UseVisualStyleBackColor = true;
            this.OpenStreetTable.Click += new System.EventHandler(this.OpenStreetTable_Click);
            // 
            // OpenHouseTable
            // 
            this.OpenHouseTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenHouseTable.Location = new System.Drawing.Point(1060, 136);
            this.OpenHouseTable.Name = "OpenHouseTable";
            this.OpenHouseTable.Size = new System.Drawing.Size(131, 36);
            this.OpenHouseTable.TabIndex = 8;
            this.OpenHouseTable.Text = "Дома";
            this.OpenHouseTable.UseVisualStyleBackColor = true;
            this.OpenHouseTable.Click += new System.EventHandler(this.OpenHouseTable_Click);
            // 
            // OpenCommandTable
            // 
            this.OpenCommandTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenCommandTable.Location = new System.Drawing.Point(1254, 136);
            this.OpenCommandTable.Name = "OpenCommandTable";
            this.OpenCommandTable.Size = new System.Drawing.Size(131, 36);
            this.OpenCommandTable.TabIndex = 11;
            this.OpenCommandTable.Text = "Экипажи";
            this.OpenCommandTable.UseVisualStyleBackColor = true;
            this.OpenCommandTable.Click += new System.EventHandler(this.OpenCommandTable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 390);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(8, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 36);
            this.button2.TabIndex = 16;
            this.button2.Text = "Создать запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1254, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 33);
            this.button3.TabIndex = 17;
            this.button3.Text = "Пользователи";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkedListBox2);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1053, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 204);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(210, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Редактированиe таблиц";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Просмотр таблиц";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(132, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "Загрузить данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Улицы",
            "Дома",
            "Квартиры",
            "Клиенты",
            "Сделки",
            "Вызовы",
            "Экипажи"});
            this.checkedListBox2.Location = new System.Drawing.Point(236, 59);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(120, 109);
            this.checkedListBox2.TabIndex = 1;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Улицы",
            "Дома",
            "Квартиры",
            "Клиенты",
            "Сделки",
            "Вызовы",
            "Экипажи"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 59);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 109);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.системаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1478, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.сделкиToolStripMenuItem,
            this.вызовыToolStripMenuItem,
            this.квартирыToolStripMenuItem,
            this.экипажиToolStripMenuItem,
            this.улицыToolStripMenuItem,
            this.домаToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click_1);
            // 
            // сделкиToolStripMenuItem
            // 
            this.сделкиToolStripMenuItem.Name = "сделкиToolStripMenuItem";
            this.сделкиToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.сделкиToolStripMenuItem.Text = "Сделки";
            this.сделкиToolStripMenuItem.Click += new System.EventHandler(this.сделкиToolStripMenuItem_Click);
            // 
            // вызовыToolStripMenuItem
            // 
            this.вызовыToolStripMenuItem.Name = "вызовыToolStripMenuItem";
            this.вызовыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.вызовыToolStripMenuItem.Text = "Вызовы";
            this.вызовыToolStripMenuItem.Click += new System.EventHandler(this.вызовыToolStripMenuItem_Click);
            // 
            // квартирыToolStripMenuItem
            // 
            this.квартирыToolStripMenuItem.Name = "квартирыToolStripMenuItem";
            this.квартирыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.квартирыToolStripMenuItem.Text = "Квартиры";
            this.квартирыToolStripMenuItem.Click += new System.EventHandler(this.квартирыToolStripMenuItem_Click);
            // 
            // экипажиToolStripMenuItem
            // 
            this.экипажиToolStripMenuItem.Name = "экипажиToolStripMenuItem";
            this.экипажиToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.экипажиToolStripMenuItem.Text = "Экипажи";
            this.экипажиToolStripMenuItem.Click += new System.EventHandler(this.экипажиToolStripMenuItem_Click);
            // 
            // улицыToolStripMenuItem
            // 
            this.улицыToolStripMenuItem.Name = "улицыToolStripMenuItem";
            this.улицыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.улицыToolStripMenuItem.Text = "Улицы";
            this.улицыToolStripMenuItem.Click += new System.EventHandler(this.улицыToolStripMenuItem_Click_1);
            // 
            // домаToolStripMenuItem
            // 
            this.домаToolStripMenuItem.Name = "домаToolStripMenuItem";
            this.домаToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.домаToolStripMenuItem.Text = "Дома";
            this.домаToolStripMenuItem.Click += new System.EventHandler(this.домаToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.wordToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // wordToolStripMenuItem
            // 
            this.wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            this.wordToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.wordToolStripMenuItem.Text = "Word";
            this.wordToolStripMenuItem.Click += new System.EventHandler(this.wordToolStripMenuItem_Click);
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.системаToolStripMenuItem.Text = "Система";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // word
            // 
            this.word.Enabled = false;
            this.word.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.word.Location = new System.Drawing.Point(165, 449);
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(87, 36);
            this.word.TabIndex = 22;
            this.word.Text = "Отчет Word";
            this.word.UseVisualStyleBackColor = false;
            this.word.Visible = false;
            this.word.Click += new System.EventHandler(this.word_Click);
            // 
            // excel
            // 
            this.excel.Enabled = false;
            this.excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.excel.Location = new System.Drawing.Point(258, 449);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(87, 36);
            this.excel.TabIndex = 23;
            this.excel.Text = "Отчет Exel";
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Visible = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(351, 454);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 26);
            this.textBox1.TabIndex = 24;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 588);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.word);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OpenFlatTable);
            this.Controls.Add(this.openclienttable);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.OpenHouseTable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OpenStreetTable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.OpenCommandTable);
            this.Controls.Add(this.OpenGoTable);
            this.Controls.Add(this.opendealtable);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Охранноe Агенство";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openclienttable;
        private System.Windows.Forms.Button opendealtable;
        private System.Windows.Forms.Button OpenGoTable;
        private System.Windows.Forms.Button OpenFlatTable;
        private System.Windows.Forms.Button OpenStreetTable;
        private System.Windows.Forms.Button OpenHouseTable;
        private System.Windows.Forms.Button OpenCommandTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вызовыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem квартирыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экипажиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem улицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem домаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem;
        private System.Windows.Forms.Button word;
        private System.Windows.Forms.Button excel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

