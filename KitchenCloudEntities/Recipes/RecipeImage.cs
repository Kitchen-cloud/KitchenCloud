using KitchenCloudEntities.Common;

namespace KitchenCloudEntities.Recipes
{
   public class RecipeImage
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string folderPath;

        public string FolderPath
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

        private Priority imagePriority;

        public Priority ImagePriority
        {
            get { return imagePriority; }
            set { imagePriority = value; }
        }

    }
}
