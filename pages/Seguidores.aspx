<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seguidores.aspx.cs" Inherits="InstagramPF.pages.Seguidores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seguidores</title>
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

      .seguidores-foto-usuario { grid-area: ufoto; }
      .seguidores-username { grid-area: usuario; }

      .seguidores-grid-container {
        display: grid;
        grid-template-areas:
          'ufoto ufoto usuario usuario usuario usuario';
        grid-gap: 2px;
        background-color: var(--color-fondo-control-1);
        padding: 10px 15vw;
        margin: 20px 0;
      }

      .seguidores-grid-container > div {
        background-color: var(--color-fondo-3);
        /*text-align: center;*/
        padding: 20px 10px;
      }

    </style>
    <link href="../css/Estilos.css" rel="stylesheet" />
    <script type="text/javascript">
        function clicInicio(e) {
            //alert(e);
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
             document.getElementById("btnLoguearse1").click();
        }
        function clicUsuario(e) {
           
            document.getElementById("HiddenField1").value = e;
            document.getElementById("Button1").click();
        }
        function clicSeguidos(e) {
            //alert(e);
            //document.getElementById("HiddenField1").value = e;
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnSeguidos1").click();
        }
        function clicSeguidores(e) {
            //alert(e);
            /*document.getElementById("HiddenField1").value = e;*/
            //document.getElementById("btnLoguearse").Text = e;
            //alert(document.getElementById("HiddenField1").value);
            document.getElementById("btnSeguidores1").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" value="" />
        <div id="divPrincipal" runat="server" class="inicio-grid-container">
            <div id="divContenido" runat="server" class="contenido">Contenido
                <asp:Button id='btnLoguearse1' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickInicio' Text='lola' />
                <asp:Button id='Button1' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickUsuario' Text='lola' />
                <asp:Button id='btnSeguidos1' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickSeguidos' Text='lola' />
                <asp:Button id='btnSeguidores1' style='color: #ffff; background-color: #000000; border: none; display:none' runat ='server'  OnClick='clickSeguidores' Text='lola' />
            </div>
        </div>
    </form>
</body>
</html>
