using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.listaDoble
{
    class IteradorLista
    {
        private NodoListaDoble actual;

        public IteradorLista(ClsListaDoble Id)
        {
            actual = Id.cabeza;
        }

        public NodoListaDoble siguiente()
        {
            NodoListaDoble a;
            a = actual;
            if (actual != null)
            {
                actual = actual.adelante;
            }
            return a;
        }
    }
}
