using Cosmetics.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Mock
{
    internal class MockedEngine : CosmeticsEngine
    {
        public MockedEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart)
            : base(factory, shoppingCart)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }
    }
}
