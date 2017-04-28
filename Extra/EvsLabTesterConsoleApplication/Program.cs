using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;

namespace EvsLabTesterConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StudentDACHandler std=new StudentDACHandler();

            foreach (var student in std.SelectAllStudents())
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.FatherName);
                Console.WriteLine(student.Email);
            }
            Console.ReadKey();
        }

    }
}
