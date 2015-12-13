/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfApplication1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private IContactsRepository _contactRepository;
        private IContactsService _contactsService;

        public ViewModelLocator()
        {
            _contactRepository = new WpfApplication1.ContactsRepository(); // что за метод к какому классу он относиться?
            _contactsService = new ContactsService(_contactRepository);
        }

        public MainViewModel Main
        {
            get
            {
                return new MainViewModel(_contactsService);
            }
        }

        public CreatingViewModel Contact
        {
            get
            {
                return new CreatingViewModel(_contactsService);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}