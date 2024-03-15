using System;
using System.Windows;

namespace DateOfBirthProject
{
    public class MainWindowViewModel
    {
        public DateTime SelectedDate { get; set; }

        public int Age { get; set; }

        public string DayZodiac { get; set; }

        public string YearZodiac { get; set; }

        public void CalculateAge()
        {
            DateTime currentDate = DateTime.Today;
            Age = currentDate.Year - SelectedDate.Year;
            if (SelectedDate.Month > currentDate.Month || (SelectedDate.Month == currentDate.Month && SelectedDate.Day > currentDate.Day))
            {
                Age--;
            }
        }

        public string ZodiakSignByDay(DateTime selectedDate)
        {
            if ((selectedDate.Day >= 21 && selectedDate.Month == 03) || (selectedDate.Day <= 20 && selectedDate.Month == 04))
            {
                return "Овен";
            }
            if ((selectedDate.Day >= 21 && selectedDate.Month == 04) || (selectedDate.Day <= 21 && selectedDate.Month == 05))
            {
                return "Телець";
            }
            if ((selectedDate.Day >= 22 && selectedDate.Month == 05) || (selectedDate.Day <= 21 && selectedDate.Month == 06))
            {
                return "Близнята";
            }
            if ((selectedDate.Day >= 22 && selectedDate.Month == 06) || (selectedDate.Day <= 22 && selectedDate.Month == 07))
            {
                return "Рак";
            }
            if ((selectedDate.Day >= 23 && selectedDate.Month == 07) || (selectedDate.Day <= 23 && selectedDate.Month == 08))
            {
                return "Лев";
            }
            if ((selectedDate.Day >= 24 && selectedDate.Month == 08) || (selectedDate.Day <= 23 && selectedDate.Month == 09))
            {
                return "Діва";
            }
            if ((selectedDate.Day >= 24 && selectedDate.Month == 09) || (selectedDate.Day <= 23 && selectedDate.Month == 10))
            {
                return "Терези";
            }
            if ((selectedDate.Day >= 23 && selectedDate.Month == 10) || (selectedDate.Day <= 22 && selectedDate.Month == 11))
            {
                return "Скорпіон";
            }
            if ((selectedDate.Day >= 23 && selectedDate.Month == 11) || (selectedDate.Day <= 22 && selectedDate.Month == 12))
            {
                return "Стрілець";
            }
            if ((selectedDate.Day >= 23 && selectedDate.Month == 12) || (selectedDate.Day <= 20 && selectedDate.Month == 01))
            {
                return "Козоріг";
            }
            if ((selectedDate.Day >= 21 && selectedDate.Month == 01) || (selectedDate.Day <= 20 && selectedDate.Month == 02))
            {
                return "Водолій";
            }
            if ((selectedDate.Day >= 21 && selectedDate.Month == 02) || (selectedDate.Day <= 20 && selectedDate.Month == 03))
            {
                return "Риби";
            }
            else
            {
                return "";
            }
        }

        public string ZodiakSignByYear(DateTime selectedDate)
        {
            string[] signsArray = ["Мавпи", "Півня", "Собаки", "Свині", "Криси", "Бика", "Тигра", "Кролика", "Дракона", "Змії", "Коня", "Вівці"];

            int signCount = selectedDate.Year % 12;

           string zodiacSign = signsArray[signCount];

            return zodiacSign;

        }

        public void ShowBirthdayWishes()
        {
            DateTime currentDate = DateTime.Today;
            if (SelectedDate.Day == currentDate.Day && SelectedDate.Month == currentDate.Month)
            {
                MessageBox.Show("Вітаю тебе з Днем народження!! Нехай усі твої мрії збуваються <3");
            }
        }
    }

       
    }

