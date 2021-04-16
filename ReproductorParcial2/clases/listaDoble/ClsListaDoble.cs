using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.listaDoble
{
    class ClsListaDoble
    {
        public NodoListaDoble primero;
        public NodoListaDoble ultimo;
        public NodoListaDoble cabeza; // es el nodo que se llama primero

        public ClsListaDoble()
        {
            cabeza = null;
        }
    
        public ClsListaDoble insertarCabezaLista(string entrada)
        {
            NodoListaDoble nuevo;
            nuevo = new NodoListaDoble(entrada);
            nuevo.adelante = cabeza;
            if (cabeza != null)
            {
                cabeza.atras = nuevo;
            }
            cabeza = nuevo;
            return this;
        }

        public void insertarCabezaArreglado(String name)
        {
            NodoListaDoble nuevo;
            nuevo = new NodoListaDoble(name);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cabeza.atras = nuevo;
                ultimo = cabeza;
            }
            else
            {
                ultimo.adelante = nuevo;
                nuevo.atras = cabeza;
                ultimo = nuevo;

            }
        }

        public ClsListaDoble insertaDespues(NodoListaDoble anterior, string entrada)
        {
            NodoListaDoble nuevo;
            nuevo = new NodoListaDoble(entrada);
            nuevo.adelante = anterior.adelante;
            if (anterior.adelante != null)
            {
                anterior.adelante.atras = nuevo;
            }
            anterior.adelante = nuevo;
            nuevo.atras = anterior;
            return this;
        }

        public void eliminar(string entrada)
        {
            NodoListaDoble actual;
            bool encontrado = false;
            actual = cabeza;

            // bucle de busqueda
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato == entrada);
                if (!encontrado)
                {
                    actual = actual.adelante;
                }
            }

            // enlace de nodo anterior con el siguiente
            if (actual != null)
            {
                // distinguir entre nodo cabecera del resto de la lista
                if (actual == cabeza)
                {
                    cabeza = actual.adelante;
                    if (actual.adelante != null)
                    {
                        actual.adelante.atras = null;
                    }
                }
                else if (actual.adelante != null)
                { // no es el ultimo nodo 
                    actual.atras.adelante = actual.adelante;
                    actual.adelante.atras = actual.atras;
                }
                else
                { // es el ultimo nodo
                    actual.atras.adelante = null;
                }
                actual = null;
            }
        }

        public void visualizar()
        {
            NodoListaDoble n;
            n = cabeza;
            while (n != null)
            {
                Console.WriteLine(n.dato + "\n");
                n = n.adelante;
            }
        }
    }
}
