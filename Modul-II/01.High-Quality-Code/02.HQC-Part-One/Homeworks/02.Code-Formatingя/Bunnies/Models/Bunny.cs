namespace Bunnies.Models
{
    using System;
    using System.Text;

    using Bunnies.Contracts;
    using Bunnies.Enums;
    using Bunnies.Extensions;

    [Serializable]
    public class Bunny
    {
        public Bunny(string name, int age, FurType furType)
        {
            this.Name = name;
            this.Age = age;
            this.FurType = furType;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public FurType FurType { get; private set; }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine(string.Format("{0} - \"I am {1} years old!\"", this.Name, this.Age));
            writer.WriteLine(string.Format("{0} - \"And I am {1}", this.Name, this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()));
        }

        public override string ToString()
        {
            int builderSize = 200;
            var builder = new StringBuilder(builderSize);

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}");

            return builder.ToString();
        }
    }
}
