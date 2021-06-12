using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramPF.Estructuras_de_Datos.Pilas;

namespace InstagramPF.Clases
{
    public  partial class Usuario
    {
        public String USERNAME { get; set; }
        public String FULLNAME { get; set; }
        public String PROFILEIMAGE { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public long ID { get; set; }
        public Pila POSTS { get; set; }
        public Clases.Seguido[] SEGUIDOS { get; set; }
        public Clases.Seguidor[] SEGUIDORES { get; set; }
        public int NumeroPosts;
        public int numeroSeguidos;
        public int numeroSeguidores;

        public void insertar(long id, String user, String name, String image, DateTime bdate)
        {
            ID = id;
            USERNAME = user;
            FULLNAME = name;
            PROFILEIMAGE = image;
            BIRTHDATE = bdate;
            SEGUIDOS = new Clases.Seguido[200];
            SEGUIDORES = new Clases.Seguidor[200];
            POSTS = new Pila();
            NumeroPosts = 0;
            numeroSeguidos = 0;
            numeroSeguidores = 0;
        }
    }
}