using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Author>> GetAuthors();
        Uri GetBaseAddress();
        Task AddAuthor(Author author);
        Task<Author> GetAuthor(int id);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}
