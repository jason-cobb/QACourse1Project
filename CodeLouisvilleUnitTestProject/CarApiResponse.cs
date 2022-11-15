using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeLouisvilleUnitTestProject
{
    public class CarApiResponse
    {
        [JsonPropertyName("Make_Name")]
        public string Make_Name { get; set; }

        [JsonPropertyName("Model_Name")]
        public string Model_Name { get; set; }
        
        public string MakeId { get; set; }

    }
    
}
