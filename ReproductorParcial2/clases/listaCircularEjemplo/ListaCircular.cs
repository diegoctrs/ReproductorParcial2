using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.listaCircularEjemplo
{
    class ListaCircular
    {
        public NodoListaC lc;
        public NodoListaC nuevo;
        public NodoListaC ultimo;

        public ListaCircular()
        {
            lc = null;
            nuevo = null;
            ultimo = null;
        }

        public ListaCircular insertar(String entrada)
        {
            nuevo = new NodoListaC(entrada);
            if (lc != null) // lista circular no vacía
            {
                nuevo.enlace = lc.enlace;
                lc.enlace = nuevo;
            }
            lc = nuevo;
            return this;
        }

        public void insertarArreglado(String name)
        {           
            nuevo = new NodoListaC(name);
            if (lc == null)
            {
                lc = nuevo;
                lc.enlace = lc;
                ultimo = lc;
            }
            else
            {
                ultimo.enlace = nuevo;
                nuevo.enlace = lc;
                ultimo = nuevo;

            }
        }

        public void eliminar(String entrada)
        {
            NodoListaC actual;
            actual = lc;
            while ((actual.enlace != lc) && !actual.enlace.dato.Equals(entrada))
            {
                if (!actual.enlace.dato.Equals(entrada))
                {
                    actual = actual.enlace;
                }
            }
            // Enlace de nodo anterior con el siguiente
            // si se ha encontrado el nodo.
            if (actual.enlace.dato.Equals(entrada))
            {
                NodoListaC p;
                p = actual.enlace; // Nodo a eliminar
                if (lc == lc.enlace) // Lista con un solo nodo
                {
                    lc = null;
                }
                else
                {
                    if (p == lc)
                    {
                        lc = actual; // Se borra el elemento referenciado por lc,   
                                     // el nuevo acceso a la lista es el anterior
                    }
                    actual.enlace = p.enlace;
                }
                p = null;
            }
        }

        public void borrarLista()
        {
            NodoListaC p;
            if (lc != null)
            {
                p = lc;
                do
                {
                    NodoListaC t;
                    t = p;
                    p = p.enlace;
                    t = null; // no es estrictamente necesario
                } while (p != lc);
            }
            else
            {
                Console.WriteLine("\n\t Lista vacía.");
            }
            lc = null;
        }

        public void recorrer()
        {
            NodoListaC p;
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
            {
                Console.WriteLine("\t Lista Circular vacía.");
            }
        }
    }
}
