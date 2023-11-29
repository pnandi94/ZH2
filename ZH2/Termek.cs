using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class Termek
    {
        private string nev;
        private int ar;
        private List<Action> arvaltozasEsemenyek = new List<Action>();

        public string Nev { get { return nev; } }
        public int Ar
        {
            get { return ar; }
            set
            {
                if (ar != value)
                {
                    ar = value;
                    OnArvaltozas();
                }
            }
        }

        public Termek(string nev, int ar)
        {
            this.nev = nev;
            this.ar = ar;
        }

        public event Action Arvaltozas
        {
            add { arvaltozasEsemenyek.Add(value); }
            remove { arvaltozasEsemenyek.Remove(value); }
        }

        private void OnArvaltozas()
        {
            foreach (var esemenykezelo in arvaltozasEsemenyek)
            {
                esemenykezelo.Invoke();
            }
        }
    }
}
