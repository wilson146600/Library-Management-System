using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Wilson_Quayson
{
    internal class Library
    {
        // FIELDS EN ATRIBUTEN
        public List<Book> books = new List<Book>();

        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();
        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get { return allReadingRoom; }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // CONSTRUCTOR
        public Library(string name)
        {
            this.Name = name;
        }

        // METHODES

        public void AddBook(Book book)
        {
            if (!books.Contains(book))
            {
                books.Add(book);
            }
        }

        public void RemoveBook(string title)
        {
            List<Book> BooksToRemove = new List<Book>(books);

            foreach (var book in BooksToRemove)
            {
                if(book.Title == title)
                {
                    books.Remove(book);
                }
            }
        }

        public void FindByTitleAuthor(string title, string author)
        {
            foreach (var book in books)
            {
                if(book.Title == title && book.Author == author)
                {
                    book.DisplayInfo();
                }
            }
        }

        public void FindByIsbn(string isbn)
        {
            foreach (var book in books)
            {
                if(book.Isbn == isbn)
                {
                    book.DisplayInfo();
                }
            }
        }

        public List<Book> ReturnByAuthor(string author)
        {
            List<Book> booksToReturnByAuthor = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author == author)
                {
                    booksToReturnByAuthor.Add(book);
                }
            }
            return booksToReturnByAuthor;
        }

        // Newspaper methods

        public void AddNewspaper()
        {
            // prompts
            Console.WriteLine("Wat is de naam van de krant?");
            string title = Console.ReadLine();
            Console.WriteLine("Wat is de datum van de krant? (bv. 1/3/2024)");
            string stringDate = Console.ReadLine();
            Console.WriteLine("Wat is de uitgeverij van de krant?");
            string publisher = Console.ReadLine();

            // datum splitten om hier een DateTime van te maken
            string[] splitDate = stringDate.Split("/");
            DateTime date = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));

            // object aanmaken op basis van prompts
            NewsPaper newsPaper = new NewsPaper(title, publisher, date);

            // tijd van creatie object opslaan
            DateTime timeCreated = DateTime.Now;

            // toevoegen aan dictionary
            AllReadingRoom.Add(timeCreated, newsPaper);

            Console.WriteLine($"\n---------------------------\n{title} succesvol toegevoegd\n---------------------------\n");

        }

        public void ShowAllNewsPapers()
        {
            Console.WriteLine("De kranten in de leeszaal:");
            CultureInfo dutchCI = new CultureInfo("nl-BE");
            foreach (var item in AllReadingRoom.Values)
            {
                if(item is NewsPaper newsPaper)
                {
                    // NewsPaper newsPaper = (NewsPaper)item;
                    Console.WriteLine($"- {newsPaper.Title} van {newsPaper.Date.ToString("dddd dd MMMM yyyy", dutchCI)} van uitgeverij {newsPaper.Publisher}");
                }
            }
        }

        public void AddMagazine()
        {
            // prompts
            Console.WriteLine("Wat is de naam van het maandblad?");
            string title = Console.ReadLine();
            Console.WriteLine("Wat is de maand van het maandblad?");
            byte month = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Wat is het jaar van het maandblad?");
            uint year = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Wat is de uitgeverij van het maandblad?");
            string publisher = Console.ReadLine();

            // object aanmaken
            Magazine magazine = new Magazine(title, publisher, month, year);

            // tijd van creatie object opslaan
            DateTime timeCreated = DateTime.Now;

            // toevoegen aan dictionary
            AllReadingRoom.Add(timeCreated, magazine);

            Console.WriteLine($"\n---------------------------\n{title} succesvol toegevoegd\n---------------------------\n");
        }

        public void ShowAllMagazines()
        {
            Console.WriteLine("Alle maandbladen uit de leeszaal");
            foreach (var item in AllReadingRoom.Values)
            {
                if(item is Magazine magazine)
                {
                    Console.WriteLine($"- {magazine.Title} van {magazine.Month}/{magazine.Year} van uitgeverij {magazine.Publisher}");
                }
            }
        }

        public void AcquisitionsReadingRoomToday()
        {
            DateTime today = DateTime.Today;
            CultureInfo dutchCI = new CultureInfo("nl-BE");
            Console.WriteLine($"Aanwinsten in de leeszaal van {today.ToString("dddd, dd, MMMM yyyy", dutchCI)}:");

            foreach (var media in AllReadingRoom)
            {
                DateTime creationDate = media.Key.Date;

                if (creationDate == today)
                {
                    var item = media.Value;
                    Console.WriteLine($"{item.Title} met id {item.Identification}");
                }
            }
        }



    }
}
