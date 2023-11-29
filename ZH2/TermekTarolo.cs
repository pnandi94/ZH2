using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class TermekTarolo
    {
        public ListaElem fej;


        public void TermekFelvetel(Termek termek)
        {
            ListaElem elem = new ListaElem(termek);
            termek.Arvaltozas += OnArvaltozas;

            if (fej == null || termek.Ar <= fej.Termek.Ar)
            {
                elem.NextElem = fej;
                fej = elem;
            }
            else
            {
                ListaElem jelenlegi = fej;
                while (jelenlegi.NextElem != null && jelenlegi.NextElem.Termek.Ar < termek.Ar)
                {
                    jelenlegi = jelenlegi.NextElem;
                }
                elem.NextElem = jelenlegi.NextElem;
                jelenlegi.NextElem = elem;
            }
        }

        private void OnArvaltozas()
        {
            // Rendezettség ellenőrzése és helyreállítása szükség esetén
            // Tetszőleges módon megtehetjük, például elem átmozgatással vagy törlés és újrafelvétellel

            // Ha a lista üres, vagy csak egy elem van, nincs szükség rendezésre
            if (fej == null || fej.NextElem == null)
            {
                return;
            }

            // Létrehozunk egy új listát a rendezett elemekkel
            ListaElem rendezettFej = null;
            ListaElem jelenlegi = fej;

            while (jelenlegi != null)
            {
                ListaElem kovetkezo = jelenlegi.NextElem;

                // A fej áthelyezése, ha az új elem kisebb
                if (rendezettFej == null || jelenlegi.Termek.Ar <= rendezettFej.Termek.Ar)
                {
                    jelenlegi.NextElem = rendezettFej;
                    rendezettFej = jelenlegi;
                }
                else
                {
                    // Az elem beillesztése a rendezett listába
                    ListaElem rendezettJelenlegi = rendezettFej;
                    while (rendezettJelenlegi.NextElem != null && rendezettJelenlegi.NextElem.Termek.Ar < jelenlegi.Termek.Ar)
                    {
                        rendezettJelenlegi = rendezettJelenlegi.NextElem;
                    }
                    jelenlegi.NextElem = rendezettJelenlegi.NextElem;
                    rendezettJelenlegi.NextElem = jelenlegi;
                }

                jelenlegi = kovetkezo;
            }

            // A rendezett listát átállítjuk a eredeti listára
            fej = rendezettFej;
        }

        public TermekTarolo Szures(int maximumAr)
        {
            TermekTarolo szurtTarolo = new TermekTarolo();
            ListaElem jelenlegi = fej;
            while (jelenlegi != null)
            {
                if (jelenlegi.Termek.Ar <= maximumAr)
                {
                    szurtTarolo.TermekFelvetel(jelenlegi.Termek);
                }
                jelenlegi = jelenlegi.NextElem;
            }
            if (szurtTarolo.fej == null)
            {
                throw new NincsIlyenElemException("Nincs olyan termék, amely a megadott árnál olcsóbb vagy egyenlő.");
            }
            return szurtTarolo;
        }
    }
}
