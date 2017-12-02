using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WhenRepair.Application
{
    public class Geocoder
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://nominatim.openstreetmap.org/search")
        };
        
        public Task<GeoCoordinate> Get(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Get(GeoCoordinate coordinate)
        {
            var query = $"{coordinate.Latitude:#######.#######}+{coordinate.Longitude:#######.#######}";
            var responseMessage = await client.GetAsync($"?format=json&q={query}");
            responseMessage.EnsureSuccessStatusCode();
            var content = await responseMessage.Content.ReadAsStringAsync();

            var json = JArray.Parse(content);

            return json.Count != 0 ? json.First["display_name"].ToString() : null;
        }
    }
}