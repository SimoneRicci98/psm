<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="OrdiniMoblie1.aspx.cs" Inherits="Amministrazione" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
        <div class="col-md-12"> 

<div class="col-md-12">
    <asp:Panel runat="server" Visible="true">
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
                    <asp:Button ID="Button1"  runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Ricerca" />
        &nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-success" runat="server" Text="Indietro" />

        
        </asp:Panel>
     <asp:UpdatePanel runat="server" ID="Update1" UpdateMode="Conditional">
    <ContentTemplate>
         <div style="text-align:right;background-color:white;position:sticky;position:-webkit-sticky;top:0;height:70px">
         <br />Totale articoli acquistati &nbsp<asp:Label ID="Label2" runat="server" Text="0"></asp:Label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                Costo totale:
            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
            &nbsp;€ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" OnClick="btnOrdina_Click" runat="server">Ordina</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-success" OnClick="btnScarica_Click" runat="server">Scarica</asp:LinkButton>&nbsp;&nbsp;
             <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Annulla" OnClick="Button2_Click" />
             <br />
            </div>
        <br /><br />
                         <div style="position:sticky;top:70px;position:-webkit-sticky;" >
<table style="width:100%;background-color:#1C5E55;color:white;height:35px;font-weight:bold;text-align:center">
                    <tr>
                        <td style="width:40%">
                            Immagine
                        </td>
                        <td style="width:10%">
                            Codice
                        </td>
                        <td style="width:25%">
                            Quantità magazzino
                        </td>
                        <td style="width:25%">
                            Acquisto
                        </td>
                    </tr>
                </table>
                         </div>        
               <br /><br />
 <asp:GridView OnRowDataBound="gvDistricts_RowDataBound" HeaderStyle-CssClass="headerpos" OnRowCreated="grdArticoli_RowCreated" ShowHeader="false" ID="grdArticoli" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="grdArticoli_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                <asp:ImageField DataImageUrlField="Immagine" HeaderText="Immagine" ItemStyle-Width="40%" ControlStyle-Width="100%" ControlStyle-Height="400px">
                </asp:ImageField>
                <asp:BoundField DataField="Codice" HeaderText="Codice" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Qta_Mag" HeaderText="Quantità" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" >
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Acquisto" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" > 
                                <ItemTemplate>
                                        <asp:TextBox BorderColor="Black" BorderWidth="1px" ID="txtQta" Text="0" Width="50%" AutoPostBack="true" TextMode="Number" OnTextChanged="txtQta_TextChanged" runat="server"></asp:TextBox>                                  
                                </ItemTemplate>

                            </asp:TemplateField>
        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView> 

            <br /><br />
   
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
        
            </div>
    </div>
    </asp:Content>