using BL.Exceptions;
using BL.Models;
using BL.PhoneBookServices;
using Microsoft.Win32;
using PhoneBook.Helpers;
using PhoneBook.Switcher;
using PhoneBook.ViewModels;
using PhoneBook.ViewModels.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для UpdatePersonPage.xaml
    /// </summary>
    public partial class UpdatePersonPage : UserControl
    {
        protected ObservableCollection<PhoneNumberGridItem> _PhoneNumberItems;
        protected Person _Person;

        protected PhoneNumberConverter _PhoneNumberConverter;

        public UpdatePersonPage()
        {
            _PhoneNumberItems = new ObservableCollection<PhoneNumberGridItem>();
            _PhoneNumberConverter = new PhoneNumberConverter();

            InitializeComponent();
        }

        public UpdatePersonPage(int id)
            : this()
        {
            using (var service = new PhoneBookCRUDService())
            {
                _Person = service.GetPersonById(id);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(_Person.ImagePath))
            {
                var uri = new Uri(_Person.ImagePath, UriKind.Relative);
                iPersonImage.Source = (ImageHelper.GetImageFromUri(uri)).Source;
            }

            tbFirstName.Text = _Person.FirstName;
            tbLastName.Text = _Person.LastName;
            tbPatronymic.Text = _Person.Patronymic;

            if (_Person.PhoneNumbers.Count() > 0)
            {
                _PhoneNumberItems =
                    new ObservableCollection<PhoneNumberGridItem>(
                        _Person
                        .PhoneNumbers
                        .Select(x => _PhoneNumberConverter.Convert(x)));
            }

            dgPhoneNumbers.DataContext = _PhoneNumberItems;
        }

        private void bLeft_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new PersonInfoPage(_Person.Id));
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                MessageBox.Show("Поле 'Имя' должно быть заполнено!");
                return;
            }

            if (_PhoneNumberItems.FirstOrDefault(x => String.IsNullOrWhiteSpace(x.Number)) != null)
            {
                MessageBox.Show("Поле 'Телефон' должно быть заполнено!");
                return;
            }

            var fullPath = iPersonImage.Source.ToString().Remove(0, 8);
            var name = fullPath.Split('/').Last();
            var projectPath = Environment.CurrentDirectory;
            var newFilePath = "PeopleImages/" + name;

            if (!File.Exists(newFilePath))
            {
                File.Copy(fullPath, projectPath + '/' + newFilePath);
            }

            _Person.FirstName = tbFirstName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.Patronymic = tbPatronymic.Text;
            _Person.ImagePath = newFilePath;

            try
            {
                using (var service = new PhoneBookCRUDService())
                {
                    var oldPhones = _Person.PhoneNumbers;
                    foreach (var phone in oldPhones)
                    {
                        if (_PhoneNumberItems.SingleOrDefault(x => x.Id == phone.Id) == null)
                        {
                            service.DeleteNumber(phone);
                        }
                    }

                    foreach (var phone in _PhoneNumberItems)
                    {
                        var blPhone = _PhoneNumberConverter.Convert(phone);
                        blPhone.SetPerson(_Person.Id);

                        if (blPhone.Id == 0)
                        {
                            service.AddNumber(blPhone);
                        }
                        else
                        {
                            service.UpdateNumber(blPhone);
                        }
                    }
                    service.UpdatePerson(_Person);
                }
            }
            catch (DuplicatePersonNameException ex)
            {
                MessageBox.Show("Не удалось обновить данные о контакте!Такие данные уже существуют!");
                return;
            }

            PageSwitcher.Switch(new PeopleListPage());
        }

        private void iPersonImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите фотографию";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                var uri = new Uri(op.FileName);
                iPersonImage.Source = (ImageHelper.GetImageFromUri(uri)).Source;
            }
        }
    }
}
