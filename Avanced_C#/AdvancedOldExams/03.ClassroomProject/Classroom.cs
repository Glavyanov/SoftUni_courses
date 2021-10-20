
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> strudents;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.strudents = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => this.strudents.Count;

        public string RegisterStudent(Student student)
        {
            if (this.strudents != null && this.Count < this.Capacity)
            {
                this.strudents.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.strudents != null && this.strudents.Any( s => s.FirstName == firstName && s.LastName == lastName))
            {
                Student student = this.strudents.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                this.strudents.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (this.strudents != null)
            {
                var subjectStudents = this.strudents.Where(s => s.Subject == subject).ToList();
                if (subjectStudents.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Subject: {subject}")
                        .AppendLine("Students:");
                    foreach (var item in subjectStudents)
                    {
                        sb.AppendLine($"{item.FirstName} {item.LastName}");
                    }
                    return sb.ToString().TrimEnd();

                }

            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return this.strudents.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
