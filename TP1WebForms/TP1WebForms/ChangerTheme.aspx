<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangerTheme.aspx.cs"  MasterPageFile="~/Main.Master" Inherits="TP1WebForms.ChangerTheme" %>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="mainContent">
    <div class="jumbotron">
        
        
        Changer de thème:<br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ChangerTheme.aspx?Theme=Excentrique">Coloré</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ChangerTheme.aspx?Theme=Professionnel">Professionnel</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="ChangerTheme.aspx?Theme=Aucun">Aucun</asp:HyperLink>

<%--  --%>
    </div>
</asp:Content>
<%--  --%>