using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookrepository = new BookRepository();

            var bookManager = new BookManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n---- Book Rental Management System:------");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4. Delete a Book");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();



                switch (option)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string title = bookrepository.CapitalizeTitle(Console.ReadLine());
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Rental Price: ");
                        decimal rentalPrice = bookManager.ValidateBookRentalPrice();
                        bookrepository.CreateBook(title, author, rentalPrice);

                        break;

                    case "2":
                        Console.Clear();
                        bookrepository.GetAllBooks();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter Book ID to update: ");
                        string updateId =Console.ReadLine();
                        Console.Write("Enter New Title: ");
                        string newTitle = bookrepository.CapitalizeTitle(Console.ReadLine());
                        Console.Write("Enter New Author: ");
                        string newAuthor = Console.ReadLine();
                        Console.Write("Enter New Rental Price: ");
                        decimal newRentalPrice = bookManager.ValidateBookRentalPrice();
                        bookrepository.UpdateBook(updateId, newTitle, newAuthor, newRentalPrice);

                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Enter Book ID to delete: ");
                        string deleteId = Console.ReadLine();
                        bookrepository.DeleteBook(deleteId);

                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                };




                Console.WriteLine("\n press any key to continue.....");
                Console.ReadKey();
            }



        }
    }
}
