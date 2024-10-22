using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Codes.Models
{
    public class Book

    {
        public const int MAX_TITLE_LENGTH = 250;

        private Book(Guid id, string title, string destription, decimal price)
        {
            Id = id;

            Title = title;

            Description = destription;

            Price = price;

        }
        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public static (Book Book, string Error) Create (Guid id, string title, string destription, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title so longer 250 simphol";
            }    

            var book = new Book(id, title, destription, price);

            return (book, error);   
        }
    }
}