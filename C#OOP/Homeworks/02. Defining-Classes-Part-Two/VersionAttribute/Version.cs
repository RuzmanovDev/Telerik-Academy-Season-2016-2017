namespace VersionAttribute
{
    using System;

    [AttributeUsage(
        AttributeTargets.Struct
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Method
        | AttributeTargets.Enum,
        AllowMultiple = false)]

    public class Version : Attribute
    {
        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }

        public int Minor { get; private set; }

        public override string ToString()
        {
            return $"{this.Major}.{this.Minor}";
        }
    }
}
