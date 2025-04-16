using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации формы: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        






        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(WeightInput.Text))
                {
                    throw new Exception("Надо ввести вес");
                }

                

                if (string.IsNullOrEmpty(HeightInput.Text))
                {
                    throw new Exception("Надо ввести рост");
                }

                if (string.IsNullOrEmpty(AgeInput.Text))
                {
                    throw new Exception("Надо ввести возраст");
                }

                if (!MaleRadioButton.Checked && !FemaleRadioButton.Checked)
                {
                    throw new Exception("Надо выбрать пол");

                }


                if (string.IsNullOrEmpty(GoalComboBox.Text))
                {
                    throw new Exception("Надо выбрать цель");
                }

                if (string.IsNullOrEmpty(wantedWeightTextBox.Text) && GoalComboBox.SelectedIndex != 0)
                {
                    throw new Exception("Введите жедаемый вес");
                }

                if (string.IsNullOrEmpty(periodInput.Text))
                {
                    throw new Exception("Введите желаемый срок");
                }
                if (double.Parse(WeightInput.Text) > 200 || double.Parse(WeightInput.Text) < 45)
                    throw new Exception("Введите корректный вес");

                if (int.Parse(wantedWeightTextBox.Text) > 200 || int.Parse(wantedWeightTextBox.Text) < 45)
                    throw new Exception("Введите корректный вес");


                if (int.Parse(AgeInput.Text) < 13 || int.Parse(AgeInput.Text) > 80)
                {
                    throw new Exception("Введите корректный возраст");
                }

                if (double.Parse(HeightInput.Text) > 400 || double.Parse(HeightInput.Text) < 141)
                {
                    throw new Exception("Введите корректный рост");
                }

                if (DateTime.Parse(periodInput.Text) <= DateTime.Now)
                {
                    throw new Exception("Введите корретную дату цели");
                }
                if ( GoalComboBox.SelectedIndex == 1 &&  (int.Parse(wantedWeightTextBox.Text) >= double.Parse(WeightInput.Text))
                    || (GoalComboBox.SelectedIndex == 2 && (double.Parse(wantedWeightTextBox.Text) <= double.Parse(WeightInput.Text))))
                {
                    throw new Exception("Несоответствие цели и желаемого веса");
                }



                double weight = double.Parse(WeightInput.Text);
            double height = double.Parse(HeightInput.Text);
            int age = int.Parse(AgeInput.Text);
            bool isMale = MaleRadioButton.Checked;
            double bmi = weight / (height / 100) / (height / 100);
            DateTime GoalDay = DateTime.Parse(periodInput.Text);

            int weeks = (int)((GoalDay - DateTime.Now).TotalDays/7);

            int wantedWeight = int.Parse(wantedWeightTextBox.Text);

                

                    string result = $"Ваш имт {bmi:f2}\r\n";
            

            if(bmi < 18.5)
            {
                result += "Дефицит массы тела\r\n";
            }
            else if(bmi <= 25){
                result += "Норма\r\n";
            }
            else if(bmi < 30)
            {
                result += "Избыточный вес\r\n";
            }
            else
            {
                result += "Ожирение\r\n";
            }
            double TDEE;

            int goal = GoalComboBox.SelectedIndex;

                Calculator calculator = new Calculator();
            
            TDEE = calculator.calculateTDEE(weight, height, age, isMale);

            if (goal == 1)
            {
                TDEE = calculator.calculateCalorieNorm(TDEE, true, isMale, weeks, Math.Abs(wantedWeight - weight));
            }
            else if (goal == 2)
            {
                TDEE = calculator.calculateCalorieNorm(TDEE, false, isMale, weeks, Math.Abs(wantedWeight - weight));
            }

            result += $"Чтобы добиться вашей цели," +
                $" ваша суточная норма каллорий должнa быть равна {TDEE:f0}\r\n";

            result += $"на вашу цель уйдет " + calculator.actualWeeks/7 + " недель" ;
            ResultOutput.Text = result;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ResultOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
