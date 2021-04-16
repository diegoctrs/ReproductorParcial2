using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2
{
    class Nodos
    {
        public string dato;
        public Nodos enlace;

        public Nodos(string x)
        {
            this.dato = x;
            this.enlace = null;
        }

        public Nodos(string x, Nodos n)
        {

            dato = x;
            enlace = n;
        }

        public string getDato()
        {
            return dato;
        }

        public Nodos getEnlace()
        {
            return enlace;
        }

        public void setEnlace(Nodos enlace)
        {
            this.enlace = enlace;
        }
    }
}
