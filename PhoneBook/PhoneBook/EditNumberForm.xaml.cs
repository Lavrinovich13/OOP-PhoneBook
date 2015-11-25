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
    /// Логика взаимодействия для EditNumberForm.xaml
    /// </summary>
    public partial class EditNumberForm : Window
    {
        private int _numberId;
        private int _personId;
        public EditNumberForm()
        {
            InitializeComponent();
        }

        public EditNumberForm(RepositoryModelPhoneNumber number)
            :this()
        {
            _numberId = number.Id;
            _personId = number.PersonId;

            tbNumber.Text = number.Number;
            tbDescription.Text = number.Description;
        }

        private void bEditNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbNumber.Text) &&
               !String.IsNullOrWhiteSpace(tbDescription.Text))
            {
                RepositoryModelPhoneNumber number =
                    new RepositoryModelPhoneNumber(_numberId, _personId, tbNumber.Text, tbDescription.Text);
                (this.Owner as MainWindow).EditNumber(number);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
