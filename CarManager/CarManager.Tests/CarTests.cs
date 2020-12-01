using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf", 10, 100)]
        [TestCase("BMW", "3", 20, 200)]
        public void CarCtorSouldSetAllDataCorrectly
            (
            string make, 
            string model, 
            double fuelConsumption, 
            double fuelCapacity)
        {

            //Arrange Act
            Car car = new Car(
                make:make,
                model:model,
                fuelConsumption:fuelConsumption,
                fuelCapacity:fuelCapacity);

            //Assert

            Assert.AreEqual(car.Make,make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarCtorSouldThrowExceptinIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 10));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarCtorSouldThrowExceptinIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 10));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void CarCtorSouldThrowExceptinIfFuelConsumptinIsBelowOrEqualTO_0(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelConsumption, 10));
        }

        [Test]
        [TestCase(-1)]
        
        public void CarCtorSouldThrowExceptinIfFuelCapacityIsBelowOrEqualTo_0(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model",10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelSouldThrowExceptionWhenPassValueIsBelowOrWqualTo_0(double value)
        {
            Car car = new Car("make","model", 10, 1000);

            Assert.Throws<ArgumentException>(() => car.Refuel(value));
        }

        [Test]
        [TestCase(100, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldWorkAsExpected(double capacity, double fuel, double expResult)
        {

            //Arrange
            Car car = new Car("make", "model", 10, capacity);

            //Act
            car.Refuel(fuel);

            //Assert

            var actResult = car.FuelAmount;
            Assert.AreEqual(expResult, actResult);
        }

        [Test]
        [TestCase(10, 50, 505)]
        [TestCase(15, 30, 505)]
      
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnough(double fuelConsumptio, double refuel, double km)
        {

            //Arrange 
            Car car = new Car("make", "model", 10, 100);

            
            car.Refuel(50);
            //Assert//Act

            Assert.Throws<InvalidOperationException>(() => car.Drive(505));
        }

        [Test]
        [TestCase(10,100,50, 95)]
        public void DriveShouldReduceFuelBasedOnDrivenKm(double fuelConsumption, double fuel, double km, double fuelAmountLeft)
        {
            //arrange
            Car car = new Car("make", "model", fuelConsumption, 100);

            car.Refuel(fuel);
            //Act
            car.Drive(km);
            //Assert
            var expValue = fuelAmountLeft;
            var actValue = car.FuelAmount;

            Assert.AreEqual(expValue, actValue);
        }
    }
}