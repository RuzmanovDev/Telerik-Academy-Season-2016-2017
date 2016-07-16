using AcademyRPG.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public class Ninja : Fighter, IGatherer
    {
        // ninja <name> <position> <owner> 
        public Ninja(string name, Point position, int owner) 
            : base(name, position, owner,0,int.MaxValue)
        {
            this.HitPoints = int.MaxValue;
        }

        public override int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sorted = availableTargets.OrderByDescending(t=>t.HitPoints).ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                if (sorted[i].Owner != this.Owner && sorted[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity*2;
                return true;
            }

            return false;
        }

       
       
    }
}
