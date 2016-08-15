using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Mocks
{
    public class MockedTeleportedStation : TeleportStation
    {
        public MockedTeleportedStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner GetBusinnesOwner
        {
            get { return base.owner; }
        }

        public IEnumerable<IPath> GetGalacticMap
        {
            get { return base.galacticMap; }
        }

        public ILocation GetLocation
        {
            get { return base.location; }
        }

        public void AddResources(IResources res)
        {
            base.resources.Add(res);
        }
    }
}
