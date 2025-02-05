﻿using BookStore.Codes.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class BookReposytory : IBookReposytory
    {
        private readonly BookStoreDbContext _context;

        public BookReposytory(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();
            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
                .ToList();
            return books;
        }
        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
            };
            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return bookEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string destription, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => destription)
                .SetProperty(b => b.Price, b => price));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
