using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramPF.Estructuras_de_Datos.ArbolesAVL;

namespace InstagramPF.Clases
{
    public class Seguidor
    {
        public ArbolAVL seguidoresAVL { get; set; }

        public Seguidor(){
            seguidoresAVL = new ArbolAVL();
        }
    }
}