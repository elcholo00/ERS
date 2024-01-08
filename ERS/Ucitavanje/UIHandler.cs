using Comon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucitavanje
{
    public class UIHandler
    {
        public static ObradaPodatakaCSV obradaCsv;
        public static ObradaPodatakaTXT obradaTxt;
        public static ObradaPodatakaXML obradaXML;

        public UIHandler(IEvidencija proxy)
        {
            obradaCsv = new ObradaPodatakaCSV(proxy);
            obradaTxt = new ObradaPodatakaTXT(proxy);
            obradaXML = new ObradaPodatakaXML(proxy);
        }
        public void meni()
        {
            while (true) // Beskonačna petlja za prikaz menija
            {
                // Prikazujemo meni opcija
                Console.WriteLine("Dobrodošli u aplikaciju za uvoz podataka o potrošnji električne energije.");
                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1. Unos putanje za učitavanje");
                Console.WriteLine("2. Izlaz");
                Console.Write("\nVaš izbor: ");

                // Čitanje korisničkog unosa
                string unos = Console.ReadLine();

                // Provera korisničkog unosa i izvršavanje odgovarajuće akcije
                switch (unos)
                {
                    case "1":
                        UnosPutanje();
                        break;
                    case "2":
                        Console.WriteLine("Izlazak iz aplikacije.");
                        return;
                    default:
                        Console.WriteLine("Nepoznata opcija. Molimo izaberite ponovo.");
                        break;
                }

                // Pauza da bi korisnik mogao da vidi poruku pre nego što se meni ponovo prikaže
                Console.WriteLine("\nPritisnite bilo koju tipku za povratak na glavni meni.");
                Console.ReadKey();
                Console.Clear(); // Čišćenje konzole za sledeći prikaz menija
            }
        }
        static void UnosPutanje()
        {
            Console.Write("Unesite putanju do foldera sa fajlovima za učitavanje: ");
            string putanjaDoFoldera = Console.ReadLine();

            // Provera postojanja direktorijuma
            if (!Directory.Exists(putanjaDoFoldera))
            {
                Console.WriteLine("Unesena putanja ne postoji!");
                return;
            }

            // Učitavanje i obrada fajlova iz datog foldera
            ObradiFajloveIzFoldera(putanjaDoFoldera);
        }
        static void ObradiFajloveIzFoldera(string folderPutanja)
        {
            // Učitavanje svih fajlova iz datog foldera
            string[] fajlovi = Directory.GetFiles(folderPutanja);

            // Prolazimo kroz svaki fajl i određujemo tip
            foreach (string fajl in fajlovi)
            {
                string ekstenzija = Path.GetExtension(fajl).ToLower();

                // Poziv odgovarajuće funkcije na osnovu ekstenzije fajla
                switch (ekstenzija)
                {
                    case ".xml":
                        obradaXML.ObradaFajla(fajl);
                        break;
                    case ".csv":
                        obradaCsv.ObradaFajla(fajl);
                        break;
                    case ".txt":
                        obradaTxt.ObradaFajla(fajl);
                        break;
                    default:
                        Console.WriteLine($"Nepodržana ekstenzija fajla: {ekstenzija}");
                        break;
                }
            }
        }
    }
}
