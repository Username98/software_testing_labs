using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgMarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(1,"Valera","2-1");
            Student student2 = new Student(2,"Katya","2-2");
            Student student3 = new Student(3, "Zhenya", "2-1");
			Student student4 = new Student(4, "Sonya" , "2-1")
			

            student1.Score = new int[] {9,10,10,10,10};
            student2.Score = new int[] {4,5,6,4,4,4,5,6,8,5,6};
            student3.Score = new int[] { 2,10,5};
			student4.Score = new int[] {10,10,10,10,10,10,10,10,10,10,10,10,10,10,1};
            double []mas = new double[] { student1.GetAvgScore(student1.Score), student2.GetAvgScore(student2.Score), student3.GetAvgScore(student3.Score),student4.GetAvgScore(student4.Score)};
            student1.GetInfo();
            student2.GetInfo();
            student3.GetInfo();
			student4.GetInfo();
            Console.WriteLine("Students Count: {1},Group AvgScore: {0}",Student.GetGroupAvgScore(mas), Student.studentsCount);

            
         }
    }
}
