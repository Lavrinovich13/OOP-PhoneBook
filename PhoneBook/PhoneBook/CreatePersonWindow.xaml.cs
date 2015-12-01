using PhoneBook.EntityModels;
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
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для AddPersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        public CreatePersonWindow()
        {
            InitializeComponent();
        }

        private void bCreatePerson_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbName.Text) &&
                !String.IsNullOrWhiteSpace(tbLastName.Text) &&
                !String.IsNullOrWhiteSpace(tbPatronymic.Text) &&
                !String.IsNullOrWhiteSpace(tbDesc.Text))
            {
                Person person = new Person()
                {
                    FirstName = tbName.Text,
                    LastName = tbLastName.Text,
                    Patronymic = tbPatronymic.Text,
                    Description = tbDesc.Text
                };

                (this.Owner as MainWindow).AddNewPerson(person);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
