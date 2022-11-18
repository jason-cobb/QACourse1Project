using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class SemiTruckTests
    {

        //Verify that the SemiTruck constructor creates a new SemiTruck
        //object which is also a Vehicle and has 18 wheels. Verify that the
        //Cargo property for the newly created SemiTruck is a List of
        //CargoItems which is empty, but not null.
        [Fact]
        public void NewSemiTruckIsAVehicleAndHas18TiresAndEmptyCargoTest()
        {
            using(new AssertionScope())
            { 
                //arrange
                SemiTruck semiTruck = new SemiTruck();

                //act

                //List<CargoItem> cargoItems = new List<CargoItem>();

                //assert
                semiTruck.Should().BeAssignableTo<Vehicle>(because: "semiTruck instanciates the parameterless SemiTruck which inherits from a parent of Vehicle class.");
                semiTruck.NumberOfTires.Should().Be(18);
                semiTruck.Cargo.Should().BeAssignableTo<List<CargoItem>>();
                semiTruck.Cargo.Should().BeEmpty();
                semiTruck.Cargo.Should().NotBeNull();
            }
        }

        //Verify that adding a CargoItem using LoadCargo does successfully add
        //that CargoItem to the Cargo. Confirm both the existence of the new
        //CargoItem in the Cargo and also that the count of Cargo increased to 1.
        [Fact]
        public void LoadCargoTest()
        {
            //arrange
            
            SemiTruck semiTruck = new SemiTruck();
            //var box = semiTruck.Cargo;
            CargoItem box = new CargoItem();
            //act
            semiTruck.LoadCargo(box);            
           
            //assert
            semiTruck.Cargo.Should().Contain(box);
            semiTruck.Cargo.Should().HaveCount(1); 

        }

        //Verify that unloading a  cargo item that is in the Cargo does
        //remove it from the Cargo and return the matching CargoItem
        [Fact]
        public void UnloadCargoWithValidCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            //var box = semiTruck.Cargo;
            CargoItem box = new CargoItem
            {
                Name = "Crate",
                Description = "Box of braces",
                Quantity = 1
            };
            //act
            semiTruck.LoadCargo(box);
            //semiTruck.Cargo.Should().Contain(box);
            //string box;
            semiTruck.UnloadCargo("Crate");

            //assert
            semiTruck.Cargo.Should().NotContain(box);

        }

        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            SemiTruck semiTruck = new SemiTruck();
            //var box = semiTruck.Cargo;
            CargoItem box = new CargoItem
            {
                Name = "Crate",
                Description = "Box of braces",
                Quantity = 1
            };
            
            //act
            semiTruck.LoadCargo(box);
            semiTruck.Cargo.Should().Contain(box);
            //string box;
           
            Action act = () => semiTruck.UnloadCargo("water");
            ////assert

            act.Should().Throw<ArgumentException>(because: "water is not a crate : box of braces");
            

        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem();
            semiTruck.Cargo.Add(item);
            item.Quantity = 3;
            item.Description = "box of pants";
            item.Name = "Pants";

            semiTruck.Cargo.Add(item);
            Action act = () => semiTruck.GetCargoItemsByName("box");
            ////assert

            act.Should().NotBeNull();
        }

        //Verify that searching the Carto list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem();
            semiTruck.Cargo.Add(item);
            item.Quantity = 3;
            item.Description = "box of pants";
            item.Name = "Pants";
            ////assert
            Action act = () => semiTruck.GetCargoItemsByName("water");
         

            act.Should().NotBeNull(because: "If no exact name matches from the cargo item search, it should return an empty list.");

        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem();
            semiTruck.Cargo.Add(item);
            item.Quantity = 3;
            item.Description = "box of pants";
            item.Name = "Pants";

           
            ////assert

            semiTruck.GetCargoItemsByPartialDescription("pants");

            semiTruck.Cargo.Should().Contain(item, because: "pants");
            //Action act = () => semiTruck.GetCargoItemsByPartialDescription("pants");

            //act.Should().NotBeNull(because: "found pants");


            //NotBeNull(because: "The search description contains the item description.");

        }

        //Verify that searching the Carto list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem() { Name = "Pants", Description = "box of pants", Quantity = 3};
            CargoItem tape = new CargoItem() { Name = "Tape", Description = "clear and sticky", Quantity = 30 };
            //semiTruck.Cargo.Add(item);
           
        
            ///act
            semiTruck.GetCargoItemsByPartialDescription("tape");
            semiTruck.GetCargoItemsByPartialDescription("x");
            ////assert
            semiTruck.Cargo.Should().NotContain(tape, because: "tape is the name, not description");


        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            //arrange
            List<CargoItem> item = new List<CargoItem>();
            SemiTruck semiTruck = new SemiTruck();
            CargoItem pants = new CargoItem() { Name = "Pants", Description = "box of pants", Quantity = 9 };
            CargoItem tape = new CargoItem() { Name = "Tape", Description = "clear and sticky", Quantity = 30 };

            //act
            int totalItems = 0;
            semiTruck.Cargo.Add(pants);
            semiTruck.Cargo.Add(tape);
            totalItems = pants.Quantity + tape.Quantity;

            semiTruck.GetTotalNumberOfItems();
            ////assert



            totalItems.Should().Be(39);

        }
    }
}
