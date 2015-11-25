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
    /// Логика взаимодействия для EditPersonForm.xaml
    /// </summary>
    public partial class EditPersonForm : Window
    {
        private RepositoryModelPerson _person;
        public EditPersonForm()
        {
            InitializeComponent();
        }

        public EditPersonForm(RepositoryModelPerson person)
            : this()
        {
            this._person = person;

            tbName.Text = _person.FirstName;
            tbLastName.Text = _person.LastName;
            tbPatronymic.Text = _person.Patronymic;
            tbDesc.Text = _person.Description;
        }

        private void bAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbName.Text) &&
               !String.IsNullOrWhiteSpace(tbLastName.Text) &&
               !String.IsNullOrWhiteSpace(tbPatronymic.Text) &&
               !String.IsNullOrWhiteSpace(tbDesc.Text))
            {
                RepositoryModelPerson person =
                    new RepositoryModelPerson(_person.Id, tbName.Text, tbLastName.Text, tbPatronymic.Text, tbDesc.Text);
                (this.Owner as MainWindow).EditPerson(person);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
