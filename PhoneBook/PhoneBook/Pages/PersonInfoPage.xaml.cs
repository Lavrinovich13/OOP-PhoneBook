using BL.PhoneBookServices;
using PhoneBook.Helpers;
using PhoneBook.Switcher;
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
    /// Логика взаимодействия для PersonInfoPage.xaml
    /// </summary>
    public partial class PersonInfoPage : UserControl
    {
        private int _personId;

        public PersonInfoPage()
        {
            InitializeComponent();
        }

        public PersonInfoPage(int id)
            :this()
        {
            this._personId = id;
            FillForm();
        }

        private void FillForm()
        {
            PhoneBookCRUDService service = new PhoneBookCRUDService();

            var person = service.GetPersonById(_personId);

            tbPersonId.Text = person.Id.ToString();
            lFirstName.Content = person.FirstName;
            lLastName.Content = person.LastName;
            lPatronymic.Content = person.Patronymic;

            var uri = new Uri(person.ImagePath, UriKind.Relative);
            iPersonImage.Source = (ImageHelper.GetImageFromUri(uri)).Source;
            
            foreach(var number in person.PhoneNumbers)
            {
                lbNumbers.Items.Add(number);
            }
        }

        private void bLeft_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new PeopleListPage());
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(tbPersonId.Text))
            {
                using (var service = new PhoneBookCRUDService())
                {
                    service.RemovePersonById(Int32.Parse(tbPersonId.Text));
                }
            }
            PageSwitcher.Switch(new PeopleListPage());
        }

        private void bToUpdate_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new UpdatePersonPage(Int32.Parse(tbPersonId.Text)));
        }
    }
}
