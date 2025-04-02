using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace secondtry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int from = int.Parse(From.Text);
            int to = int.Parse(To.Text);
            int step = int.Parse(Step.Text);

            for (int i = from; i <= to; i += step)
            {
                Button button = new Button
                {
                    Content = i.ToString(),
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(5)
                };

                ButtonsWrapPanel.Children.Add(button);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ButtonsWrapPanel.Children.Clear();
        }
    }
}
