<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnesiPice.aspx.cs" Inherits="DiskontPica.Account.UnesiPice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Unesi pice u bazu podataka</h1>

    <asp:Label ID="Label1" runat="server" Text="Ime pica:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Vrsta pica:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Width="25%" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Unesi pice" CssClass="btn btn-primary" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
