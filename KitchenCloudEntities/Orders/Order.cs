namespace KitchenCloudEntities.Orders
{
    public class Order
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Status orderStatus;

        public Status OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }


        private int buyerId;

        public int BuyerId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }



        private TrayRecipe recipe;

        public TrayRecipe Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }


        private string orderDate;

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        private string dueDate;

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private Time orderTime;

        public Time OrderTime
        {
            get { return orderTime; }
            set { orderTime = value; }
        }






    }
}
