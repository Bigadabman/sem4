using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab02.Processor;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lab02
{
    public partial class CompCreate : Form
    {
        BindingList<Computer> computers = new BindingList<Computer>();
        private BindingList<Processors> _processors = new BindingList<Processors>();
        private BindingList<VideoCard> graphicsCard = new BindingList<VideoCard>();
        public CompCreate()
        {
            InitializeComponent();
            LoadProcessorsFromJson();
            LoadGraphicsCardFromJson();
            if (File.Exists("computers.json"))
            {
                string json = File.ReadAllText("computers.json");
                computers = JsonSerializer.Deserialize<BindingList<Computer>>(json) ?? new BindingList<Computer>();
            }

            ComputerList.DataSource = computers;
            toolStripCompAmount.Text = computers.Count().ToString();
        }


        private void LoadProcessorsFromJson()
        {
            try
            {
                string path = "processors.json";
                string json = File.ReadAllText(path);
                _processors = JsonSerializer.Deserialize<BindingList<Processors>>(json);

                // Заполнение ComboBox
                comboBoxProcessor.DataSource = _processors;
                comboBoxProcessor.DisplayMember = "DisplayInfo";
                comboBoxProcessor.ValueMember = "Performance";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void LoadGraphicsCardFromJson()
        {
            try
            {
                string path = "videocards.json";
                string json = File.ReadAllText(path);
                graphicsCard = JsonSerializer.Deserialize<BindingList<VideoCard>>(json);

                // Заполнение ComboBox
                comboBoxGraphicsCard.DataSource = graphicsCard;
                comboBoxGraphicsCard.DisplayMember = "DisplayInfo";
                comboBoxGraphicsCard.ValueMember = "Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }


        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void файлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        



        private void процессорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Processor form2 = new Processor();

            form2.ShowDialog();
        }

        private void видеокартыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphicsCard form2 = new GraphicsCard();

            form2.ShowDialog();
        }

        private void lblFrequency_Scroll(object sender, EventArgs e)
        {
            this.lblFrequency.Text = this.memorySize.Value.ToString();
        }




        private void SaveComputerToJson(Computer computer)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<Computer> computers = new List<Computer>();

            // Если файл существует, загружаем существующие данные
            if (File.Exists("computers.json"))
            {
                string json = File.ReadAllText("computers.json");
                computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();
            }

            // Добавляем новый процессор
            computers.Add(computer);

            // Сохраняем обновленный список
            string newJson = JsonSerializer.Serialize(computers, options);
            File.WriteAllText("computers.json", newJson);
        }




        private bool validateInputs(ComboBox PCType, NumericUpDown RAMSize,
            ComboBox memoryType, TrackBar memorySize, DateTimePicker BuyDate)
        {
            if (string.IsNullOrWhiteSpace(PCType.Text))
            {
                MessageBox.Show("Введите тип компьютера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(RAMSize.Text, out int size) || size <= 0 || size > 128)
            {
                MessageBox.Show("Введите корректное количество ОЗУ (1-128)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(memoryType.Text))
            {
                MessageBox.Show("Введите тип памяти!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (memorySize.Value < 120 || memorySize.Value > 2048)
            {
                MessageBox.Show("Введите корректный объем памяти (120 - 2048 Gb)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (buyDate.Value > DateTime.Now || buyDate.Value < new DateTime(2005, 1, 1)) {
                MessageBox.Show("Введите корректную дату приобретения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }


            return true;

        }

        private decimal CalculatePrice()
        {

            int cost = 0;


            if (comboBoxProcessor.SelectedItem != null)
            {
                cost += (int)((Processors)comboBoxProcessor.SelectedItem).Performance;
            }
            if (comboBoxGraphicsCard.SelectedItem != null)
            {
                cost += (int)((VideoCard)comboBoxGraphicsCard.SelectedItem).Price;
            }


            int ramPricePerGB = radioButton3.Checked ? 15 : 10; // DDR5 дороже
            if (RAMSize.Value > 0)
            {
                cost += (int)RAMSize.Value * ramPricePerGB;
            }

            
            if (memoryType.Text == "SSD")
            {
                cost += 100;
            }
            else if (memoryType.Text == "HDD")
            {
                cost += 50;
            }

            ComputerPrice.Text = cost.ToString();

            return cost;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            


           if( validateInputs(PCType, RAMSize, memoryType, memorySize, buyDate))
            {
                CalculatePrice();

                Computer Comp = new Computer
                {
                    computerType = PCType.Text,
                    RAMSize = (int)(RAMSize.Value),
                    memorySize = memorySize.Value,
                    memoryType = memoryType.Text,
                    buyDate = buyDate.Value,
                    price = int.Parse(ComputerPrice.Text),
                    processor = comboBoxProcessor.Text,
                    card = comboBoxGraphicsCard.Text,
                };

                try
                {
                    SaveComputerToJson(Comp);
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }




        }

        public class Computer
        {
            public string processor {  get; set; }
            public string card { get; set; }
            public string computerType {  get; set; }
            public int RAMSize { get; set; }
            public int memorySize { get; set; }
            public DateTime buyDate { get; set; }
            public string memoryType { get; set; }

            public decimal price { get; set; }
            
            public override string ToString()
            {
                return $"{computerType} {processor} {card}";
            }
           



        }

        private void label9_Click(object sender, EventArgs e)
        {

        }






        private void button2_Click(object sender, EventArgs e)
        {

            

            // Если файл существует, загружаем существующие данные
            if (File.Exists("computers.json"))
            {
                string json = File.ReadAllText("computers.json");
                computers = JsonSerializer.Deserialize<BindingList<Computer>>(json) ?? new BindingList<Computer>();
            }
              
            ComputerList.DataSource = computers;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 0.1\n\n\nDeveloper: Korobov E.O.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStriptime.Text = $"{DateTime.Now}";
        }
    }
}
