using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class ListaElem
    {
        public Termek Termek { get; set; }
        public ListaElem NextElem { get; set; }

        public ListaElem(Termek termek, ListaElem nextElem = null)
        {
            Termek = termek;
            NextElem = nextElem;
        }
    }
}
