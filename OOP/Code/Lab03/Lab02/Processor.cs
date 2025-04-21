using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Lab02.Processor;
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


private void btnSave_Click (object sender, EventArgs e) 
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

            };


    if (ValidateInputs(processor))
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


                processor.Performance = decimal.Parse(lblCalculatedPerformance.Text.Replace(" BYN", "").Replace(",", ""));
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


        private bool ValidateInputs(Processors processor)
        {
            var context = new ValidationContext(processor);
            var errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(processor, context, errors, true))
            {
                foreach (var error in errors)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
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

            [Required(ErrorMessage = "Модель обязательна")]
            [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина от 2 до 15")]
        public string Model { get; set; }

            [Required(ErrorMessage = "Серия обязательна")]
            [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина от 2 до 15")]
            public string Series { get; set; }
            [Required(ErrorMessage = "Введите количество ядер")]
            [Range(1, 128, ErrorMessage = "Количество ядер от  1 до 128")]
        public int Cores { get; set; }

            [Required(ErrorMessage = "Введите частоту")]
            [Range(1, 5500, ErrorMessage = "Частота от 1 до 5500 МГц")]
        public decimal Frequency { get; set; }

            [Required(ErrorMessage = "Введите максимальную частоту")]
            [Range(1, 5500, ErrorMessage = "Максимальная частота от 1 до 5500 МГц")]
            public decimal? MaxFrequency { get; set; }

            [RegularExpression("^(x86|x64)?", ErrorMessage = "Архитектура x86 или х64")]
        public string Architecture { get; set; }

            [Required(ErrorMessage = "Введите объем кэша")]
            [Range(1, 128, ErrorMessage = "Кэш от 1 до 128")]
        public int? CacheSize { get; set; }
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

        private void CoreAmountSort_Click(object sender, EventArgs e)
        {
        
        }

        private void FrequencySort_Click(object sender, EventArgs e)
        {
            
        }
    }
}
