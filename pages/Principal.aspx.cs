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
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Datos"] != null)
            {
                ObjMain objMain = (ObjMain) Session["Datos"];
                Clases.Usuario usuarioAux;
                String nuevoControl = "";

                usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(objMain.UsuarioEnUso), objMain.UsuariosAVL.getRaiz());
                
                nuevoControl = "<div class='inicio'>Inicio</div>"
                            + "<div class='menu'>Menú</div>"
                            + "<div class='imagen-perfil'>" + usuarioAux.PROFILEIMAGE + "</div>"
                            + "<div class='informacion-perfil'>" + usuarioAux.FULLNAME + "<br>" + usuarioAux.BIRTHDATE + "</div>"
                            + "<div class='numeroPosts'><button id='" + usuarioAux.USERNAME + "' runat='server' type='submit' OnClick='clicPosts(this.id)'>" + usuarioAux.NumeroPosts + " Posts </button></div>"
                            + "<div class='seguidores'><button runat='server' type='submit' OnClick='clicSeguidores()'>" + usuarioAux.numeroSeguidores + " Seguidores</button></div>"
                            + "<div class='seguidos'><button runat='server' type='submit' OnClick='clicSeguidos()'>" + usuarioAux.numeroSeguidos + " Seguidos</button></div>";
                
                LiteralControl literalControl = new LiteralControl(nuevoControl);

                divPrincipal.Controls.Add(literalControl);

                //Button boton = new Button();
                //boton.Text = "aaaaaaaaaaaaaaaaaaaa";
                //boton.Attributes.Add("runat", "server");
                //boton.Attributes.Add("type", "submit");
                //boton.Attributes.Add("OnClick", "clicUsuario(this)");
                ////boton.OnClientClick = "clickUsuario()";
                //boton.ID = "lolita";
                //divContenido.Controls.Add(boton);

                Post post = new Post();
                while (objMain.posts.getActual() != objMain.posts.getUltimo())
                {
                    post = (Post)objMain.posts.complementarRecorrido();
                    
                    usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(post.USERNAME), objMain.UsuariosAVL.getRaiz()); 

                    nuevoControl = "<div class='post-grid-container'>"
                                + "<div class='post-foto-usuario'>" + usuarioAux.PROFILEIMAGE + "</div>"
                                + "<div class='post-username'><button runat='server' type='submit' OnClick='clicUsuario(this.innerHTML)'>" + usuarioAux.USERNAME + "</button></div>"
                                + "<div class='post-foto'>" + post.MULTIMEDIA + "</div>"
                                + "<div class='post-like'>Like</div>"
                                + "<div class='post-comentario'>Comentario</div>"
                                + "<div class='post-compartir'>Compartir</div>"
                                + "<div class='post-texto'>" + post.POST + "</div>"
                                + "<div class='post-fecha'>" + post.FechaPublicacion + "</div>"
                                //+ "<asp:Button id='btnLoguearse2' style='color: #ffff; background-color: #000000; border: none;' runat ='server'  OnClick='clickUsuario' Text='" + usuarioAux.USERNAME + "' />"
                                + "</div>";

                    literalControl = new LiteralControl(nuevoControl);



                    divContenido.Controls.Add(literalControl);

                }
                objMain.posts.reiniciarActual();
            }
        }
        protected void clickUsuario(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = HiddenField1.Value;
            Response.Redirect("Usuario.aspx");
        }

        protected void clickPosts(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = HiddenField1.Value;
            Response.Redirect("Usuario.aspx");
        }
        protected void clickSeguidos(object sender, EventArgs e)
        {
            //ObjMain objMain = (ObjMain)Session["Datos"];
            Response.Redirect("Seguidos.aspx");
        }
        protected void clickSeguidores(object sender, EventArgs e)
        {
            //ObjMain objMain = (ObjMain)Session["Datos"];
            Response.Redirect("Seguidores.aspx");
        }

    }
}