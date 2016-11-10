<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Inscription.aspx.cs" Inherits="TP1WebForms.Inscription" %>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="mainContent">
    <div class="jumbotron">
        <h3>Inscription au site</h3>
        <br />

        <!--Champs à remplir pour s'inscrire-->
        Nom : <asp:TextBox ID="TextBoxNom" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ControlToValidate="TextBoxNom" runat="server" 
                                                                            ID="RFVNom" EnableClientScript="true" ErrorMessage="Nom obligatoire" />
            Prénom : <asp:TextBox ID="TextBoxPrénom" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="TextBoxPrénom" runat="server" 
                                                                            ID="RFVPrénom" EnableClientScript="true" ErrorMessage="Prénom obligatoire" /><br />
        Date de naissance : 
        <asp:DropDownList ID="DropDownAnnéeNaissance" runat="server" onchange = "PopulerJours()"></asp:DropDownList>
        <asp:DropDownList ID="DropDownMoisNaissance" runat="server" onchange = "PopulerJours()"></asp:DropDownList>
        <asp:DropDownList ID="DropDownJourNaissance" runat="server"></asp:DropDownList><br />
        <br />

        <!--On veut avoir le numéro d'assurance maladie et le numéro de passeport-->
        Numéro carte assurance maladie : <asp:TextBox ID="TextBoxNumAM" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="TextBoxNumAM" runat="server" 
                                                                            ID="RFVNumAM" EnableClientScript="true" ErrorMessage="Numéro d'assurance maladie obligatoire" /><br />
        Numéro de passeport Canada : <asp:TextBox ID="TextBoxNumPC" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="TextBoxNumPC" runat="server" 
                                                                            ID="RFVNumPC" EnableClientScript="true" ErrorMessage="Numéro de passeport Canada obligatoire" /><br />
        <br />

        <!--En appyant sur le bouton, on ajoute un textBox pour un nouveau numéro de téléphone ou une autre addresse-->
        <asp:Panel runat="server" ID="Téléphones">
            Numéros de téléphone 1 : <asp:TextBox ID="TextBoxTéléphone1" runat="server"></asp:TextBox><asp:Button ID="AjouterNumTel" runat="server" Text="Ajouter un numéro"/><br />
        </asp:Panel>
        <asp:Panel runat="server" ID="Addresses">
            Adresses 1 : <asp:TextBox ID="TextBoxAddresse1" runat="server"></asp:TextBox><asp:Button ID="AjouterAdd" runat="server" Text="Ajouter une addresse" OnClick="AjouterAdd_Click"/><br />
        </asp:Panel>
        <br />

        <!--la couleur de ceinture que la personne possède-->
        Grade : <asp:DropDownList ID="DDGrade" runat="server">
            <asp:ListItem>Blanche</asp:ListItem>
            <asp:ListItem>Jaune</asp:ListItem>
            <asp:ListItem>Orange</asp:ListItem>
            <asp:ListItem>Verte</asp:ListItem>
            <asp:ListItem>Bleu</asp:ListItem>
            <asp:ListItem>Marron</asp:ListItem>
            <asp:ListItem>Noire</asp:ListItem>
            <asp:ListItem>Rouge</asp:ListItem>
        </asp:DropDownList> (couleur de ceinture)<br />

        <!--Date à laquelle la personne à eue sa ceinture-->
        Date de passage : 
        <asp:DropDownList ID="DropDownAnnéePassage" runat="server" onchange = "PopulerJours()"></asp:DropDownList>
        <asp:DropDownList ID="DropDownMoisPassage" runat="server" onchange = "PopulerJours()"></asp:DropDownList>
        <asp:DropDownList ID="DropDownJourPassage" runat="server"></asp:DropDownList><br />
        <br />
        <!--Catégorie dans laquel la personne se situe-->
        Catégorie :
        <asp:DropDownList ID="DropDownListCatégorie" runat="server">
            <asp:ListItem>U10</asp:ListItem>
            <asp:ListItem>U12</asp:ListItem>
            <asp:ListItem>U14</asp:ListItem>
            <asp:ListItem>U16</asp:ListItem>
            <asp:ListItem>U18</asp:ListItem>
            <asp:ListItem>U21</asp:ListItem>
            <asp:ListItem>Sénior</asp:ListItem>
            <asp:ListItem>Vétéran</asp:ListItem>
        </asp:DropDownList><br />

        <!--le cours auquel la personne souhaite s'inscrire, seulement quelques cours bidons, on pourrait en mettre beaucoup plus-->
        Cours : 
        <asp:DropDownList ID="DropDownListCours" runat="server">
            <asp:ListItem>Lundi-Merc-Jeudi 19h30-21h (u16 et plus)</asp:ListItem>
            <asp:ListItem>Lundi-jeudi 18h-19h (U14-U12)</asp:ListItem>
            <asp:ListItem>Mercredi 18h (U12-U10)</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <asp:Button ID="Incription" runat="server" Text="Confirmer l'inscription" OnClick="Incription_Click" />
    </div>
</asp:Content>

