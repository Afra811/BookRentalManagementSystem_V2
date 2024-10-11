using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookRepository
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookRentalManagement;Trusted_Connection=true;TrustServerCertificate=true";

        public void CreateBook(string title, string author, decimal rentalprice)
        {


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Books(Title,Author,RentalPrice) VALUES(@title,@author,@rentalprice)";

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@RentalPrice", rentalprice);
                command.ExecuteNonQuery();

            }
            Console.WriteLine("Book Added Succefully....");
        }

        public void GetAllBooks()
        {


            using (var connection = new SqlConnection(_connectionString))
            {


                try
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Books";
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("---Books Listed__\n");
                        while (reader.Read())
                        {
                            Console.WriteLine($"BookId: {reader.GetString(0)} Title: {reader.GetString(1)} Author: {reader.GetString(2)} RentalPrice: {reader.GetDecimal(3)}");


                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }

        }

        public void GetBookById(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Books WHERE BookId = @BookId";
                    command.Parameters.AddWithValue("@BookId", bookId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"BookId: {reader.GetString(0)} Title: {reader.GetString(1)} Author: {reader.GetString(2)} RentalPrice: {reader.GetDecimal(3)}");
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        public void UpdateBook(int bookId, string title, string author, decimal rentalprice)
        {
            Console.WriteLine(bookId);
            this.GetBookById(bookId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Books SET Title = @title, Author = @author, RentalPrice = @rentalprice WHERE BookId = @bookId";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@rentalprice", rentalprice);
                command.Parameters.AddWithValue("@bookId", bookId);
                var rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    Console.WriteLine("Book Update Succefully...");
                }
                else
                {
                    Console.WriteLine("Course Not Founded......");

                }
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Books WHERE BookId = @bookId";
                command.Parameters.AddWithValue("@bookId", bookId);
                var rowsaaffected = command.ExecuteNonQuery();

                if (rowsaaffected > 0)
                {
                    Console.WriteLine("Book Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Book Not Found");
                }


            }
        }


       
    }
}
