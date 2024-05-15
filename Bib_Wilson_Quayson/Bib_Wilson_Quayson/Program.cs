using System.Security.Cryptography.X509Certificates;

namespace Bib_Wilson_Quayson
{
    internal class Program
    {
        static Library projectLibrary = new Library("project bibliotheek");
        static void Main(string[] args)
        {
            Book.CsvDeserialize(projectLibrary); // 2de paramter toevoegen als deze op een andere computer word gerund.
            Magazine.CsvDeserializeMagazine(projectLibrary); // 2de paramter toevoegen als deze op een andere computer word gerund.
            NewsPaper.CsvDeserializeNewspaper(projectLibrary); // 2de paramter toevoegen als deze op een andere computer word gerund.

            Console.WriteLine("--------------- CSV Bestanden ingeladen voor classe Book ---------------");
            Console.WriteLine("--------------- CSV Bestanden ingeladen voor classe Magazine ---------------");
            Console.WriteLine("--------------- CSV Bestanden ingeladen voor classe Newspaper ---------------");


            bool condition = true;
            while (condition)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("**************************************************");
                Console.WriteLine("*                    Library Menu                *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("*                                                *");
                Console.WriteLine("*   1. Boek toevoegen                            *");
                Console.WriteLine("*   2. isbn aan boek toe voegen                  *");
                Console.WriteLine("*   3. prijs aan boek toe voegen                 *");
                Console.WriteLine("*   4. Info tonen op basis van titel en auteur   *");
                Console.WriteLine("*   5. Boek(en) op zoeken (Prijs)                *");
                Console.WriteLine("*   6. Boek verwijderen                          *");
                Console.WriteLine("*   7. Alle boeken tonen in bibliotheek          *");
                Console.WriteLine("*   8. Krant of magazine toevoegen               *");
                Console.WriteLine("*   9. Alle kranten tonen                        *");
                Console.WriteLine("*  10. Alle maandbladen tonen                    *");
                Console.WriteLine("*  11. Aanwinsten van de leeszaal tonen          *");
                Console.WriteLine("*  12. Boek uitlenen                             *");
                Console.WriteLine("*  13. Boek terugbrengen                         *");
                Console.WriteLine("*  14. Programma verlaten                        *");
                Console.WriteLine("*                                                *");
                Console.WriteLine("**************************************************");
                Console.ResetColor();





                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddByTitleAuthor();
                        break;
                    case "2":
                        AddIsbn();
                        break;
                    case "3":
                        AddPrice();
                        break;
                    case "4":
                        ShowBookInfo();
                        break;
                    case "5":
                        SearchByPrice();
                        break;
                    case "6":
                        DeleteBook();
                        break;
                    case "7":
                        ShowAllBooks();
                        break;
                    case "8":
                        AddMagazineOrNewspaper();
                        break;
                    case "9":
                        ShowAllNewspapers();
                        break;
                    case "10":
                        ShowAllMagazines();
                        break;
                    case "11":
                        ShowAcquisitionsReadingRoom();
                        break;
                    case "12":
                        LoanOutBook();
                        break;
                    case "13":
                        ReturnBook();
                        break;
                    case "14":
                        return;
                    default:
                        break;
                }

                
            }
        }

