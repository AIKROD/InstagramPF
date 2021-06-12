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
    public partial class Seguidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Datos"] != null)
            {
                ObjMain objMain = (ObjMain)Session["Datos"];
                Clases.Usuario usuarioAux;
                String nuevoControl = "";

                usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(objMain.UsuarioAVisualizar), objMain.UsuariosAVL.getRaiz());

                nuevoControl = "<div class='inicio'><button runat='server' type='submit' OnClick='clicInicio()'>Inicio</button></div>"
                            + "<div class='menu'>Menú</div>"
                            + "<div class='imagen-perfil'>" + usuarioAux.PROFILEIMAGE + "</div>"
                            + "<div class='informacion-perfil'>" + usuarioAux.FULLNAME + "<br>" + usuarioAux.BIRTHDATE + "</div>"
                            + "<div class='numeroPosts'>" + usuarioAux.NumeroPosts + " Post </div>"
                            + "<div class='seguidores'>" + usuarioAux.numeroSeguidores + " Seguidores</div>"
                            + "<div class='seguidos'>" + usuarioAux.numeroSeguidos + " Seguidos</div>";

                LiteralControl literalControl = new LiteralControl(nuevoControl);

                divPrincipal.Controls.Add(literalControl);

                for (int i = 0; i < 200; i++)
                {
                    if(usuarioAux.SEGUIDOS[i] != null)
                    {
                        ArbolAVL auxAVL = usuarioAux.SEGUIDOS[i].seguidosAVL;
                        recorrerInOrden(auxAVL.getRaiz());
                    }
                }
            }
        }
        public void recorrerInOrden(NodoArbolAVL nodo)
        {
            if (nodo != null)
            {
                //IZQUIERDA RAIZ DERECHA
                recorrerInOrden(nodo.getNodoIzquierdo());

                ObjMain objMain = (ObjMain)Session["Datos"];
                Clases.Usuario usuarioAux;
                string texto = nodo.getObjeto().ToString();
                usuarioAux = (Clases.Usuario)objMain.UsuariosAVL.buscar(objMain.retornaLlave(texto), objMain.UsuariosAVL.getRaiz());
                
                String nuevoControl = "";
                nuevoControl = "<div class='seguido-grid-container'>"
                                    + "<div class='seguido-foto-usuario'>" + usuarioAux.PROFILEIMAGE + "</div>"
                                    + "<div class='seguido-username'><button runat='server' type='submit' OnClick='clicUsuario(this.innerHTML)'>" + usuarioAux.USERNAME + "</button></div>"
                                    + "</div>";
                LiteralControl literalControl = new LiteralControl(nuevoControl);
                divContenido.Controls.Add(literalControl);

                recorrerInOrden(nodo.getNodoDerecho());
            }
        }
        protected void clickInicio(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = objMain.UsuarioEnUso;
            Response.Redirect("Principal.aspx");
        }
        protected void clickUsuario(object sender, EventArgs e)
        {
            ObjMain objMain = (ObjMain)Session["Datos"];
            objMain.UsuarioAVisualizar = HiddenField1.Value;
            Response.Redirect("Usuario.aspx");
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