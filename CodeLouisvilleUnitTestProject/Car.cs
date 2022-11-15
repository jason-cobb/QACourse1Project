using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using WireMock.Admin.Mappings;

namespace CodeLouisvilleUnitTestProject
{

    public class Car : Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        public string Make_Name => Make;
        public string Model_Name => Model;



        public Car()
            : this(0, 0)              //this(0, "", "", 0)
        { }
        public Car(double gasTankCapacity, double milesPerGallon)
        {
            NumberOfTires = 4;
            GasTankCapacity = gasTankCapacity;
           
            MilesPerGallon = milesPerGallon;
           
        }


        public static async Task<bool> IsValidModelForMakeAsync()
        {   Car CarApiResponse = new Car();
             //string url = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";
            string baseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";
            //var userInput = (Make: honda);
            var userInput = ("");

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            var response = await client.GetAsync(userInput);
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true

            };

            //using (HttpResponseMessage client = await ApiHelper.ApiClient.GetAsync(baseUrl))
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Make_Name", "Model_Name");
            List<CarApiResponse> responseModel;
            try
            {
                responseModel = JsonSerializer.Deserialize<List<CarApiResponse>>(content, options);
            }
            catch(JsonException)
            {
                throw new JsonException(content);
            };
            //return responseModel.Count > 0;
            return true;

            
        }
        //public static async Task<bool> WasModelMadeInYearAsync(int year)
        //{
        //    //Car car = new();
        //    // string url = "https://vpic.nhtsa.dot.gov/api/";
        //    string baseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformakeyear/make/honda/modelyear/2015?format=json";


           // throw new (ArgumentException)no user data is available before 1995;
        //}
        public void AddPassengers(int passengers)
        {
            NumberOfPassengers = passengers;
            double milesPerGallon = MilesPerGallon - (passengers * 0.2);

        }

        public void RemovePassengers(int passengersStart, int removedPassengers)
        {
            //passengers = passengersStart - removedPassengers;
           
            NumberOfPassengers = Math.Max (passengersStart - removedPassengers, 0);
            double milesPerGallon = MilesPerGallon - (NumberOfPassengers * 0.2);

            //MilesPerGallon += NumberOfPassengers * 0.2;

        }
    }
}
