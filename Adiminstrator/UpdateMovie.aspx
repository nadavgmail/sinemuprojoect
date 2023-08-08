<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMovie.aspx.cs" Inherits="Adiminstrator_UpdateMovie" %>

<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center"><uc1:WebUserControl ID="WebUserControl1" runat="server" /></div>
    <p align="center">
        <br />
        &nbsp;
        <asp:Label ID="lblupdateMovie"  runat="server" Text="עידכון סרט\הוספה" Font-Bold="True" 
            Font-Size="XX-Large" ForeColor="#CC0066"></asp:Label>
    </p>
    <p align="center">
        <asp:DropDownList ID="drpmovies" runat="server" AutoPostBack="True" 
            onselectedindexchanged="drpmovies_SelectedIndexChanged">
        </asp:DropDownList>
        קודי סרטים</p>
    <div>
    
    <table align="center">
        <tr><td>&nbsp;</td>&nbsp;<td>
                &nbsp;</td></tr>
        <tr>
            <td>
                שם סרט</td>
            <td>
                <asp:TextBox ID="txtMovieName" runat="server" Width="128px" 
                    ValidationGroup="movie"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtMovieName" Display="Dynamic" 
                    ErrorMessage="must enter movieName" ValidationGroup="Mymovie">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                במאי</td>
            <td>
                <asp:TextBox ID="txtdirector" runat="server" ValidationGroup="movie"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtdirector" ErrorMessage="you have to enter director" 
                    ValidationGroup="Mymovie">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                    ValidationGroup="Mymovie" />
            </td>
        </tr>
        <tr>
            <td>
                תאור</td>
            <td>
                <asp:TextBox ID="txtdescription" runat="server" ValidationGroup="movie" 
                    Height="86px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtdescription" 
                    ErrorMessage="you have to enter description" ValidationGroup="Mymovie">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    </div>
    <div>
    
    </div>
    <p align="center">
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
            Text="הוספת סרט" /><br />
        <asp:Button ID="btnupdate" runat="server" onclick="btnupdate_Click" 
            Text="עידכון סרט" ValidationGroup="Mymovie" />
        </p>
        <div align="center"><asp:Label ID="lblerror" runat="server" ForeColor="#CC0000"></asp:Label></div>
    <p align="center">
        עידכון תמונה</p>
    <p align="center">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" 
                onclick="btnUpload_Click" Text="העלאת תמונה" />
            </p>
    </form>
</body>
</html>
