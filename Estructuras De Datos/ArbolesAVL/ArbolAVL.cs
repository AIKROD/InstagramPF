using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramPF.Estructuras_de_Datos.ArbolesAVL
{
    public class ArbolAVL
    {
        NodoArbolAVL Raiz;
        NodoArbolAVL Actual;

        public ArbolAVL()
        {
            Raiz = null;
            Actual = null;
        }

        public NodoArbolAVL getRaiz()
        {
            return Raiz;
        }

        public Object buscar(long llave, NodoArbolAVL nodo, int v = 1)
        {
            if (nodo == null)
            {
                Console.WriteLine("No fue encontrado.");
                return null;
            }
            else if (nodo.getLlave() == llave)
            {
                Console.WriteLine("Se encontro visitando " + v.ToString() + " nodos.");
                return nodo.getObjeto();
            }
            else if (nodo.getLlave() < llave)
            {
                return buscar(llave, nodo.getNodoDerecho(), v + 1);
            }
            else
            {
                return buscar(llave, nodo.getNodoIzquierdo(), v + 1);
            }
        }

        public void insertar(long llave, Object objeto)
        {
            NodoArbolAVL aux = new NodoArbolAVL(llave, objeto);
            if (Raiz == null)
            {
                Raiz = aux;
            }
            else
            {
                Raiz = recorrerParaInsertar(Raiz, llave, aux);
            }
        }

        public int obtenerFE(NodoArbolAVL nodo)
        {
            if (nodo == null)
            {
                return -1;
            }
            else
            {
                return nodo.getFE();
            }
        }

        NodoArbolAVL recorrerParaInsertar(NodoArbolAVL nodo, long llave, NodoArbolAVL nuevoNodo)
        {
            NodoArbolAVL nuevoPadre = nodo;
            if (llave < nodo.getLlave())
            {
                if (nodo.getNodoIzquierdo() != null)
                {
                    nodo.setNodoIzquierdo(recorrerParaInsertar(nodo.getNodoIzquierdo(), llave, nuevoNodo));
                    if ((obtenerFE(nodo.getNodoIzquierdo()) - obtenerFE(nodo.getNodoDerecho())) == 2)
                    {
                        if (llave < nodo.getNodoIzquierdo().getLlave())
                        {
                            nuevoPadre = rotacionIzquierda(nodo);
                        }
                        else
                        {
                            nuevoPadre = rotacionDobleIzquierda(nodo);
                        }
                    }
                }
                else
                {
                    nodo.setNodoIzquierdo(nuevoNodo);
                    //nodo.setFactorDeEquilibrio(nodo.getFE() - 1);
                }
            }
            else if (llave > nodo.getLlave())
            {
                if (nodo.getNodoDerecho() != null)
                {
                    nodo.setNodoDerecho(recorrerParaInsertar(nodo.getNodoDerecho(), llave, nuevoNodo));
                    if ((obtenerFE(nodo.getNodoDerecho()) - obtenerFE(nodo.getNodoIzquierdo())) == 2)
                    {
                        if (llave > nodo.getNodoDerecho().getLlave())
                        {
                            nuevoPadre = rotacionDerecha(nodo);
                        }
                        else
                        {
                            nuevoPadre = rotacionDobleDerecha(nodo);
                        }
                    }
                }
                else
                {
                    nodo.setNodoDerecho(nuevoNodo);
                }
            }
            if (nodo.getNodoIzquierdo() == null && nodo.getNodoDerecho() != null)
            {
                nodo.setFactorDeEquilibrio(obtenerFE(nodo.getNodoDerecho()) + 1);
            }
            else if (nodo.getNodoDerecho() == null && nodo.getNodoIzquierdo() != null)
            {
                nodo.setFactorDeEquilibrio(obtenerFE(nodo.getNodoIzquierdo()) + 1);
            }
            else
            {
                nodo.setFactorDeEquilibrio(Math.Max(obtenerFE(nodo.getNodoIzquierdo()), obtenerFE(nodo.getNodoDerecho())) + 1);
            }
            return nuevoPadre;
        }

        public NodoArbolAVL rotacionIzquierda(NodoArbolAVL nodo)
        {
            NodoArbolAVL aux = nodo.getNodoIzquierdo();
            nodo.setNodoIzquierdo(aux.getNodoDerecho());
            aux.setNodoDerecho(nodo);
            nodo.setFactorDeEquilibrio(Math.Max(obtenerFE(nodo.getNodoIzquierdo()), obtenerFE(nodo.getNodoDerecho())) + 1);
            aux.setFactorDeEquilibrio(Math.Max(obtenerFE(aux.getNodoIzquierdo()), obtenerFE(aux.getNodoDerecho())) + 1);
            return aux;
        }

        public NodoArbolAVL rotacionDerecha(NodoArbolAVL nodo)
        {
            NodoArbolAVL aux = nodo.getNodoDerecho();
            nodo.setNodoDerecho(aux.getNodoIzquierdo());
            aux.setNodoIzquierdo(nodo);
            nodo.setFactorDeEquilibrio(Math.Max(obtenerFE(nodo.getNodoIzquierdo()), obtenerFE(nodo.getNodoDerecho())) + 1);
            aux.setFactorDeEquilibrio(Math.Max(obtenerFE(aux.getNodoIzquierdo()), obtenerFE(aux.getNodoDerecho())) + 1);
            return aux;
        }

        public NodoArbolAVL rotacionDobleIzquierda(NodoArbolAVL nodo)
        {
            NodoArbolAVL aux;
            nodo.setNodoIzquierdo(rotacionDerecha(nodo.getNodoIzquierdo()));
            aux = rotacionIzquierda(nodo);
            return aux;
        }

        public NodoArbolAVL rotacionDobleDerecha(NodoArbolAVL nodo)
        {
            NodoArbolAVL aux;
            nodo.setNodoDerecho(rotacionIzquierda(nodo.getNodoDerecho()));
            aux = rotacionDerecha(nodo);
            return aux;
        }

        public void recorrerPreOrden(NodoArbolAVL nodo)
        {
            if (nodo != null)
            {
                //RAIZ IZQUIERDA DERECHA 
                Console.WriteLine(nodo.getLlave());
                recorrerPreOrden(nodo.getNodoIzquierdo());
                recorrerPreOrden(nodo.getNodoDerecho());
            }
        }

        public void recorrerInOrden(NodoArbolAVL nodo)
        {
            if (nodo != null)
            {
                //IZQUIERDA RAIZ DERECHA
                recorrerInOrden(nodo.getNodoIzquierdo());
                Console.WriteLine(nodo.getLlave());
                recorrerInOrden(nodo.getNodoDerecho());
            }
        }

        public void recorrerPostOrden(NodoArbolAVL nodo)
        {
            if (nodo != null)
            {
                //IZQUIERDA DERECHA raiz 
                recorrerPostOrden(nodo.getNodoIzquierdo());
                recorrerPostOrden(nodo.getNodoDerecho());
                Console.WriteLine(nodo.getLlave());
            }
        }

    }
}
