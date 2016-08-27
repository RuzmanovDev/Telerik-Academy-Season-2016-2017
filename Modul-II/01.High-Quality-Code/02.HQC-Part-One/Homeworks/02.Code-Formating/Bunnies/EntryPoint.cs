// <copyright file="EntryPoint.cs" company="TelerikHW">
//    Copyright (c) TelerikHW. All rights reserved.
// </copyright>
// <summary>
//    Entry point of the program 
// </summary>
namespace Bunnies
{
    using System.Collections.Generic;
    using System.IO;

    using Contracts;
    using Enums;
    using Models;

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var bunnies = new List<Bunny>
            {
                new Bunny("Leonid", 1, FurType.NotFluffy),
                new Bunny("Rasputin", 2, FurType.ALittleFluffy),
                new Bunny("Tiberii", 3, FurType.ALittleFluffy),
                new Bunny("Neron", 1, FurType.ALittleFluffy),
                new Bunny("Klavdii", 3, FurType.Fluffy),
                new Bunny("Vespasian", 3, FurType.Fluffy),
                new Bunny("Domician", 4, FurType.FluffyToTheLimit),
                new Bunny("Tit", 2, FurType.FluffyToTheLimit)
            };

            var consoleWriter = new ConsoleWriter();
            Introduce(bunnies, consoleWriter);

            var bunniesFilePath = @"..\..\bunnies.txt";

            SaveBunniesToTextFile(bunnies, bunniesFilePath);
        }

        private static void SaveBunniesToTextFile(IEnumerable<Bunny> bunnies, string bunniesFilePath)
        {
            var fileStream = File.Create(bunniesFilePath);
            fileStream.Close();

            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }

        private static void Introduce(IEnumerable<Bunny> bunnies, IWriter consoleWriter)
        {
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }
        }
    }
}
