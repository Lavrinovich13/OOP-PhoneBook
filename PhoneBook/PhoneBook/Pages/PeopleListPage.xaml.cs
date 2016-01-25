using BL.Models;
using BL.PhoneBookServices;
using PhoneBook.Helpers;
using PhoneBook.Switcher;
using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
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

namespace PhoneBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для PeopleList.xaml
    /// </summary>
    public partial class PeopleListPage : UserControl
    {
        private static string _LastSearch;

        public PeopleListPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_LastSearch != null)
            {
                tbSearch.Text = _LastSearch;
            }
            bSearch_Click(this, e);
        }

        private void PeopleList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPerson = PeopleList.SelectedItem;
            if (selectedPerson != null)
            {
                var id = (selectedPerson as PersonListItem).Id;
                PageSwitcher.Switch(new PersonInfoPage(id));
            }
        }

        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            _LastSearch = tbSearch.Text;
            PeopleList.Items.Clear();

            if (!String.IsNullOrWhiteSpace(tbSearch.Text))
            {
                List<SuitablePhoneNumber> suitableNumbers;
                using (var service = new PhoneBookSearchService())
                {
                    suitableNumbers = service.Search(tbSearch.Text);
                }
                FillPeopleList(suitableNumbers);
            }
            else
            {
                FillPeopleList();
            }
        }

        private void FillPeopleList()
        {
            List<Person> people;
            using (var service = new PhoneBookCRUDService())
            {
                people = service.GetAllPeople();
            }

            foreach (var person in people.OrderBy(x => x.FullName))
            {
                var uri = new Uri(person.ImagePath, UriKind.Relative);

                PeopleList.Items.Add(
                    new PersonListItem(
                        person.Id,
                        ImageHelper.GetImageFromUri(uri), 
                        person.FullName));
            }
        }

        private void FillPeopleList(List<SuitablePhoneNumber> numbers)
        {
            foreach (var numberInfo in numbers.OrderBy(x => x.Person.FullName))
            {
                var uri = new Uri(numberInfo.Person.ImagePath, UriKind.Relative);

                PeopleList.Items.Add(
                    new PersonListItem(
                        numberInfo.Person.Id,
                        ImageHelper.GetImageFromUri(uri), 
                        numberInfo.Person.FullName, 
                        numberInfo.PhoneNumber.FullInfo));
            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bSearch_Click(this, e);
            }
        }

        private void bAddPerson_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new AddPersonPage());
        }
    }
}
