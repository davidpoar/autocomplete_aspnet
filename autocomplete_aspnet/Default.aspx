<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestAutocompleteWeb._Default" %>


<%@ Register Src="~/Controls/UCAutotomplete.ascx" TagPrefix="uc1" TagName="UCAutotomplete" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/autocomplete.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        
    <h1>CONTROLES</h1>
    <uc1:UCAutotomplete runat="server" ID="UCAutotomplete" />
    <uc1:UCAutotomplete runat="server" ID="UCAutotomplete2" />
    <uc1:UCAutotomplete runat="server" ID="UCAutotomplete3" />
    <uc1:UCAutotomplete runat="server" ID="UCAutotomplete4" />
    <uc1:UCAutotomplete runat="server" ID="UCAutotomplete5" />

    <h1>CONTROLES DENTRO DE GRIDVIEW</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="NOMBRE" DataField="Nombre" />
            <asp:BoundField HeaderText="APELLIDOS" DataField="Apellidos" />
            <asp:TemplateField HeaderText="Pais">
                <ItemTemplate>
                    <uc1:UCAutotomplete ID="UCAutotomplete6" runat="server" Texto='<%# Bind("Valor") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label Text="SELECCIONADOS:" runat="server" ID="lblSeleccionados" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ver seleccionados" />
    </form>

</body>
</html>
