using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgMarks
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int[] Score { get; set; }
        public double AvgScore { get; set; }
        public static int studentsCount=0;

		public Student()
		{
			
		}
        public Student (int id,String name,string group)
        {
            this.Id = id;
            this.Name = name;
            this.Group = group;
            studentsCount++;
        }

       public  double GetAvgScore (int[] masScore)
            {
            double avgScore=0;
            for (int i = 0; i < masScore.Length; i++)
            {
                avgScore += (double)masScore[i];
            }
            avgScore = avgScore / masScore.Length;
            return avgScore;
            }
        public static double GetGroupAvgScore( double []masScore)
        {
            double avgScore = 0;
            for (int i = 0; i < masScore.Length; i++)
            {
                avgScore += (double)masScore[i];
            }
            avgScore = avgScore / masScore.Length;
            return avgScore;
        }
       public void GetInfo()
        {
            Console.WriteLine($"Name: {Name} \tGroup:{Group} \tAverage Score: {GetAvgScore(Score)}\n");
        }

       
    }
}
