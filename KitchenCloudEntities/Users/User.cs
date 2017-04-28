namespace KitchenCloudEntities.Users
{
  public  class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }





        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private UserType type;

        public UserType Type
        {
            get { return type; }
            set { type = value; }
        }

        private Seller seller;

        public Seller Seller
        {
            get { return seller; }
            set { seller = value; }
        }
        private Buyer buyer;

        public Buyer Buyer
        {
            get { return buyer; }
            set { buyer = value; }
        }











    }
}
