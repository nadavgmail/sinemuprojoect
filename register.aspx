<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="LogIn" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .style3
        {
            height: 22px;
        }
        .style4
        {
            height: 61px;
        }
    </style>
    
<script language="javascript" type="text/javascript">

// ]]>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder6" Runat="Server">
    <p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </p>
    <div align="center"> 
        
        </div>
        <br />
            
           <asp:Button ID="BtnSave" runat="server" Text="שמור " 
            onclick="Button1_Click" />
        <asp:Label ID="lblerrors" runat="server" ForeColor="Maroon"></asp:Label>
        <a href="HomePage.aspx.cs">בחזרה לדף הבית לחץ כאן</a><br />
        <br />
        <table align="left" style="height: 358px; width: 412px">
            <tr>
                <td>
                    שם פרטי</td>
                <td>
                    <asp:TextBox ID="txtfirstname" runat="server" EnableTheming="True" 
                        EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtfirstname" ErrorMessage="you have to enter your name">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    שם משפחה</td>
                <td>
                    <asp:TextBox ID="txtlastname" runat="server" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtlastname" ErrorMessage="you have to enter your lastname">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    שם משתמש</td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server" EnableViewState="False"></asp:TextBox>
                            </td>
                
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtusername" Display="Dynamic" 
                        ErrorMessage="you heve to enter user name">*</asp:RequiredFieldValidator>
                            </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" 
                        ControlToValidate="txtusername" ErrorMessage="user is already exist" 
                        onservervalidate="CustomValidator2_ServerValidate">*</asp:CustomValidator>
                            </td>
            </tr>
            <tr>
                <td class="style3">
                    סיסמא</td>
                <td class="style3">
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" 
                        EnableViewState="False"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtpassword" ErrorMessage="you have to enter password">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    אישור סיסמא</td>
                <td class="style3">
                    <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                <td class="style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtconfirmpassword" Display="Dynamic" 
                        ErrorMessage="you have to confirm the password">*</asp:RequiredFieldValidator>
                            </td>
                <td class="style3">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" 
                        ErrorMessage="the passwords are not equel">*</asp:CompareValidator>
                            </td>
            </tr>
            <tr>
                <td>
                    מספר כרטיס ללא מקפים</td>
                <td>
                    <asp:TextBox ID="txtcardnumber" runat="server"></asp:TextBox>
                            </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtcardnumber" Display="Dynamic" 
                        ErrorMessage="you have to enter cardnumber">*</asp:RequiredFieldValidator>
                            </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ErrorMessage="the number of digit has to be beetwen 10-20" 
                        onservervalidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                            </td>
            </tr>
            <tr>
                <td>
                    סוג כרטיס</td>
                <td>
                    <asp:TextBox ID="txtcardtype" runat="server"></asp:TextBox>
                            </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtcardtype" ErrorMessage="you have to enter card type">*</asp:RequiredFieldValidator>
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    תוקף: יש להקליד חודש יום שנה</td>
                <td class="style4">
                    <asp:TextBox ID="txtvalidatecard" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtvalidatecard_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtvalidatecard">
                    </cc1:CalendarExtender>
                    <br />
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtvalidatecard" Display="Dynamic" 
                        ErrorMessage="you heve to enter date">*</asp:RequiredFieldValidator>
                </td>
                <td class="style4">
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ErrorMessage="incorrect date" ControlToValidate="txtvalidatecard" 
                        Type="Date">*</asp:RangeValidator>
                    </td>
            </tr>
            </table>
            
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" /> 
        <asp:Label ID="lblconfirm" runat="server"></asp:Label>
        
</asp:Content>

