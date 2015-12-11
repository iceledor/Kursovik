using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.zxz
{
    class ContactsRepository : IContactsRepository
    {
        public IEnumerable<Contact> Contacts()
        {
            List<Contact> contactlist = new List<Contact>();
            using (Contact context = new Contact(_Fio,_MobileNumber,_HomeNumber,_CellNumber,_IDContact))
            {
                foreach (var item in context.Contacts)
                {
                    contactlist.Add(new Model.Contact(_Fio, _MobileNumber, _HomeNumber, _CellNumber, _IDContact));
                }
            }
            result
        }
    }
}
