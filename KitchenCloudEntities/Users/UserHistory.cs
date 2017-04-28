namespace KitchenCloudEntities.Users
{
   public class UserHistory
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string loginTime;
        public string LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        private string logoutTime;

        public string LogoutTime
        {
            get { return logoutTime; }
            set { logoutTime = value; }
        }




    }
}
