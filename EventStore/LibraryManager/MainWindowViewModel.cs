using EventStore.Library.Entities;
using System.ComponentModel;
using System.Windows.Input;
using EventStore.Library.Events;
using nblackbox;
using LibraryManager.Dialogs;
using System.Runtime.CompilerServices;

namespace LibraryManager
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private EventStore.Library.Events.LibraryManager mngr;

        public MainWindowViewModel()
        {
            RemoveBook = new RelayCommand<string>((p) => true, OnRemoveBookExecute);
            AddBook = new RelayCommand<string>((p) => true, OnAddBookExecute);
            LendBook = new RelayCommand<string>((p) => true, OnLendBookExecute);
            mngr = new EventStore.Library.Events.LibraryManager(new FolderBlackBox("library"));
        }

        public string Text => "Hello World!";

        public ICommand RemoveBook { get; set; }
        public ICommand AddBook { get; set; }
        public ICommand LendBook { get; set; }

        public void OnRemoveBookExecute(string title)
        {
            mngr.RemoveBook(title);
        }

        public void OnAddBookExecute(string title)
        {
            //var addBookDialog = new AddBookView();
            //addBookDialog.ShowDialog();

            mngr.CreateBook(title);
        }

        public void OnLendBookExecute(string title)
        {
            mngr.LendBook(title, "user");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
