namespace KitchenCloudEntities.Common
{
   public class City
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Country country;

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }


    }
}
