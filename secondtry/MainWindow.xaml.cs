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
            if (to >= 10000 || to <= 0)
            {
                CustomMessage customMessageBox = new CustomMessage($"Мда, я ж не конвеєр... \nСамі створюйте по {to} кнопок!",
                    "C:\\Users\\Legion\\source\\repos\\Many buttons\\secondtry\\emoji.png");
                customMessageBox.ShowDialog();
            }
            else
            {
                for (int i = from; i <= to; i += step)
                {
                    Button button = new Button
                    {
                        Content = i.ToString(),
                        Width = 80,
                        Height = 30,
                        Margin = new Thickness(5)
                    };
                    button.Tag = false;
                    button.Click += Button_Clicked;
                    ButtonsWrapPanel.Children.Add(button);
                }
            }
        }
        private (bool, int) IsComposite(int number)
        {
            if (number <= 1) return (false, -1);
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return (true, i);
            }
            return (false, -1);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            int kratnist = int.Parse(Kratnist.Text);
            List<Button> buttonsToRemove = new List<Button>();

            foreach (UIElement element in ButtonsWrapPanel.Children)
            {
                if (element is Button button && int.Parse(button.Content.ToString()) % kratnist == 0)
                {
                    buttonsToRemove.Add(button);
                }
            }
            foreach (Button button in buttonsToRemove)
            {
                ButtonsWrapPanel.Children.Remove(button);
            }
        }
        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int buttonValue = int.Parse(clickedButton.Content.ToString());
            var (isSkladene, firstDivisor) = IsComposite(buttonValue);

            bool isClicked = (bool)clickedButton.Tag;

            if (isClicked)
            {
                CustomMessage customMessageBox = new CustomMessage($"Скільки можна повторювати... \n{buttonValue} — складене число, \nбо можна поділити на {firstDivisor}!",
                    "C:\\Users\\Legion\\source\\repos\\Many buttons\\secondtry\\emoji.png");
                customMessageBox.ShowDialog();
            }
            else
            {
                if (isSkladene)
                {
                    CustomMessage customMessageBox = new CustomMessage($"{buttonValue} — складене число, бо можна поділити на {firstDivisor}",
                        "C:\\Users\\Legion\\source\\repos\\Many buttons\\secondtry\\thumb_up.png");
                    customMessageBox.ShowDialog();
                }
                else
                {
                    CustomMessage customMessageBox = new CustomMessage($"{buttonValue} — просте число",
                        "C:\\Users\\Legion\\source\\repos\\Many buttons\\secondtry\\thumb_up.png");
                    customMessageBox.ShowDialog();
                }

                clickedButton.Tag = true; 
            }
        }
    }
}

