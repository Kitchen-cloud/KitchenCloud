using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudDAC.Common
{
    class Country
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int code;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        private City city;

        public City City
        {
            get { return city; }
            set { city = value; }
        }




    }
}
