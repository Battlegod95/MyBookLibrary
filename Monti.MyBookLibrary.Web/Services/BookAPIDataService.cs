using Monti.MyBookLibrary.Web.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monti.MyBookLibrary.Web.Services
{
    public class BookApiDataService : IBookApiDataService
    {
        public async Task<Doc[]> GetBooksApi(string title)
        {
            //Per togliere gli spazi e sostituirli con il + con il title
            var url = "http://openlibrary.org/search.json?q=" + WebUtility.UrlEncode(title);

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            var obj = await JsonSerializer.DeserializeAsync<SearchResult>(stream);
            //l'oggetto contenuto all'interno del json contiene i libri all'interno di docs e in questo modo li vado a prendere
            return obj.docs;
        }

        public async Task<Details> GetBookDetails(string isbn)
        {
            var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:" + isbn + "&format=json&jscmd=data";

            var client = new HttpClient();
            var stringResult = await client.GetStringAsync(url);

            var obj = JObject.Parse(stringResult);
            var details = obj[$"ISBN:{isbn}"];

            return details.ToObject<Details>();
        }
    }
}
