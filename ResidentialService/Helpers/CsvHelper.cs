using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace ResidentialService.Helpers
{
    public static class CsvHelper
    {
        private static IList<T> GetRecords<T>(TextReader reader)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HeaderValidated = null,
                MissingFieldFound = null,
            };
            using var csv = new CsvReader(reader, config);
            return csv.GetRecords<T>().ToList();
        }
        public static async Task<IList<T>> ReadRecordsFromUri<T>(string uri)
        {
            var client = new HttpClient();
            using (var msg = new HttpRequestMessage(HttpMethod.Get, new Uri(uri)))
            {
                msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
                using (var resp = await client.SendAsync(msg))
                {
                    resp.EnsureSuccessStatusCode();
                    var s = await resp.Content.ReadAsStreamAsync();
                    return GetRecords<T>(new StreamReader(s));
                }
            }
        }
    }
}