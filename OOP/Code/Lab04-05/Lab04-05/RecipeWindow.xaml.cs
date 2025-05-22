using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab04_05
{
    /// <summary>
    /// Логика взаимодействия для RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        Recipe recipe = new Recipe();
        public RecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            dataLoading();
        }


        private void dataLoading()
        {

            Label name = new Label
            {
                Style = (Style)FindResource("HeaderStyle"),
                Content = recipe.name
            };
            Container.Children.Add(name);

            StackPanel detailsPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 15)
            };

            detailsPanel.Children.Add(new Label
            {
                Style = (Style)FindResource("BodyTextStyle"),
                Content = $"🍴 {recipe.PortionAmount} порций",
                Margin = new Thickness(0, 0, 15, 0)
            });

            detailsPanel.Children.Add(new Label
            {
                Style = (Style)FindResource("BodyTextStyle"),
                Content = $"⏱ {recipe.Time} минут"
            });

            Container.Children.Add(detailsPanel);

            if (!string.IsNullOrEmpty(recipe.ImagePath))
            {
                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(
                        System.IO.Path.Combine(Directory.GetCurrentDirectory(),
                        recipe.ImagePath)))
                };
                Container.Children.Add(image);
            }

            Container.Children.Add(new Label
            {
                Style = (Style)FindResource("BodyTextStyle"),
                Content = recipe.Description,
              
            });


            Container.Children.Add(new Label
            {
                Style = (Style)FindResource("SubHeaderStyle"),
                Content = "Ингредиенты"
            });

            ListBox ingredientsList = new ListBox
            {
                Margin = new Thickness(0, 0, 0, 20),
                BorderThickness = new Thickness(0)
            };

            foreach (var ingredient in recipe.ingredients)
            {
                ingredientsList.Items.Add(new Label
                {
                    Style = (Style)FindResource("BodyTextStyle"),
                    Content = $"• {ingredient}"
                });
            }
            Container.Children.Add(ingredientsList);


            Container.Children.Add(new Label
            {
                Style = (Style)FindResource("SubHeaderStyle"),
                Content = "Шаги приготовления"
            });

            StackPanel stepsPanel = new StackPanel { Margin = new Thickness(0, 0, 0, 20) };
            int stepNumber = 1;

            foreach (var step in recipe.steps)
            {
                stepsPanel.Children.Add(new Label
                {
                    Style = (Style)FindResource("BodyTextStyle"),
                    Content = $"{stepNumber++}. {step}",
                   
                });
            }
            Container.Children.Add(stepsPanel);

            

        }

    }
}
