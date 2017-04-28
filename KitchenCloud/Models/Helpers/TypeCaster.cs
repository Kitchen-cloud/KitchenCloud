using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Messenger;
using KitchenCloud.Models.Recipes;
using KitchenCloud.Models.Sellers;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Messenger;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Messenger;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Helpers
{
    public class TypeCaster
    {

        public static List<SelectListItem> ToSelectListItem(dynamic List)
        {
            List<SelectListItem> temp = null;
            if (List != null)
            {
                temp = new List<SelectListItem>();
                foreach (var item in List)
                {

                    temp.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
                }
            }
            return temp;
        }

        public static List<RecipeTemplate> ToRecipeTemplateList(List<Recipe> RecipeList)
        {
            List<RecipeTemplate> recipeTemplateList = null;
            if (RecipeList != null)
            {
                recipeTemplateList = new List<RecipeTemplate>();
                foreach (Recipe recipe in RecipeList)
                {

                    RecipeImage img = null;
                    foreach (RecipeImage recipeImage in recipe.RecipeImages)
                    {
                        if (recipeImage.ImagePriority == Priority.High)
                        {
                            img = new RecipeImage()
                            {
                                Caption = recipeImage.Caption,
                                FolderPath = recipeImage.FolderPath,
                                Id = recipeImage.Id,
                                ImageName = recipeImage.ImageName,
                                ImagePriority = recipeImage.ImagePriority
                            };
                        }
                    }
                    List<string> taglist = new List<string>();
                    foreach (RecipeTag recipeTag in recipe.RecipeTags)
                    {
                        taglist.Add(recipeTag.Name);
                    }
                    string[] tg = taglist.ToArray();

                    try
                    {



                        recipeTemplateList.Add(new RecipeTemplate()
                        {
                            Id = recipe.Id,
                            Image = img.FolderPath,
                            Location = recipe.City.Name + ", " + recipe.City.Country.Name,
                            PersonsFor = recipe.PersonsFor.ToString(),
                            Ratings = recipe.Ratings,
                            Title = recipe.Title,
                            TotalOrders = recipe.TotalOrders,
                            Services = new string[] { recipe.SubCategory.RecipeCategory.Name, recipe.SubCategory.Name },
                            Price = recipe.Price,
                            Seller = new RecipeSeller()
                            {
                                Id = recipe.Seller.Id,
                                FullName = recipe.Seller.FirstName + " " + recipe.Seller.SecondName,
                                Description = recipe.Seller.Description,
                                ProfileImage = recipe.Seller.ProfileImage.FolderPath
                            },
                            Tags = tg
                        });

                    }
                    catch (Exception ex)
                    {

                        string a = ex.Message;
                    }
                }

            }
            return recipeTemplateList;

        }

        public static RecipeTemplate ToRecipeTemplate(Recipe recipe)
        {
            RecipeTemplate recipeTemplate = null;
            if (recipe != null)
            {
                recipeTemplate = new RecipeTemplate();


                RecipeImage img = null;
                foreach (RecipeImage recipeImage in recipe.RecipeImages)
                {
                    if (recipeImage.ImagePriority == Priority.High)
                    {
                        img = new RecipeImage()
                        {
                            Caption = recipeImage.Caption,
                            FolderPath = recipeImage.FolderPath,
                            Id = recipeImage.Id,
                            ImageName = recipeImage.ImageName,
                            ImagePriority = recipeImage.ImagePriority
                        };
                    }
                }
                List<string> taglist = new List<string>();
                foreach (RecipeTag recipeTag in recipe.RecipeTags)
                {
                    taglist.Add(recipeTag.Name);
                }
                string[] tg = taglist.ToArray();

                new RecipeTemplate()
                {
                    Id = recipe.Id,
                    Image = img.FolderPath,
                    Location = recipe.City.Name + ", " + recipe.City.Country.Name,
                    PersonsFor = recipe.PersonsFor.ToString(),
                    Ratings = recipe.Ratings,
                    Title = recipe.Title,
                    TotalOrders = recipe.TotalOrders,
                    Services = new string[] { recipe.SubCategory.RecipeCategory.Name, recipe.SubCategory.Name },
                    Price = recipe.Price,
                    Seller = new RecipeSeller()
                    {
                        Id = recipe.Seller.Id,
                        FullName = recipe.Seller.FirstName + " " + recipe.Seller.SecondName,
                        Description = recipe.Seller.Description,
                        ProfileImage = recipe.Seller.ProfileImage.FolderPath
                    },
                    Tags = tg
                };




            }
            return recipeTemplate;

        }


        public static List<MessageModel> MessageListToMessageModelList(List<Message> messageList)
        {

            List<MessageModel> messages = null;
            if (messageList != null)
            {
                messages = new List<MessageModel>();
                foreach (Message message in messageList)
                {
                    ProfileImage img = new ProfileImageHandler().GetById(new SellerHandler().GetById(message.Sender.Id).ProfileImage.Id);

                    messages.Add(new MessageModel()
                    {
                        Status = message.Status,
                        Id = message.Id,
                        SentOn = message.SentDateTime.ToString(),
                        Body = message.Body,
                        SenderName = new SellerHandler().GetById(message.Sender.Id).FirstName,
                        SenderImage = img.FolderPath+img.ImageName,
                        RecieverId = message.Reciever.Id,
                        SenderId = message.Sender.Id
                       
                    });
                }

            }
            return messages;
        }

        public static List<MessagePreviewModel> MessageModelListToMessagePreviewList(List<MessageModel> messageList)
        {
            List<MessagePreviewModel> messages = null;
            if (messageList != null)
            {
                messages = new List<MessagePreviewModel>();
                foreach (MessageModel message in messageList)
                {
                    messages.Add(new MessagePreviewModel()
                    {
                        Status = message.Status,
                        Id = message.Id,
                        SenderName = message.SenderName,
                        SenderImage = message.SenderImage,
                        RecievedOn=Convert.ToDateTime(message.SentOn),
                        Preview = message.Body.Length>30?message.Body.Substring(0,message.Body.Length/2):message.Body
                    });
                }

            }
            return messages;

        }




        ////public static List<SellerServices> ToService(FormCollection formCollection)
        //{
        //    List<SellerServices> sellerServices = null;
        //    if (formCollection != null)
        //    {
        //        sellerServices = new List<SellerServices>
        //        {
        //             //(string.IsNullOrEmpty(data["Wifi"])) ? false : true;
        //        new SellerServices()
        //            {
        //                IsChecked = formCollection["IB"].Equals("True")  ,
        //                Name = "Instant Bake",
        //                Key = "IB"

        //            },
        //            new SellerServices()
        //            {
        //                IsChecked =  formCollection["FD"].Equals("True"),
        //                Name = "Fast Delivery",
        //                Key = "FD"

        //            },
        //            new SellerServices()
        //            {
        //                IsChecked = formCollection["AJ"].Equals("True"),
        //                Name = "Available For Job",
        //                Key = "AJ"
        //            }
        //        };
        //    }
        //    return sellerServices;
        //}


    }
}
