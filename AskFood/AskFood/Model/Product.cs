namespace AskFood.Model
{
    public class Product : BaseViewModel
    {
        public int Id { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name , value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description , value); }
        }


        public int Type { get; set; }
    }
}