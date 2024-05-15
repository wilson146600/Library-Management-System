using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Wilson_Quayson
{
    internal class Book : ILendable
    {
        // FIELDS EN ATRIBUTEN

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value ?? throw new ArgumentNullException("Title moet meegegeven worden");
            }
        }

        private string isbn;
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if(value == null || value.Length != 13)
                {
                    throw new FormatException("Het formaat van je ingegeven ISBM nummer klopt niet. Het moet precies 13 karakters zijn");
                }
                isbn = value;
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                if(value is null)
                {
                    throw new ArgumentNullException(nameof(value), "Auteur moet meegegeven worden");
                }
                author = value;
            }
        }

        private Genre.Genres genre;
        public Genre.Genres Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if(value == 0)
                {
                    throw new ArgumentException(nameof(value), "Prijs moet meegegeven worden");
                }else if(value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "prijs mag niet negatief zijn");
                }
                price = value;
            }
        }


        private bool isAvailable;
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }


        private DateTime borrowingDate;
        public DateTime BorrowingDate
        {
            get { return borrowingDate; }
            set { borrowingDate = value; }
        }


        private int borrowDays;
        public int BorrowDays
        {
            get { return borrowDays; }
            set
            {
                if(this.Genre == Bib_Wilson_Quayson.Genre.Genres.Schoolboek)
                {
                    borrowDays = 10;
                }
                else
                {
                    borrowDays = 20;
                }
            }
        }




        // CONSTRUCTORS

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;

            this.IsAvailable = true;
        }
        public Book(string title, string author, string isbn, Genre.Genres genre, double price)
        {
            this.Title = title;
            this.Isbn = isbn;
            this.Author = author;
            this.Genre = genre;
            this.Price = price;

            this.IsAvailable = true;
        }

        // METHODES
        public void DisplayInfo()
        {
            Console.WriteLine($"Titel: {this.Title}");
            Console.WriteLine($"Auteur: {this.Author}");
            Console.WriteLine($"ISBN: {this.Isbn}");
            Console.WriteLine($"Genre: {this.Genre}");
            Console.WriteLine($"Price: {this.Price:C}");
        }

        // --- csv methode
        public static void CsvDeserialize(Library library, string csvFile = @"C:\Users\Wilson\Documents\books.csv")
        {
            try
            {
                if (!File.Exists(csvFile))
                {
                    Console.WriteLine($"Bestand bestaat niet: {csvFile}");
                    return;
                }

                string[] lines = File.ReadAllLines(csvFile);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(";");

                    if(fields.Length != 2)
                    {
                        Console.WriteLine($"Fout lijn formaat: {line}");
                        continue;
                    }

                    string title = fields[0];
                    string author = fields[1];

                    library.AddBook(new Book(title, author));
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Borrow()
        {
            if(this.IsAvailable == true)
            {
                Console.WriteLine("Vul de datum van ontlening in (bv. 28/12/2024)");
                string dateLoan = Console.ReadLine();

                string[] dateLoandsplitted = dateLoan.Split("/");

                int day = Convert.ToInt32(dateLoandsplitted[0]);
                int month = Convert.ToInt32(dateLoandsplitted[1]);
                int year = Convert.ToInt32(dateLoandsplitted[2]);

                DateTime dateLoanedOut = new DateTime(year, month, day);
                DateTime now = DateTime.Now;

                this.IsAvailable = false;
                this.BorrowingDate = dateLoanedOut;

                Console.WriteLine($"\n---------------------------\n{this.Title} succesvol uitgeleend\n---------------------------\n");

                Console.WriteLine($"Boek moet ten laatste {now.AddDays(20).ToShortDateString()} teruggebracht worden");
            }else if (this.IsAvailable == false)
            {
                Console.WriteLine($"{this.Title} is al uitgeleend");
            }
        }

        public void Return()
        {
            if(this.IsAvailable == false)
            {
                this.isAvailable = true;

                DateTime now = DateTime.Now;
                TimeSpan loanDuration = now - this.BorrowingDate;

                if(loanDuration.Days > this.BorrowDays)
                {
                    Console.WriteLine($"\n---------------------------\n{this.Title} succesvol teruggebracht\n---------------------------\n");
                    Console.WriteLine("Boek werd te laat teruggebracht");
                }
                else if(loanDuration.Days <= this.BorrowDays && loanDuration.Days >= 0)
                {
                    Console.WriteLine($"\n---------------------------\n{this.Title} succesvol teruggebracht\n---------------------------\n");
                    Console.WriteLine("Boek werd op tijd teruggebracht");
                }
                else
                {
                    Console.WriteLine("FOUT: Boek kan niet worden teruggebracht voor hij is uitgeleend");
                }
            }
            else if(this.IsAvailable == true)
            {
                Console.WriteLine($"{this.Title} is niet uitgeleend.");
            }
        }
    }
}
