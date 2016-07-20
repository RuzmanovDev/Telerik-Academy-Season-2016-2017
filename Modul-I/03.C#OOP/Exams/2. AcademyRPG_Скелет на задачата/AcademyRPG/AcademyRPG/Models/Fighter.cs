using AcademyRPG.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public abstract class Fighter : Character, IFighter
    {
        private int atackPoints;
        private int deffencePoints;

        public Fighter(string name, Point position, int owner,int atackPoints, int deffencePoints) 
            : base(name, position, owner)
        {
            this.AttackPoints = atackPoints;
            this.DefensePoints = deffencePoints;
        }

        public virtual int AttackPoints
        {
            get
            {
                return this.atackPoints;
            }

            protected set
            {
                this.atackPoints = value;
            }
        }

        public virtual int DefensePoints
        {
            get
            {
                return this.deffencePoints;
            }

            protected set
            {
                this.deffencePoints = value;
            }
        }

        public abstract int GetTargetIndex(List<WorldObject> availableTargets);
       
    }
}
