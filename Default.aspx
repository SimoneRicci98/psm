<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="col-md-12">
        Effettua una ricerca specifica <br />
        <asp:Table CssClass="table-responsive table-hover table" runat="server" >
             <asp:TableRow>
                <asp:TableCell Width="20%">
                    Codice
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCod" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="20%">
                    Descrizione
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="20%">
                     Categoria   
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="drpCat" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="20%">
                    Marca
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="drpMarca"  runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="20%">
                    Prezzo
                </asp:TableCell>
                <asp:TableCell>da &nbsp<asp:TextBox ID="txtPrezzoDa" Text="0"  runat="server"></asp:TextBox>€</asp:TableCell>
                <asp:TableCell>a  &nbsp<asp:TextBox ID="txtPrezzoA" Text="99999" runat="server"></asp:TextBox>€</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Ricerca" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" OnClick="Button2_Click" Text="Indietro" />
        <br /><br />
                    <asp:GridView ID="grdArticoli" runat="server" HeaderStyle-Height="30px" OnRowCommand="g1_RowCommand" OnRowDataBound="grpProdotti_RowDataBound" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                <asp:ImageField DataImageUrlField="Immagine" HeaderText="Immagine" ItemStyle-Width="40px" ControlStyle-Width="100" ControlStyle-Height="100">
            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Width="40px"></ItemStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Codice" HeaderText="Codice" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Marca" HeaderText="Marca" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Colore" HeaderText="Colore" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Cartellino" HeaderText="Prezzo cartellino" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Vendita" HeaderText="Prezzo vendita" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QtaMag" HeaderText="Quantità magazzino">
                                </asp:BoundField>
                <asp:ButtonField HeaderText="Modifica" Text="Prosegui" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="prova" />
            </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>

            <br /><br />
    <asp:Button ID="btnScarica" CssClass="btn btn-success" OnClick="btnScarica_Click" runat="server" Text="Scarica" />
        </div>


</asp:Content>