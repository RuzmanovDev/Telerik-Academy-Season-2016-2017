using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Suplements
{
    public abstract class Suplement : ISupplement
    {
        public Suplement()
        {

        }
        public virtual int AggressionEffect
        {
            get; protected set;
        }

        public virtual int HealthEffect
        {
            get; protected set;
        }

        public virtual int PowerEffect
        {
            get; protected set;

        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

            // TODO : •	Edit: The ReactTo method needs to be implemented specifically
            // for ONLY two of the above tasks – most supplements don’t need to react (at least in this task) 
            throw new NotImplementedException();
        }
    }
}
