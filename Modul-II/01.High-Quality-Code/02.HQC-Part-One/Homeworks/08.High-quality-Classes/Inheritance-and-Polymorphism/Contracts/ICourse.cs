using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism.Contracts
{
    public interface ICourse
    {
        string Name { get; }

        string TeacherName { get; }

        ICollection<string> Students { get; }
    }
}
