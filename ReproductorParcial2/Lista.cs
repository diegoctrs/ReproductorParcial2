using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2
{
    class Lista
    {
        public Nodos first;
        public Nodos last;

        public Lista()
        {
            first = null;
            last = null;

        }

        private int leerEntero()
        {
            Console.WriteLine("Ingrese valor, -1 para finalizar");
            return Int32.Parse(Console.ReadLine());

        }

        public Nodos searchposition(int index)
        {

            if (index < 0)
            {
                return null;
            }

            int n = 0;
            Nodos aux = first;
            while (n != index)
            {
                aux = aux.enlace;
                n++;
            }

            return aux;
        }

        public void insertarCanciones(String name)
        {
            Nodos dato = new Nodos(name);

            if (first == null)
            {
                first = dato;
                first.enlace = null;
                last = dato;
            }
            else
            {

                last.enlace = dato;
                dato.enlace = null;
                last = dato;
            }
        }

        public void deleteMusic(int cancion)
        {
            Nodos actual, anterior;
            bool encontrado;
            //inicializa los apuntadores
            Nodos dato = searchposition(cancion);
            actual = first;
            anterior = null;
            encontrado = false;

            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.enlace == dato.enlace);


                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }

            //enlace del nodo anteior con el siguiente
            if (actual != null)
            {
                //distinguir si es el nodo inicial a cabeza
                //es cualquiera otro nodo de la lista
                if (actual == first)
                {
                    first = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
            }

        }

        public Lista insertarUltimo(Nodos ultimo, string entrada)
        {
            ultimo.enlace = new Nodos(entrada);
            ultimo = ultimo.enlace;
            return this;
        }

        public Lista insertarCabeza(Nodos cabeza, string valor)
        {
            cabeza.enlace = new Nodos(valor);
            cabeza = cabeza.enlace;
            return this;
        }

        public Nodos buscarLista(string destino)
        {
            Nodos indice;
            for (indice = first; indice != null; indice = indice.enlace)
            {
                if (destino == indice.dato)
                {
                    return indice;
                }
            }
            return null;
        }

        public void eliminar(string entrada)
        {
            Nodos actual, anterior;
            bool encontrado;
            //inicializa los apuntadores
            actual = first;
            anterior = null;
            encontrado = false;

            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato == entrada);

                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }

            //enlace del nodo anteior con el siguiente
            if (actual != null)
            {
                //distinguir si es el nodo inicial a cabeza
                //es cualquiera otro nodo de la lista
                if (actual == first)
                {
                    first = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
                actual = null;
            }

        }

        public Lista insertarLista(string testigo, string entrada)
        {
            Nodos nuevo, anterior;
            anterior = buscarLista(testigo);

            if (anterior != null)
            {
                nuevo = new Nodos(entrada);
                nuevo.enlace = anterior.enlace;
                anterior.enlace = nuevo;
            }
            return this;
        }

        public void visualizar()
        {
            Nodos n;
            int k = 0;
            n = first;
            while (n != null)
            {
                Console.WriteLine(n.dato + " ");
                n = n.enlace;
                k++;
                Console.WriteLine((k % 15 != 0 ? "" : "\n"));
            }
        }
    }
}
