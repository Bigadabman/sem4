namespace Lab02
{
    partial class GraphicsCard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.bntCalculate = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.txtMemorySize = new System.Windows.Forms.TextBox();
            this.cmbMemoryType = new System.Windows.Forms.ComboBox();
            this.txtGPUClock = new System.Windows.Forms.TextBox();
            this.txtMemoryClock = new System.Windows.Forms.TextBox();
            this.txtBusWidth = new System.Windows.Forms.TextBox();
            this.lblCalculatedPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Информация о видеокарте";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(64, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Модель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(454, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Серия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(64, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Объем видеопамяти";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(64, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Тип видеопамяти";
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(64, 288);
            this.label6.MaximumSize = new System.Drawing.Size(230, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "Частота графического процессора";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(64, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Частота памяти";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(64, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ширина шины";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSave.Location = new System.Drawing.Point(619, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 31);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bntCalculate
            // 
            this.bntCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bntCalculate.Location = new System.Drawing.Point(459, 450);
            this.bntCalculate.Name = "bntCalculate";
            this.bntCalculate.Size = new System.Drawing.Size(126, 31);
            this.bntCalculate.TabIndex = 40;
            this.bntCalculate.Text = "Рассчитать";
            this.bntCalculate.UseVisualStyleBackColor = true;
            this.bntCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(295, 129);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 20);
            this.txtModel.TabIndex = 41;
            // 
            // txtSeries
            // 
            this.txtSeries.Location = new System.Drawing.Point(562, 130);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(100, 20);
            this.txtSeries.TabIndex = 42;
            // 
            // txtMemorySize
            // 
            this.txtMemorySize.Location = new System.Drawing.Point(295, 186);
            this.txtMemorySize.Name = "txtMemorySize";
            this.txtMemorySize.Size = new System.Drawing.Size(100, 20);
            this.txtMemorySize.TabIndex = 43;
            // 
            // cmbMemoryType
            // 
            this.cmbMemoryType.FormattingEnabled = true;
            this.cmbMemoryType.Items.AddRange(new object[] {
            "GDDR5",
            "GDDR6",
            "GDDR6X"});
            this.cmbMemoryType.Location = new System.Drawing.Point(295, 241);
            this.cmbMemoryType.Name = "cmbMemoryType";
            this.cmbMemoryType.Size = new System.Drawing.Size(100, 21);
            this.cmbMemoryType.TabIndex = 44;
            // 
            // txtGPUClock
            // 
            this.txtGPUClock.Location = new System.Drawing.Point(296, 294);
            this.txtGPUClock.Name = "txtGPUClock";
            this.txtGPUClock.Size = new System.Drawing.Size(100, 20);
            this.txtGPUClock.TabIndex = 45;
            // 
            // txtMemoryClock
            // 
            this.txtMemoryClock.Location = new System.Drawing.Point(295, 363);
            this.txtMemoryClock.Name = "txtMemoryClock";
            this.txtMemoryClock.Size = new System.Drawing.Size(100, 20);
            this.txtMemoryClock.TabIndex = 46;
            // 
            // txtBusWidth
            // 
            this.txtBusWidth.Location = new System.Drawing.Point(295, 425);
            this.txtBusWidth.Name = "txtBusWidth";
            this.txtBusWidth.Size = new System.Drawing.Size(100, 20);
            this.txtBusWidth.TabIndex = 47;
            // 
            // lblCalculatedPrice
            // 
            this.lblCalculatedPrice.AutoSize = true;
            this.lblCalculatedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCalculatedPrice.Location = new System.Drawing.Point(530, 288);
            this.lblCalculatedPrice.Name = "lblCalculatedPrice";
            this.lblCalculatedPrice.Size = new System.Drawing.Size(153, 20);
            this.lblCalculatedPrice.TabIndex = 48;
            this.lblCalculatedPrice.Text = "Рассчетная цена";
            this.lblCalculatedPrice.Click += new System.EventHandler(this.label9_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(66, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 25);
            this.label9.TabIndex = 49;
            this.label9.Text = "Производитель";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "NVIDIA",
            "AMD",
            "INTEL"});
            this.comboBox1.Location = new System.Drawing.Point(296, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 50;
            // 
            // GraphicsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 499);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCalculatedPrice);
            this.Controls.Add(this.txtBusWidth);
            this.Controls.Add(this.txtMemoryClock);
            this.Controls.Add(this.txtGPUClock);
            this.Controls.Add(this.cmbMemoryType);
            this.Controls.Add(this.txtMemorySize);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.bntCalculate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GraphicsCard";
            this.Text = "GraphicsCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button bntCalculate;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtSeries;
        private System.Windows.Forms.TextBox txtMemorySize;
        private System.Windows.Forms.ComboBox cmbMemoryType;
        private System.Windows.Forms.TextBox txtGPUClock;
        private System.Windows.Forms.TextBox txtMemoryClock;
        private System.Windows.Forms.TextBox txtBusWidth;
        private System.Windows.Forms.Label lblCalculatedPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}