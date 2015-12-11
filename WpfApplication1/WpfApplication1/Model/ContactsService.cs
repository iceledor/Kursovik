using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            if (contactsRepository == null) throw new ArgumentNullException("contactsRepository");

            this._contactsRepository = contactsRepository;
        }

        public IEnumerable<Model.Contact> Contacts()
        {
            return _contactsRepository.Contacts();
        }

        public Model.Contact Save(Model.Contact newContact)
        {
            if (string.IsNullOrEmpty(newContact.Fio)) throw new ArgumentException("Contact was not named");
            if (newContact.IDContact == 0) return AddNewContact(newContact);
            else return AddNewContact(newContact);
        }

        public void Remove(int id)
        {
            _contactsRepository.Remove(id);
        }

        private Model.Contact AddNewContact(Model.Contact newContact)
        {
            if (Contacts().Any(x => x.Fio.CompareTo(newContact.Fio) == 0)) 
                throw new ArgumentException("This name was already used");

            int _IDContact = _contactsRepository.Add(newContact);
            int _MobileNumber = _contactsRepository.Add(newContact);
            int _HomeNumber = _contactsRepository.Add(newContact);
            int _CellNumber = _contactsRepository.Add(newContact);
            return new Model.Contact(newContact.Fio,_MobileNumber,_HomeNumber,_CellNumber,_IDContact);
        }
    }
}
