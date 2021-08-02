using prototype.forms.Models.Menu.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace prototype.forms.Models.Menu
{
    public class MenuOption : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuTypes Type { get; set; }
        public string Title { get; set; }

    }
}
