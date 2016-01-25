using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PhoneBook.ViewModels
{
    public class PersonListItem
    {
        public int Id { get; protected set; }
        public Image Image { get; protected set; }
        public string FullName { get; protected set; }
        public string NumberInfo { get; protected set; }

        public PersonListItem(int id, Image image, string fullName, string numberInfo = "")
        {
            this.Id = id;
            this.Image = image;
            this.FullName = fullName;
            this.NumberInfo = numberInfo;
        }
    }
}
