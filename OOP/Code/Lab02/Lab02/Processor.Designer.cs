namespace Lab02
{
    partial class Processor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCache = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaxFrequency = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCores = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCalculatedPerformance = new System.Windows.Forms.Label();
            this.rbX64 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnCalculatePerformance = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCache
            // 
            this.txtCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCache.Location = new System.Drawing.Point(281, 350);
            this.txtCache.Name = "txtCache";
            this.txtCache.Size = new System.Drawing.Size(100, 26);
            this.txtCache.TabIndex = 52;
            this.txtCache.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label16.Location = new System.Drawing.Point(42, 350);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 25);
            this.label16.TabIndex = 51;
            this.label16.Text = "Размер кэша";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label15.Location = new System.Drawing.Point(42, 293);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(259, 25);
            this.label15.TabIndex = 49;
            this.label15.Text = "Разрядность архитектуры";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtMaxFrequency
            // 
            this.txtMaxFrequency.Location = new System.Drawing.Point(331, 252);
            this.txtMaxFrequency.Name = "txtMaxFrequency";
            this.txtMaxFrequency.Size = new System.Drawing.Size(71, 20);
            this.txtMaxFrequency.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label14.Location = new System.Drawing.Point(99, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 22);
            this.label14.TabIndex = 47;
            this.label14.Text = "Максимальная частота";
            // 
            // txtFrequency
            // 
            this.txtFrequency.LargeChange = 1;
            this.txtFrequency.Location = new System.Drawing.Point(281, 212);
            this.txtFrequency.Maximum = 5500;
            this.txtFrequency.Minimum = 1;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(183, 45);
            this.txtFrequency.SmallChange = 100;
            this.txtFrequency.TabIndex = 46;
            this.txtFrequency.Value = 1;
            this.txtFrequency.Scroll += new System.EventHandler(this.txtFrequency_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label13.Location = new System.Drawing.Point(42, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 25);
            this.label13.TabIndex = 45;
            this.label13.Text = "Частота";
            // 
            // txtCores
            // 
            this.txtCores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCores.Location = new System.Drawing.Point(281, 157);
            this.txtCores.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.txtCores.Name = "txtCores";
            this.txtCores.Size = new System.Drawing.Size(120, 26);
            this.txtCores.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label12.Location = new System.Drawing.Point(42, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 25);
            this.label12.TabIndex = 43;
            this.label12.Text = "Количество ядер";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtModel.Location = new System.Drawing.Point(650, 103);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(121, 26);
            this.txtModel.TabIndex = 42;
            this.txtModel.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.Location = new System.Drawing.Point(490, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 25);
            this.label11.TabIndex = 41;
            this.label11.Text = "Модель";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtSeries
            // 
            this.txtSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSeries.Location = new System.Drawing.Point(281, 103);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(121, 26);
            this.txtSeries.TabIndex = 40;
            this.txtSeries.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(42, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 39;
            this.label10.Text = "Серия";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.Location = new System.Drawing.Point(42, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 25);
            this.label9.TabIndex = 37;
            this.label9.Text = "Производитель";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 25);
            this.label8.TabIndex = 36;
            this.label8.Text = "Информация о процессоре";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSave.Location = new System.Drawing.Point(645, 389);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 31);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCalculatedPerformance
            // 
            this.lblCalculatedPerformance.AutoSize = true;
            this.lblCalculatedPerformance.Location = new System.Drawing.Point(593, 237);
            this.lblCalculatedPerformance.Name = "lblCalculatedPerformance";
            this.lblCalculatedPerformance.Size = new System.Drawing.Size(115, 13);
            this.lblCalculatedPerformance.TabIndex = 54;
            this.lblCalculatedPerformance.Text = "Производительность";
            this.lblCalculatedPerformance.Click += new System.EventHandler(this.lblCalculatedPerformance_Click);
            // 
            // rbX64
            // 
            this.rbX64.AutoSize = true;
            this.rbX64.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbX64.Location = new System.Drawing.Point(365, 295);
            this.rbX64.Name = "rbX64";
            this.rbX64.Size = new System.Drawing.Size(52, 24);
            this.rbX64.TabIndex = 32;
            this.rbX64.TabStop = true;
            this.rbX64.Text = "x64";
            this.rbX64.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton2.Location = new System.Drawing.Point(307, 295);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 24);
            this.radioButton2.TabIndex = 31;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "x86";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnCalculatePerformance
            // 
            this.btnCalculatePerformance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculatePerformance.Location = new System.Drawing.Point(484, 390);
            this.btnCalculatePerformance.Name = "btnCalculatePerformance";
            this.btnCalculatePerformance.Size = new System.Drawing.Size(126, 31);
            this.btnCalculatePerformance.TabIndex = 55;
            this.btnCalculatePerformance.Text = "Рассчитать";
            this.btnCalculatePerformance.UseVisualStyleBackColor = true;
            this.btnCalculatePerformance.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Intel",
            "AMD",
            "qualcomm"});
            this.comboBox1.Location = new System.Drawing.Point(281, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(470, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 24);
            this.label1.TabIndex = 57;
            this.label1.Text = "0";
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCalculatePerformance);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.lblCalculatedPerformance);
            this.Controls.Add(this.rbX64);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCache);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaxFrequency);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCores);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "Processor";
            this.Text = "Processor";
            this.Load += new System.EventHandler(this.Processor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCache;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaxFrequency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar txtFrequency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown txtCores;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSeries;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCalculatedPerformance;
        private System.Windows.Forms.RadioButton rbX64;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnCalculatePerformance;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}