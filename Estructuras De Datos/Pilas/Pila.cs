using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramPF.Estructuras_de_Datos.Pilas
{
    public class Pila
    {
        NodoPila Cima;
        NodoPila Ultimo;
        NodoPila Actual;

        public Pila() 
        {
            Cima = null;
            Ultimo = null;
            Actual = null;
        }
        public void insertar(Object objeto)
        {
            NodoPila aux = new NodoPila();
            aux.setObjeto(objeto);

            if (Cima == null)
            {
                Cima = aux;
                Ultimo = Cima;
            }
            else {
                aux.setSiguiente(Cima);
                Cima = aux;
            }
        }
        public Object getCima()
        {
            return Cima;
        }
        public Object getUltimo()
        {
            return Ultimo;
        }
        public Object getActual() 
        {
            return Actual;
        }

        public void reiniciarActual() {
            Actual = null;
        }

        public Object obtenerElemento(NodoPila nodo)
        {
            return nodo.getObjeto();
        }

        // Esta función sirve para ayudar a recorrer la pila con objetos dinamicos
        // y que pueda ser reutilizable.
        public Object complementarRecorrido()
        {
            if (Actual == null)
            {
                Actual = Cima;
            }
            else
            {
                Actual = Actual.getSiguiente();
            }
            if(Actual != null)
            {
                return obtenerElemento(Actual);
            } else
            {
                return null;
            }
        }
        public void eliminarCima()
        {
            Cima = Cima.getSiguiente();
        }

    }
}

