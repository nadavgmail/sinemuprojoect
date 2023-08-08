<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hendlemovies.aspx.cs" Inherits="Adiminstrator_hendlemovies" %>

<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <p align="center">
        <uc1:WebUserControl ID="WebUserControl1" runat="server" />
        <br />
       <div align="center"> <asp:Label ID="Label3"  runat="server" Text="הוספת סרט מחיקה עידכון" Font-Bold="True" 
            Font-Size="XX-Large" ForeColor="#339933"></asp:Label></div>
    </p>
    <br />
        <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div align="center">
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </div>
&nbsp;<div align="center">
                <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
    
        </div>
    
                <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="CodeName" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                            onrowdeleting="GridView1_RowDeleting" BackColor="#DEBA84" 
                        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CellSpacing="2" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" 
                        onrowdatabound="GridView1_RowDataBound">
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" EditText="הצגות מקושרות" 
                                HeaderText="הצגות מקושרות" ShowEditButton="True" ShowHeader="True" />
                            <asp:CommandField ButtonType="Button" HeaderText="עריכת סרט" 
                    ShowSelectButton="True" SelectText="עידכון" />
                            <asp:CommandField ButtonType="Button" HeaderText="מחיקה" 
                    ShowDeleteButton="True" DeleteText="מחיקה" />
                            <asp:BoundField DataField="CodeName" HeaderText="קוד סרט" 
                    SortExpression="CodeName" />
                            <asp:BoundField DataField="MovieName" HeaderText="שם סרט" 
                    SortExpression="MovieName" />
                            <asp:BoundField DataField="Director" HeaderText="במאי" 
                    SortExpression="Director" />
                            <asp:TemplateField HeaderText="תיאור סרט">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt1" runat="server" Height="68px" ReadOnly="True" 
                                        TextMode="MultiLine" Width="211px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                </div>
    
    <br />
    <div align="right">
        <asp:Button ID="btnAddMovie" runat="server" onclick="btnAddMovie_Click" 
        Text="הוסף סרט" /><div align="center">
        &nbsp;&nbsp;&nbsp; <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;בחירת 
            תמונה&nbsp;&nbsp;
               &nbsp;&nbsp;</div>
        <div align="center">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            &nbsp;&nbsp;<asp:Button ID="btnUpload" runat="server" 
                onclick="btnUpload_Click" Text="העלאת תמונה" />
            <div align="center">
        &nbsp;&nbsp;&nbsp; 
                <div align="center">
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                </div>
    
                <asp:Label ID="lblerror" runat="server"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <div align="center">
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </div>
        </div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
        </div>
    
        <br />
        <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
    
        <p align="center">
            &nbsp;</p>
        <br />
        <div align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
    
    <p align="center">
    
    </p>
        <div align="right"></div>
    </form>
</body>
</html>
