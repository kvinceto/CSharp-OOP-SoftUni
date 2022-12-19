using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent s = this.students.FindByName($"{firstName} {lastName}");
            if (s != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            s = new Student(this.GetStudentId(), firstName, lastName);
            this.students.AddModel(s);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, this.students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;
            switch (subjectType)
            {
                case "EconomicalSubject":
                    subject = new EconomicalSubject(this.GetSubjectId(), subjectName); break;
                case "HumanitySubject":
                    subject = new HumanitySubject(this.GetSubjectId(), subjectName); break;
                case "TechnicalSubject":
                    subject = new TechnicalSubject(this.GetSubjectId(), subjectName); break;
                default:
                    return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            ISubject s = this.subjects.FindByName(subjectName);
            if (s != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            this.subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, this.subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity u = this.universities.FindByName(universityName);
            if (u != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> ids = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                var s = this.subjects.FindByName(subject);
                if (s != null)
                {
                    ids.Add(s.Id);
                }
            }
            IUniversity university = new University(this.GetUniId(), universityName, category, capacity, ids);
            this.universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, this.universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            var student = this.students.FindByName(studentName);
            if (student == null)
            {
                string[] name = studentName.Split(' ');
                return string.Format(OutputMessages.StudentNotRegitered, name[0], name[1]);
            }

            var uni = this.universities.FindByName(universityName);
            if (uni == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            HashSet<int> uniExams = uni.RequiredSubjects.ToHashSet();
            List<int> studentExams = student.CoveredExams.ToList();

            foreach (var id in studentExams)
            {
                if (uniExams.Contains(id))
                {
                    uniExams.Remove(id);
                }
                if (uniExams.Count == 0)
                    break;
            }

            if (uniExams.Count > 0)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null)
            {
                if (student.University.Name == universityName)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
                }
            }

            student.JoinUniversity(uni);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = this.students.FindById(studentId);
            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            var subject = this.subjects.FindById(subjectId);
            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Any(id => id == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var uni = this.universities.FindById(universityId);

            List<IStudent> students = this.students.Models
                .Where(s =>  s.University != null)
                .Where(s => s.University.Name == uni.Name)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AppendLine($"*** {uni.Name} ***")
                .AppendLine($"Profile: {uni.Category}")
                .AppendLine($"Students admitted: {students.Count}")
                .AppendLine($"University vacancy: {uni.Capacity - students.Count}");

            return stringBuilder.ToString().Trim();
        }

        private int GetSubjectId()
        {
            return this.subjects.Models.Count + 1;
        }

        private int GetUniId()
        {
            return this.universities.Models.Count + 1;
        }

        private int GetStudentId()
        {
            return this.students.Models.Count + 1;
        }
    }
}
