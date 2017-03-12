using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryManager.Dialogs
{
    class LendBookViewModel : INotifyPropertyChanged
    {
        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value == _user)
                    return;

                _user = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
