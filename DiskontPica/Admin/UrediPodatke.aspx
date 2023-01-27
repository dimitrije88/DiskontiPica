<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UrediPodatke.aspx.cs" Inherits="DiskontPica.Admin.UrediPodatke" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Uredi podatke o diskontima i picu</h1>

    <div>
        <h3>Uredi diskonte</h3>

        <asp:GridView ID="GridView1" runat="server" 
            CssClass="table"
            AutoGenerateSelectButton="true"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>

        <asp:Label ID="Label1" runat="server" Text="ID diskonta:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ime diskonta:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Mesto diskonta:"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Uredi diskont" CssClass="btn btn-primary" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Obrisi diskont" CssClass="btn btn-danger" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>

    </div>

    <div>
        <h3>Uredi pica</h3>

        <asp:GridView ID="GridView2" runat="server" 
            CssClass="table"
            AutoGenerateSelectButton="true"
            OnSelectedIndexChanged="GridView2_SelectedIndexChanged"></asp:GridView>

        <asp:Label ID="Label5" runat="server" Text="ID pica:"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Ime pica:"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Vrsta pica:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="25%" Enabled="false" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Uredi pice" CssClass="btn btn-primary" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Obrisi pice" CssClass="btn btn-danger" OnClick="Button4_Click"/>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
    </div>

</asp:Content>
