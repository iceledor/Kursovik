using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.ComponentModel;


namespace WpfApplication1.ViewModel
{
    class CreatingViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IContactsService _contactsService;

        private int _id;
        private string _fio;
        private int _MobileNumber;
        private int _HomeNumber;
        private int _CellNumber;

        public string Fio { get { return _fio; } set { _fio = value; RaisePropertyChanged("Fio"); } }
        public event EventHandler<SaveContactEventArgs> SavingResult;

        private RelayCommand _save;
        public ICommand Save
        {
            get
            {
                if (_save == null) _save = new RelayCommand(SaveContact, ModelIsValid);
                return _save;
            }
        }

        private void SaveContact()
        {
            try
            {
                _contactsService.Save(new Model.Contact(_fio, _MobileNumber, _HomeNumber, _CellNumber, _id));
                if (SavingResult != null)
                    SavingResult(this, new SaveContactEventArgs(true, string.Empty));
            }
            catch(Exception ex)
            {
                if (SavingResult != null)
                    SavingResult(this, new SaveContactEventArgs(false, ex.Message));
            }
        }
        private bool ModelIsValid()
        {
            if (string.IsNullOrEmpty(_fio)) return false;

            return true;
        }

        public CreatingViewModel(IContactsService contactsService)
        {
            if (contactsService == null) throw new ArgumentNullException("contactsService");

            this._contactsService = contactsService;
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Fio" && string.IsNullOrEmpty(_fio)) return "Input a name";

                return null;
            }
        }
        public void SetContact(Contact contact)
        {
            Fio = contact.Fio;
            _MobileNumber = contact.MobileNumber;
            _HomeNumber = contact.HomeNumber;
            _CellNumber = contact.CellNumber;
            _id = contact.IDContact;
        }
    }
    public class SaveContactEventArgs : EventArgs
    {
        public bool Result { get; private set; }
        public string Message { get; private set; }

        public SaveContactEventArgs(bool result, string message)
        {
            this.Result = result;
            this.Message = message;
        }
    }
}
