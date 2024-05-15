using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Wilson_Quayson
{
    internal class Magazine : ReadingRoomItem
    {
        private string categorie;
        public override string Categorie
        {
            get { return "Maandblad"; }
        }

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
                string month = this.Month.ToString("00");
                string year = this.Year.ToString("0000");
                return $"{result}{month}{year}";
            }
        }

        private byte month;
        public byte Month
        {
            get { return month; }
            set
            {
                if(value > 12)
                {
                    Console.WriteLine("De maand is maximaal 12");
                }
                else
                {
                    month = value;
                }
            }
        }

        private uint year;
        public uint Year
        {
            get { return year; }
            set
            {
                if(value > 2500)
                {
                    Console.WriteLine("Het jaartal is maximaal 2500");
                }
                else
                {
                    year = value;
                }
            }
        }



        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            this.Month = month;
            this.Year = year;
        }


        public static void CsvDeserializeMagazine(Library library, string csvFile = @"C:\Users\Wilson\Documents\magazines.csv")
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

                    if (fields.Length != 4)
                    {
                        Console.WriteLine($"Fout lijn formaat: {line}");
                        continue;
                    }

                    string title = fields[0];
                    string publisher = fields[1];
                    byte month = Convert.ToByte(fields[2]);
                    uint year = Convert.ToUInt32(fields[3]);

                    library.AllReadingRoom.Add(DateTime.Now, new Magazine(title, publisher, month, year));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
