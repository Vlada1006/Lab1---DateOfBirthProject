using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DateOfBirthProject.Models
{
    public class Person
    {
        public DateTime SelectedDate { get; set; }
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
        }

        public Person(string name, string surname, string email)
             : this(name, surname, email, DateTime.MinValue)
        {
        }

        public Person(string name, string surname, DateTime birthday)
            : this(name, surname, "", birthday)
        {
        }

        public Person() : this("", "", "", DateTime.MinValue) { }

        public bool IsAdult
        {
            get { return CalculateIsAdult(); }
        }

        public bool IsBirthday
        {
            get { return CalculateIsBirthday(); }
        }

        public string SunSign
        {
            get { return CalculateSunSign(Birthday); }
        }

        public string ChineseSign
        {
            get { return CalculateChineseSign(Birthday); }
        }


        private bool CalculateIsAdult()
        {
            if (PersonAge() >= 18)
            {
                return true;
            }
            return false;
        }

        private int PersonAge()
        {
            int res = DateTime.Now.Year - this._birthday.Year;
            if (DateTime.Now.DayOfYear < this._birthday.DayOfYear) res -= 1;
            return res;

        }

        private bool CalculateIsBirthday()
        {
            if (Birthday.Day == DateTime.Now.Day && Birthday.Month == DateTime.Now.Month)
            {
                return true;
            }
            return false;
        }

        private string CalculateSunSign(DateTime selectedDate)
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

        private string CalculateChineseSign(DateTime selectedDate)
        {
            string[] signsArray = ["Мавпа", "Півень", "Собака", "Свиня", "Криса", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Вівця"];

            int signCount = selectedDate.Year % 12;

            string zodiacSign = signsArray[signCount];

            return zodiacSign;
           
        }
    }

   
}


   
        
      
