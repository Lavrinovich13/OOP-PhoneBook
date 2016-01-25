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
    /// Логика взаимодействия для AddPersonPage.xaml
    /// </summary>
    public partial class AddPersonPage : UserControl
    {
        protected ObservableCollection<PhoneNumberGridItem> _PhoneNumberItems;
        protected PhoneNumberConverter _PhoneNumberConverter;

        public AddPersonPage()
        {
            _PhoneNumberItems = new ObservableCollection<PhoneNumberGridItem>();
            _PhoneNumberConverter = new PhoneNumberConverter();

            InitializeComponent();
        }

        private void bLeft_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new PeopleListPage());
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

            var person = new Person(
                tbFirstName.Text,
                tbLastName.Text,
                tbPatronymic.Text,
                newFilePath);

            person.AddPhones(_PhoneNumberItems
                .Where(x => !String.IsNullOrWhiteSpace(x.Number))
                .Select(x => _PhoneNumberConverter.Convert(x))
                .ToList());

            try
            {
                using (var service = new PhoneBookCRUDService())
                {
                    service.AddPerson(person);
                }
            }
            catch (DuplicatePersonNameException ex)
            {
                MessageBox.Show("Контакт с таким именем уже существует!");
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgPhoneNumbers.DataContext = _PhoneNumberItems;
        }
    }
}
