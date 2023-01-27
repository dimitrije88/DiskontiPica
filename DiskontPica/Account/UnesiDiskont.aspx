<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnesiDiskont.aspx.cs" Inherits="DiskontPica.Account.UnesiDiskont" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Unesi diskont u bazu podataka</h1>

    <asp:Label ID="Label1" runat="server" Text="Ime diskonta:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Mesto diskonta:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Unesi diskont" CssClass="btn btn-warning" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
