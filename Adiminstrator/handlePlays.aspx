<%@ Page Language="C#" AutoEventWireup="true" CodeFile="handlePlays.aspx.cs" Inherits="handlePlays" %>

<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        <uc1:WebUserControl ID="WebUserControl1" runat="server" />
        <br />
    
        <asp:Label ID="lblplays"  runat="server" Text="מחיקת הצגה הוספת הצגה" Font-Bold="True" 
            Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
    
        <br />
        <asp:Label ID="lblpalys" runat="server" ForeColor="#990000"></asp:Label>
    
    
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            DataKeyNames="MovieCode,PlayCode" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="הוספת הצגה" 
                    SelectText="הוספת הצגה" ShowHeader="True" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" EditText="מחיקת הצגה" 
                    HeaderText="מחיקת הצגה" ShowEditButton="True" ShowHeader="True" />
                <asp:BoundField DataField="PlayCode" HeaderText="קוד הצגה" 
                    SortExpression="PlayCode" />
                <asp:BoundField DataField="MovieCode" HeaderText="קוד סרט" 
                    SortExpression="MovieCode" />
                <asp:BoundField DataField="PlayDate" HeaderText="תאריך הצגה" 
                    SortExpression="PlayDate" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <p  align="center">
   
        <asp:Label ID="lblerror" runat="server" ForeColor="Maroon"></asp:Label>
    </p>
    </form>
</body>
</html>
