<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestisciCampagna.aspx.cs" Inherits="GestisciCampagna" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-2">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate> 
            Selezione articolo da gestire <asp:DropDownList ID="drpProd" OnSelectedIndexChanged="drpProd_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
            Taglia <asp:DropDownList ID="drpTaglie" runat="server" OnSelectedIndexChanged="drpTaglie_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<br /><br />
<asp:Table ID="tableArt" runat="server" CssClass="table-responsive table-hover table" Width="70%" >
       <asp:TableRow>
           <asp:TableCell >
               Codice
           </asp:TableCell>
           <asp:TableCell>
               <asp:Label ID="lblCod" runat="server"></asp:Label>
           </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell>
               Descrizione
           </asp:TableCell>
           <asp:TableCell>
               <asp:Label ID="lblDescr" runat="server"></asp:Label>
           </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell>
               Marca
           </asp:TableCell>
           <asp:TableCell>
               <asp:Label ID="lblMarca" runat="server"></asp:Label>
           </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell>
               Prezzo
           </asp:TableCell>
           <asp:TableCell>
               <asp:Label ID="lblPrezzo" runat="server"></asp:Label>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell>
               Quantità
           </asp:TableCell>
           <asp:TableCell>
               <asp:Label ID="lblQta" runat="server"></asp:Label>     
           </asp:TableCell>
       </asp:TableRow>
   </asp:Table> 
        </ContentTemplate>
    </asp:UpdatePanel> 
                 
     
            Quantità vendute &nbsp <asp:TextBox ID="txtQta" runat="server"></asp:TextBox>&nbsp
               <asp:Button OnClick="btnConferma_Click" CssClass="btn btn-success" ID="btnConferma" Text="Conferma" runat="server" /> 
                 <br /><br />
                 <asp:LinkButton CssClass="btn btn-success" OnClick="btnTornaIndietr_Click" ID="btnTornaIndietr" Text="Torna indietro" runat="server" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                 <asp:LinkButton CssClass="btn btn-danger" OnClick="btnElimina_Click" ID="btnElimina" Text="Elimina campagna" runat="server" />
                 </div>
</asp:Content>