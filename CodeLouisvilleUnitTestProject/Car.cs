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

    public class Car: Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        public string Make { get; }
        public string Model { get; }

        private HttpClient _client;
       

        public Car()
            : this (0, "", "", 0)
        { }
       
        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
        {
            NumberOfTires = 4;
            GasTankCapacity = gasTankCapacity;
            Make = make;
            Model = model;
            MilesPerGallon = milesPerGallon;
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
            };

        }

        public async Task<bool> IsValidModelForMakeAsync()
        {
            string urlSuffix = $"vehicles/getformake/{Make}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            return data.Results.Any(r => r.Model_Name == Model);

        }
        //string url = 
        //if (name != null)
        //{
        //  
        //    string Url = $"vehicles/getmodelsformake/{Make}?format=json";
        //    var response = await _client.GetAsync(Url);
        //    var content = await response.Content.ReadAsStringAsync();
        //    var responseModel = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(content);
        //    return responseModel.Results.Any(r => r.Model_Name == Model);   //.Equals(name));
        //}
        //else  { throw new ArgumentNullException("There was no model with the name provided"); }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            
            if (year < 1995) throw new ArgumentException("No data is available for years before 1995");
            string urlSuffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            return data.Results.Any(r => r.Model_Name == Model);

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
