using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.circularDefinicion
{
    class ClsListaCircularBase
    {
        private NodoCircular lc;

        public ClsListaCircularBase()
        {
            lc = null;
        }

        public ClsListaCircularBase insertar(int entrada)
        {
            NodoCircular nuevo;
            nuevo = new NodoCircular(entrada);
            if (lc != null)
            {
                nuevo.enlace = lc.enlace;
            }
            lc = nuevo;
            return this;
        }

        public void eliminar(int entrada)
        {
            NodoCircular actual;
            bool encontrado = false;

            // bucle de busqueda
            actual = lc;
            while ((actual.enlace != lc) && (!encontrado))
            {
                encontrado = (actual.enlace.dato == entrada);
                if (!encontrado)
                {
                    actual = actual.enlace;
                }
            }
            encontrado = (actual.enlace.dato == entrada);
            // enlace de nodo anterior con el siguiente
            if (encontrado)
            {
                NodoCircular p;
                p = actual.enlace;
                if (lc == lc.enlace)
                {
                    lc = null;
                }
                else
                {
                    if (p == lc)
                    {
                        lc = actual; // se borra el elemento referenciado por la lc
                                     // el nuevo acceso a la lista es el anterior
                    }
                    actual.enlace = p.enlace;
                }
                p = null;
            }
        }

        public void recorrer()
        {
            NodoCircular p;
            if (lc != null)
            {
                p = lc.enlace; // siguiente nodo al de acceso
                do
                {
                    Console.WriteLine("\t" + p.dato);
                    p = p.enlace;
                } while (p != lc.enlace);
            }
            else
                Console.WriteLine("\t Lista Circular vacía.");
        }
    }
}
