using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Entities;

namespace Presentation.Razor.Services
{
    public class BookSoapClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl = "http://localhost:5158/soap/multimedia";

        public BookSoapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var soapEnvelope = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GetAllBooks xmlns=""http://tempuri.org/"" />
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/GetAllBooks");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var doc = XDocument.Parse(content);
            XNamespace ns = "http://tempuri.org/";
            var books = new List<Book>();
            var bookElements = doc.Descendants(ns + "Book");
            foreach (var el in bookElements)
            {
                books.Add(new Book
                {
                    Id = (int?)el.Element(ns + "Id") ?? 0,
                    Title = (string?)el.Element(ns + "Title") ?? string.Empty,
                    Author = (string?)el.Element(ns + "Author") ?? string.Empty,
                    Year = (int?)el.Element(ns + "Year") ?? 0
                });
            }
            return books;
        }

        public async Task AddBookAsync(string title, string author, int year)
        {
            var soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <AddBook xmlns=""http://tempuri.org/"">
      <book>
        <Title>{System.Security.SecurityElement.Escape(title)}</Title>
        <Author>{System.Security.SecurityElement.Escape(author)}</Author>
        <Year>{year}</Year>
      </book>
    </AddBook>
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/AddBook");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }

    public class GameSoapClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl = "http://localhost:5158/soap/multimedia";

        public GameSoapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            var soapEnvelope = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <GetAllGames xmlns=""http://tempuri.org/"" />
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/GetAllGames");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var doc = XDocument.Parse(content);
            XNamespace ns = "http://tempuri.org/";
            var games = new List<Game>();
            var gameElements = doc.Descendants(ns + "Game");
            foreach (var el in gameElements)
            {
                games.Add(new Game
                {
                    Id = (int?)el.Element(ns + "Id") ?? 0,
                    Title = (string?)el.Element(ns + "Title") ?? string.Empty,
                    Developer = (string?)el.Element(ns + "Developer") ?? string.Empty,
                    Year = (int?)el.Element(ns + "Year") ?? 0
                });
            }
            return games;
        }

        public async Task AddGameAsync(string title, string developer, int year)
        {
            var soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <AddGame xmlns=""http://tempuri.org/"">
      <game>
        <Title>{System.Security.SecurityElement.Escape(title)}</Title>
        <Developer>{System.Security.SecurityElement.Escape(developer)}</Developer>
        <Year>{year}</Year>
      </game>
    </AddGame>
  </soap:Body>
</soap:Envelope>";
            var request = new HttpRequestMessage(HttpMethod.Post, _serviceUrl);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IMultimediaSoapService/AddGame");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
