using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DateOfBirthProject.Models;
using DateOfBirthProject.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DateOfBirthProject.Views
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private PersonViewModel _viewModel;
        private PersonDataList database = new PersonDataList();
        private List<Person> _people;
        public PersonView()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonViewModel();
            Database.DataContext = database.GetBase();
        }


        private void sort_by_number(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Email")
            {
                ObservableCollection<Person> people = database.GetBase();
                if (e.Column.SortDirection == null || e.Column.SortDirection == ListSortDirection.Descending)
                {

                    Database.ItemsSource = new ObservableCollection<Person>(
                        from p in people
                        let match = Regex.Match(p.Email, @"(\d+)@")
                        let emailNumber = match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue
                    orderby emailNumber ascending
                        select p);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    Database.ItemsSource = new ObservableCollection<Person>(
                        from p in people
                        let match = Regex.Match(p.Email, @"(\d+)@")
                        let emailNumber = match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue
                        orderby emailNumber descending
                        select p);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
                e.Handled = true;
            }

            foreach (var dgColumn in Database.Columns)
            {
                if (dgColumn.Header.ToString() != e.Column.Header.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }
        }

        private void FilterType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string filterText = txtFilter.Text;
            ObservableCollection<Person> people = database.GetBase();

            ComboBoxItem selectedItem = (ComboBoxItem)cmbFilterType.SelectedItem;
            if (selectedItem != null)
            {
                string selectedFilter = selectedItem.Content.ToString();

                switch (selectedFilter)
                {
                    case "Name":
                        Database.ItemsSource = new ObservableCollection<Person>(
                            people.Where(p => p.Name.Contains(filterText)).ToList());
                        break;
                    case "Surname":
                        Database.ItemsSource = new ObservableCollection<Person>(
                            people.Where(p => p.Surname.Contains(filterText)).ToList());
                        break;
                    case "Birthday":
                        DateTime filterDate;
                        if (DateTime.TryParse(filterText, out filterDate))
                        {
                            Database.ItemsSource = new ObservableCollection<Person>(
                                people.Where(p => p.Birthday.Date == filterDate.Date).ToList());
                        }
                        else
                        {
                            MessageBox.Show("Invalid date format. Please enter date in correct format.");
                        }
                        break;
                    case "Email":
                        Database.ItemsSource = new ObservableCollection<Person>(
                            people.Where(p => p.Email.Contains(filterText)).ToList());
                        break;
                    case "IsAdult":
                        bool isAdultFilter;
                        if (bool.TryParse(filterText, out isAdultFilter))
                        {
                            Database.ItemsSource = new ObservableCollection<Person>(
                                people.Where(p => p.IsAdult == isAdultFilter).ToList());
                        }
                        else
                        {
                            MessageBox.Show("Invalid value for IsAdult. Please enter 'true' or 'false'.");
                        }
                        break;
                    case "SunSign":
                        Database.ItemsSource = new ObservableCollection<Person>(
                            people.Where(p => p.SunSign.Contains(filterText)).ToList());
                        break;
                    case "ChineseSign":
                        Database.ItemsSource = new ObservableCollection<Person>(
                            people.Where(p => p.ChineseSign.Contains(filterText)).ToList());
                        break;
                    case "IsBirthday":
                        bool isBirthdayFilter;
                        if (bool.TryParse(filterText, out isBirthdayFilter))
                        {
                            Database.ItemsSource = new ObservableCollection<Person>(
                                people.Where(p => p.IsBirthday == isBirthdayFilter).ToList());
                        }
                        else
                        {
                            MessageBox.Show("Invalid value for IsBirthday. Please enter 'true' or 'false'.");
                        }
                        break;
                    default:
                        Database.ItemsSource = people;
                        break;
                }
            }
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {

            if (_viewModel.CanExecute(sender))
            {
                try
                {
                    _viewModel.ExceptionValidation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Person newPerson1 = _viewModel.Person;
                Person newPerson = new Person(newPerson1.Name, newPerson1.Surname, newPerson1.Email, newPerson1.Birthday);
                database.People.Add(newPerson);
                Database.ItemsSource = database.People;
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Database.SelectedItem != null)
            {
                Person selectedPerson = (Person)Database.SelectedItem;

                bool removed = database.RemovePerson(selectedPerson);

                if (removed)
                {
                    Database.ItemsSource = null;
                    Database.ItemsSource = database.GetBase();

                    MessageBox.Show($"Selected person: {selectedPerson.Name} {selectedPerson.Surname} deleted.");
                }
                else
                {
                    MessageBox.Show($"Failed to delete {selectedPerson.Name} {selectedPerson.Surname}.");
                }
            }
            else
            {
                MessageBox.Show("Please select a person to delete.");
            }
        }

    }

}



