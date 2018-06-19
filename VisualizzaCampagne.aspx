<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisualizzaCampagne.aspx.cs" Inherits="GestisciProdotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-2 col-md-8">
        Selezionare la campagna da gestire &nbsp;<br /><br />
       <asp:GridView ID="grdCamp" OnRowCommand="grdCamp_RowCommand" HeaderStyle-Height="25px" RowStyle-Height="40px" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:BoundField DataField="NomeC" HeaderText="Nome campagna" />
               <asp:BoundField DataField="Deal" HeaderText="Deal" />
               <asp:BoundField DataField="DataI" HeaderText="Data inizio" />
               <asp:BoundField DataField="DataF" HeaderText="Data fine" />
               <asp:ButtonField HeaderText="Gestisci" Text="Gestisci" />
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