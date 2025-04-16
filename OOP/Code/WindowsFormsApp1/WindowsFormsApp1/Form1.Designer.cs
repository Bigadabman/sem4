namespace WindowsFormsApp1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.WeightInput = new System.Windows.Forms.MaskedTextBox();
            this.HeightInput = new System.Windows.Forms.MaskedTextBox();
            this.AgeInput = new System.Windows.Forms.MaskedTextBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.GoalComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.periodInput = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.wantedWeightTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вес";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(40, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Рост";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(40, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Возраст";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(40, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пол";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // ResultOutput
            // 
            this.ResultOutput.Location = new System.Drawing.Point(359, 89);
            this.ResultOutput.Multiline = true;
            this.ResultOutput.Name = "ResultOutput";
            this.ResultOutput.ReadOnly = true;
            this.ResultOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultOutput.Size = new System.Drawing.Size(200, 150);
            this.ResultOutput.TabIndex = 9;
            this.ResultOutput.TextChanged += new System.EventHandler(this.ResultOutput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(354, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Результат";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // WeightInput
            // 
            this.WeightInput.Location = new System.Drawing.Point(166, 35);
            this.WeightInput.Mask = "999";
            this.WeightInput.Name = "WeightInput";
            this.WeightInput.Size = new System.Drawing.Size(100, 20);
            this.WeightInput.TabIndex = 11;
            this.WeightInput.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(166, 80);
            this.HeightInput.Mask = "000";
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(100, 20);
            this.HeightInput.TabIndex = 12;
            // 
            // AgeInput
            // 
            this.AgeInput.Location = new System.Drawing.Point(166, 127);
            this.AgeInput.Mask = "999";
            this.AgeInput.Name = "AgeInput";
            this.AgeInput.Size = new System.Drawing.Size(100, 20);
            this.AgeInput.TabIndex = 13;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(166, 177);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(34, 17);
            this.MaleRadioButton.TabIndex = 14;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "M";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(235, 178);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(31, 17);
            this.FemaleRadioButton.TabIndex = 15;
            this.FemaleRadioButton.TabStop = true;
            this.FemaleRadioButton.Text = "F";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GoalComboBox
            // 
            this.GoalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GoalComboBox.FormattingEnabled = true;
            this.GoalComboBox.Items.AddRange(new object[] {
            "Поддержание веса",
            "Снижение веса",
            "Увеличение веса"});
            this.GoalComboBox.Location = new System.Drawing.Point(166, 218);
            this.GoalComboBox.Name = "GoalComboBox";
            this.GoalComboBox.Size = new System.Drawing.Size(121, 21);
            this.GoalComboBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(40, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Цель";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(42, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Срок";
            // 
            // periodInput
            // 
            this.periodInput.Location = new System.Drawing.Point(166, 300);
            this.periodInput.Mask = "00/00/0000";
            this.periodInput.Name = "periodInput";
            this.periodInput.Size = new System.Drawing.Size(100, 20);
            this.periodInput.TabIndex = 20;
            this.periodInput.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(40, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Желаемый вес";
            // 
            // wantedWeightTextBox
            // 
            this.wantedWeightTextBox.Location = new System.Drawing.Point(187, 263);
            this.wantedWeightTextBox.Mask = "000";
            this.wantedWeightTextBox.Name = "wantedWeightTextBox";
            this.wantedWeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.wantedWeightTextBox.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.wantedWeightTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.periodInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GoalComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FemaleRadioButton);
            this.Controls.Add(this.MaleRadioButton);
            this.Controls.Add(this.AgeInput);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.WeightInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResultOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ResultOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox WeightInput;
        private System.Windows.Forms.MaskedTextBox HeightInput;
        private System.Windows.Forms.MaskedTextBox AgeInput;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox GoalComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox periodInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox wantedWeightTextBox;
    }
}

