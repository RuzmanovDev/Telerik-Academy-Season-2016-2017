namespace Cars.Tests
{
    using System;

    using NUnit.Framework;
    using Models;
    using Moq;
    using Contracts;
    using Controllers;
    using System.Collections.Generic;

    // I've deleted the old tests and I wrote new ones.
    [TestFixture]
    public class CarsControllerTests
    {
        private ICollection<Car> fakeCarsDb = new List<Car>()
        {
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 }
        };

        [Test]
        public void Add_WhenPassedNullValue_ShouldThrowArgumentException()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            var controler = new CarsController(mockedRepo.Object);

            Assert.Throws<ArgumentNullException>(() => controler.Add(null));
        }


        [Test]
        public void Add_WhenPassedNullValue_ShouldThrowArgumentExceptionWithMsgContainingCar()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            CarsController controler = new CarsController(mockedRepo.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => controler.Add(null));

            StringAssert.Contains("car", ex.Message);
        }


        [TestCase("")]
        [TestCase(null)]
        public void Add_WhenPassedCarNameWithMakeThatIsNullOrEmpty_ShouldThrowArgumentNullException(string make)
        {
            var car = new Car();
            car.Make = make;
            var mockedRepo = new Mock<ICarsRepository>();
            CarsController controler = new CarsController(mockedRepo.Object);


            Assert.Throws<ArgumentNullException>(() => controler.Add(car));
        }

        [Test]
        public void Sort_WhenPassedMakeAsPramaeter_ShouldCallSortedByMakeMethod()
        {
            var mockedCarsRepo = new Mock<ICarsRepository>();
            mockedCarsRepo.Setup(x => x.SortedByMake()).Returns(fakeCarsDb);

            var carsControler = new CarsController(mockedCarsRepo.Object);

            var sortedByMake = carsControler.Sort("make").Model as ICollection<Car>;

            Assert.AreEqual(sortedByMake.Count, this.fakeCarsDb.Count);

        }

        [Test]
        public void Sort_WhenPassedYearAsPramaeter_ShouldCallSortedByYearMoethod()
        {
            var mockedCarsRepo = new Mock<ICarsRepository>();
            mockedCarsRepo.Setup(x => x.SortedByYear()).Returns(fakeCarsDb);

            var carsControler = new CarsController(mockedCarsRepo.Object);

            var sortedByMake = carsControler.Sort("year").Model as ICollection<Car>;

            Assert.AreEqual(sortedByMake.Count, this.fakeCarsDb.Count);

        }

        [Test]
        public void Sort_WhenPassedInvalidPramaeter_ShouldThrowArgumentException()
        {
            var mockedCarsRepo = new Mock<ICarsRepository>();
            var carsControler = new CarsController(mockedCarsRepo.Object);

            Assert.Throws<ArgumentException>(() => carsControler.Sort("yearssas"));

        }

        [Test]
        public void Index_WhenCalled_ShouldReturnAllCars()
        {
            var fakedb = this.fakeCarsDb;
            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.All()).Returns(fakedb);

            var carsControler = new CarsController(mockedRepo.Object);

            var actualResult = carsControler.Index().Model as ICollection<Car>;
            var expected = fakedb;

            Assert.AreEqual(expected, actualResult);
        }

    }
}
