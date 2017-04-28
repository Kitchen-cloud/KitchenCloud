using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudDAC.Menus
{
  public class MenuImages
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private static string folderPath;

        public static string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        private string imageName;

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        private string caption;

        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }





    }
}
