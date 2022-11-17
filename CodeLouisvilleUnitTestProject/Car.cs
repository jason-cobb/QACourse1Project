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


        
        private HttpClient _client;
       

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
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
            };

        }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            var make = this.Make;
            var model = this.Model;
            if (year < 1995) throw new ArgumentException("No data is available for years before 1995");
            string urlSuffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            await response.Content.ReadAsStringAsync();
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            return data.Results.Any(r => r.Model_Name == Model);
            
        }

        public async Task<bool> IsValidModelForMakeAsync(string name)
        {

            //string url = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=json";
           // Car car = new();
            //var userInput = (Make: honda);
            var make = this.Make;
            var model = this.Model;
            if (make != name) throw new ArgumentNullException("There was no model with the name provided");
            string Url = $"vehicles/getmodelsformake/{Make}?format=json";
            
            var response = await _client.GetAsync(Url);
            var content = await response.Content.ReadAsStringAsync();
            var responseModel = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(content);
            return responseModel.Results.Any(r => r.Model_Name.Equals(name));

            //    List<CarApiResponse> responseModel;
            //    try
            //    {
            //        responseModel = JsonSerializer.Deserialize<List<CarApiResponse>>(content, options);
            //    }
            //    catch(JsonException)
            //    {
            //        throw new JsonException(content);
            //    };
            //    //return responseModel.Count > 0;
            //    if (car.Model_Name != null)
            //        return true;
            //    else{  return false;}
        }
        public void AddPassengers(int passengers)
        {
            NumberOfPassengers += passengers;
            double milesPerGallon = MilesPerGallon - (passengers * 0.2);

        }

        public void RemovePassengers(int removedPassengers)
        {
            //passengers = passengersStart - removedPassengers;
            int passengersStart = 5;
             NumberOfPassengers = Math.Max (passengersStart - removedPassengers, 0);
            double milesPerGallon = MilesPerGallon - (NumberOfPassengers * 0.2);

            //MilesPerGallon += NumberOfPassengers * 0.2;

        }
    }
}
