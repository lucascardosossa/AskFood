using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.Model
{
    public class Item : BaseViewModel
    {
        public int Id { get; set; }

        private String name;

        public String Name
        {
            get { return name; }
            set { SetProperty(ref name , value); }
        }

        private String description;

        public String Description
        {
            get { return description; }
            set { SetProperty(ref description , value); }
        }

        private int amount;

        public int Amount
        {
            get { return amount; }
            set { SetProperty(ref amount , value); }
        }
        
        public int Product_id { get; set; }
    }
}
