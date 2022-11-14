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
            string HONDA = car.Make;
            string Civic = car.Model;
            //string Toyota = car.Model;

            //car.Make = Honda;
            //car.Model_Name = Civic;

            //vehicle.HasFlatTire = true;


            Func<Task> act = async () => { await Car.IsValidModelForMakeAsync(); };

            //not sure where to put await - many fails
            //assert
            await act.Should().NotThrowAsync();




        }
        [Fact]
        public async Task IsNotValidModelForTheMakeAsyncTest()
        {
            //arrange
            Car car = new Car();
            string HONDA = car.Make;
            string Toyota = car.Model;

            //act
            Func<Task> act = async () => { await Car.IsValidModelForMakeAsync(); };


            //assert
            await act.Should().ThrowAsync<JsonException>();
            //await act.Should().ThrowAsync<ArgumentException>();



        }

        [Theory]
        [InlineData(29.6, 2)]
        [InlineData(29, 5)]

        public void AddPassengersTests(double milesPerGallon, int passengers)
        {
            using (new AssertionScope())
            {
                //arrange
                Car car = new Car();
                //assert
                car.MilesPerGallon = 30;
                car.AddPassengers(passengers);


                //milesPerGallon.Should().Be(milesPerGallon - (passengers * 0.2));
                milesPerGallon.Should().BeApproximately(car.MilesPerGallon - 0.2 * passengers, 0.01);
                //vehicle.GasLevel.Should().Be($"{vehicle.GasRemaining / vehicle.GasTankCapacity}%");
                //vehicle.MilesRemaining.Should().BeApproximately(vehicle.GasRemaining * vehicle.MilesPerGallon, 0.01);

            }
        }


        [Theory]
        [InlineData(21.6, 5, 3)]
        [InlineData(22, 5, 5)]
        [InlineData(22, 5, 25)]

        public void RemovePassengersTests(double milesPerGallon, int passengersStart, int removedPassengers)
            {
                using (new AssertionScope())
                {
                    //arrange
                    Car car = new Car();
                    //assert
                    car.MilesPerGallon = 22;
                    car.RemovePassengers(passengersStart, removedPassengers);

                    car.NumberOfPassengers.Should().BeGreaterThanOrEqualTo(0);
                    milesPerGallon.Should().BeApproximately(car.MilesPerGallon - 0.2 * car.NumberOfPassengers, 0.01);
                    

                }




            }
      
    }
}




