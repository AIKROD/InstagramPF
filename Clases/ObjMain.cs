using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramPF.Estructuras_de_Datos.ArbolesAVL;
using InstagramPF.Estructuras_de_Datos.Pilas;

namespace InstagramPF.Clases
{
    public class ObjMain
    {
        public String UsuarioEnUso { get; set; }
        public ArbolAVL UsuariosAVL { get; set; }
        public Pila posts { get; set; }
        public String UsuarioAVisualizar { get; set; }

        //CONVIERTE CADA CARACTER DEL USUARIO EN VALOR ASCII Y LO CONCATENA PARA DEVOLVER UN LONG O INT64
        //ESTO NOS SIRVE PARA LA LLAVE DE CADA USUARIO EN EL ARBOL BINARIO
        public long retornaLlave(String usuario)
        {
            long valor = 0;
            String codigo = "";
            for (int i = 0; i < usuario.Length; i++)
            {
                codigo += System.Text.ASCIIEncoding.ASCII.GetBytes(usuario.ElementAt(i).ToString())[0];
            }
            valor = Convert.ToInt64(codigo);
            return valor;
        }

        // Función donde se determina la función hash que indicara en que posición del arreglo se almacenaran los seguidos y seguidores de cada usuario
        // Los arreglos fueron definidos con tamaño 200
        // La solución para las coliciones fue que los arreglos almacenaran arboles AVL en el que se almacenara el username, y su respectiva valor en ascii como llave para el ordenamiento
        public int funcionHash(long llave)
        {
            int resultado = 0;

            resultado = Convert.ToInt32(llave % 199);

            return resultado;
        }
    }
}