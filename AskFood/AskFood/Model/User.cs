namespace AskFood.Model
{
    public class User : BaseViewModel
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


    }
}
