namespace CodeLouisvilleUnitTestProject
{
    public class SemiTruck : Vehicle
    {
        public List<CargoItem> Cargo { get; private set; }

        /// <summary>
        /// Creates a new SemiTruck that always has 18 Tires
        /// </summary>
        public SemiTruck()
           : this(18)
        { }
        public SemiTruck(int numberOfTires)
        {
            Cargo = new List<CargoItem>();
            NumberOfTires = numberOfTires;

        }

        /// <summary>
        /// Adds the passed CargoItem to the Cargo
        /// </summary>
        /// <param name="item">The CargoItem to add</param>
        public void LoadCargo(CargoItem item)
        {
            //YOUR CODE HERE
            //var box = item;
            Cargo.Add(item);


        }

        /// <summary>
        /// Attempts to remove the first item with the passed name from the Cargo and return it
        /// </summary>
        /// <param name="name">The name of the CargoItem to attempt to remove</param>
        /// <returns>The removed CargoItem</returns>
        /// <exception cref="ArgumentException">Thrown if no CargoItem in the Cargo matches the passed name</exception>
        public CargoItem UnloadCargo(string name)
        {
            //YOUR CODE HERE
            if
                (name != null)
            {
                Cargo[0].Name = name;
                Cargo.RemoveAt(0);
                return Cargo[0];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Returns all CargoItems with the exact name passed. If no CargoItems have that name, returns an empty List.
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns>A List of CargoItems with the exact name passed</returns>
        public List<CargoItem> GetCargoItemsByName(string name)
        {
            //YOUR CODE HERE
            List<CargoItem> cargoItems = new List<CargoItem>();
            // foreach (CargoItem item in Cargo)
            cargoItems = Cargo;
                if (name.Equals(cargoItems))
                {
                    return cargoItems;
                }

                else
                {
                    return Cargo;
                }
        }

    

        /// <summary>
        ///  Returns all CargoItems who have a description containing the passed description. If no CargoItems have that name, returns an empty list.
        /// </summary>
        /// <param name="description">The partial description to match</param>
        /// <returns>A List of CargoItems with a description containing the passed description</returns>
        public List<CargoItem> GetCargoItemsByPartialDescription(string description)
        {
            //YOUR CODE HERE

            List<CargoItem> cargoItems = new List<CargoItem>();
            cargoItems = Cargo;
            foreach (CargoItem item in cargoItems)
            {
                item.Description = description;
                
            }

            Cargo.FindAll(item => item.Description == description).ToList();
            return cargoItems;
        }

        /// <summary>
        /// Get the number of total items in the Cargo.
        /// </summary>
        /// <returns>An integer representing the sum of all Quantity properties on all CargoItems</returns>
        public int GetTotalNumberOfItems()
        {
            //YOUR CODE HERE

            List<CargoItem> cargoItems = new List<CargoItem>();
            cargoItems = Cargo;
            int quantity = 0;
            int total = 0;
            int subTotal = 0;
            foreach (CargoItem item in cargoItems)
            {
                item.Quantity = quantity;
                subTotal += quantity; 

               
            }
            total = quantity + subTotal;
            return total;
            // semiTruck.Cargo.Count
            //cargoItems = Cargo;
            //for (int i = 0, i <cargoItems.LongCount, i++)

            //int i = 0;
             //foreach (CargoItem item in cargoItems)

            //cargoItems.Quantity;
            // totalQuantity = quantity;
            //return totalQuantity;
            //for (int i = 0;i < cargoItems.Count, i++)
            //{
            //    quantity += totalQuantity;

            //    return totalQuantity ;
            //    }
                //int result = cargoItems.Sum(item);

               
              

        }
    }
}
