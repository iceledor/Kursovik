using System;
using WpfApplication1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApplication1.View;
using WpfApplication1.ViewModel;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
        
namespace WpfApplication1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region gg
/*        public MainViewModel()
        {
        }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string CellNumber { get; set; }
        public string Fio { get; set; }
        private RelayCommand<MetroWindow> _create;

        public RelayCommand<MetroWindow> Create
        {
            get
            {
                if (_create == null)
                {
                    _create = new RelayCommand<MetroWindow>(ExecuteOpenCreating);
                }
                return _create;
            }
            set
            {
                _create = value;
            }
        }
        private void ExecuteOpenCreating(MetroWindow MainWindow)
        {
            Creating window = new Creating();
            window.Show();
            MainWindow.Close();
        }
        private RelayCommand<MetroWindow> _edit;

        public RelayCommand<MetroWindow> Edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand<MetroWindow>(ExecuteOpenEditing);
                }
                return _edit;
            }
            set 
            {
                _edit = value;
            }
        }
        private void ExecuteOpenEditing(MetroWindow MainWindow)
        {
            Editing window = new Editing();
            window.Show();
            MainWindow.Close();
        }*/
#endregion gg
        private readonly IContactsService _service;

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return new ObservableCollection<Contact>(_service.Contacts());
            }
        }

        public Contact SelectedContact { get; set; }

        private RelayCommand _createOpen;
        public ICommand CreateOpen
        {
            get
            {
                if (_createOpen == null) _createOpen = new RelayCommand(CreateOpenWindow);
                return _createOpen;
            }
        }

        private RelayCommand _editOpen;
        public ICommand EditOpen
        {
            get
            {
                if (_editOpen == null) _editOpen = new RelayCommand(EditOpenWindow);
                return _editOpen;
            }
        }

        private void CreateOpenWindow()
        {
            if (Creating.Instance == null)
            {
                Creating win = new Creating();
                ((CreatingViewModel)win.DataContext).SavingResult += MainViewModel_SavingResult;
                win.Show();
            }
            else
                Creating.Instance.Focus();
        }

        private void EditOpenWindow()
        {
            if (Creating.Instance == null)
            {
                Creating win = new Creating();
                ((CreatingViewModel)win.DataContext).SavingResult += MainViewModel_SavingResult;
                ((CreatingViewModel)win.DataContext).SetContact(SelectedContact);
                win.Show();
            }
            else
                Creating.Instance.Focus();
        }

        public void MainViewModel_SavingResult(object sender, SaveContactEventArgs e)
        {
            if (e.Result)
            {
                RaisePropertyChanged("Contacts");
                Creating.Instance.Close();
            }
        }

        public MainViewModel(IContactsService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            this._service = service;
        }
    }
}
