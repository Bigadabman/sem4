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
using System.ComponentModel.DataAnnotations;
using static Lab02.CompCreate;

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


        private async void  btnSave_Click(object sender, EventArgs e)
        {

            var videoCard = new VideoCard
            {
                Model = txtModel.Text,
                Series = txtSeries.Text,
                //MemorySize = int.Parse(txtMemorySize.Text),
                MemoryType = cmbMemoryType.Text,
                //GPUClock = int.Parse(txtGPUClock.Text),
                //MemoryClock = int.Parse(txtMemoryClock.Text),
                //BusWidth = int.Parse(txtBusWidth.Text),

            };

            int.TryParse(txtGPUClock.Text, out var GpuClock);
            int.TryParse(txtMemorySize.Text, out var memorySize);
            int.TryParse(txtMemoryClock.Text, out var MemoryClock);
            int.TryParse(txtBusWidth.Text, out var BusWidth);
            videoCard.GPUClock = GpuClock;
            videoCard.MemorySize = memorySize;
            videoCard.MemoryClock = MemoryClock;
            videoCard.BusWidth = BusWidth;

            if (ValidateInputs(videoCard))
    {

                decimal price = CalculatePrice(
                       int.Parse(txtMemorySize.Text),
                       cmbMemoryType.SelectedItem.ToString(),
                       int.Parse(txtGPUClock.Text),
                       int.Parse(txtMemoryClock.Text),
                       int.Parse(txtBusWidth.Text));

                lblCalculatedPrice.Text = $"{price:N0} руб.";

                videoCard.Price = decimal.Parse(lblCalculatedPrice.Text.Replace(" руб.", "").Replace(",", ""));

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
        

        private bool ValidateInputs(VideoCard graphicsCard)
        {
            var context = new ValidationContext(graphicsCard);
            var errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(graphicsCard, context, errors, true))
            {
                foreach (var error in errors)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
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
        [Required(ErrorMessage = "Модель обязательна")]
        [StringLength(15, MinimumLength = 2, ErrorMessage ="Длина от 2 до 15")]
    public string Model { get; set; }
        [Required(ErrorMessage = "Модель обязательна")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина от 2 до 15")]
        public string Series { get; set; }

        [Required(ErrorMessage = "Введите объем прамяти")]
        [Range(1, 48, ErrorMessage = "Обхем памяти от 1 до 48 ГБ")]
    public int MemorySize { get; set; }

        [Required(ErrorMessage = "Выберите тип памяти")]
        [RegularExpression(@"^(GDDR5|GDDR6|GDDR6X)?", ErrorMessage = "Видеопамять модет быть GDDR5, GDDR6, GDDR6X")]
    public string MemoryType { get; set; }
        [Required(ErrorMessage = "Введите частоту графического процессора")]
        [Range(1, 3000, ErrorMessage = "частота графического процессора 1-3000 МГц")]
    public int GPUClock { get; set; }

        [Required(ErrorMessage = "Введите частоту памяти")]
        [Range(1, 25000, ErrorMessage = "частота памяти 1-25000 МГц")]
    public int MemoryClock { get; set; }

        [Required(ErrorMessage = "Введите ширину шины")]
        [Range(1, 512, ErrorMessage = "ширина шины 1-512 бит")]
    public int BusWidth { get; set; }
    public decimal Price { get; set; }
        public string DisplayInfo => $"{Series} {Model}";
    }
}

    

