using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            var teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            var localCourse = new LocalCourse(name, teacher, lab);
            return localCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            var offsiteCourse = new OffsiteCourse(name, teacher, town);
            return offsiteCourse;
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            CourseFactory factory = new CourseFactory();
            ITeacher nakov = factory.CreateTeacher("Nakov");
            Console.WriteLine(nakov);
            nakov.Name = "Svetlin Nakov";
            ICourse oop = factory.CreateLocalCourse("OOP", nakov, "Light");
            oop.AddTopic("Using Classes and Objects");
            oop.AddTopic("Defining Classes");
            oop.AddTopic("OOP Principles");
            oop.AddTopic("Teamwork");
            oop.AddTopic("Exam Preparation");
            Console.WriteLine(oop);
            ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
            html.AddTopic("Using Classes and Objects");
            html.AddTopic("Defining Classes");
            html.AddTopic("OOP Principles");
            html.AddTopic("Teamwork");
            html.AddTopic("Exam Preparation");
            Console.WriteLine(html);
            nakov.AddCourse(oop);
            nakov.AddCourse(html);
            Console.WriteLine(nakov);
            oop.Name = "Object-Oriented Programming";
            (oop as ILocalCourse).Lab = "Enterprise";
            oop.Teacher = factory.CreateTeacher("George Georgiev");
            oop.AddTopic("Practical Exam");
            Console.WriteLine(oop);
            html.Name = "HTML Basics";
            (html as IOffsiteCourse).Town = "Varna";
            html.Teacher = oop.Teacher;
            html.AddTopic("Practical Exam");
            Console.WriteLine(html);
            ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
            Console.WriteLine(css);
        }

    }

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the teacher cannot be null");
                }
                this.name = value;
            }
        }

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }
        public IList<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
            private set
            {
                this.courses = value;
            }
        }
        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            //  return $"Teacher: Name={this.Name}; Courses=[{string.Join(",", this.courses)}]";
            string format = "Teacher: Name={0}";
            if (this.courses.Count > 0)
            {
                format += "; Courses=[{1}]";
            }

            var courseNames = this.courses.Select(x => x.Name);
            string result = string.Format(format, this.Name, string.Join(", ", courseNames));

            return result;
        }
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private IList<string> topics;


        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();

        }
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            // (course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            // return $"Name{this.Name}; Teacher={this.Teacher}; Topics={string.Join(", ", this.topics)}";

            string result = string.Format("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                result += string.Format("; Teacher={0}", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                result += string.Format("; Topics=[{0}]", string.Join(", ", this.topics));
            }

            return result;
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;


        public LocalCourse(string name, ITeacher teacher, string lab) : base(name, teacher)
        {
            this.Lab = lab;
        }
        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            //   return $"course type: {this.GetType().ToString()}" + base.ToString();
            return string.Format("{0}; Lab={1}", base.ToString(), this.Lab);
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;
        public OffsiteCourse(string name, ITeacher teacher, string town) : base(name, teacher)
        {
            this.Town = town;
        }
        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}; Town={1}", base.ToString(), this.Town);
        }
    }
}