        public static void AddByTitleAuthor()
        {
            try
            {
                Console.WriteLine("Geef een titel in: ");
                string title = Console.ReadLine();
                Console.WriteLine("Geef een auteur in: ");
                string author = Console.ReadLine();

                projectLibrary.AddBook(new Book(title, author));

                Console.WriteLine($"\n---------------------------\n{title} door {author} succesvol toegevoegd\n---------------------------\n");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Fout: Fout formaat ingegeven");
                Console.WriteLine(fe);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("titel en/of auteur mogen niet null of leeg zijn");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AddIsbn()
        {
            Console.WriteLine("Wat is de titel van het boek waar je een ISBN nummer aan wilt toevoegen");
            string choice = Console.ReadLine();

            foreach (var book in projectLibrary.books)
            {
                if(book.Isbn != null)
                {
                    Console.WriteLine("Boek heeft al een isbn nummer");
                }else if(book.Title == choice && book.Isbn == null)
                {
                    Console.WriteLine("Geef het ISBN nummer dat je wilt toevoegen in: ");
                    string isbn = Console.ReadLine();

                    book.Isbn = isbn;
                    Console.WriteLine("ISBN nummer is toegevoegd");
                    break;
                }
            }
        }

        public static void AddPrice()
        {
            Console.WriteLine("Wat is de titel van het boek waar je de prijs aan wilt toevoegen (bv. 13,99)");
            string choice = Console.ReadLine();
            Console.WriteLine("Welke prijs wil je instellen voor dit boek?");
            double price = Convert.ToDouble(Console.ReadLine());

            foreach (var book in projectLibrary.books)
            {
                if (book.Title == choice)
                {
                    book.Price = price;
                    Console.WriteLine("Prijs toegevoegd");
                    break;
                }
            }
        }

        public static void ShowBookInfo()
        {
            Console.WriteLine("Wat is de titel van het boek dat je wilt zien: ");
            string title = Console.ReadLine();
            Console.WriteLine("Wie is de auteur van het boek dat je wilt zien: ");
            string author = Console.ReadLine();

            foreach (var book in projectLibrary.books)
            {
                if(book.Title == title && book.Author == author)
                {
                    book.DisplayInfo();
                    break;
                }
            }
        }

        public static void SearchByPrice()
        {
            List<Book> matchedPrice = new List<Book>();
            Console.Write("Geef de numerale waarde van een prijs in (bv. 10.00) : ");
            double price = Convert.ToDouble(Console.ReadLine());
            foreach (var book in projectLibrary.books)
            {
                if(book.Price == price)
                {
                    matchedPrice.Add(book);
                }
            }
            foreach (var book in matchedPrice)
            {
                Console.WriteLine($"-{book.Title} van auteur {book.Author}");
            }
        }

        public static void DeleteBook()
        {
            Console.Write("Wat is de titel van het boek dat je wilt verwijderen: ");
            string choice = Console.ReadLine();

            foreach (var book in projectLibrary.books)
            {
                if(book.Title == choice)
                {
                    Console.WriteLine($"Ben je zeker dat je {book.Title} wilt verwijderen uit de bibliotheek? (ja/nee)");
                    string confirmation = Console.ReadLine();
                    if(confirmation.ToLower() == "ja")
                    {
                        projectLibrary.books.RemoveAll(book => book.Title == choice);
                        Console.WriteLine($"{choice} is verwijderd uit de bibliotheek");
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void ShowAllBooks()
        {
            int count = 1;
            foreach (var book in projectLibrary.books)
            {
                Console.WriteLine($"{count}. {book.Title}");
                count++;
            }
        }

        public static void AddMagazineOrNewspaper()
        {
            Console.WriteLine("Wilt u een krant of magazine toevoegen\n1. krant\n2. magazine");
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                projectLibrary.AddNewspaper();
            }
            else if(choice == "2")
            {
                projectLibrary.AddMagazine();
            }
            else
            {
                Console.WriteLine($"\"{choice}\" is geen geldige optie");
            }
        }

        public static void ShowAllNewspapers()
        {
            projectLibrary.ShowAllNewsPapers();
        }

        public static void ShowAllMagazines()
        {
            projectLibrary.ShowAllMagazines();
        }

        public static void ShowAcquisitionsReadingRoom()
        {
            projectLibrary.AcquisitionsReadingRoomToday();
        }

        public static void LoanOutBook()
        {
            Console.WriteLine("Welk boek wil je lenen?");
            for (int i = 0; i < projectLibrary.books.Count; i++)
            {
                Console.WriteLine($"{i}.\t{projectLibrary.books[i].Title}");
            }
            int indexChoice = Convert.ToInt32(Console.ReadLine());
            projectLibrary.books[indexChoice].Borrow();
        }

        public static void ReturnBook()
        {
            Console.WriteLine("Welk boek wil je terugbrengen?");
            for (int i = 0; i < projectLibrary.books.Count; i++)
            {
                Console.WriteLine($"{i}.\t{projectLibrary.books[i].Title}");
            }
            int indexChoice = Convert.ToInt32(Console.ReadLine());
            projectLibrary.books[indexChoice].Return();
        }
        


    }
}