namespace StudentClass
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : ICloneable, IComparable
    {
        public Student(
            string firstame,
            string middleName,
            string lastName,
            int ssn,
            string pernamentAddress,
            string mobilePhone,
            string email,
            string course,
            SpecialtiesType specialty,
            UniversityTypes univeristy,
            FacultiesType faculty)
        {
            this.FirstName = firstame;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PernamenAddress = pernamentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = univeristy;
            this.Faculty = faculty;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public string MobilePhone { get; private set; }

        public string PernamenAddress { get; private set; }

        public int SSN { get; private set; }

        public string Email { get; private set; }

        public string Course { get; private set; }

        public SpecialtiesType Specialty { get; private set; }

        public UniversityTypes University { get; private set; }

        public FacultiesType Faculty { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder(24);
            builder.AppendLine($"Frist name: {this.FirstName}");
            builder.AppendLine($"Middle name: {this.MiddleName}");
            builder.AppendLine($"Last name: {this.LastName}");
            builder.AppendLine($"SSN: {this.SSN}");
            builder.AppendLine($"Pernament address: {this.PernamenAddress}");
            builder.AppendLine($"Email: {this.Email}");
            builder.AppendLine($"Mobile phone: {this.MobilePhone}");
            builder.AppendLine($"Course: {this.Course}");
            builder.AppendLine($"Specialty name: {this.Specialty}");
            builder.AppendLine($"University: {this.University}");
            builder.AppendLine($"Faculty: {this.Faculty}");

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.SSN;
        }

        public override bool Equals(object obj)
        {
            var anotherStudent = obj as Student;

            if (anotherStudent.SSN == this.SSN)
            {
                return true;
            }

            return false;
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.LastName, this.LastName, this.SSN, this.PernamenAddress, this.MobilePhone, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(object obj)
        {
            var other = obj as Student;

            if (this.FirstName != other.FirstName)
            {
                return (string.Compare(this.FirstName, other.FirstName));
            }
            if (this.LastName != other.LastName)
            {
                return (string.Compare(this.LastName, other.LastName));
            }
            if (this.SSN != other.SSN)
            {
                return (int)(this.SSN - other.SSN);
            }
            return 0;

        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !s1.Equals(s2);
        }

    }
}
