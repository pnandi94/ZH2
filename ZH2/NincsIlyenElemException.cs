using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class NincsIlyenElemException : Exception
    {
        public NincsIlyenElemException(string message) : base("Nincs ilyen elem")
        {
        }
    }
}
