using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PeopleRepository _peopleRepository;
        public PhoneNumbersRepository _numbersRepository;
        private List<int> Ids;

        private int PersonId = -1;
        public MainWindow()
        {
            _peopleRepository = new PeopleRepository();
            _numbersRepository = new PhoneNumbersRepository();

            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PeopleGrid.ItemsSource = _peopleRepository.Items.OrderBy(x => x.FirstName);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            miSaveChanges_Click(this, null);
            _peopleRepository.Dispose();
            _numbersRepository.Dispose();
        }

        private void PeopleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = PeopleGrid.CurrentItem;

            if (person != null)
            {
                PersonId = (person as RepositoryModelPerson).Id;
                var personId = (person as RepositoryModelPerson).Id;
                NumbersGrid.ItemsSource = null;
                NumbersGrid.ItemsSource = _numbersRepository.Items.Where(x => x.PersonId == personId);
            }
            else
            {
                PersonId = -1;
            }
        }

        #region PersonFunctions
        public void AddNewPerson(RepositoryModelPerson person)
        {
            _peopleRepository.Add(person);

            PeopleGrid.ItemsSource = null;
            PeopleGrid.ItemsSource = _peopleRepository.Items; ;
        }

        public void EditPerson(RepositoryModelPerson person)
        {
            _peopleRepository.Edit(person);

            PeopleGrid.ItemsSource = null;
            PeopleGrid.ItemsSource = _peopleRepository.Items;
            NumbersGrid.ItemsSource = null;
        }
        #endregion

        #region NumberFuctions
        internal void AddNewNumber(RepositoryModelPhoneNumber number)
        {
            _numbersRepository.Add(number);

            NumbersGrid.ItemsSource = _numbersRepository.Items.Where(x => x.PersonId == number.PersonId);
        }

        internal void EditNumber(RepositoryModelPhoneNumber number)
        {
            _numbersRepository.Edit(number);

            NumbersGrid.ItemsSource = _numbersRepository.Items.Where(x => x.PersonId == number.PersonId);
        }
        #endregion

        #region PersonContextMenu
        private void EditPerson_Click(object sender, RoutedEventArgs e)
        {
            var person = PeopleGrid.CurrentItem;

            if (person != null)
            {
                PersonId = (person as RepositoryModelPerson).Id;
                EditPersonForm form = new EditPersonForm((person as RepositoryModelPerson)) { Owner = this };
                form.ShowDialog();
            }
            else
            {
                PersonId = -1;
            }
        }
        private void CreateNewPerson_Click(object sender, RoutedEventArgs e)
        {
            CreatePersonForm form = new CreatePersonForm() { Owner = this };
            form.ShowDialog();
        }

        private void RemovePerson_Click(object sender, RoutedEventArgs e)
        {
            var person = PeopleGrid.CurrentItem;

            if (person != null)
            {
                var personId = (person as RepositoryModelPerson).Id;
                _peopleRepository.Remove(personId);

                var numbers = _numbersRepository.Items.Where(x => x.PersonId == personId);
                foreach (var number in numbers)
                {
                    _numbersRepository.Remove(number.Id);
                }

                PeopleGrid.ItemsSource = null;
                PeopleGrid.ItemsSource = _peopleRepository.Items.ToList();

                PersonId = -1;
            }
        }
        #endregion

        #region NumberContextMenu
        private void CreateNumber_Click(object sender, RoutedEventArgs e)
        {
            if (PersonId != -1)
            {
                CreateNumberForm form = new CreateNumberForm(PersonId) { Owner = this };
                form.ShowDialog();
            }
        }

        private void EditNumber_Click(object sender, RoutedEventArgs e)
        {
            var number = NumbersGrid.CurrentItem;
            if (PersonId != -1 && number != null)
            {
                EditNumberForm form = new EditNumberForm(number as RepositoryModelPhoneNumber) { Owner = this };
                form.ShowDialog();
            }
        }

        private void RemoveNumber_Click(object sender, RoutedEventArgs e)
        {
            var objectNumber = NumbersGrid.CurrentItem;

            if (objectNumber != null)
            {
                var number = (objectNumber as RepositoryModelPhoneNumber);
                _numbersRepository.Remove(number.Id);

                NumbersGrid.ItemsSource = null;
                NumbersGrid.ItemsSource = _numbersRepository.Items.Where(x => x.PersonId == number.PersonId);
            }
        }
        #endregion

        #region Menu
        private void miSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _peopleRepository.SaveChanges();
            _numbersRepository.SaveChanges();
        }

        private void miSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchForm form = new SearchForm() { Owner = this };
            form.Show();
        }

        public void Search(string searchText)
        {
            Ids = new List<int>();

            foreach(var person in _peopleRepository.Items)
            {
                foreach (var number in _numbersRepository.Items.Where(x => x.PersonId == person.Id))
                {
                    var str = person.CreateFullName() + " " + number.CreateFullNumber();
                    if (IsContainsAllParts(str.ToLower(), searchText.ToLower()))
                    {
                        Ids.Add(person.Id);
                        Ids.Add(number.Id);
                    }
                }
            }

            PeopleGrid.ItemsSource = null;
            PeopleGrid.ItemsSource = _peopleRepository.Items;
        }

        protected bool IsContainsAllParts(string input, string search)
        {
            foreach(var part in search.Split(' '))
            {
                if (!input.Contains(part))
                    return false;
            }
            return true;
        }

        public void SearchClose()
        {
            Ids = null;
            PeopleGrid.ItemsSource = null;
            PeopleGrid.ItemsSource = _peopleRepository.Items;
        }

        #endregion

        #region LoadingRow
        private void PeopleGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (Ids != null)
            {
                RepositoryModelPerson person = (RepositoryModelPerson)e.Row.DataContext;
                if (Ids.Contains(person.Id))
                {
                    e.Row.Background = new SolidColorBrush(Colors.SlateGray);
                }
            }
        }

        private void NumbersGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (Ids != null)
            {
                RepositoryModelPhoneNumber number = (RepositoryModelPhoneNumber)e.Row.DataContext;
                if (Ids.Contains(number.Id))
                {
                    e.Row.Background = new SolidColorBrush(Colors.SlateGray);
                }
            }
        }
        #endregion
    }
}
