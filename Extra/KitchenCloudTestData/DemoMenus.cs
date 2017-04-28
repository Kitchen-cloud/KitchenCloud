using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudDAC.Menus;

namespace KitchenCloudTestData
{
    class DemoMenus 
    {

        public IEnumerable <Menu> GetListOfMenus()
        {
            IEnumerable<Menu> listOfMenus = new List<Menu>
            {

                new Menu
                {
                    Id = 1,
                    Location = "Lahore",
                    MenuImages = new MenuImages[]
                    {
                        new MenuImages {Caption = "Chinese", Id = 1, ImageName = "Content/Images/All Menus/MenuImg "},
                        new MenuImages {Caption = "Fast Food", Id = 1, ImageName = "Content/Images/All Menus/MenuImg "},
                        new MenuImages {Caption = "Pakistani", Id = 1, ImageName = "Content/Images/All Menus/MenuImg "},
                        new MenuImages {Caption = "L", Id = 1, ImageName = "Content/Images/All Menus/MenuImg "},
                    }
                }

            };

            return listOfMenus;
        }

    }
}
