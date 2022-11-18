using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTests
    {
        [Fact]
        public void CarHas4Tires()
        {
            //arrange
            Car car = new Car();
            //act

            //assert
            car.NumberOfTires.Should().Be(4);
        }
       
        [Fact]
        public void CarIsAVehicle()
        {
            //arrange
            Car car = new Car();
            //act

            //assert
            car.Should().BeAssignableTo<Vehicle>();
        }
        //Verify that IsValidModelForMakeAsync can successfully
        //be used to tell if a Make and Model are valid
        [Fact]
        public async Task IsValidModelForMakeAsyncTest()
        {
            //arrange
            Car car = new Car();
            string Honda = car.Make;
            string Civic = car.Model;
            //assert
            Func<Task> act = async () => { await car.IsValidModelForMakeAsync(); };

            await act.Should().NotThrowAsync<ArgumentNullException>();
          
        }
        [Fact]
        public async Task IsValidModelForMakeAsyncTestWrongModel()
        {
            //arrange///////////double gasTankCapacity,string carMake, string carModel, double milesPerGallon
            Car car = new Car();
            string Honda = car.Make;
            string Camry = car.Model;

            //assert
            Func<Task> act = async () => { await car.IsValidModelForMakeAsync(); };

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]//Negative test
        public async Task WasModelMadeInYearAsyncNegative()
        {
            //arrange
            Car car = new Car();
           
            //act
            Func<Task> act = async () => { await car.WasModelMadeInYearAsync(1994); };

            //assert
            await act.Should().ThrowAsync<ArgumentException>().WithMessage("No data*");
           
        }
        [Theory]////   Positive test
        [InlineData(2000)]
        //[InlineData()]
        //[InlineData()]
        //[InlineData()]
        public async Task WasModelMadeInYearAsyncPositive(int year)
        {
            //arrange
            Car car = new Car();
            var Subaru = car.Make;
            var WRX = car.Model;

            //act
            Func<Task> act = async () => { await car.WasModelMadeInYearAsync(1996); };

            //assert
            await act.Should().ThrowAsync<ArgumentException>();

        }

        [Theory]
        [InlineData(29.6, 2)]
        [InlineData(29, 5)]
        [InlineData(30, 0)]

        public void AddPassengersTests(double milesPerGallon, int passengers)
        {
            using (new AssertionScope())
            {
                //arrange
                Car car = new Car();
                //assert
                car.MilesPerGallon = 30;
                car.AddPassengers(passengers);

                milesPerGallon.Should().BeApproximately(car.MilesPerGallon - 0.2 * passengers, 0.01);
                //milesPerGallon.Should().Be(milesPerGallon - (passengers * 0.2));

               // car.GasLevel.Should().Be($"{car.GasRemaining / car.GasTankCapacity}%");
               // car.MilesRemaining.Should().BeApproximately(car.GasRemaining * car.MilesPerGallon, 0.01);

            }
        }


        [Theory]
        [InlineData(20.6, 3)]
        [InlineData(21, 5)]
        [InlineData(21, 25)]

        public void RemovePassengersTests(double milesPerGallon, int removedPassengers)
        {
                using (new AssertionScope())
                {
                    //arrange
                    Car car = new Car();
                    //assert
                    car.MilesPerGallon = 21;
                    car.RemovePassengers(removedPassengers);
                    

                    car.NumberOfPassengers.Should().BeInRange(0, 5);// BeGreaterThanOrEqualTo(0)
                    milesPerGallon.Should().BeApproximately(car.MilesPerGallon - 0.2 * car.NumberOfPassengers, 0.01);
                    

                }




        }
      
    }
}




