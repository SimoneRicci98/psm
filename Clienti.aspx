<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clienti.aspx.cs" Inherits="Clienti" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="col-md-12" style="margin-top:2%">
            <asp:UpdatePanel runat="server">
            <ContentTemplate>        
        <asp:GridView ID="GridView1" Width="100%" HeaderStyle-Height="25px" RowStyle-Height="50px" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
                <asp:BoundField DataField="Ragione_Sociale" HeaderText="Ragione sociale" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Partita_iva" HeaderText="Partita iva" />
                <asp:BoundField DataField="Cod_Fisc" HeaderText="Codice fiscale" />
                <asp:BoundField DataField="Indirizzo_Fatt" HeaderText="Indirizzo fatturazione" />
                <asp:BoundField DataField="Num_Tel" HeaderText="Numero telefono" />
                <asp:ButtonField HeaderText="Elimina" Text="Elimina" CommandName="Elimina"/>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>