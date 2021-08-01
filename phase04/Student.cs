using System.Collections.Generic;
using System.Linq;

namespace phase04 
{
    class Student
    {
        public string FirstName {set; get;}
        public string LastName {get; set;}
        public int StudentNumber {get; set;}
        private List<double> _Grades;
        public double GPA {set; get;}
        public Student(int studentNumber, string firstName, string lastName) {
            GPA = 0;
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
            _Grades = new List<double>();
        }
        public void AddScore(double grade) 
        {
            _Grades.Add(grade);
        }

        public void CalculateGPA()
        {
            double gradesSum = _Grades.Sum();            
            GPA = gradesSum/_Grades.Count;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "       GPA: " + GPA + '\n'; 
        }
    }

}