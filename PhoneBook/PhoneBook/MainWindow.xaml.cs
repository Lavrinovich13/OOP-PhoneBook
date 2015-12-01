using PhoneBook.EntityModels;
using PhoneBook.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        protected UnitOfWork _unitOfWork;
        protected BindingList<Person> _personsInfo;

        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _personsInfo = new BindingList<Person>(
                _unitOfWork
                .PeopleRepository
                .GetAll((x) => { return true; }));

            FillGrids();
        }

        private void FillGrids()
        {
            PeopleGrid.ItemsSource = _personsInfo;

            NumbersGrid.ItemsSource = _personsInfo[0].PhoneNumbers;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }

        private void PeopleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = PeopleGrid.CurrentItem;

            if (person != null)
            {
                NumbersGrid.ItemsSource = (person as Person).PhoneNumbers;
            }
        }

        #region PersonFunctions
        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow window = new CreatePersonWindow() { Owner = this };
            window.ShowDialog();
        }

        internal void AddNewPerson(Person person)
        {
            _unitOfWork.PeopleRepository.Add(person);
            _unitOfWork.SaveChanges();
        }

        private void RemovePerson_Click(object sender, RoutedEventArgs e)
        {
            var person = PeopleGrid.CurrentItem;
            if (person != null)
            {
                _unitOfWork.PeopleRepository.Remove(person as Person);
                _unitOfWork.SaveChanges();
            }
        }
        #endregion

        private void miRefresh_Click(object sender, RoutedEventArgs e)
        {
            _personsInfo = new BindingList<Person>(_unitOfWork.PeopleRepository.GetAll((x) => { return true; }));
            FillGrids();
        }

        #region NumberFunctions

        private void AddNumber_Click(object sender, RoutedEventArgs e)
        {
            CreateNumberWindow window = new CreateNumberWindow() { Owner = this };
            window.ShowDialog();
        }

        internal void AddNewNumber(PhoneNumber number)
        {
            var person = PeopleGrid.CurrentItem;
            (person as Person).PhoneNumbers.Add(number);
            if(number != null)
            {
                _unitOfWork.PeopleRepository.Update(person as Person);
                _unitOfWork.SaveChanges();
            }
        }

        private void RemoveNumber_Click(object sender, RoutedEventArgs e)
        {
            var number = NumbersGrid.CurrentItem;
            if (number != null)
            {
                _unitOfWork.PhoneNumbersRepository.Remove(number as PhoneNumber);
                _unitOfWork.SaveChanges();
            }
        }

        #endregion
    }
}
