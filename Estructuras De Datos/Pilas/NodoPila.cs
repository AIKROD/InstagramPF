using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramPF.Estructuras_de_Datos.Pilas
{
    public class NodoPila
    {
        Object Objeto;
        NodoPila Siguiente;

        public void setObjeto(Object objeto) 
        {
            Objeto = objeto;    
        }
        public Object getObjeto()
        {
            return Objeto;
        }
        public void setSiguiente(NodoPila nodo)
        {
            Siguiente = nodo;
        }
        public NodoPila getSiguiente()
        {
            return Siguiente;
        }
    }
}
