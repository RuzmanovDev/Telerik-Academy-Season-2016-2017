using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {

            // TODO: 70/100
            var engine = new Engine(new ExtendedInteractionManager());
            engine.Start();
        }
    }
}
