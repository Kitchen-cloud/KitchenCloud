using System.Collections.Generic;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Users;

namespace KitchenCloudEntities.Recipes
{
 public  class Recipe
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



        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }







        private ServingFor  personsFor;

        public ServingFor PersonsFor
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

        private Seller seller;

        public Seller Seller
        {
            get { return seller; }
            set {  seller = value; }
        }


       

        private City city;

        public City City
        {
            get { return city; }
            set { city = value; }
        }



        private string streetAddress;

        public string StreeAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }
    








        private List<RecipeImage> recipeImages;

        public List<RecipeImage> RecipeImages
        {
            get { return recipeImages; }
            set { recipeImages = value; }
        }

  private RecipeSubCategory subCategory;

        public RecipeSubCategory SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; }
        }


        private List<RecipeReview> recipeReviews;

        public List<RecipeReview> RecipeReviews
        {
            get { return recipeReviews; }
            set { recipeReviews = value; }
        }
        private List<RecipeTag> recipeTags;

        public List<RecipeTag> RecipeTags
        {
            get { return recipeTags; }
            set { recipeTags = value; }
        }


    }
}
