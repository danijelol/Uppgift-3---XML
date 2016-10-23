<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Uppgift_3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:DropDownList ID="valCap" runat="server">
            <asp:ListItem Text="Visa alla" Value="1"></asp:ListItem>
            <asp:ListItem Text="Small Cap" Value="2"></asp:ListItem>
            <asp:ListItem Text="Medium Cap" Value="3"></asp:ListItem>
            <asp:ListItem Text="Large Cap" Value="4"></asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="valTyp" runat="server">
            <asp:ListItem Text="Visa alla" Value="1"></asp:ListItem>
            <asp:ListItem Text="A" Value="A"></asp:ListItem>
            <asp:ListItem Text="B" Value="B"></asp:ListItem>
        </asp:DropDownList>
    <asp:Button ID="btnFiltrera" runat="server" OnClick="btnFiltrera_Click" Text="Filtrera" /><br /><br />


                <div id="aktieDiv" runat="server">Här nedan kommer aktierna visas:</div>
<%--    <asp:TextBox ID="txtXml" runat="server" TextMode="MultiLine" Height="500px" Width="600px" />--%>

</asp:Content>
