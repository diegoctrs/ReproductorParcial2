using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.listaDoble
{
    class NodoListaDoble
    {
        public string dato;
        public NodoListaDoble adelante;
        public NodoListaDoble atras;

        public string getDato()
        {
            return dato;
        }

        public NodoListaDoble(string entrada)
        {
            dato = entrada;
            adelante = atras = null;
        }
    }
}
