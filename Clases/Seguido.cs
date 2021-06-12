using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramPF.Estructuras_de_Datos.ArbolesAVL;

namespace InstagramPF.Clases
{
    public class Seguido
    {
        public ArbolAVL seguidosAVL { get; set; }
        

        public Seguido(){
            seguidosAVL = new ArbolAVL();
        }
    }
}