using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryManager.Dialogs
{
    internal class AddBookViewModel : INotifyPropertyChanged
    {
        public AddBookViewModel()
        {

        }

        private string _bookTitle;
        public string BookTitle
        {
            get
            {
                return _bookTitle;
            }
            set
            {
                if (value == _bookTitle)
                    return;

                _bookTitle = value;
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
