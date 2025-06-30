using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Entities;

namespace Presentation.Razor.Services
{
    // Simple SOAP client for Movies
    public class MovieSoapClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl = "http://localhost:5158/soap/multimedia";

        public MovieSoapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var soapEnvelope = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GetAllMovies xmlns=""http://tempuri.org/"" />
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/GetAllMovies");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Parse the SOAP XML response
            var doc = XDocument.Parse(content);
            XNamespace ns = "http://tempuri.org/";
            var movies = new List<Movie>();
            var movieElements = doc.Descendants(ns + "Movie");
            foreach (var el in movieElements)
            {
                movies.Add(new Movie
                {
                    Id = (int?)el.Element(ns + "Id") ?? 0,
                    Title = (string?)el.Element(ns + "Title") ?? string.Empty,
                    Director = (string?)el.Element(ns + "Director") ?? string.Empty,
                    Year = (int?)el.Element(ns + "Year") ?? 0
                });
            }
            return movies;
        }

        public async Task AddMovieAsync(string title, string director, int year)
        {
            var soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <AddMovie xmlns=""http://tempuri.org/"">
      <movie>
        <Title>{System.Security.SecurityElement.Escape(title)}</Title>
        <Director>{System.Security.SecurityElement.Escape(director)}</Director>
        <Year>{year}</Year>
      </movie>
    </AddMovie>
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/AddMovie");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // TODO: Add UpdateMovieAsync, DeleteMovieAsync
    }
}
