using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CADesktopUI.Helpers;
using IronPython.Hosting;
using Microsoft.Win32;

namespace CADesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uri PictureUri; 
        public MainWindow()
        {
            InitializeComponent();
            RunClassificationButton.IsEnabled = false;
        }

        

        private async void RunClassificationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextHelper textHelper = new TextHelper();
                PythonHelper pythonHelper = new PythonHelper();

                textHelper.WriteToFile(@"C:\Users\Andrian\Desktop\Projects\CatsVsDogs\ClassificatonAplication\CANeuralNetwork\DataFromUI\TextData.txt", PictureUri.ToString());


                var result = await pythonHelper.RunFileAsync(@"C:\Users\Andrian\Desktop\Projects\CatsVsDogs\ClassificatonAplication\CANeuralNetwork\Model.py");
                string resultString = textHelper.FormatResult(result);
                Result.Content = resultString; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPictureButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                PictureUri = new Uri(op.FileName);
                BorderPicture.ImageSource = new BitmapImage(PictureUri);
                RunClassificationButton.IsEnabled = true;
            }
        }
    }
}
