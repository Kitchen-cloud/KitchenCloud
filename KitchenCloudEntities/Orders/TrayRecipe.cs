using KitchenCloudEntities.Users;

namespace KitchenCloudEntities.Orders
{
  public  class TrayRecipe
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        private string subCategory;

        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private Seller seller;

        public Seller Seller
        {
            get { return seller; }
            set { seller = value; }
        }


    }
}
