namespace KitchenCloudEntities.Chat
{
    public class Attachment
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private Message message;

        public Message Message
        {
            get { return message; }
            set { message = value; }
        }




    }
}
