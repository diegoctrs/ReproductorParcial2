using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorParcial2.clases.listaCircularEjemplo
{
    class NodoListaC
    {
        public String dato;
        public NodoListaC enlace;

        public NodoListaC(String entrada)
        {
            dato = entrada;
            enlace = this; // se apunta asímismo
        }
    }
}
