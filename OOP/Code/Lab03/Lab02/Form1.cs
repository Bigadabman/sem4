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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            lastAction.Text = "none";
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

            lastAction.Text = "Процессор";
            Processor form2 = new Processor();

            form2.ShowDialog();
        }

        private void видеокартыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastAction.Text = "Видеокарта";
            GraphicsCard form2 = new GraphicsCard();

            form2.ShowDialog();
        }

        private void lblFrequency_Scroll(object sender, EventArgs e)
        {
            this.lblFrequency.Text = this.memorySize.Value.ToString();
        }




        private void SaveComputerToJson(Computer computer, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<Computer> computers = new List<Computer>();

            // Если файл существует, загружаем существующие данные
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();
            }
            File.Copy("computers.json", "prevComputers.json");

            // Добавляем новый процессор
            computers.Add(computer);

            // Сохраняем обновленный список
            string newJson = JsonSerializer.Serialize(computers, options);
            File.WriteAllText(path, newJson);
        }


        private bool ValidateComputer(Computer computer)
        {
            var context = new ValidationContext(computer);
            var errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(computer, context, errors, true))
            {
                foreach (var error in errors)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
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
            lastAction.Text = "Сохранение";

            Computer Comp = new Computer
                            {
                                computerType = PCType.Text,
                                RAMSize = (int)(RAMSize.Value),
                                memorySize = memorySize.Value,
                                memoryType = memoryType.Text,
                                buyDate = buyDate.Value,
                                processor = comboBoxProcessor.Text,
                                card = comboBoxGraphicsCard.Text,
                            };

           if( ValidateComputer(Comp))
            {
                CalculatePrice();
                Comp.price = int.Parse(ComputerPrice.Text);


                try
                {
                    SaveComputerToJson(Comp, "computers.json");
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


            [Required(ErrorMessage = "Модель обязательна")]
            [RegularExpression(@"^(Server|PC|Laptop)$", ErrorMessage = "Допустимые значения: Server, PC, Laptop")]
            public string computerType {  get; set; }


            [Range(1, 128, ErrorMessage = "ОЗУ должно быть от 1 до 128 ГБ")]

            public int RAMSize { get; set; }

            [Range (120, 2048, ErrorMessage ="Память должна быть от 120 до 2048 ГБ")]
            public int memorySize { get; set; }

            public DateTime buyDate { get; set; }


            [RegularExpression(@"^(SSD|HDD)$", ErrorMessage = "Допустимые значения: SSD, HDD")]
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


            lastAction.Text = "Список";

            if (File.Exists("computers.json"))
            {
                string json = File.ReadAllText("computers.json");
                computers = JsonSerializer.Deserialize<BindingList<Computer>>(json) ?? new BindingList<Computer>();
            }
              
            ComputerList.DataSource = computers;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lastAction.Text = "О программе";

            MessageBox.Show("Version: 0.1\n\n\nDeveloper: Korobov E.O.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStriptime.Text = $"{DateTime.Now}";
        }

        private void PCType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void стоимостиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lastAction.Text = "Сортировка";

            List<Computer> computers = new List<Computer>();
            string json = File.ReadAllText("computers.json");
            computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();

            var sorted = computers
                .OrderByDescending(p => p.price)
                .ToList();


            search newSearch = new search(sorted, "Sorted_by_price");
            newSearch.ShowDialog();


        }

        private void размеруОЗУToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lastAction.Text = "Сортировка";


            List<Computer> computers = new List<Computer>();
            string json = File.ReadAllText("computers.json");
            computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();
            
            var sorted = computers
                .OrderByDescending(p => p.buyDate)
                .ToList();


            search newSearch = new search(sorted, "Sorted_by_buyDate");
            newSearch.ShowDialog();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            lastAction.Text = "Очистка";

            PCType.Text = "";
            RAMSize.ResetText();
            memorySize.Value = 120;
            this.lblFrequency.Text = this.memorySize.Value.ToString();
            memoryType.Text = "";
            buyDate.Value = DateTime.Now;
            comboBoxProcessor.Text = "";
            comboBoxGraphicsCard.Text = "";
            ComputerPrice.Text = "00000";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;
            button3.Text = (button3.Text == "Скрыть") ? "Показать" : "Скрыть";
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lastAction.Text = "Поиск";

            Find find = new Find();
            if(find.ShowDialog() == DialogResult.OK)
            {
                string request = find.GetRequest();
                List<Computer> fbf = new List<Computer>();

                bool isRegexValid = false;
                Regex regex = null;


                try
                {
                    regex = new Regex(request.Trim(), RegexOptions.IgnoreCase);
                    isRegexValid = true;
                }
                catch
                {
                    isRegexValid = false;
                }

                if (string.IsNullOrWhiteSpace(request))
                    fbf = computers.ToList();

                else
                {

                    if (isRegexValid)
                    {
                        fbf = computers.Where(comp =>
                            regex.IsMatch(comp.processor) ||
                            regex.IsMatch(comp.computerType) ||
                            regex.IsMatch(comp.card) ||
                            regex.IsMatch(comp.price.ToString()) ||
                            regex.IsMatch(comp.buyDate.ToString())).ToList();
                    }


                    else
                    {
                        request = request.Trim().ToLower();

                        fbf = computers
                            .Where(comp =>
                                (comp.processor).Contains(request) ||
                                comp.card.Contains(request) ||
                                (comp.computerType.ToLower() ?? "").Contains(request) ||
                                comp.price.ToString().Contains(request) ||
                                (comp.buyDate.ToString().ToLower() ?? "").Contains(request))
                            .ToList();
                    }

                }



                search find1 = new search(fbf, "find_computers");
                find1.ShowDialog();

            }

        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {

            lastAction.Text = "Поиск";


            Find find = new Find();
            if (find.ShowDialog() == DialogResult.OK)
            {
                string request = find.GetRequest();
                List<Computer> fbf = new List<Computer>();

                bool isRegexValid = false;
                Regex regex = null;


                try
                {
                    regex = new Regex(request.Trim(), RegexOptions.IgnoreCase);
                    isRegexValid = true;
                }
                catch
                {
                    isRegexValid = false;
                }

                if (string.IsNullOrWhiteSpace(request))
                    fbf = computers.ToList();

                else
                {

                    if (isRegexValid)
                    {
                        fbf = computers.Where(comp =>
                            regex.IsMatch(comp.processor) ||
                            regex.IsMatch(comp.computerType) ||
                            regex.IsMatch(comp.card) ||
                            regex.IsMatch(comp.price.ToString()) ||
                            regex.IsMatch(comp.buyDate.ToString())).ToList();
                    }


                    else
                    {
                        request = request.Trim().ToLower();

                        fbf = computers
                            .Where(comp =>
                                (comp.processor).Contains(request) ||
                                comp.card.Contains(request) ||
                                (comp.computerType.ToLower() ?? "").Contains(request) ||
                                comp.price.ToString().Contains(request) ||
                                (comp.buyDate.ToString().ToLower() ?? "").Contains(request))
                            .ToList();
                    }

                }



                search find1 = new search(fbf, "find_computers");
                find1.ShowDialog();

            }


        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void сортировкаПоДатеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lastAction.Text = "Сортировка";

            List<Computer> computers = new List<Computer>();
            string json = File.ReadAllText("computers.json");
            computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();

            var sorted = computers
                .OrderByDescending(p => p.buyDate)
                .ToList();


            search newSearch = new search(sorted, "Sorted_by_buyDate");
            newSearch.ShowDialog();

        }

        private void сортировкаПоЦенеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastAction.Text = "Сортировка";

            List<Computer> computers = new List<Computer>();
            string json = File.ReadAllText("computers.json");
            computers = JsonSerializer.Deserialize<List<Computer>>(json) ?? new List<Computer>();

            var sorted = computers
                .OrderByDescending(p => p.price)
                .ToList();


            search newSearch = new search(sorted, "Sorted_by_price");
            newSearch.ShowDialog();


        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            File.Delete("computers.json");
            MessageBox.Show("\"Computers.json\" удален");


        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            File.Copy("computers.json", "Nextcomputers.json", true);
            File.Copy("prevComputers.json", "computers.json", true);
            MessageBox.Show("Откат на 1");
            backButton.Enabled = false;
            nextButton.Enabled = true;

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

            File.Copy("computers.json", "prevComputers.json", true);
            File.Copy("nextComputers.json", "computers.json", true);
            MessageBox.Show("Наткат на 1");
            backButton.Enabled = true;
            nextButton.Enabled = false;
        }
    }
}
