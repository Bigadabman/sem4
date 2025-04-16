namespace Lab02
{
    partial class CompCreate
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.PCType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RAMSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.memoryType = new System.Windows.Forms.ComboBox();
            this.memorySize = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.buyDate = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.процессорыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видеокартыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.comboBoxProcessor = new System.Windows.Forms.ComboBox();
            this.comboBoxGraphicsCard = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ComputerPrice = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ComputerList = new System.Windows.Forms.ListBox();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCompAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStriptime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RAMSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memorySize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип компьютера";
            // 
            // PCType
            // 
            this.PCType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PCType.FormattingEnabled = true;
            this.PCType.Items.AddRange(new object[] {
            "Server",
            "PC",
            "Laptop"});
            this.PCType.Location = new System.Drawing.Point(232, 43);
            this.PCType.Name = "PCType";
            this.PCType.Size = new System.Drawing.Size(121, 28);
            this.PCType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(29, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Процессор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(28, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Видеокарта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(29, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Размер ОЗУ";
            // 
            // RAMSize
            // 
            this.RAMSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RAMSize.Location = new System.Drawing.Point(231, 212);
            this.RAMSize.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.RAMSize.Name = "RAMSize";
            this.RAMSize.Size = new System.Drawing.Size(120, 26);
            this.RAMSize.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(29, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Тип ОЗУ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton1.Location = new System.Drawing.Point(232, 269);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 24);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DDR4";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton3.Location = new System.Drawing.Point(310, 269);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 24);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.Text = "DDR5";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(29, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Жесткий диск";
            // 
            // memoryType
            // 
            this.memoryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.memoryType.FormattingEnabled = true;
            this.memoryType.Items.AddRange(new object[] {
            "HDD",
            "SSD"});
            this.memoryType.Location = new System.Drawing.Point(232, 314);
            this.memoryType.Name = "memoryType";
            this.memoryType.Size = new System.Drawing.Size(121, 28);
            this.memoryType.TabIndex = 13;
            // 
            // memorySize
            // 
            this.memorySize.LargeChange = 20;
            this.memorySize.Location = new System.Drawing.Point(143, 369);
            this.memorySize.Maximum = 2048;
            this.memorySize.Minimum = 120;
            this.memorySize.Name = "memorySize";
            this.memorySize.Size = new System.Drawing.Size(239, 45);
            this.memorySize.SmallChange = 5;
            this.memorySize.TabIndex = 14;
            this.memorySize.Value = 120;
            this.memorySize.Scroll += new System.EventHandler(this.lblFrequency_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(29, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Дата приобритения";
            // 
            // buyDate
            // 
            this.buyDate.CustomFormat = "dd MMMM yyyyг";
            this.buyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.buyDate.Location = new System.Drawing.Point(234, 420);
            this.buyDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.buyDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.buyDate.Name = "buyDate";
            this.buyDate.Size = new System.Drawing.Size(184, 26);
            this.buyDate.TabIndex = 18;
            this.buyDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 28);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.процессорыToolStripMenuItem,
            this.видеокартыToolStripMenuItem});
            this.файлыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.файлыToolStripMenuItem.Text = "Комплектующие";
            this.файлыToolStripMenuItem.Click += new System.EventHandler(this.файлыToolStripMenuItem_Click);
            // 
            // процессорыToolStripMenuItem
            // 
            this.процессорыToolStripMenuItem.Name = "процессорыToolStripMenuItem";
            this.процессорыToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.процессорыToolStripMenuItem.Text = "Процессоры";
            this.процессорыToolStripMenuItem.Click += new System.EventHandler(this.процессорыToolStripMenuItem_Click);
            // 
            // видеокартыToolStripMenuItem
            // 
            this.видеокартыToolStripMenuItem.Name = "видеокартыToolStripMenuItem";
            this.видеокартыToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.видеокартыToolStripMenuItem.Text = "Видеокарты";
            this.видеокартыToolStripMenuItem.Click += new System.EventHandler(this.видеокартыToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button1.Location = new System.Drawing.Point(621, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 31);
            this.button1.TabIndex = 38;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(70, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 40;
            this.label8.Text = "объем";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFrequency.Location = new System.Drawing.Point(405, 382);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(40, 24);
            this.lblFrequency.TabIndex = 41;
            this.lblFrequency.Text = "120";
            // 
            // comboBoxProcessor
            // 
            this.comboBoxProcessor.FormattingEnabled = true;
            this.comboBoxProcessor.Location = new System.Drawing.Point(231, 113);
            this.comboBoxProcessor.Name = "comboBoxProcessor";
            this.comboBoxProcessor.Size = new System.Drawing.Size(122, 21);
            this.comboBoxProcessor.TabIndex = 42;
            // 
            // comboBoxGraphicsCard
            // 
            this.comboBoxGraphicsCard.FormattingEnabled = true;
            this.comboBoxGraphicsCard.Location = new System.Drawing.Point(229, 156);
            this.comboBoxGraphicsCard.Name = "comboBoxGraphicsCard";
            this.comboBoxGraphicsCard.Size = new System.Drawing.Size(122, 21);
            this.comboBoxGraphicsCard.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(35, 491);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Рассчетная цена";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // ComputerPrice
            // 
            this.ComputerPrice.AutoSize = true;
            this.ComputerPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComputerPrice.Location = new System.Drawing.Point(239, 498);
            this.ComputerPrice.Name = "ComputerPrice";
            this.ComputerPrice.Size = new System.Drawing.Size(54, 20);
            this.ComputerPrice.TabIndex = 45;
            this.ComputerPrice.Text = "00000";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(478, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 31);
            this.button2.TabIndex = 46;
            this.button2.Text = "Список";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComputerList
            // 
            this.ComputerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComputerList.FormattingEnabled = true;
            this.ComputerList.ItemHeight = 20;
            this.ComputerList.Location = new System.Drawing.Point(465, 58);
            this.ComputerList.Name = "ComputerList";
            this.ComputerList.Size = new System.Drawing.Size(239, 184);
            this.ComputerList.TabIndex = 47;
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCompAmount,
            this.toolStriptime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 48;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCompAmount
            // 
            this.toolStripCompAmount.Name = "toolStripCompAmount";
            this.toolStripCompAmount.Size = new System.Drawing.Size(118, 17);
            this.toolStripCompAmount.Text = "toolStripStatusLabel1";
            this.toolStripCompAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripCompAmount.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStriptime
            // 
            this.toolStriptime.Name = "toolStriptime";
            this.toolStriptime.Size = new System.Drawing.Size(33, 17);
            this.toolStriptime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CompCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ComputerList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ComputerPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxGraphicsCard);
            this.Controls.Add(this.comboBoxProcessor);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buyDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.memorySize);
            this.Controls.Add(this.memoryType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RAMSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PCType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompCreate";
            this.Text = "1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RAMSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memorySize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PCType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RAMSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox memoryType;
        private System.Windows.Forms.TrackBar memorySize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker buyDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem процессорыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видеокартыToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.ComboBox comboBoxProcessor;
        private System.Windows.Forms.ComboBox comboBoxGraphicsCard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ComputerPrice;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ComputerList;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCompAmount;
        private System.Windows.Forms.ToolStripStatusLabel toolStriptime;
        private System.Windows.Forms.Timer timer1;
    }


}

