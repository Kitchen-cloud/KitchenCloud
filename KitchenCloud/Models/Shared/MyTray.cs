using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Shared
{

        public class MyTray
    {
            public MyTray()
            {
                items = new List<MyTrayRecipe>();
            }




        private List<MyTrayRecipe> items;

            public List<MyTrayRecipe> Items
            {
                get { return items; }
            }

            public void Add(MyTrayRecipe item)
            {
            MyTrayRecipe found = items.Find(ci => ci.Id == item.Id);
                if (found == null)
                {
                    items.Add(item);
                }
                else
                {
                    found.Quantity += item.Quantity;
                }
            }

            //public void Add(int id,int qty)
            //{
            //    CartItem cItem = items.Find(ci => ci.Id == id);
            //    if (cItem == null)
            //    {
            //        items.Add(new CartItem { Id = id, Quantity = qty });
            //    }
            //    else
            //    {
            //        cItem.Quantity += qty;
            //    }            
            //}
        }
    }
