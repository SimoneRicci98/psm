<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="mArticoli.aspx.cs" Inherits="Amministrazione" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
        <div class="col-md-12">
              Effettua una ricerca specifica <br />
        <asp:Table CssClass="table-responsive table-hover table" runat="server" >
            <asp:TableRow>
                <asp:TableCell Width="50%">
                    Marca
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="drpMarca"  runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Ricerca" />
        &nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-success" runat="server" Text="Indietro" />
          <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="update1">
              <ContentTemplate> 
                  <fieldset>
         <p style="text-align:right">
         <br />Totale articoli acquistati &nbsp<asp:Label ID="Label2" runat="server" Text="0"></asp:Label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                Costo totale:
            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
            &nbsp;€<br />
            </p>

        <br /><br />
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                 <ContentTemplate>
 <asp:GridView OnRowDataBound="gvDistricts_RowDataBound" OnRowCreated="grdArticoli_RowCreated" HeaderStyle-Height="50px" ItemStyle-HorizontalAlign="Center" ShowHeader="True" ID="grdArticoli" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="grdArticoli_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                <asp:ImageField DataImageUrlField="Immagine" HeaderText="Immagine"  ControlStyle-Width="100" ControlStyle-Height="100">
            <ControlStyle Height="150px" Width="150px"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle ></ItemStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Codice" ItemStyle-Width="10%" HeaderText="Codice" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Marca" ItemStyle-Width="10%" HeaderText="Marca" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Categoria" ItemStyle-Width="10%" HeaderText="Categoria" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle  />
                            </asp:BoundField>
                <asp:BoundField DataField="Colore" ItemStyle-Width="10%"  HeaderText="Colore" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Cartellino" ItemStyle-Width="10%" HeaderText="Prezzo cartellino">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle/>
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Vendita" ItemStyle-Width="10%" HeaderText="Prezzo vendita">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Taglie" ItemStyle-Width="10%" HeaderText="Taglie">
                            <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qta_Mag" ItemStyle-Width="10%" HeaderText="Quantità magazzino" >
                            <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Quantità"> 
                                <ItemTemplate>
                                        <asp:TextBox ID="txtQta" Text="0" Width="50%" AutoPostBack="true" TextMode="Number" OnTextChanged="txtQta_TextChanged" runat="server"></asp:TextBox>                                  
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
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
                      </fieldset>
                          
              </ContentTemplate>
          </asp:UpdatePanel>
            <br /><br />
            <asp:LinkButton ID="btnOrdina" CssClass="btn btn-success" OnClick="btnOrdina_Click" runat="server">Ordina</asp:LinkButton>
            <asp:LinkButton ID="btnScarica" CssClass="btn btn-success" OnClick="btnScarica_Click" runat="server">Scarica</asp:LinkButton>
   
        </div>
    </asp:Content>