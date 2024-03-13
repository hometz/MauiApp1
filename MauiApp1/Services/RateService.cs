using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Globalization;

namespace MauiApp1.Services
{
    public class RateService : IRateService
    {
        public static HttpClient _client;

        public RateService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<Rate>> GetRates(DateTime date) 
        {
            string StringDate = date.ToString("yyyy-MM-dd");
            var rates = await _client.GetFromJsonAsync<List<Rate>>
                ($"https://api.nbrb.by/exrates/rates?ondate={StringDate}&periodicity=0");
            return rates;
        }
    }
}
