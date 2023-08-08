<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder6">
    <p>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <p align="right">
        <a href="login.aspx">להכנסת שם משתמש וסיסמא לחץ כאן</a></p>
    <p align="right">
        <asp:Label ID="lblerror" runat="server"></asp:Label>
        <asp:Label ID="lblresult" runat="server"></asp:Label>
        <asp:Button ID="btnsearchmovie" runat="server" Text="serchMovie" 
            onclick="btnsearchmovie_Click" />
        <asp:TextBox ID="txtmobiename" runat="server"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="txtmobiename_AutoCompleteExtender" runat="server" 
            DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
            ServicePath="" TargetControlID="txtmobiename" UseContextKey="True" 
            CompletionInterval="1" MinimumPrefixLength="1">
        </cc1:AutoCompleteExtender>
        <asp:Label ID="Label2" runat="server" Text="חיפוש סרט"></asp:Label>
    </p>
    <p align="center">
        <asp:Label ID="lblmoviechosen" runat="server" Text="שלושה סרטים נבחרים" 
            Font-Size="X-Large" ForeColor="#3366FF"></asp:Label>
    </p>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="GridView3_SelectedIndexChanged" 
            DataKeyNames="CodeName" onrowdeleting="GridView2_RowDeleting" 
        Width="446px" CellPadding="4" ForeColor="#333333" GridLines="None" 
        onrowdatabound="GridView3_RowDataBound" >
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="בחר בי" 
                    ShowSelectButton="True" HeaderText="בחירת סרט" />
                <asp:BoundField DataField="MovieName" HeaderText="שם סרט" />
                <asp:BoundField DataField="Director" HeaderText="במאי" />
                <asp:TemplateField HeaderText="תיאור ">
                    <ItemTemplate>
                        <!--<asp:Label runat="server" ID="lbl1" />-->
                        <asp:TextBox runat="server" ID="txt1" TextMode="MultiLine" Height="63px" 
                            ReadOnly="True" Width="197px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="Codename" 
                    DataImageUrlFormatString="~/moviePicture/{0}.jpg" HeaderText="תמונה">
                    <ControlStyle Height="40px" Width="40px" />
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    <p>
    </p>
    <p align="center">
        <asp:Label ID="lblmovieresult" runat="server" Text="תוצאות חיפוש" 
            Font-Size="X-Large" ForeColor="#33CC33"></asp:Label>
    </p>
    <p align="right">
        &nbsp;</p>
    <asp:Panel ID="Panel2" runat="server">
    </asp:Panel>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" 
            DataKeyNames="CodeName" onrowdeleting="GridView2_RowDeleting" 
        Width="446px" CellPadding="4" ForeColor="#333333" GridLines="None" 
        onrowdatabound="GridView2_RowDataBound" >
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="בחר בי" 
                    ShowSelectButton="True" HeaderText="בחירת סרט" />
                <asp:BoundField DataField="MovieName" HeaderText="שם סרט" />
                <asp:BoundField DataField="Director" HeaderText="במאי" />
                <asp:TemplateField HeaderText="תיאור">
                    <ItemTemplate>
                        <asp:TextBox ID="txt2" runat="server" Height="63px" ReadOnly="True" 
                            TextMode="MultiLine" Width="197px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="Codename" 
                    DataImageUrlFormatString="~/moviePicture/{0}.jpg" HeaderText="תמונה">
                    <ControlStyle Height="40px" Width="40px" />
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
</asp:Content>



