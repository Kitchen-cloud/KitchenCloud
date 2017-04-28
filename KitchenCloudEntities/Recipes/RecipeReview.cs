using KitchenCloudEntities.Orders;

namespace KitchenCloudEntities.Recipes
{
   public class RecipeReview
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Order order;

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }


        private double stars;

        public double Stars
        {
            get { return stars; }
            set { stars = value; }
        }
        private string feedBack;

        public string FeedBack
        {
            get { return feedBack; }
            set { feedBack = value; }
        }



    }
}
