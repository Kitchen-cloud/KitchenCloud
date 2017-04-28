namespace KitchenCloudEntities.Chat
{
    public class Inbox
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private MessagePreview messagePreview;

        public MessagePreview MessagePreview
        {
            get { return messagePreview; }
            set { messagePreview = value; }
        }




    }
}
