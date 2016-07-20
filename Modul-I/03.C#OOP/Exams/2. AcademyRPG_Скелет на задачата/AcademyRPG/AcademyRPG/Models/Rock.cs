using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public class Rock : Resource
    {
        public Rock(int hp,Point position, int owner = 0)
            : base(position, 0)
        {
            this.HitPoints = hp;
            this.Type = ResourceType.Stone;
            this.Quantity = this.HitPoints / 2;
        }
       
    }
}
