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

namespace DateOfBirthProject.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person = new Person();
        //private Person _person;
        private RelayCommand<object> _proceedCommand;
        private string _info1 = "";
        private string _info2 = "";
        private bool _isEnabled = true;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;



        #region Properties

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


        public string Info1
        {
            set
            {
                _info1 = value;
                OnPropertyChanged("Info1");
            }
            get { return _info1; }
        }


        public string Info2
        {
            set
            {
                _info2 = value;
                OnPropertyChanged("Info2");
            }
            get { return _info2; }
        }

        

        #endregion

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
              
                
                if (Birthday.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show("Seems, like you haven't even been born yet -_-");
                }
                else if (DateTime.Now.Year - Birthday.Year > 136)
                {
                    MessageBox.Show("C`mon, it can`t be true");
                }
                else
                {
                    if (IsBirthday)
                    {
                       
                        MessageBox.Show("Happy birthday lil sweetheart <3 !!");
                    }

                    Task.Delay(2000).Wait();

                    Info1 = $"First name: {Name} \nLast name: {Surname}\n" +
                    $"Birthday: {Birthday.Date.ToString("dd/MM/yyyy")} \nEmail: {Email}";
                    Info2 = $"IsAdult: {IsAdult} \nSunSign: {SunSign}\n" +
                    $"ChineseSign: {ChineseSign} \nIsBirthday: {IsBirthday}";

                }

            });
            IsEnabled = true;
        }
        private bool CanExecute(object obj)
        {
            //return true;
            return !String.IsNullOrWhiteSpace(_person.Name) &&
                !String.IsNullOrWhiteSpace(_person.Surname) &&
                (DateTime.MinValue != _person.Birthday) &&
                !String.IsNullOrWhiteSpace(_person.Email);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}