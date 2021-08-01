using System;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace phase04
{
    class ScoresOrganizer
    {
        private List<Student> StudentsList;
        private List<Grade> ScoresList;
        
        public Student FindStudent(int studentNumber)
        {
            return StudentsList.Where(Student => Student.StudentNumber == studentNumber).First();
        }
        public void GetData(FileReader fileReader, DataManager dataManager)
        {
            string studentsJsonInput = fileReader.ReadData("Students.json");
            StudentsList = dataManager.GetStudentsData(studentsJsonInput);

            string scoresJsonInput = fileReader.ReadData("Scores.json");
            ScoresList = dataManager.GetScoresData(scoresJsonInput);   
        }
        public void PrintOutput()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(StudentsList[i].ToString());
            }             
        }
        public void SortStudentsList(){
            StudentsList.Sort((a, b) => b.GPA.CompareTo(a.GPA));
        }
        public void AddGrades(){
            foreach(Grade grade in ScoresList)
            {
                Student student = FindStudent(grade.StudentNumber);
                student.AddScore(grade.Score);
            }
        }
        public void SetGPAs(){
            foreach(Student student in StudentsList)
                student.CalculateGPA();
        }
        public void Run(FileReader fileReader, DataManager dataManager)
        {
            GetData(fileReader, dataManager);
            AddGrades();
            SetGPAs();
            SortStudentsList();
            PrintOutput();
        }
    }
}