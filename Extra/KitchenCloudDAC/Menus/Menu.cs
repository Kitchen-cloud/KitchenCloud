using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudDAC.Menus
{
 public  class Menu
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private float rating;

        public float Ratings
        {
            get { return rating; }
            set { rating = value; }
        }

        private int totalOrders;

        public int TotalOrders
        {
            get { return totalOrders; }
            set { totalOrders = value; }
        }

        private MenuImages[] menuImages;

        public MenuImages[] MenuImages
        {
            get { return menuImages; }
            set { menuImages = value; }
        }

        private string personsFor;

        public string PersonsFor
        {
            get { return personsFor; }
            set { personsFor = value; }
        }


        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }



    }
}
