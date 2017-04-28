using KitchenCloudEntities.Common;

namespace KitchenCloudEntities.Users
{
   public class Seller : Person
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




        private bool instantBake;

        public bool InstantBake
        {
            get { return instantBake; }
            set { instantBake = value; }
        }

        private bool fastDelivery;

        public bool FastDelivery
        {
            get { return fastDelivery; }
            set { fastDelivery = value; }
        }


        private bool availableForJob;

        public bool AvailableForJob
        {
            get { return availableForJob; }
            set { availableForJob = value; }
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

       private string slogan;

       public string Slogan
        {
            get { return slogan; }
            set { slogan = value; }
        }



    }
}
