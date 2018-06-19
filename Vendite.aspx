<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vendite.aspx.cs" Inherits="Vendite" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-1 col-md-10 style="margin-top:2%"">
        Ecco tutte le vendite effettuate
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" RowStyle-Height="50px" OnRowCommand="GridView1_RowCommand" Width="100%" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Acquirente" DataField="Acquirente" />
            <asp:BoundField HeaderText="Totale" DataField="Totale" />
            <asp:BoundField HeaderText="Data" DataField="Data" />
            <asp:ButtonField HeaderText="Fattura" Text="Visualizza" />
            <asp:ButtonField HeaderText="Elimina" CommandName="Elimina" Text="Elimina" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    </div>
</asp:Content>

