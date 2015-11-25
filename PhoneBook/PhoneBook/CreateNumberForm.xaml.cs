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
    /// Логика взаимодействия для CreateNumberForm.xaml
    /// </summary>
    public partial class CreateNumberForm : Window
    {
        private int _personId;
        public CreateNumberForm()
        {
            InitializeComponent();
        }

        public CreateNumberForm(int PersonId) : this()
        {
            _personId = PersonId;
        }

        private void bAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbNumber.Text) &&
               !String.IsNullOrWhiteSpace(tbDescription.Text))
            {
                RepositoryModelPhoneNumber number =
                    new RepositoryModelPhoneNumber(0, _personId, tbNumber.Text, tbDescription.Text);
                (this.Owner as MainWindow).AddNewNumber(number);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
