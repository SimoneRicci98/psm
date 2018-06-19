<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AggiungiArticoli.aspx.cs" Inherits="GestisciProdotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" style="font-size:18px;text-align:center">
        Aggiungi qui i nuovi prodotti
        <br />
       <b>N.B. Separare taglie e quantità con una virgola!</b> 
    </div>
        
    <div class="col-md-offset-2 col-md-8">
        <asp:Table ID="GEST_ARTICOLO" runat ="server" Width="60%" HorizontalAlign="Center" CssClass ="table-hover table-responsive table">
            <asp:TableRow>
                <asp:TableCell Width="30%">Codice</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtCodice" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="30%">Descrizione</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtDescr" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Categoria</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtCat" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Marca</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Colore</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtColore" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Prezzo cartellino</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtPrezzoCartellino" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Prezzo vendita</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtPrezzoVenita" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                             <asp:TableRow>
                <asp:TableCell Width="30%">Taglie</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtTaglie" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Quantità</asp:TableCell>
                <asp:TableCell Width="70%"><asp:TextBox ID="txtQta" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Taglia spedizione</asp:TableCell>
                <asp:TableCell Width="70%">
                    <asp:DropDownList ID="drpTagliaSpedizione" CssClass="form-control" runat="server"></asp:DropDownList>
                    &nbsp <asp:TextBox ID="txtNuovaTagliaSped" Text="Nuova taglia spedizione" runat="server"></asp:TextBox><-- inserisci qui nuova taglia
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Prodotto spedizione</asp:TableCell>
                <asp:TableCell Width="70%"><asp:DropDownList ID="drpProdSPedizione" CssClass="form-control" runat="server"></asp:DropDownList>
                    &nbsp <asp:TextBox ID="txtNuovoPrdSped" Text="Nuovo prodotto spedizione" runat="server"></asp:TextBox><-- inserisci qui nuova taglia
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell Width="30%">Immagine</asp:TableCell>
                <asp:TableCell Width="70%">
                    <asp:FileUpload ID="flpImmagine" runat="server" /></asp:TableCell>
            </asp:TableRow>
       
        </asp:Table>
            <asp:LinkButton ID="btnSalva" CssClass="btn btn-success" OnClick="btn_Salva" runat="server">Salva</asp:LinkButton>&nbsp&nbsp<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>