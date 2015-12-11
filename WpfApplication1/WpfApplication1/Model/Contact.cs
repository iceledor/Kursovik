using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApplication1.Model
{
    public class Contact : DbContext
    {
        public int MobileNumber { get; set; }
        public int HomeNumber { get; set; }
        public int CellNumber { get; set; }
        public string Fio { get; set; }
        public int IDContact { get; set; }
        public Contact(string _Fio,int _MobileNumber,int _HomeNumber,int _CellNumber,int _IDContact)
        {
            MobileNumber = _MobileNumber;
            HomeNumber = _HomeNumber;
            CellNumber = _CellNumber;
            Fio = _Fio;
            IDContact = _IDContact;
        }
    }
}
