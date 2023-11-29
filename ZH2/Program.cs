using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class Program
    {
        static void Main()
        {
            // Teszt TermekTarolo létrehozása és feltöltése
            TermekTarolo tarolo = new TermekTarolo();
            tarolo.TermekFelvetel(new Termek("Termek1", 100));
            tarolo.TermekFelvetel(new Termek("Termek2", 150));
            tarolo.TermekFelvetel(new Termek("Termek3", 120));
            tarolo.TermekFelvetel(new Termek("Termek4", 90));

            // ÁrVáltozás eseménykezelő tesztelése
            tarolo.TermekFelvetel(new Termek("Termek5", 200)); // Példa eseménykezelő feliratkozásra
            tarolo.TermekFelvetel(new Termek("Termek6", 80));  // Példa eseménykezelő feliratkozásra
            tarolo.TermekFelvetel(new Termek("Termek7", 110)); // Példa eseménykezelő feliratkozásra

            // Kiírjuk az eredeti rendezett listát
            Console.WriteLine("Eredeti rendezett lista:");
            ListaElem jelenlegi = tarolo.fej;
            while (jelenlegi != null)
            {
                Console.WriteLine($"{jelenlegi.Termek.Nev}: {jelenlegi.Termek.Ar}");
                jelenlegi = jelenlegi.NextElem;
            }

            // Ár változás példa
            tarolo.fej.Termek.Ar = 95;

            // Kiírjuk a rendezett listát az ár változás után
            Console.WriteLine("\nLista az ár változás után:");
            jelenlegi = tarolo.fej;
            while (jelenlegi != null)
            {
                Console.WriteLine($"{jelenlegi.Termek.Nev}: {jelenlegi.Termek.Ar}");
                jelenlegi = jelenlegi.NextElem;
            }

            // Szűrés metódus tesztelése
            try
            {
                int sz = 100;
                TermekTarolo szurtTarolo = tarolo.Szures(sz);
                Console.WriteLine("\n" + sz + " alatti termékek");
                jelenlegi = szurtTarolo.fej;
                while (jelenlegi != null)
                {
                    Console.WriteLine($"{jelenlegi.Termek.Nev}: {jelenlegi.Termek.Ar}");
                    jelenlegi = jelenlegi.NextElem;
                }
            }
            catch (NincsIlyenElemException e)
            {
                Console.WriteLine($"Hiba: {e.Message}");
            }
        }
    }
}
