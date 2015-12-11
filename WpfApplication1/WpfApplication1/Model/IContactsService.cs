using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public interface IContactsService
    {
        IEnumerable<Contact> Contacts();
        Contact Save(Contact contact);
        void Remove(int _IDContact);
    }
}
