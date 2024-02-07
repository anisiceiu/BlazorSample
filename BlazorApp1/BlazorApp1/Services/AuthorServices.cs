using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly HttpClient httpClient;
        string _baseAddress = "http://localhost:5142/";

        public AuthorServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(_baseAddress);
        }

        public async Task AddAuthor(Author author)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Author/Create", author);
        }

        public async Task<Author> GetAuthor(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Author>($"api/Author/Details/{id}");
            return result;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
           return await httpClient.GetFromJsonAsync<IEnumerable<Author>>("api/Author/Index");
        }

        public Uri GetBaseAddress()
        {
            return new Uri(this._baseAddress);
        }
    }
}
