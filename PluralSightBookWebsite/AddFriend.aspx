<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFriend.aspx.cs" Inherits="PluralSightBook.AddFriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="EmailLabel" Text="Friend's email address: " AssociatedControlID="EmailTextBox"></asp:Label>
    <asp:TextBox runat="server" ID="EmailTextBox"></asp:TextBox>
    <asp:Button runat="server" ID="SaveButton" Text="Add" OnClick="SaveButton_Click" />

</asp:Content>
