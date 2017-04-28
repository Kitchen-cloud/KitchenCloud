using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAC
{
    internal class DACHelper
    {

        internal static SqlConnection DataBaseConnection()
        {
            return new SqlConnection("Data Source=IRSHADAHMED;Initial Catalog=EvsLab;Integrated Security=True");
        }
    }
}