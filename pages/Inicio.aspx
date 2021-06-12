<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="InstagramPF.pages.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/Estilos.css" rel="stylesheet" />
    <title>Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-login">
            <h1>
                SIGN IN
            </h1>

            <div class="floating-label">
                <input placeholder="User" type="text" name="user" id="txtUser" autocomplete="off" runat="server" />
                <label for="txtUser">User:</label>
            </div>

            <div style="text-align:center;">
                <asp:Button id="btnLoguearse" style="color: #ffff; background-color: #000000; border: none;" runat="server"  OnClick="clickIR" Text="LOGIN" />                
            </div>

            <div class="linea-horizontal"></div>

            <h3>
                SIGN UP
            </h3>

            <div class="floating-label">
                <input placeholder="USERNAME:" type="text" name="USERNAME" id="txtUSERNAME" autocomplete="off" />
                <label for="txtUSERNAME">USERNAME:</label>
            </div>

            <div class="floating-label">
                <input placeholder="FULLNAME:" type="text" name="FULLNAME" id="txtFULLNAME" autocomplete="off" />
                <label for="txtFULLNAME">FULLNAME:</label>
            </div>

            <div class="floating-label">
                <input placeholder="BIRTHDATE:" type="date" name="BIRTHDATE" id="txtBIRTHDATE" autocomplete="off" />
                <label for="txtBIRTHDATE">BIRTHDATE:</label>
            </div>

            <div style="text-align:center;">
                <button style="color: #ffff; background-color: #000000; border: none; ">REGISTER</button>
            </div>
        </div>
    </form>
</body>
</html>
