using KitchenCloudEntities.Users;

namespace KitchenCloudEntities.Common
{
    public class Person
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string FirstName
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

        private ProfileImage profileImage;

        public ProfileImage ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }


        private City city;

        public City City
        {
            get { return city; }
            set { city = value; }
        }



        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }




    }
}
