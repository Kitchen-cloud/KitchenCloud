using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAC;

namespace EvsLab
{
    public class StudentDatabaseHandler
    {

        public List<Student> SelectAllStudents()
        {

            return new StudentDAC(DACHelper.DataBaseConnection()).ListOfStudents();


        }



    }
}