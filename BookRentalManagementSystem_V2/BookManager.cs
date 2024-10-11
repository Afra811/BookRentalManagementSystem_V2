using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookManager
    {
        public List<Book> books = new List<Book>();


        public void CreateBook(string bookId,string title, string author, decimal rentalprice)
        {

            var book = new Book(bookId, title, author, rentalprice);
            books.Add(book);
            Console.WriteLine("Book added successfully!");

        }

        public void ReadBooks()
        {
            Console.WriteLine("---Book List----\n");
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"BookId:{book.BookId}, Title:{book.Title}, Author:{book.Author}, RentalPrice:{book.RentalPrice}");
                }
            }

            else
            {
                Console.WriteLine("Book Not Available.......");
            }
        }

        public void UpdateBook(string updateId, string newTitle, string newAuthor, decimal newRentalPrice)
        {
            var book = books.Where(b => b.BookId == updateId).FirstOrDefault();
            Console.WriteLine(updateId);
            if (book != null)
            {

                book.Title = newTitle;
                book.Author = newAuthor;
                book.RentalPrice = newRentalPrice;


                Console.WriteLine("\nBook updated successfully...");

            }
            else
            {
                Console.WriteLine("Book not found.....");
            }
        }

        public void DeleteBook(string bookId)
        {
            var book = books.Find(b => b.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found....");
            }
        }

        public decimal ValidateBookRentalPrice()
        {
            decimal price;
            do
            {
                Console.WriteLine("Rental price must be a positive value. Please enter a valid rental price:");
                price = decimal.Parse(Console.ReadLine());
                if (price <= 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (price <= 0);
            return price;
        }
    }
}
