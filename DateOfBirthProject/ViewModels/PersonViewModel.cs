using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DateOfBirthProject.Models;
using DateOfBirthProject.Views;
using DateOfBirthProject.Tools;
using System.Diagnostics;
using DateOfBirthProject.Tools.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Documents;
using System.Text.RegularExpressions;

namespace DateOfBirthProject.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person = new Person();
        private RelayCommand<object> _proceedCommand;
        private string _enteredData = "";
        private string _calculatedData = "";
        private bool _isEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        internal Person Person { get => _person; set => _person = value; }

        public bool IsEnabled
        {
            set { _isEnabled = value; OnPropertyChanged("IsEnabled"); }
            get { return _isEnabled; }
        }
        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return _person.Surname; }
            set { _person.Surname = value; OnPropertyChanged("Surname"); }
        }

        public DateTime Birthday
        {
            get { return _person.Birthday; }
            set { _person.Birthday = value; OnPropertyChanged("Birthday"); }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; OnPropertyChanged("Email"); }
        }

        public bool IsAdult
        {
            get { return _person.IsAdult; }
        }

        public string SunSign
        {
            get { return _person.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person.ChineseSign; }
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday; }
        }


        public string EnteredData
        {
            set
            {
                _enteredData = value;
                OnPropertyChanged("EnteredData");
            }
            get { return _enteredData; }
        }


        public string CalculatedData
        {
            set
            {
                _calculatedData = value;
                OnPropertyChanged("CalculatedData");
            }
            get { return _calculatedData; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        private async void Proceed()
        {
           
            IsEnabled = false;
            await Task.Run(() =>
            {
                try
                {
                   ExceptionValidation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    IsEnabled = true;
                    return;
                }

                    if (IsBirthday)
                    {
                       
                        MessageBox.Show("Happy birthday lil sweetheart <3 !!");
                    }

                    Task.Delay(2000).Wait();

                    EnteredData = $"First name: {Name}\nLast name: {Surname}\n" +
                    $"Birthday: {Birthday.Date.ToString("dd/MM/yyyy")} \nEmail: {Email}";
                    CalculatedData = $"IsAdult: {IsAdult}\nSunSign: {SunSign}\n" +
                    $"ChineseSign: {ChineseSign}\nIsBirthday: {IsBirthday}";

                

            });
            IsEnabled = true;
        }

        public void ExceptionValidation()
        {
            if (Birthday.CompareTo(DateTime.Now) > 0)
            {
                throw new DateInFutureException("Error!\n The birthday date can`t be in future");
            }

            if (DateTime.Now.Year - Birthday.Year > 135)
            {
                throw new DateInLatePastException("Error!\n The birthday date can`t be so far in past");
            }

            if (!Email.Contains("@"))
            {
                throw new InvalidEmailAddressException("Error!\n Email must have @ symbol");
            }

            if (!Email.Contains("gmail.com") && !Email.Contains("yahoo.com") && !Email.Contains("outlook.com") && !Email.Contains("ukr.net"))
            {
                throw new InvalidEmailAddressException("Error!\n The domain is not recognised");
            }

            if (!Char.IsUpper(Name[0]) || !Char.IsUpper(Surname[0]))
            {
                throw new NotFoundCapitalLetterInBeginningException("Error!\n You are supposed to put capital letter in the beginning of your name and surname");
            }

            if ((Name.Length < 2 || Name.Length > 20) || (Surname.Length < 2 || Surname.Length > 20))
            {
                throw new AmountOfLettersException("Error!\n Your name and surname can`t be shorter that 2 and longer that 20 letters");
            }

            if (Regex.IsMatch(Name, @"[.,?!_*#@$%^&`~'<>;:""]") || Regex.IsMatch(Surname, @"[.,?!_*#@$%^&`~'<>;:""]"))
            {
                throw new UnnecessaryExtraCharactersException("Error!\n Your name and surname can`t contain any characters except dash (-)");
            }

            if(Name.Contains(" ") || Surname.Contains(" "))
            {
                throw new UnnecessaryExtraCharactersException("Error!\n Your name and surname can`t contain white spaces");
            }
        }
        public  bool CanExecute(object obj)
        {
            //return true;
            return !string.IsNullOrWhiteSpace(_person.Name.Trim()) && !string.IsNullOrWhiteSpace(_person.Surname.Trim()) 
                   && _person.Birthday != DateTime.MinValue && !string.IsNullOrWhiteSpace(_person.Email);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}