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
using System.Windows.Shapes;

namespace secondtry
{
    /// <summary>
    /// Interaction logic for CustomMessage.xaml
    /// </summary>
    public partial class CustomMessage : Window
    {
        public CustomMessage(string message, string imagePath)
        {
            InitializeComponent();
            MessageText.Text = message; // Встановлюємо текст повідомлення
            MessageImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)); // Встановлюємо зображення
        }

        // Обробник натискання кнопки
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закриваємо вікно при натисканні кнопки
        }
    }
}
