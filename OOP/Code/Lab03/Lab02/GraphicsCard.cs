using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Lab02
{
    public partial class GraphicsCard : Form
    {

        private string saveFilePath = "videocards.json";

        public GraphicsCard()
        {
            InitializeComponent();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click (object sender,EventArgs e)
            {
                if (ValidateInputs(txtModel, txtSeries, txtMemorySize, cmbMemoryType, txtGPUClock, txtMemoryClock, txtBusWidth))
                {
                    decimal price = CalculatePrice(
                        int.Parse(txtMemorySize.Text),
                        cmbMemoryType.SelectedItem.ToString(),
                        int.Parse(txtGPUClock.Text),
                        int.Parse(txtMemoryClock.Text),
                        int.Parse(txtBusWidth.Text)
                    );
        lblCalculatedPrice.Text = $"{price:N0} руб.";
                }
            }

        private async void  btnSave_Click(object sender, EventArgs e)
        {
    if (ValidateInputs(txtModel, txtSeries, txtMemorySize, cmbMemoryType, txtGPUClock, txtMemoryClock, txtBusWidth))
    {
        var videoCard = new VideoCard
        {
            Model = txtModel.Text,
            Series = txtSeries.Text,
            MemorySize = int.Parse(txtMemorySize.Text),
            MemoryType = cmbMemoryType.SelectedItem.ToString(),
            GPUClock = int.Parse(txtGPUClock.Text),
            MemoryClock = int.Parse(txtMemoryClock.Text),
            BusWidth = int.Parse(txtBusWidth.Text),
            Price = decimal.Parse(lblCalculatedPrice.Text.Replace(" руб.", "").Replace(",", ""))
        };

        try
        {
             await SaveVideoCardToJson(videoCard);
            MessageBox.Show("Данные успешно сохранены в JSON файл!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    }
        

        private bool ValidateInputs(TextBox txtModel, TextBox txtSeries, TextBox txtMemorySize, ComboBox cmbMemoryType,
                                    TextBox txtGPUClock, TextBox txtMemoryClock, TextBox txtBusWidth)
{
    if (string.IsNullOrWhiteSpace(txtModel.Text))
    {
        MessageBox.Show("Введите модель видеокарты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (string.IsNullOrWhiteSpace(txtSeries.Text))
    {
        MessageBox.Show("Введите серию видеокарты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (!int.TryParse(txtMemorySize.Text, out int memorySize) || memorySize <= 0 || memorySize > 48)
    {
        MessageBox.Show("Введите корректный объем видеопамяти (1-48 ГБ)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (cmbMemoryType.SelectedIndex == -1)
    {
        MessageBox.Show("Выберите тип видеопамяти!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (!int.TryParse(txtGPUClock.Text, out int gpuClock) || gpuClock <= 0 || gpuClock > 3000)
    {
        MessageBox.Show("Введите корректную частоту графического процессора (1-3000 МГц)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (!int.TryParse(txtMemoryClock.Text, out int memoryClock) || memoryClock <= 0 || memoryClock > 25000)
    {
        MessageBox.Show("Введите корректную частоту памяти (1-25000 МГц)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    if (!int.TryParse(txtBusWidth.Text, out int busWidth) || busWidth <= 0 || busWidth > 512)
    {
        MessageBox.Show("Введите корректную ширину шины (1-512 бит)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    return true;
}

private decimal CalculatePrice(int memorySize, string memoryType, int gpuClock, int memoryClock, int busWidth)
{
    decimal basePrice = 10000;
    decimal price = basePrice;

    price += memorySize * 2000;
    price += gpuClock * 10;
    price += memoryClock * 0.5m;
    price += busWidth * 50;

    switch (memoryType)
    {
        case "GDDR5": price *= 1.0m; break;
        case "GDDR6": price *= 1.2m; break;
        case "GDDR6X": price *= 1.5m; break;
        case "HBM2": price *= 1.8m; break;
        case "HBM2E": price *= 2.0m; break;
    }

    return price;
}

private async Task SaveVideoCardToJson(VideoCard videoCard)
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    List<VideoCard> videoCards = new List<VideoCard>();

    // Если файл существует, загружаем существующие данные
    if (File.Exists(saveFilePath))
    {
        string json = System.IO.File.ReadAllText(saveFilePath);
        videoCards = JsonSerializer.Deserialize<List<VideoCard>>(json) ?? new List<VideoCard>();
    }

    // Добавляем новую видеокарту
    videoCards.Add(videoCard);

    // Сохраняем обновленный список
    string newJson = JsonSerializer.Serialize(videoCards, options);
     System.IO.File.WriteAllText(saveFilePath, newJson);
}
    }

    public class VideoCard
{
    public string Model { get; set; }
    public string Series { get; set; }
    public int MemorySize { get; set; }
    public string MemoryType { get; set; }
    public int GPUClock { get; set; }
    public int MemoryClock { get; set; }
    public int BusWidth { get; set; }
    public decimal Price { get; set; }
        public string DisplayInfo => $"{Series} {Model}";
    }
}

    

