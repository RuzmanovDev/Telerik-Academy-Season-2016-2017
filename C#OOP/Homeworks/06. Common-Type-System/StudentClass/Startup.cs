namespace StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // Problem 1. Student class
            var pesho = new Student("Petar", "Dimitrov", "Dimitrov", 1190, "Pesho str29", "0888888888", "pesho@abv.bg", "pesoCourse", SpecialtiesType.JavaDevelopment, UniversityTypes.UNWE, FacultiesType.IT);
            var atanas = new Student("Atanas", "Dimitrov", "Dimitrov", 190, "Pesho str29", "0888888888", "pesho@abv.bg", "pesoCourse", SpecialtiesType.JavaDevelopment, UniversityTypes.UNWE, FacultiesType.IT);

            // this will return true because the have the sam SSN
            Console.WriteLine("Two students are equal if the have the same SSN");
            Console.WriteLine(pesho == atanas);

            // Problem 2. ICloneable
            var clone = pesho.Clone();
            Console.WriteLine(clone);

            // Problem 3. IComparable
            Console.WriteLine(atanas.CompareTo(pesho));
        }
    }
}
