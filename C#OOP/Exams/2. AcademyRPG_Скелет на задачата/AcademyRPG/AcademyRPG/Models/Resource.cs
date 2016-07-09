using AcademyRPG.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Models
{
    public abstract class Resource : StaticObject, IResource
    {
        private int quantity;
        private ResourceType type;

        public Resource(Point position, int owner = 0)
            : base(position, owner)
        {
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            protected set
            {
                this.quantity = value;
            }
        }

        public ResourceType Type
        {
            get
            {
                return this.type;
            }

            protected set
            {
                this.type = value;
            }
        }
    }
}
