using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace ODataBookStore.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
        }
    }

    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }
        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }
            listBooks = new List<Book>();
            Book book = new Book
            {
                Id = 1,
                ISBN = "929-0-111-222-111",
                Title = "Title",
                Author = "Author",
                Price = 59.99m,
                Location = new Address
                {
                    City = "HCMC",
                    Street = "D2, Thuduc"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Name",
                    Category = Category.Book
                }

            };
            listBooks.Add(book);
            book = new Book
            {
                Id = 2,
                ISBN = "929-0-111-222-112",
                Title = "Another Title",
                Author = "Another Author",
                Price = 69.99m,
                Location = new Address
                {
                    City = "Hanoi",
                    Street = "D1, Ba Dinh"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "Another Name",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            return listBooks;
        }
    }

}
