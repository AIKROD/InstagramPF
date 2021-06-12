using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstagramPF.Estructuras_de_Datos.ArbolesAVL;
using InstagramPF.Estructuras_de_Datos.Pilas;
using InstagramPF.Clases;
using InstagramPF.pages;

namespace InstagramPF.pages
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Datos"] != null)
            {
                ObjMain objMain = (ObjMain)Session["Datos"];
                Clases.Usuario usuarioAux;
                String nuevoControl = "";

                usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(objMain.UsuarioAVisualizar), objMain.UsuariosAVL.getRaiz());

                nuevoControl = "<div class='inicio'><button runat='server' type='submit' OnClick='clicUsuario(this.innerHTML)'>Inicio</button></div>"
                            + "<div class='menu'>Menú</div>"
                            + "<div class='imagen-perfil'>" + usuarioAux.PROFILEIMAGE + "</div>"
                            + "<div class='informacion-perfil'>" + usuarioAux.FULLNAME + "<br>" + usuarioAux.BIRTHDATE + "</div>"
                            + "<div class='numeroPosts'>" + usuarioAux.NumeroPosts + " Post </div>"
                            + "<div class='seguidores'><button runat='server' type='submit' OnClick='clicSeguidores()'>" + usuarioAux.numeroSeguidores + " Seguidores</button></div>"
                            + "<div class='seguidos'><button runat='server' type='submit' OnClick='clicSeguidos()'>" + usuarioAux.numeroSeguidos + " Seguidos</button></div>";

                LiteralControl literalControl = new LiteralControl(nuevoControl);

                divPrincipal.Controls.Add(literalControl);

                Post post = new Post();
                while (usuarioAux.POSTS.getActual() != usuarioAux.POSTS.getUltimo())
                {
                    post = (Post)usuarioAux.POSTS.complementarRecorrido();

                    if (post != null)
                    {
                        //usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(post.USERNAME), objMain.UsuariosAVL.getRaiz());

                        nuevoControl = "<div class='post-grid-container'>"
                                    + "<div class='post-foto'>" + post.MULTIMEDIA + "</div>"
                                    + "<div class='post-like'>Like</div>"
                                    + "<div class='post-comentario'>Comentario</div>"
                                    + "<div class='post-compartir'>Compartir</div>"
                                    + "<div class='post-texto'>" + post.POST + "</div>"
                                    + "<div class='post-fecha'>" + post.FechaPublicacion + "</div>"
                                    + "</div>";

                        literalControl = new LiteralControl(nuevoControl);

                        divContenido.Controls.Add(literalControl);                        
                    }

                }
                objMain.posts.reiniciarActual();
            }
        }
        protected void clickUsuario(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = objMain.UsuarioEnUso;
            Response.Redirect("Principal.aspx");
        }

        protected void clickSeguidos(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = objMain.UsuarioAVisualizar;
            Response.Redirect("Seguidos.aspx");
        }
        protected void clickSeguidores(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = objMain.UsuarioAVisualizar;
            Response.Redirect("Seguidores.aspx");
        }
    }
}