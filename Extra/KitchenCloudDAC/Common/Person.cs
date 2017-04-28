using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudDAC.Common
{
    class Person
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string Name
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }




        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string profileImage;

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }


        private Country country;

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }


       





    }
}
