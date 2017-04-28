using System;

namespace KitchenCloudEntities.Users
{
    public class OnlineUser
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string loginTime;

        public string LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        private int duration;

        public int Duration
        {
            get { return duration=(Convert.ToDateTime(loginTime)-DateTime.Now).Hours; }
          
        }


        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }


    }
}
