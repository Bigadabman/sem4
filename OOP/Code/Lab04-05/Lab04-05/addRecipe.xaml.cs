using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Lab04_05
{
    /// <summary>
    /// Логика взаимодействия для addRecipe.xaml
    /// </summary>
    public partial class addRecipe : Window
    {
        public addRecipe()
        {
            InitializeComponent();
            addIngredient_Click(null, null);
            addIngredient_Click(null, null);

            addStep_Click(null, null);
            addStep_Click(null, null);
        }


        

        private void PortionCounterPlus_Click(object sender, RoutedEventArgs e)
        {
            this.PortionCounter.Content = int.Parse(this.PortionCounter.Content.ToString()) + 1;
            PortionCounterMinus.IsEnabled = true;
        }

        private void PortionCounterMinus_Click(object sender, RoutedEventArgs e)
        {

            if(int.Parse(this.PortionCounter.Content.ToString()) > 1)
            {
                
                this.PortionCounter.Content = int.Parse(this.PortionCounter.Content.ToString()) - 1;
            }
            else if (int.Parse(this.PortionCounter.Content.ToString()) == 1)
            {
                PortionCounterMinus.IsEnabled = false;
                this.PortionCounter.Content = int.Parse(this.PortionCounter.Content.ToString()) - 1;
            }
            if (int.Parse(this.PortionCounter.Content.ToString()) <= 0)
            {
                
                return;
            }
            
            
        }

        private void addIngredient_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid();
            

            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(400) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            
            TextBox ingredientName = new TextBox()
            {
                Height = 50,
                
            };
            Grid.SetRow(ingredientName, 1);
            Grid.SetColumn(ingredientName, 0);

            
            TextBox ingredientAmount = new TextBox()
            {
                Height = 50,
                
            };
            Grid.SetRow(ingredientAmount, 1);
            Grid.SetColumn(ingredientAmount, 1);

            
            Label unitLabel = new Label()
            {
                Content = "Гр",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetRow(unitLabel, 1);
            Grid.SetColumn(unitLabel, 2);

            
            Button deleteButton = new Button()
            {
                Content = "X",
                Width = 30,
                Height = 30,
               
            };
            Grid.SetRow(deleteButton, 1);
            Grid.SetColumn(deleteButton, 3);

           
            deleteButton.Click += (s, args) =>
            {
                IngredientList.Children.Remove(grid);
            };

            grid.Children.Add(ingredientName);
            grid.Children.Add(ingredientAmount);
            grid.Children.Add(unitLabel);
            grid.Children.Add(deleteButton);

            IngredientList.Children.Insert(IngredientList.Children.Count - 1, grid);
        }

        


        private void addStep_Click(object sender, RoutedEventArgs e)
        {
            
            Grid grid = new Grid();
            

            
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(600) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            
            Label stepLabel = new Label()
            {
                Content = $"Шаг {Steps.Children.Count - 1}",
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 5)
            };
            Grid.SetRow(stepLabel, 0);

            TextBox stepDescription = new TextBox()
            {
                Height = 100,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };
            Grid.SetRow(stepDescription, 1);
            Grid.SetColumn(stepDescription, 0);

            Button deleteButton = new Button()
            {
                Content = "X",
                Width = 30,
                Height = 30,
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetRow(deleteButton, 1);
            Grid.SetColumn(deleteButton, 1);
            
            
            deleteButton.Click += (s, args) =>
            {
                Steps.Children.Remove(grid);
                UpdateStepNumbers();
            };

            
            grid.Children.Add(stepLabel);
            grid.Children.Add(stepDescription);
            grid.Children.Add(deleteButton);


            Steps.Children.Insert(Steps.Children.Count - 1, grid) ;
        }

       
        private void UpdateStepNumbers()
        {
            for (int i = 0; i < Steps.Children.Count; i++)
            {
                if (Steps.Children[i] is Grid grid && grid.Children[0] is Label label)
                {
                    label.Content = $"Шаг {i}";
                }
            }
        }




        private bool ValidateRecipe(Recipe recipe)
        {
            var context = new ValidationContext(recipe);
            var errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if(!Validator.TryValidateObject(recipe, context, errors, true))
            {

                foreach(var error in errors)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
                return false;

            }

            return true;


        }



        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == true)
            {

                RecipeImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }



        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {



            Recipe recipe = new Recipe
            {
                name = RecipeName.Text.Trim(),
                PortionAmount = int.Parse(PortionCounter.Content.ToString()),
                Time = (int)hours.Value + (int)minutes.Value,
                Description = Description.Text.Trim(),
                ingredients = new List<string>(),
                steps = new List<string>(),
                ImagePath = string.Empty 
            };



            if (RecipeImage.Source is BitmapImage bitmapImage && bitmapImage.UriSource != null)
            {
                string sourceImagePath = bitmapImage.UriSource.LocalPath;
                string appDirectory = Directory.GetCurrentDirectory();
                string imageFolder = System.IO.Path.Combine(appDirectory, "RecipeImages");


                Directory.CreateDirectory(imageFolder);

   
                string fileName = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(sourceImagePath)}";
                string destPath = System.IO.Path.Combine(imageFolder, fileName);

                File.Copy(sourceImagePath, destPath);

                recipe.ImagePath = System.IO.Path.Combine("RecipeImages", fileName);
            }


            foreach (var child in IngredientList.Children)
                {
                    if (child is Grid grid)
                    {

                        var ingredientBox = grid.Children.OfType<TextBox>().FirstOrDefault();
                        if (ingredientBox != null && !string.IsNullOrWhiteSpace(ingredientBox.Text))
                        {
                            recipe.ingredients.Add(ingredientBox.Text.Trim());
                        }
                    }
                }


                foreach (var child in Steps.Children)
                {
                    if (child is Grid grid)
                    {

                        var stepBox = grid.Children.OfType<TextBox>().FirstOrDefault();
                        if (stepBox != null && !string.IsNullOrWhiteSpace(stepBox.Text))
                        {
                            recipe.steps.Add(stepBox.Text.Trim());
                        }
                    }
                }

                if (!ValidateRecipe(recipe))
                {
                    MessageBox.Show("Ошибка");
                    return;
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                List<Recipe> recipes = new List<Recipe>();

                string filePath = "Resources/Recipes.json";

                
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    recipes = JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
                }

                recipes.Add(recipe);
                string newJson = JsonSerializer.Serialize(recipes, options);
                File.WriteAllText(filePath, newJson);


            MainWindow.LoadRecipes();

                MessageBox.Show("Рецепт успешно сохранен!");
                this.Close();                


        }
    }
}
