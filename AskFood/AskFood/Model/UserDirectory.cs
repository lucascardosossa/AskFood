using AskFood.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.Model
{
    public class UserDirectory : BaseViewModel
    {
        private ObservableCollection<User> user = new ObservableCollection<User>();

        public ObservableCollection<User> User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
    }
}
