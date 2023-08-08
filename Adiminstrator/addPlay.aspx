<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addPlay.aspx.cs" Inherits="Adiminstrator_addPlay" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
        <asp:Label ID="lbladdmovie" runat="server" Font-Size="XX-Large" 
            ForeColor="#0066CC" Text="הוספת הצגה"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        
        <asp:DropDownList ID="drpmovies" runat="server">
        </asp:DropDownList>
    <asp:Label ID="lblmoviecode" runat="server" Text="קוד סרט" ForeColor="#FF5050"></asp:Label>
    </div>
    <table align="center">
        <tr>
            <td align="right">
                    &nbsp;</td>
            <td>
                <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdate">
                </cc1:CalendarExtender>
            
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="incorrect date" Type="Date" 
                    ValidationGroup="date">*</asp:RangeValidator>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="you must enter date" ControlToValidate="txtdate" 
                    ValidationGroup="date">*</asp:RequiredFieldValidator>
            </td>
            
            
        </tr>
        <tr>
            <td >
                    
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                    ValidationGroup="date" />
                    
            </td>
        </tr>
    </table>
   <p align="center"> <asp:Label ID="lbldate" runat="server" Text="יש להליד חודש יום שנה"></asp:Label></p>
    <p align="center">
        <asp:DropDownList ID="ddlminit" runat="server">
        </asp:DropDownList>
        שעה<asp:DropDownList ID="ddlhour" runat="server">
        </asp:DropDownList>
        דקה</p>
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="הוסף הצגה" 
            onclick="Button1_Click" ValidationGroup="date" /></div>
   <div align="center"> <asp:Label ID="lblerror" runat="server" ForeColor="Maroon"></asp:Label></div>
    </form>
</body>
</html>
