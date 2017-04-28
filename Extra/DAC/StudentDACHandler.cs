using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAC
{
    public class StudentDACHandler
    {
        public void AddStudent(Student std)
        {

            new StudentDAC(DACHelper.DataBaseConnection(), std).InsertStudent();

        }

        public Student SelectStudentById(int Id)
        {
            return new StudentDAC(DACHelper.DataBaseConnection()).StudentById(Id);
        }


        public List<Student> SelectAllStudents()
        {

            return new StudentDAC(DACHelper.DataBaseConnection()).ListOfStudents();
        }


        public void UpdateStudent(Student student)
        {
            new StudentDAC(DACHelper.DataBaseConnection(),student).UpdataStudent();
        }


        public void DeleteStudent(int Id)
        {
            new StudentDAC(DACHelper.DataBaseConnection()).DeleteStudent(Id);
        }


    }
}