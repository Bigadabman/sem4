using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Globalization;
using System.Threading;

namespace Lab04_05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static  List<Recipe> recipes = new List<Recipe>();
        private const string RecipesPath = "Resources/Recipes.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadRecipes();
            CreateRecipeCards(recipes);
        }



        private void LoadLanguage(string cultureCode)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);

            
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(
                new ResourceDictionary()
                {
                    Source = new Uri($"/Localization/Strings.{cultureCode}.xaml", UriKind.Relative)
                });
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var newCulture = currentCulture == "ru-RU" ? "ru-RU" : "en-EN";
            LoadLanguage(newCulture);
        }




        public static void LoadRecipes()
        {
            if (File.Exists(RecipesPath))
            {
                string json = File.ReadAllText(RecipesPath);
                recipes = recipes = JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>(); ;
            }
        }



        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void MaxTime_TextChanged(object sender, TextChangedEventArgs e)
        {
           ApplyFilters();
        }

        private void ApplyFilters()
        {


            var filtered = recipes.Where(r =>
                (string.IsNullOrEmpty(SearchBox.Text) ||
                r.name.Contains(SearchBox.Text)))
                .ToList();


            if (int.TryParse(MaxTime.Text, out int maxTime))
            {
                filtered = filtered.Where(r => r.Time <= maxTime).ToList();
            }

            CreateRecipeCards(filtered);
        }

        


        private void CreateRecipeCards(List<Recipe> rec)
        {
            WrapPanel wrapPanel = new WrapPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            foreach (var recipe in rec)
            {
                Border card = new Border
                {
                    Width = 150,
                    Height = 200,
                    Margin = new Thickness(10),
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(10),
                    Effect = new DropShadowEffect
                    {
                        BlurRadius = 10,
                        Opacity = 0.2,
                        ShadowDepth = 3
                    },

                };

                StackPanel content = new StackPanel();
                content.MouseDown += (sender, e) =>
                {
                    RecipeWindow recipeWindow = new RecipeWindow(recipe);
                    recipeWindow.Show();
                };


                if (!string.IsNullOrEmpty(recipe.ImagePath))
                {
                    Image img = new Image
                    {
                        Source = new BitmapImage(new Uri(
                            System.IO.Path.Combine(Directory.GetCurrentDirectory(),
                            recipe.ImagePath))),
                        Height = 100,
                        Stretch = Stretch.UniformToFill
                    };
                    content.Children.Add(img);
                }


                TextBlock title = new TextBlock
                {
                    Text = recipe.name,
                    FontSize = 16,
                    Margin = new Thickness(10, 5, 10, 0),
                    FontWeight = FontWeights.Bold
                };
                content.Children.Add(title);

                TextBlock details = new TextBlock
                {
                    Text = $"Порций: {recipe.PortionAmount}\nВремя: {recipe.Time} мин",
                    Margin = new Thickness(10, 0, 10, 0),
                    TextWrapping = TextWrapping.Wrap
                };
                

                card.Child = content;

                Button del = new Button
                {
                    Content = "Удалить",
                    
                };
                del.Click += (sender, e) =>
                {
                    wrapPanel.Children.Remove(card);
                };


                 content.Children.Add(details);
                content.Children.Add(del);
                wrapPanel.Children.Add(card);
            }


           Container.Children.Clear();
            Container.Children.Add(wrapPanel);
        }


        public void RefreshRecipes()
        {
            LoadRecipes();
            CreateRecipeCards(recipes);
        }



        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            addRecipe addRec = new addRecipe();
            addRec.Show();
            
        }
    }
}
