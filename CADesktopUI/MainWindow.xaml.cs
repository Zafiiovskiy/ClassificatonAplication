using System;
using System.Windows;
using CADesktopUI.Helpers;
using IronPython.Hosting;

namespace CADesktopUI
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

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            string TextBoxText = TestTextBox.Text;
            try
            {
                TextHelper textHelper = new TextHelper();
                PythonHelper pythonHelper = new PythonHelper();

                textHelper.WriteToFile(@"C:\Users\Andrian\Desktop\Projects\CatsVsDogs\ClassificatonAplication\CANeuralNetwork\DataFromUI\TextData.txt", TextBoxText);
                var result = pythonHelper.RunFile(@"C:\Users\Andrian\Desktop\Projects\CatsVsDogs\ClassificatonAplication\CANeuralNetwork\CANeuralNetwork.py");
                MessageBox.Show(result);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
