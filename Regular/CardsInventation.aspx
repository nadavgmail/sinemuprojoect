<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CardsInventation.aspx.cs" Inherits="CardsInventation" Title="Untitled Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder6" Runat="Server">
    <p align="center">
        <asp:Label ID="Label2" runat="server" Text="הזמנת כרטיסים" Font-Bold="True" 
            Font-Size="XX-Large" ForeColor="Red"></asp:Label>
        <br />
    &nbsp;&nbsp;&nbsp;
    </p>
    
    <p align="center" style="margin-left: 40px">
        <asp:Label ID="lbleror" runat="server" ForeColor="#CC0000"></asp:Label>
        <div align="center">
        <div align="center">
        <div align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
            <asp:TextBox ID="txtcardnumber" runat="server" Height="25px" 
                style="margin-left: 27px" Width="30px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; הכנס מספר כרטיסים מבוקש</div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <div align="center">
            <asp:GridView ID="PlayGridView" runat="server" 
                AutoGenerateColumns="False" 
                onselectedindexchanged="PlayGridView_SelectedIndexChanged" Width="224px" 
                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" CellSpacing="2" DataKeyNames="PlayCode">
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="בחירה" 
                    ShowSelectButton="True" HeaderText="בחירת הצגה" />
                <asp:BoundField DataField="PlayDate" HeaderText="תאריך הצגה" />
                <asp:BoundField DataField="PlayCode" HeaderText="מספר הצגה" Visible="False" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        </asp:GridView>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Panel ID="Panel1" runat="server">
                <a href="../HomePage.aspx">בחזרה לדף הבית לחץ כאן</a>
               
                    
            </asp:Panel>
            </div>
    </div>
    </p>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder7" Runat="Server">
</asp:Content>

