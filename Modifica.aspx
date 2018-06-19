<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modifica.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
        <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

     <div class="col-md-12" style="margin-top:5%;margin-bottom:5%">
         <div class="col-md-offset-1 col-md-10">
             <asp:UpdatePanel runat="server">
                 <ContentTemplate>
<asp:Table ID="tableArt" runat="server" CssClass="table-responsive table-hover table" Width="100%" >
       <asp:TableRow>
           <asp:TableCell Width="30%">
               Codice
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblCod" runat="server"></asp:Label>
           </asp:TableCell>
           <asp:TableCell Width="40%">
               <asp:TextBox ID="txtCod" runat="server"></asp:TextBox><-- inserisci qui nuovo codice
           </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow> 
           <asp:TableCell Width="30%">
               Descrizione
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblDescr" runat="server"></asp:Label>
           </asp:TableCell>
           <asp:TableCell Width="40%">
                <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox><-- inserisci qui nuova descrizione
           </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell Width="30%">
               Categoria
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblCat" runat="server"></asp:Label>
           </asp:TableCell>
           <asp:TableCell Width="40%">
                <asp:TextBox ID="txtCat" runat="server"></asp:TextBox><-- inserisci qui nuova categoria
         </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell Width="30%">
               Marca
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblMarca" runat="server"></asp:Label>&nbsp
           </asp:TableCell>
                  <asp:TableCell Width="40%">
                      <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox><-- inserisci qui nuova marca
                 </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
           <asp:TableCell Width="30%">
               Colore
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblColore" runat="server"></asp:Label>
           </asp:TableCell>
                  <asp:TableCell Width="40%">
                      <asp:TextBox ID="txtColore" runat="server"></asp:TextBox><-- inserisci qui nuovo colore
                  </asp:TableCell>
       </asp:TableRow>
                     <asp:TableRow>
           <asp:TableCell Width="30%">
               Prezzo cartellino
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblPrezzoCart" runat="server"></asp:Label>
           </asp:TableCell>
                         <asp:TableCell Width="40%">
                             <asp:TextBox ID="txtPrezCart" runat="server"></asp:TextBox><-- inserisci qui nuovo prezzo cartellino
                         </asp:TableCell>
       </asp:TableRow>
                     <asp:TableRow>
           <asp:TableCell Width="30%">
               Prezzo vendita
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblPrezzoVend" runat="server"></asp:Label>
           </asp:TableCell>
                         <asp:TableCell Width="40%">
                             <asp:TextBox ID="txtPrezVen" runat="server"></asp:TextBox><-- inserisci qui nuovo prezzo vendita
                         </asp:TableCell>
       </asp:TableRow>
                     <asp:TableRow>
           <asp:TableCell Width="30%">
               Taglie
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:DropDownList ID="drpTaglie" AutoPostBack="true" OnSelectedIndexChanged="drpTaglie_SelectedIndexChanged" runat="server"></asp:DropDownList>
               &nbsp&nbsp<asp:Button ID="btnRimuoviTaglia" OnClick="btnRimuoviTaglia_Click" runat="server" Text="Rimuovi taglia" CssClass="btn btn-danger" />

           </asp:TableCell>
          <asp:TableCell Width="40%">
              <asp:TextBox ID="txtTaglie" runat="server"></asp:TextBox><-- inserisci qui nuove taglie
          </asp:TableCell>
       </asp:TableRow>
        <asp:TableRow>
           <asp:TableCell Width="30%">
               Quantità in magazzino
           </asp:TableCell>
           <asp:TableCell Width="30%">
               <asp:Label ID="lblQtaMag" runat="server"></asp:Label> 
           </asp:TableCell>
            <asp:TableCell Width="40%">
                <asp:TextBox ID="txtQtaMag" runat="server"></asp:TextBox><-- inserisci o modifica qui le quantità
            </asp:TableCell>
       </asp:TableRow>
              <asp:TableRow>
                <asp:TableCell Width="30%">Taglia spedizione</asp:TableCell>
                <asp:TableCell Width="30%">
                    <asp:DropDownList ID="drpTagliaSpedizione" CssClass="form-control" runat="server"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell Width="40%">
                <asp:TextBox ID="txtNuovaTagliaSped" Text="Nuova taglia spedizione" runat="server"></asp:TextBox><-- inserisci qui nuova taglia
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Prodotto spedizione</asp:TableCell>
                <asp:TableCell Width="30%"><asp:DropDownList ID="drpProdSPedizione" CssClass="form-control" runat="server"></asp:DropDownList>
                </asp:TableCell>
                            <asp:TableCell Width="40%">
                                <asp:TextBox ID="txtNuovoPrdSped" Text="Nuovo prodotto spedizione" runat="server"></asp:TextBox><-- inserisci qui nuova taglia
                            </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Immagine</asp:TableCell>
                <asp:TableCell Width="30%">
                    <asp:FileUpload ID="flpImmagine" runat="server" /></asp:TableCell>
                            <asp:TableCell Width="40%"></asp:TableCell>
            </asp:TableRow>
   </asp:Table>
                 </ContentTemplate>
             </asp:UpdatePanel>

         <br /><br />
         <asp:LinkButton ID="btnAcquista" CssClass="btn btn-success" OnClick="btn_Acquista" runat="server">Aggiorna</asp:LinkButton>
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnElimina" runat="server" Text="Elimina" CssClass="btn btn-danger" OnClick="btnElimina_Click" />
         </div>
    </div>
</asp:Content>