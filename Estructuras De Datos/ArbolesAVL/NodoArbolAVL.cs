using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramPF.Estructuras_de_Datos.ArbolesAVL
{
    public class NodoArbolAVL
    {
        NodoArbolAVL Izquierdo;
        Object Objeto;
        NodoArbolAVL Derecho;
        int FE;
        long Llave;

        public NodoArbolAVL(long llave, Object obj)
        {
            Izquierdo = null;
            Objeto = obj;
            Derecho = null;
            FE = 0;
            Llave = llave;
        }

        public object getObjeto()
        {
            return Objeto;
        }

        public NodoArbolAVL getNodoIzquierdo()
        {
            return Izquierdo;
        }

        public NodoArbolAVL getNodoDerecho()
        {
            return Derecho;
        }

        public long getLlave()
        {
            return Llave;
        }

        public int getFE()
        {
            return FE;
        }

        public void setNodoIzquierdo(NodoArbolAVL izq)
        {
            Izquierdo = izq;
        }

        public void setNodoDerecho(NodoArbolAVL der)
        {
            Derecho = der;
        }

        public void setFactorDeEquilibrio(int fe)
        {
            FE = fe;
        }
    }
}
