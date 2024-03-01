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

        public MainWindow()
        {
            InitializeComponent();

            


        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = datePicker.SelectedDate.Value;

            if (datePicker.SelectedDate.HasValue)
            {

                int age = CalculateAge(selectedDate);

                if(age < 0 )
                {
                    MessageBox.Show("Схоже, ви ще не народилися.. Спробуйте ще раз!");
                    return;
                }
                if (age > 135)
                {
                    MessageBox.Show("Щось забагато вам рочків.. Спробуйте ще раз!");
                    return;
                }
                else
                {
                    if(age == 1 )
                        ageTextBlock.Text = $" Вам {age} рік.";
                    if (age > 1 && age <= 4 )
                        ageTextBlock.Text = $" Вам {age} роки.";
                    if (age >= 5 || age == 0)
                        ageTextBlock.Text = $" Вам {age} років.";

                }
            }
            BirthdayWishes(selectedDate);

            ZodiakSignByDay(selectedDate);

            ZodiakSignByYear(selectedDate);


        }

        public static int CalculateAge(DateTime selectedDate) 
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - selectedDate.Year;

            if (selectedDate.Month > currentDate.Month || (selectedDate.Month == currentDate.Month && selectedDate.Day > currentDate.Day))
            {
                age--;
            }
            return age;
        }


        public static string BirthdayWishes(DateTime selectedDate)
        {
            DateTime currentDate = DateTime.Today;

            string wishes = "Вітаю тебе з Днем народження!! Нехай усі твої мрії збуваються <3";

            if (selectedDate.Day == currentDate.Day && selectedDate.Month == currentDate.Month)
            {
                MessageBox.Show(wishes);
                return wishes;
            }
            else
            {               
                return wishes;
            }
        }

         public void ZodiakSignByDay(DateTime selectedDate)
         {
             if((selectedDate.Day >= 21 && selectedDate.Month == 03) ||  (selectedDate.Day <= 20 &&  selectedDate.Month == 04))
             {
                 dayZodiakTextBlock.Text = "Овен";
             }
             if((selectedDate.Day >= 21 && selectedDate.Month == 04) ||  (selectedDate.Day <= 21 &&  selectedDate.Month == 05))
             {
                 dayZodiakTextBlock.Text = "Телець";
             }
            if((selectedDate.Day >= 22 && selectedDate.Month == 05) ||  (selectedDate.Day <= 21 &&  selectedDate.Month == 06))
            {
                dayZodiakTextBlock.Text = "Близнята";
            }
            if((selectedDate.Day >= 22 && selectedDate.Month == 06) ||  (selectedDate.Day <= 22 &&  selectedDate.Month == 07))
            {
                dayZodiakTextBlock.Text = "Рак";
            }
            if((selectedDate.Day >= 23 && selectedDate.Month == 07) ||  (selectedDate.Day <= 23 &&  selectedDate.Month == 08))
            {
                dayZodiakTextBlock.Text = "Лев";
            }
            if((selectedDate.Day >= 24 && selectedDate.Month == 08) ||  (selectedDate.Day <= 23 &&  selectedDate.Month == 09))
            {
                dayZodiakTextBlock.Text = "Діва";
            }
            if((selectedDate.Day >= 24 && selectedDate.Month == 09) ||  (selectedDate.Day <= 23 &&  selectedDate.Month == 10))
            {
                dayZodiakTextBlock.Text = "Терези";
            }
            if((selectedDate.Day >= 23 && selectedDate.Month == 10) ||  (selectedDate.Day <= 22 &&  selectedDate.Month == 11))
            {
                dayZodiakTextBlock.Text = "Скорпіон";
            }
            if((selectedDate.Day >= 23 && selectedDate.Month == 11) ||  (selectedDate.Day <= 22 &&  selectedDate.Month == 12))
            {
                dayZodiakTextBlock.Text = "Стрілець";
            }
            if((selectedDate.Day >= 23 && selectedDate.Month == 12) ||  (selectedDate.Day <= 20 &&  selectedDate.Month == 01))
            {
                dayZodiakTextBlock.Text = "Козоріг";
            }
            if((selectedDate.Day >= 21 && selectedDate.Month == 01) ||  (selectedDate.Day <= 20 &&  selectedDate.Month == 02))
            {
                dayZodiakTextBlock.Text = "Водолій";
            }
            if((selectedDate.Day >= 21 && selectedDate.Month == 02) ||  (selectedDate.Day <= 20 &&  selectedDate.Month == 03))
            {
                dayZodiakTextBlock.Text = "Риби";
            }
         }

        public double ZodiakSignByYear(DateTime selectedDate)
        {
            string [] signsArray = ["Мавпи", "Півня", "Собаки", "Свині", "Криси", "Бика", "Тигра", "Кролика", "Дракона", "Змії", "Коня", "Вівці" ];

            int signCount = selectedDate.Year % 12;

                yearTextBlock.Text = $"{signsArray[signCount]}";

            return signCount;

        }        

    }
}