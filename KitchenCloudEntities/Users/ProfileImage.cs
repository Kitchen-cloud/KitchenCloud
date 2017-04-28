namespace KitchenCloudEntities.Users
{
   public class ProfileImage
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


    }
}
