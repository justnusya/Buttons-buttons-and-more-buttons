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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using secondtry;

namespace Two_options_one_choice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _random;
        public MainWindow()
        {
            InitializeComponent();
            sadsound.Source = new Uri("C:\\Users\\Legion\\source\\repos\\Many buttons\\Two options one choice\\sadsound.mp4");
            sadsound.Play();
            _random = new Random();
        }
        private void No_etrance(object sender, MouseEventArgs e)
        {
            double X = _random.Next(0, (int)(this.ActualWidth - NO.ActualWidth));
            double Y = _random.Next(0, (int)(this.ActualHeight - NO.ActualHeight));
            NO.Margin = new Thickness(X, Y, 0, 0);
        }

        private void YES_Click(object sender, RoutedEventArgs e)
        {
            sadsound.Stop();
            happysound.Source = new Uri("C:\\Users\\Legion\\source\\repos\\Many buttons\\Two options one choice\\happysound.mp4");
            happysound.Play();

            Window.Children.Remove(caption);
            Window.Children.Remove(YES);
            Window.Children.Remove(NO);
            Window.Children.Remove(cutie);

            for (int i = 0; i < 6; i++)
            {
                Image heartImage = new Image
                {
                    Source = new BitmapImage(new Uri("C:\\Users\\Legion\\source\\repos\\Many buttons\\Two options one choice\\heart.png")),
                    Width = 50,
                    Height = 50
                };

                double randomX = _random.Next(0, 750);
                double randomY = _random.Next(0, 400);

                Canvas.SetLeft(heartImage, randomX);
                Canvas.SetTop(heartImage, randomY);
                HeartCanvas.Children.Add(heartImage);
            }

            Label label = new Label();
            label.Content = "Дякую!";
            label.Margin = new Thickness(300,40,0,0);
            label.FontSize = 50;
            label.FontWeight = FontWeights.ExtraBold;
            label.Foreground = new SolidColorBrush(Color.FromRgb(237, 43, 165));
            Window.Children.Add(label);

            Image newImage = new Image();

            newImage.Source = new BitmapImage(new Uri("C:\\Users\\Legion\\source\\repos\\Many buttons\\Two options one choice\\cutie.png"));
            newImage.Width = 100;
            newImage.Height = 100;
            newImage.Margin = new Thickness(150);
            ImageStackPanel.Children.Add(newImage);

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 100,
                To = 250,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = false
            };
            DoubleAnimation heightAnimation = widthAnimation;

            ScaleTransform scaleTransform = new ScaleTransform();
            newImage.RenderTransform = scaleTransform;
            newImage.RenderTransformOrigin = new Point(0.5, 0.5);

            newImage.BeginAnimation(Image.WidthProperty, widthAnimation);
            newImage.BeginAnimation(Image.HeightProperty, heightAnimation);
        }
        private void NO_Click(object sender, RoutedEventArgs e)
        {
            Window.Children.Remove(NO);
            CustomMessage customMessageBox = new CustomMessage($"Чшшш.. Ви нічого не бачили..",
                    "C:\\Users\\Legion\\source\\repos\\Many buttons\\Two options one choice\\silence.png");
            customMessageBox.ShowDialog();
        }
    }
}
