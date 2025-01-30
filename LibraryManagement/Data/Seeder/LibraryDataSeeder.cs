using LibraryManagement.Models;
using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Data.Seeder
{
    /// <summary>
    /// Seeder class to seed initial data into the database.
    /// </summary>
    public static class LibraryDataSeeder
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(LibraryContext context)
        {
            SeedAuthors(context);
            SeedBooks(context);
            SeedBorrowers(context); // Correctly seed borrowers with linked data
        }

        /// <summary>
        /// Seeds the authors.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void SeedAuthors(LibraryContext context)
        {
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author { Name = "TestAuthor1" },
                    new Author { Name = "TestAuthor2" },
                    new Author { Name = "TestAuthor3" }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Seeds the books.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void SeedBooks(LibraryContext context)
        {
            if (!context.Books.Any())
            {
                var author1 = context.Authors.FirstOrDefault(a => a.Name == "TestAuthor1");
                var author2 = context.Authors.FirstOrDefault(a => a.Name == "TestAuthor2");
                var author3 = context.Authors.FirstOrDefault(a => a.Name == "TestAuthor3");

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Book1",
                        Genre = "Fiction",
                        AuthorId = author3.Id,
                        IsBorrowed = false
                    },
                    new Book
                    {
                        Title = "Book2",
                        Genre = "Children",
                        AuthorId = author1.Id,
                        IsBorrowed = false
                    },
                    new Book
                    {
                        Title = "Book3",
                        Genre = "Fiction",
                        AuthorId = author2.Id,
                        IsBorrowed = false
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Seeds the borrowers and borrow records.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void SeedBorrowers(LibraryContext context)
        {
            if (!context.Borrowers.Any())
            {
                context.Borrowers.AddRange(
                    new Borrower { Name = "Borrower1" },
                    new Borrower { Name = "Borrower2" }
                );
                context.SaveChanges();
            }

            if (!context.BorrowRecords.Any())
            {
                var borrower1 = context.Borrowers.FirstOrDefault(b => b.Name == "Borrower1");
                var borrower2 = context.Borrowers.FirstOrDefault(b => b.Name == "Borrower2");

                var book1 = context.Books.FirstOrDefault(b => b.Title == "Book1");
                var book2 = context.Books.FirstOrDefault(b => b.Title == "Book2");

                // Adding borrow records
                context.BorrowRecords.AddRange(
                    new BorrowRecord
                    {
                        BookId = book1.Id,
                        BorrowerId = borrower1.Id,
                        BorrowedDate = DateTime.Now
                    },
                    new BorrowRecord
                    {
                        BookId = book2.Id,
                        BorrowerId = borrower2.Id,
                        BorrowedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
