<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="PluralSightBookWebsite.Friends" %>
<%@ Register Namespace="PluralSightBookWebsite.Code" TagPrefix="psb" Assembly="PluralSightBookWebsite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Friends</h1>
    <a href="AddFriend.aspx">Add a Friend</a>

    <asp:GridView runat="server" DataSourceID="DataSource1" AutoGenerateColumns="false" DataKeyNames="Id">
        <EmptyDataTemplate>
            <p>You have no friends</p>
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField HeaderText="Friend's Email" DataField="EmailAddress" />
            <asp:CommandField HeaderText="Remove" ButtonType="Link" ShowDeleteButton="true" /> 
        </Columns>
    </asp:GridView>

    <asp:EntityDataSource runat="server" ID="DataSource1" EntitySetName="Friends" ConnectionString="name=aspnetdbEntities" DefaultContainerName="aspnetdbEntities" Where="it.UserId=@UserId" EnableDelete="true">
        <WhereParameters>
            <psb:UserParameter Name="UserId"></psb:UserParameter>
        </WhereParameters>

    </asp:EntityDataSource>

</asp:Content>
