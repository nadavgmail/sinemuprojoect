<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder6" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder7">
    <p align="center">
        <br />
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <asp:Label ID="lblusername" runat="server" Text="שם משתמש"></asp:Label>
    </p>
    <p align="center">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblpassword" runat="server" Text="סיסמא"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p align="center">
        <asp:Button ID="btnLogin" runat="server" Text="התחבר" 
            onclick="btnLogin_Click" />
    </p>
    <p align="center">
        <asp:Label ID="lblconfirm" runat="server" Font-Underline="True" 
            ForeColor="#CC0066"></asp:Label>
        <asp:Label ID="lblerror" runat="server" Font-Underline="True" 
            ForeColor="#CC0066"></asp:Label>
    </p>
    <p align="center">
        <font size="30" color="GREEN"><a href="register.aspx">להרשמה לחץ פה</a></font></p>
    <p>
    </p>
    
</asp:Content>


