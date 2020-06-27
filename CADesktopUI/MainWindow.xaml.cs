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
            try
            {
                PythonHelper pythonHelper = new PythonHelper();
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
