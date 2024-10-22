using BookStore.Codes.Models;

namespace BookStore.DataAccess.Repositories
{
    public interface IBookReposytory
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string destription, decimal price);
    }
}