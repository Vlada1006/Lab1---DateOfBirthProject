using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DateOfBirthProject
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SelectedDate = datePicker.SelectedDate ?? DateTime.MinValue;
            viewModel.CalculateAge();
            viewModel.ShowBirthdayWishes();
            dayZodiacTextBlock.Text = viewModel.ZodiakSignByDay(viewModel.SelectedDate);
            yearZodiacTextBlock.Text = viewModel.ZodiakSignByYear(viewModel.SelectedDate);
        }

        
    }
}