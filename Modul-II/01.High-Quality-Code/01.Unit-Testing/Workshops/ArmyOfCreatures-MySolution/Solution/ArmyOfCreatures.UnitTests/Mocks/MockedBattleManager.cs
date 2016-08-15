using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.UnitTests.Mocks
{
    public class MockedBattleManager : BattleManager
    {
        public MockedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
        }

        //protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        //{
        //    if (identifier.ArmyNumber == 1)
        //    {

        //    }
        //}
    }
}
