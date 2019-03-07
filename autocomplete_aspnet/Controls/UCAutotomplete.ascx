<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAutotomplete.ascx.cs" Inherits="TestAutocompleteWeb.UCAutotomplete" %>

<div class="autocomplete">
    <asp:HiddenField runat="server" ID="hfValor" Value=""/>
    <asp:HiddenField runat="server" ID="hfTexto" Value=""/>
    <asp:TextBox runat="server" ID="tbTexto"></asp:TextBox>

    <div class="result" >
    </div>
</div>