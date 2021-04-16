using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.circularDefinicion
{
    class NodoCircular
    {
        public int dato;
        public NodoCircular enlace;

        public NodoCircular(int entrada)
        {
            dato = entrada;
            enlace = this;
        }
    }
}
