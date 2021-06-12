 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="InstagramPF.pages.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal</title>
    <style>

      .inicio { grid-area: inicio; }
      .menu { grid-area: menu; }
      .imagen-perfil { grid-area: pimagen; }
      .informacion-perfil { grid-area: pinfo; }
      .numeroPosts { grid-area: nposts; }
      .seguidores { grid-area: seguidores; }
      .seguidos { grid-area: seguidos; }
      .contenido { grid-area: contnt; }

      .inicio-grid-container {
        display: grid;
        grid-template-areas:
          'inicio  espacio espacio espacio espacio menu   menu       menu'
          'pimagen pimagen pinfo   pinfo   pinfo   nposts seguidores seguidos '
          'contnt  contnt  contnt  contnt  contnt  contnt contnt     contnt';
        grid-gap: 10px;
        /*background-color: #000000;*/
        padding: 10px;
      }

      .inicio-grid-container > div {
        /*background-color: rgba(0, 0, 0, 0.5);*/
        background-color: var(--color-fondo-3);
        /*text-align: center;*/
        padding: 20px 10px;
        /*font-size: 30px;*/
      }

      .post-foto-usuario { grid-area: ufoto; }
      .post-username { grid-area: usuario; }
      .post-foto { 
          grid-area: foto; 
          text-align: center;
      }
      .post-like { 
          grid-area: like; 
          text-align: center;
      }
      .post-comentario { 
          grid-area: comentario; 
          text-align: center;
      }
      .post-compartir { 
          grid-area: compartir; 
          text-align: center;
      }
      .post-texto { grid-area: texto; }
      .post-fecha { 
          grid-area: fecha; 
          font-size: 10px;
      }

      .post-grid-container {
        display: grid;
        grid-template-areas:
          'ufoto ufoto      usuario   usuario usuario usuario'
          'foto  foto       foto      foto    foto    foto '
          'like  comentario compartir espacio espacio espacio'
          'texto texto      texto     texto   texto   texto'
          'fecha fecha      fecha     fecha   fecha   fecha';
        grid-gap: 2px;
        background-color: var(--color-fondo-control-1);
        padding: 10px 15vw;
        margin: 20px 0;
      }

      .post-grid-container > div {
        background-color: var(--color-fondo-3);
        /*text-align: center;*/
        padding: 20px 10px;
      }

    </style>
    <link href="../css/Estilos.css" rel="stylesheet" />
    <script type="text/javascript">
        function clicPosts(e) {
            //alert(e);
            document.getElementById("HiddenField1").value = e;
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnPosts").click()
        }
        function clicUsuario(e) {
            //alert(e);
            document.getElementById("HiddenField1").value = e;
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnLoguearse").click()
        }
        function clicSeguidos(e) {
            //alert(e);
            //document.getElementById("HiddenField1").value = e;
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnSeguidos").click();
        }
        function clicSeguidores(e) {
            //alert(e);
            /*document.getElementById("HiddenField1").value = e;*/
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnSeguidores").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" value="" />
        <div id="divPrincipal" runat="server" class="inicio-grid-container">
          <div id="divContenido" runat="server" class="contenido">Contenido
            <asp:Button id='btnLoguearse' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickUsuario' Text='lola' />
            <asp:Button id='btnPosts' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickPosts' Text='lola' />
            <asp:Button id='btnSeguidos' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickSeguidos' Text='lola' />
            <asp:Button id='btnSeguidores' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickSeguidores' Text='lola' />
      	    <%--<div class="post-grid-container">
              <div class="post-foto-usuario">Foto Usuario</div>
              <div class="post-username">Username</div>
              <div class="post-foto">Foto</div>
              <div class="post-like">Like</div>
              <div class="post-comentario">Comentario</div>
              <div class="post-compartir">Compartir</div>
              <div class="post-texto">Texto del Publicación</div>
              <div class="post-fecha">Fecha Publicación</div>
            </div>--%>            
          </div>
        </div>

    </form>
</body>
</html>
