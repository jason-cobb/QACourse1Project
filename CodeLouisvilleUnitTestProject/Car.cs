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
        //private HttpClient _httpClient;


        static string baseUrl = "https://vpic.nhtsa.dot.gov/api/";
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };

        public Car()
            : this (0, "", "", 0)
        { }
       
        public Car(double gasTankCapacity,string carMake, string carModel, double milesPerGallon)
        {
            NumberOfTires = 4;
            GasTankCapacity = gasTankCapacity;
            carMake = Make_Name;
            carModel = Model_Name;
            MilesPerGallon = milesPerGallon;
            //HttpClient client = _httpClient;
            
        }


        public static async Task<bool> IsValidModelForMakeAsync()
        {   Car car = new Car();
             //string url = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";
            string baseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";
            //var userInput = (Make: honda);
            var userInput = ("Make: honda");

            //HttpClient client = new HttpClient
            //{
            //    BaseAddress = new Uri(baseUrl)
            //};
            var response = await _httpClient.GetAsync(userInput);
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

            if (car.Model_Name != null)
                return true;
            else

                return false;
            

            
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
