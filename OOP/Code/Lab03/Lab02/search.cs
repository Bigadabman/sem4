using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab02.CompCreate;

namespace Lab02
{
    public partial class search : Form
    {

        List<Computer> data;
        string fileName;
        public search(List<Computer> computers, string sortingMethod)
        {
            InitializeComponent();
            fileName = sortingMethod;
            ListGrid.DataSource = computers;
            data = computers;

        }

        private void search_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSortedData(data, $"{fileName}.json");
        }


        private void SaveSortedData(List<Computer> data, string filename)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(path, JsonSerializer.Serialize(data, jsonOptions));

                MessageBox.Show($"Данные сохранены в {filename}!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка");
            }
        }


    }
}
