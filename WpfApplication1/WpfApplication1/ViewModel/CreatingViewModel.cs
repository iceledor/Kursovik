using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApplication1.ViewModel
{
    class CreatingViewModel : ViewModelBase
    {
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string CellNumber { get; set; }
        public string Fio { get; set; }
    }
}
