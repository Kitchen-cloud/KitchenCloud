using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudDAC.Common;
namespace KitchenCloudDAC.Users
{
    class Seller : Person
    {
        private float rank;

        public float Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        private int totalOrders;

        public int TotalOrders
        {
            get { return totalOrders; }
            set { totalOrders = value; }
        }


        private Services[] services;

        public Services[] Services
        {
            get { return services; }
            set { services = value; }
        }


        private int reviews;

        public int Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }


        private int visitors;

        public int Visitors
        {
            get { return visitors; }
            set { visitors = value; }
        }





    }
}
