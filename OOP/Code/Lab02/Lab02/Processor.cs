using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;
namespace Lab02
{
    public partial class Processor : Form
    {

        private string saveFilePath = "processors.json";

        public Processor()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

     

        private void Processor_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnCalculate_Click(object sender, EventArgs e)
            {
                if (ValidateInputs(txtModel, txtSeries, txtCores, txtFrequency, txtMaxFrequency, txtCache))
                {
                    int architecture = rbX64.Checked ? 64 : 32;
        decimal performance = CalculatePerformance(
            int.Parse(txtCores.Text),
            txtFrequency.Value,
            decimal.Parse(txtMaxFrequency.Text),
            int.Parse(txtCache.Text),
            architecture
        );
        lblCalculatedPerformance.Text = $"{performance:N0} баллов";
                }
}

private void btnSave_Click (object sender, EventArgs e) 
{
    if (ValidateInputs(txtModel, txtSeries, txtCores, txtFrequency, txtMaxFrequency, txtCache))
    {
        var processor = new Processors
        {
            Model = txtModel.Text,
            Series = txtSeries.Text,
            Cores = int.Parse(txtCores.Text),
            Frequency = (txtFrequency.Value),
            MaxFrequency = decimal.Parse(txtMaxFrequency.Text),
            Architecture = rbX64.Checked ? "x64" : "x86",
            CacheSize = int.Parse(txtCache.Text),
            Performance = decimal.Parse(lblCalculatedPerformance.Text.Replace(" BYN", "").Replace(",", ""))
        };

        try
        {
            SaveProcessorToJson(processor);
            MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
        

     private bool ValidateInputs(TextBox txtModel, TextBox txtSeries, NumericUpDown txtCores,
                                      TrackBar txtFrequency, TextBox txtMaxFrequency, TextBox txtCache)
    {
        if (string.IsNullOrWhiteSpace(txtModel.Text))
        {
            MessageBox.Show("Введите модель процессора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSeries.Text))
        {
            MessageBox.Show("Введите серию процессора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(txtCores.Text, out int cores) || cores <= 0 || cores > 128)
        {
            MessageBox.Show("Введите корректное количество ядер (1-128)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (txtFrequency.Value <= 0 || txtFrequency.Value > 5500)
        {
            MessageBox.Show("Введите корректную частоту (1-5500 МГц)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!decimal.TryParse(txtMaxFrequency.Text, out decimal maxFreq) || maxFreq <= 0 || maxFreq > 5500 || maxFreq < txtFrequency.Value)
        {
            MessageBox.Show("Введите корректную максимальную частоту (1-5500 МГц)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(txtCache.Text, out int cache) || cache <= 0 || cache > 128)
        {
            MessageBox.Show("Введите корректный размер кэша (1-128 МБ)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private decimal CalculatePerformance(int cores, decimal frequency, decimal maxFrequency, int cacheSize, int architecture)
    {
        // Формула для расчета производительности (условная)
        decimal performance = cores * (frequency + maxFrequency) / (2 * 100);
        performance += cacheSize + 50;
        performance *= architecture == 64 ? 1.5m : 1.0m;
        return performance;
    }

    private void SaveProcessorToJson(Processors processor)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        List<Processors> processors = new List<Processors>();

        // Если файл существует, загружаем существующие данные
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            processors = JsonSerializer.Deserialize<List<Processors>>(json) ?? new List<Processors>();
        }

        // Добавляем новый процессор
        processors.Add(processor);
            
        // Сохраняем обновленный список
        string newJson = JsonSerializer.Serialize(processors, options);
        File.WriteAllText(saveFilePath, newJson);
    }
    

    public class Processors
    {
        public string Model { get; set; }
        public string Series { get; set; }
        public int Cores { get; set; }
        public decimal Frequency { get; set; }
        public decimal MaxFrequency { get; set; }
        public string Architecture { get; set; }
        public int CacheSize { get; set; }
        public decimal Performance { get; set; }

            public string DisplayInfo => $"{Series} {Model}";

            private static Processors LoadFromJsoN(string filepath)
            {
                var serializer = new XmlSerializer(typeof(Processors));
                using (var reader = new StreamReader(filepath))
                {
                    return (Processors)serializer.Deserialize(reader);
                }
            }
        }

        

        private void txtFrequency_Scroll(object sender, EventArgs e)
        {
            this.label1.Text = this.txtFrequency.Value.ToString();
        }

        private void lblCalculatedPerformance_Click(object sender, EventArgs e)
        {

        }


        
    }
}
