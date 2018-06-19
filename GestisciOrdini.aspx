<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestisciOrdini.aspx.cs" Inherits="GestisciProdotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-2 col-md-8">
       Visualizzare l'ordine di &nbsp <asp:DropDownList ID="drpAcquirenti" OnSelectedIndexChanged="drpAcquirenti_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>

       <asp:GridView ID="grdCarrello" Width="100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
          <asp:ImageField DataImageUrlField="img" HeaderText="Immagine" ItemStyle-Width="40px" ControlStyle-Width="100" ControlStyle-Height="100">
            <ControlStyle Height="100px" Width="100px"></ControlStyle>
            <ItemStyle Width="40px"></ItemStyle>
                </asp:ImageField>
            <asp:BoundField DataField="Articolo" HeaderText="Articolo" />
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Taglia" HeaderText="Taglia" />
            <asp:BoundField DataField="Quantità" HeaderText="Quantità" />
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
       <br /><br />
       Totale ordine: <asp:Label ID="lblTot" runat="server" ></asp:Label>
       <br /><br />
       Come si desidera procedere con l'ordine?
       <br /><br />
        &nbsp&nbsp
       <asp:LinkButton ID="btnConferma" CssClass="btn btn-success" OnClick="btn_Conferma" runat="server"><i class="fa fa-check"></i>&nbsp Conferma</asp:LinkButton>&nbsp&nbsp
       <asp:LinkButton ID="btnElimina" CssClass="btn btn-danger" OnClick="btn_Elimina" runat="server"><i class="fa fa-trash-o"></i>&nbsp Elimina</asp:LinkButton>
   </div>
</asp:Content>