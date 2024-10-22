
using BookStore.Codes.Models;
using BookStore.DataAccess.Repositories;

namespace BookStoreApplication.Sevices
{
    public class BookServices
    {
        private readonly IBookReposytory _bookReposytory;

        public BookServices(IBookReposytory bookReposytory)
        {
            _bookReposytory = bookReposytory;
        }

        public IBookReposytory Get_bookReposytory()
        {
            return _bookReposytory;
        }

        public async Task<List<Book>> GetAllBooks(IBookReposytory bookReposytory)
        {
            return await bookReposytory.Get();
        }
        public async Task<Guid> Create 
    }
}
