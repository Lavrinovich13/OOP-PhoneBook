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
    /// Логика взаимодействия для CreateNumberWindow.xaml
    /// </summary>
    public partial class CreateNumberWindow : Window
    {
        public CreateNumberWindow()
        {
            InitializeComponent();
        }

        private void bAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbNumber.Text) &&
               !String.IsNullOrWhiteSpace(tbDescription.Text))
            {
                PhoneNumber number =
                    new PhoneNumber() { Number = tbNumber.Text, Description = tbDescription.Text };
                (this.Owner as MainWindow).AddNewNumber(number);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
