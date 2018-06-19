<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Articolicsv.aspx.cs" Inherits="GestisciProdotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        Seleziona il file csv con gli articoli <asp:FileUpload ID="CsvUpload"  runat="server"/>
        
        <br />
        <asp:Button ID="btnVisual" CssClass="btn btn-success" runat="server" OnClick="btn_ImportCSV_Click" Text="Visualizza" /> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnCarica" runat="server" Text="Carica" CssClass="btn btn-success" />
        <br /><asp:Label ID="lbl_ErrorMsg" ForeColor="Red" Visible="false" runat="server" Text="Il file non è un csv"></asp:Label>
        <br /><br />
        <asp:GridView ID="GridCsv" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" Height="50px" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Height="50px" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <br />

    </div>
</asp:Content>