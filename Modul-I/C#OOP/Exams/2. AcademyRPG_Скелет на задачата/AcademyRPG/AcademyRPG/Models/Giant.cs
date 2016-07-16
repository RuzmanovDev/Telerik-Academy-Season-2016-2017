using AcademyRPG.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public class Giant : Fighter, IGatherer
    {
        private const int DefaultAtack = 150;
        private const int DefaultDeff = 80;
        private const int DefaultHP = 200;
        private bool hasGathereStone;

        public Giant(string name, Point position)
            : base(name, position, 0, DefaultAtack, DefaultDeff)
        {
            this.HitPoints = DefaultHP;
            this.hasGathereStone = false;
        }

        public override int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            //TODO only once
            if (resource.Type == ResourceType.Stone && !hasGathereStone)
            {
                this.AttackPoints += 100;
                hasGathereStone = true;
                return true;
            }

            if (resource.Type == ResourceType.Stone)
            {
                return true;
            }
            return false;
        }
    }
}
