using AcademyRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Contracts
{
    public interface IFighter : IControllable
    {
        int AttackPoints
        {
            get;
        }

        int DefensePoints
        {
            get;
        }

        int GetTargetIndex(List<WorldObject> availableTargets);
    }
}
