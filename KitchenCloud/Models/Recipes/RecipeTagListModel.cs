using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Recipes
{
    public class RecipeTagListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static List<RecipeTagListModel> Tags= new List<RecipeTagListModel>();


        public RecipeTagListModel(int id, string name)
        {
            Tags.Add(new RecipeTagListModel() { Id=id,Name = name.Replace(',',' ').ToLower()});
        }

        public RecipeTagListModel()
        {
        }
    }
}