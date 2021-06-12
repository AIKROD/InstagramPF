using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using InstagramPF.Estructuras_de_Datos.ArbolesAVL;
using InstagramPF.Estructuras_de_Datos.Pilas;
using InstagramPF.Clases;

namespace InstagramPF.pages
{
    public partial class Inicio :  Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ObjMain objMain = new ObjMain();

            //SE CARGAN TODOS LOS USUARIOS A UN ARBOL AVL

            String ruta = Server.MapPath("~/xml/UserData.xml");
            XmlDocument document = new XmlDocument();
            document.Load(ruta);
            XmlNodeList nodos = document.SelectNodes("/USERDATA/USER");

            Clases.Usuario usuario;
            ArbolAVL usuariosAVL = new ArbolAVL();

            foreach (XmlNode nodo in nodos)
            {
                usuario = new Clases.Usuario();
                usuario.insertar(objMain.retornaLlave(nodo.SelectSingleNode("USERNAME").InnerText), nodo.SelectSingleNode("USERNAME").InnerText, nodo.SelectSingleNode("FULLNAME").InnerText, nodo.SelectSingleNode("PROFILEIMAGE").InnerText, Convert.ToDateTime(nodo.SelectSingleNode("BIRTHDATE").InnerText.ToString()));

                usuariosAVL.insertar(objMain.retornaLlave(nodo.SelectSingleNode("USERNAME").InnerText), usuario);

            }

            
            objMain.UsuariosAVL = usuariosAVL;


            //SECCIÓN PARA ALMACENAR LOS POST EN UNA PILA QUE SERAN REFLEJADOS EN LA PANTALLA PRINCIPAL
            //SE AGREGAN SUS RESPECTIVOS POST A CADA USUARIO DENTRO DE UNA PILA            

            ruta = Server.MapPath("~/xml/FeedData.xml");
            document.Load(ruta);
            nodos = document.SelectNodes("/FEEDDATA/USER");

            Clases.Post post;
            Pila pila = new Pila();

            for (int i = (nodos.Count - 1); i >= 0; i--)
            {
                post = new Clases.Post();
                post.USERNAME = nodos[i].SelectSingleNode("USERNAME").InnerText;
                post.POST = nodos[i].SelectSingleNode("POST").InnerText;
                post.MULTIMEDIA = nodos[i].SelectSingleNode("MULTIMEDIA").InnerText;

                Object obj = usuariosAVL.buscar(objMain.retornaLlave(post.USERNAME), usuariosAVL.getRaiz());
                usuario = (Clases.Usuario)obj;
                usuario.POSTS.insertar(post);
                usuario.NumeroPosts++;

                if (usuario.USERNAME == "ABANDA")
                {
                    usuario.USERNAME.ToString();
                }

                pila.insertar(post);
            }

            objMain.posts = pila;

            //SECCIÓN PARA ALMACENAR SEGUIDOS Y LOS SEGUIDORES PARA CADA USUARIO

            ruta = Server.MapPath("~/xml/FollowerFollowingData.xml");
            document.Load(ruta);
            nodos = document.SelectNodes("/FOLLOWINGFOLLOWERDATA/USER");

            foreach (XmlNode nodo in nodos)
            {
                //INICIO SECCION PARA INSERTAR SEGUIDOS
                Object obj = usuariosAVL.buscar(objMain.retornaLlave(nodo.SelectSingleNode("FOLLOWER").InnerText), usuariosAVL.getRaiz());
                usuario = (Clases.Usuario)obj;

                long llave = objMain.retornaLlave(nodo.SelectSingleNode("FOLLOWER").InnerText);

                if (usuario.SEGUIDOS[objMain.funcionHash(llave)] == null)
                {
                    Clases.Seguido seguidoAux = new Clases.Seguido();
                    usuario.SEGUIDOS[objMain.funcionHash(llave)] = seguidoAux;
                }
                usuario.SEGUIDOS[objMain.funcionHash(llave)].seguidosAVL.insertar(llave, nodo.SelectSingleNode("FOLLOWING").InnerText);
                usuario.numeroSeguidos++;
                //FIN SECCION PARA INSERTAR SEGUIDOS

                //INICIO SECCION PARA INSERTAR SEGUIDORES
                obj = usuariosAVL.buscar(objMain.retornaLlave(nodo.SelectSingleNode("FOLLOWING").InnerText), usuariosAVL.getRaiz());
                usuario = (Clases.Usuario)obj;

                llave = objMain.retornaLlave(nodo.SelectSingleNode("FOLLOWING").InnerText);

                if (usuario.SEGUIDORES[objMain.funcionHash(llave)] == null)
                {
                    Clases.Seguidor seguidorAux = new Clases.Seguidor();
                    usuario.SEGUIDORES[objMain.funcionHash(llave)] = seguidorAux;
                }
                usuario.SEGUIDORES[objMain.funcionHash(llave)].seguidoresAVL.insertar(llave, nodo.SelectSingleNode("FOLLOWER").InnerText);
                usuario.numeroSeguidores++;
                //FIN SECCION PARA INSERTAR SEGUIDORES

            }


            //objMain.UsuarioEnUso = "HPHILTAN";
            //objMain.UsuarioAVisualizar = "HPHILTAN";

            Session["Datos"] = objMain;
        }

        protected void clickIR (object sender, EventArgs e)
        {
            if (txtUser.Value.ToString().Trim() != ""){

                ObjMain objMain = (ObjMain)Session["Datos"];
                Clases.Usuario usuarioAux;
                usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(txtUser.Value), objMain.UsuariosAVL.getRaiz());

                if (usuarioAux != null)
                {
                    objMain.UsuarioEnUso = usuarioAux.USERNAME;
                    objMain.UsuarioAVisualizar = usuarioAux.USERNAME;
                    Response.Redirect("Principal.aspx");
                }
            }

        }
    }
}