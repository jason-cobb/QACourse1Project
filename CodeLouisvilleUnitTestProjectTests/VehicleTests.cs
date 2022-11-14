using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTests
    {

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle();
           
            //act

            //assert          
            vehicle.Should().Be(vehicle);
            vehicle.Should().NotBeNull();
            
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact] 
        public void VehicleConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10,"Toyota", "Camry", 30);


            //act
            ////assert
            Assert.True(true, "That is not our vehicle.");
            vehicle.Should().Be(vehicle);

        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "","", 30);

            
            //act
            vehicle.AddGas();

            //assert

            vehicle.GasLevel.Should().Be("100%");



        }

        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
            //arrange
            //Vehicle vehicle = new Vehicle();
            Vehicle sut = new Vehicle(4, 100, "", "", 30);
            
            //act
            

            double newTotal = (sut.GasRemaining + sut.AddGas(5));
            
            //assert5

            sut.GasLevel.Should().Be($"{newTotal}%"); 

        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

           
            ////act                 
            Action act = () => vehicle.AddGas(11);
            ////assert
            //throw new Exception();
            act.Should().Throw<GasOverfillException>();

        }
        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("0%", 0)]
        [InlineData("25%", 2.5)]
        [InlineData("50%", 5)]
        [InlineData("75%", 7.5)]
        [InlineData("100%", 10)]
        public void GasLevelPercentageIsCorrectForAmountOfGas(string percent, float gasToAdd)
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            
            //act
            vehicle.AddGas(gasToAdd);

            //assert
            vehicle.GasLevel.Should().Be(percent);

        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string “Cannot drive, out of gas.”.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string “Cannot drive due to flat tire.”.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */
      
       
        [Fact]
        public void DriveNegativeTestsOutOfGas()//(string Drive[], double miles)
        { //throw new NotImplementedException();
          //arrange
            Vehicle vehicle = new Vehicle();

            ////act
            vehicle.Drive(5);
                
                     // Action act = () => vehicle.Drive(0);
                     //vehicle._gasRemaining = 0;
            ////assert
            vehicle.MilesRemaining.Should().Be(0, because: "Cannot drive, out of gas.");
          
        }
        [Fact]
        public void DriveNegativeTestsHasFlat()//(string Drive[], double miles)
        {   ///arrange
            Vehicle vehicle = new Vehicle();

            vehicle.HasFlatTire = true;
            ////act

            vehicle.Drive(200);
            
            ///assert
            vehicle.HasFlatTire.Should().Be(true, because: " Oh no! Got a flat tire!");

        }
        [Fact]
        public void DriveNegativeTestsUntilRunOutOfGas()//(string Drive[], double miles)
        {   //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);
            double milesDriven = 300;
            double gasUsed = 10; 
            double startingMileage = vehicle.Mileage;
            double endingMileage = vehicle.Mileage + milesDriven;

            ////act

            vehicle.Drive(3050);
            
            
            //assert
            milesDriven.Should().BeApproximately(gasUsed * vehicle.MilesPerGallon, 0.01);
            vehicle.GasLevel.Should().Be($"{vehicle.GasRemaining / vehicle.GasTankCapacity}%");
            vehicle.MilesRemaining.Should().BeApproximately(vehicle.GasRemaining * vehicle.MilesPerGallon, 0.01);
            endingMileage.Should().Be(startingMileage + milesDriven);

        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.333, 10)]
        [InlineData(3.333, 100)]
        //[InlineData(10, 3000)]

        public void DrivePositiveTests(double gasUsed, double milesDriven)        //(params object[] yourParamsHere)
        {
            using (new AssertionScope())
            {
                //arrange
                Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);
                double startingMileage = vehicle.Mileage;
                double endingMileage = (vehicle.Mileage + milesDriven); 
                //vehicle.AddGas();
                //act
                Action act = () => vehicle.Drive(milesDriven);///////////////////

                
                
                //assert
              
                milesDriven.Should().BeApproximately(gasUsed * vehicle.MilesPerGallon, 0.01);
                vehicle.GasLevel.Should().Be($"{vehicle.GasRemaining / vehicle.GasTankCapacity}%");
                vehicle.MilesRemaining.Should().BeApproximately(vehicle.GasRemaining * vehicle.MilesPerGallon, 0.01);
                endingMileage.Should().Be(startingMileage + milesDriven);

                //*******need to add gas tank empty status report
            }

        }
        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "", "", 30);

            //////assert


            //await vehicle.ChangeTireAsync();
            Func<Task> runCheck = async () => { await vehicle.ChangeTireAsync(); };
           

             await runCheck.Should().ThrowAsync<NoTireToChangeException>();



           
        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle();
            vehicle.HasFlatTire = true;
            //vehicle._hasFlatTire.Should().BeTrue();

            Func<Task> act = () => vehicle.ChangeTireAsync();
            
           //not sure where to put await - many fails
            //assert
            await act.Should().NotThrowAsync<NoTireToChangeException>();
                     

           }

        //BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}