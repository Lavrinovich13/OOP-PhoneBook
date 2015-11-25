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
    /// Логика взаимодействия для SearchForm.xaml
    /// </summary>
    public partial class SearchForm : Window
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(tbSearchText.Text))
            {
                (this.Owner as MainWindow).Search(tbSearchText.Text);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (this.Owner as MainWindow).SearchClose();
        }
    }
}
