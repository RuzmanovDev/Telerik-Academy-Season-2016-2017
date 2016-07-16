using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public class Knight : Fighter
    {
        //100 AttackPoints, 100 DefensePoints and 100 HitPoints. 
        private const int DefaultAtack = 100;
        private const int DefaultDeff = 100;
        private const int DefaultHP = 100;

        public Knight(string name, Point position,int owner) 
            : base(name, position, owner, DefaultAtack, DefaultDeff)
        {
            this.AttackPoints = DefaultAtack;
            this.DefensePoints = DefaultDeff;
            this.HitPoints = DefaultHP;
        }

        // TODO the guard and the knight have similar atackmethod
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
    }
}
