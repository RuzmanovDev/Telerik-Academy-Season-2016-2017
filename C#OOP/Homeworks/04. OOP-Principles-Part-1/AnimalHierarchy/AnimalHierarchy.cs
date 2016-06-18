namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    using Models;

    public class AnimalHierarchy
    {
        public static void Main(string[] args)
        {
            // Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method 
            var garfild = new Cat("Garfild", 3, Gender.Male);
            var peshi = new Cat("Peshi", 1, Gender.Male);
            var malinka = new Cat("Garfild", 10, Gender.Female);
            var cats = new[] { garfild, peshi, malinka };

            var kitty = new Kitten("Kitty", 1);
            var anotherKitty = new Kitten("Sweety", 3);
            var kapinka = new Kitten("Kapinka", 2);
            var kittens = new[] { kitty, anotherKitty, kapinka };

            var tom = new TomCat("Tom", 5);
            var pesho = new TomCat("Pesho", 10);
            var macharok = new TomCat("Macharok", 8);
            var tomCats = new[] { tom, peshi, macharok };

            var kvaKva = new Frog("Kva-Kva", 1, Gender.Male);
            var krqKrq = new Frog("Krq-Krq", 2, Gender.Male);
            var ploplo = new Frog("Plo-Plo", 1, Gender.Male);
            var frogs = new[] { kvaKva, krqKrq, ploplo };

            var jaime = new Dog("Jaime", 3, Gender.Male);
            var sharo = new Dog("Sharo", 1, Gender.Male);
            var strela = new Dog("Strela", 10, Gender.Female);
            var dogs = new[] { jaime, sharo, strela };

            var averageAgeOfCats = cats
                                    .Select(c => c.Age)
                                    .Average();

            var averageOfKittenns = kittens
                                    .Select(c => c.Age)
                                    .Average();

            var averageAgeOfTomCats = tomCats
                                    .Select(c => c.Age)
                                    .Average();

            var averageAgeOfFrogs = frogs
                                    .Select(f => f.Age)
                                    .Average();

            var averageAgeOGDogs = dogs
                                   .Select(d => d.Age)
                                   .Average();

            Console.WriteLine($"Average age of cats is: {averageAgeOfCats}");
            Console.WriteLine($"Average age of kittens is: {averageOfKittenns}");
            Console.WriteLine($"Average age of tomcats is: {averageAgeOfTomCats}");
            Console.WriteLine($"Average age of frogs is: {averageAgeOfFrogs}");
            Console.WriteLine($"Average age of dogs is: {averageAgeOGDogs}");
        }
    }
}
