using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Wilson_Quayson
{
    internal class NewsPaper : ReadingRoomItem
    {
        private string identification;
        public override string Identification
        {
            get
            {
                string result = "";
                string[] identificationSplit = this.Title.Split(" ");
                foreach (var word in identificationSplit)
                {
                    result += word[0];
                }
                string day = this.Date.Day.ToString("00");
                string month = this.Date.Month.ToString("00");
                string year = this.Date.Year.ToString();
                return $"{result}{day}{month}{year}";
            }
        }

        private string categorie;
        public override string Categorie
        {
            get { return "krant"; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            this.Date = date;
        }

        public static void CsvDeserializeNewspaper(Library library, string csvFile = @"C:\Users\Wilson\Documents\newspaper.csv")
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

                    if (fields.Length != 3)
                    {
                        Console.WriteLine($"Fout lijn formaat: {line}");
                        continue;
                    }

                    CultureInfo dutchCI = new CultureInfo("nl-BE");
                    string title = fields[0];
                    string publisher = fields[1];
                    DateTime date = DateTime.ParseExact(fields[2], "dd/MM/yyyy", dutchCI);

                    library.AllReadingRoom.Add(DateTime.Now, new NewsPaper(title, publisher, date));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
