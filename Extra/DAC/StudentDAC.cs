using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    internal class StudentDAC
    {
        private string GETALL = "SELECT * FROM Student";
        private string GETBYID = "SELECT * FROM Student WHERE Id=@I";
        private string INSERT = "INSERT INTO Student(Name,Father,Email)" +
                                " VALUES(@N,@F,@E)";

        private string DELETE = "DELETE FROM Student WHERE Id=@I";
        private string UPDATE = "UPDATE Student SET Name=@N,Father=@F,Email=@E WHERE Id=@I";


        private SqlConnection conn=null;
        private Student student=null;
        


        public  void InsertStudent()
        {

            SqlCommand cmd=new SqlCommand(INSERT,conn );
            cmd.Parameters.AddWithValue("@N", student.Name);
            cmd.Parameters.AddWithValue("@F", student.FatherName);
            cmd.Parameters.AddWithValue("@E", student.Email);
            conn.Open();

            using (cmd)
            {
                cmd.ExecuteNonQuery();

            }
            
        }

        private List<Student> StudentList = null; 
        public List<Student> ListOfStudents()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(GETALL, conn);

                conn.Open();
                using (cmd)
                {

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        StudentList = new List<Student>();
                        while (rdr.Read())
                        {
                            Student Obj = new Student();


                            Obj.Name = rdr.GetString(1);
                            Obj.Email = rdr.GetString(3);
                            Obj.FatherName = rdr.GetString(2);
                            Obj.Id = rdr.GetInt32(0);



                            StudentList.Add(Obj);

                        }

                    }
                }

            }
            catch (Exception ex)
            {

                string e = ex.Message;
            }
           

            return StudentList;
        }



        public Student StudentById(int Id)
        {

            Student Obj = null;

            SqlCommand cmd = new SqlCommand(GETBYID, conn);
            cmd.Parameters.AddWithValue("@I", Id);
            conn.Open();
            using (cmd)
            {

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    Obj=new Student();
                    rdr.Read();

                        Obj.Name = rdr.GetString(1);
                        Obj.Email = rdr.GetString(3);
                        Obj.FatherName = rdr.GetString(2);
                        Obj.Id = rdr.GetInt32(0);


                    rdr.Close();


                }
            }
            return Obj;

        }



        public void UpdataStudent()
        {
            SqlCommand cmd=new SqlCommand(UPDATE,conn);
            cmd.Parameters.AddWithValue("@I", student.Id);
            cmd.Parameters.AddWithValue("@N", student.Name);
            cmd.Parameters.AddWithValue("@F", student.FatherName);
            cmd.Parameters.AddWithValue("@E", student.Email);
            conn.Open();
            using (cmd)
            {
                cmd.ExecuteNonQuery();
            }
        }




        public void DeleteStudent(int Id)
        {
            SqlCommand cmd=new SqlCommand(DELETE,conn);
            cmd.Parameters.AddWithValue("@I", Id);
            conn.Open();
            using (cmd)
            {
                cmd.ExecuteNonQuery();

            }
        }


   public   StudentDAC(SqlConnection ConnectioString)
     {
         conn = ConnectioString;


     }
     public   StudentDAC(SqlConnection ConnectionString,Student student)
        {

            conn = ConnectionString;
            this.student = student;
        }



    }
}
