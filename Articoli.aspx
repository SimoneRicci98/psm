<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Articoli.aspx.cs" Inherits="Amministrazione" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
       <script type="text/javascript">
      // It is important to place this JavaScript code after ScriptManager1
      var xPos, yPos;
      var prm = Sys.WebForms.PageRequestManager.getInstance();

      function BeginRequestHandler(sender, args) {
        if ($get('<%=Panel1.ClientID%>') != null) {
          // Get X and Y positions of scrollbar before the partial postback
          xPos = $get('<%=Panel1.ClientID%>').scrollLeft;
          yPos = $get('<%=Panel1.ClientID%>').scrollTop;
        }
     }

     function EndRequestHandler(sender, args) {
         if ($get('<%=Panel1.ClientID%>') != null) {
           // Set X and Y positions back to the scrollbar
           // after partial postback
           $get('<%=Panel1.ClientID%>').scrollLeft = xPos;
           $get('<%=Panel1.ClientID%>').scrollTop = yPos;
         }
     }

     prm.add_beginRequest(BeginRequestHandler);
     prm.add_endRequest(EndRequestHandler);
 </script>
        <div class="col-md-12">
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
                     <asp:Panel runat="server" ID="Panel1" ScrollBars="Vertical" Height="500px">
                         <div style="position:absolute;padding-right:15px">
<table style="width:100%;background-color:#1C5E55;color:white;height:25px;font-weight:bold;text-align:center">
                    <tr>
                        <td style="width:270px">
                            Immagine
                        </td>
                        <td style="width:8.333333%">
                            Codice
                        </td>
                        <td style="width:8.333333%">
                            Marca
                        </td>
                        <td style="width:10.333333%">
                            Descrizione
                        </td>
                        <td style="width:9.333333%">
                            Categoria
                        </td>
                        <td style="width:8.333333%">
                            Colore
                        </td>
                        <td style="width:8.333333%">
                            Prezzo cartellino
                        </td>
                        <td style="width:8.333333%" >
                            Prezzo vendita
                        </td>
                        <td style="width:8.333333%">
                            Taglie
                        </td>
                        <td style="width:8.333333%">
                            Quantità magazzino
                        </td>
                        <td style="width:8.333333%">
                            Acquisto
                        </td>
                    </tr>
                </table>
                         </div>        
               <br /><br />
 <asp:GridView OnRowDataBound="gvDistricts_RowDataBound" OnRowCreated="grdArticoli_RowCreated" ShowHeader="False" ID="grdArticoli" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="grdArticoli_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                <asp:ImageField DataImageUrlField="Immagine" HeaderText="" ControlStyle-CssClass="itemimg" ControlStyle-Width="100" ControlStyle-Height="100">
            <ControlStyle CssClass="itemimg" Height="150px" Width="150px"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle ></ItemStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Codice" ItemStyle-Width="8.333333%" HeaderText="" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Marca" ItemStyle-Width="8.333333%" HeaderText="" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Descrizione" ItemStyle-Width="10.333333%" HeaderText="" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle  />
                            </asp:BoundField>
                <asp:BoundField DataField="Categoria" ItemStyle-Width="9.333333%" HeaderText="" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle  />
                            </asp:BoundField>
                <asp:BoundField DataField="Colore" ItemStyle-Width="8.333333%" HeaderText="" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                            <ItemStyle />
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Cartellino" ItemStyle-Width="9.333333%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle/>
                            </asp:BoundField>
                <asp:BoundField DataField="Prezzo_Vendita" ItemStyle-Width="8.333333%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Taglie" ItemStyle-Width="8.333333%">
                            <ItemStyle Width="8.333333%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qta_Mag" ItemStyle-Width="8.333333%" >
                            <ItemStyle Width="8.333333%" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-Width="8.333333%"> 
                                <ItemTemplate>
                                        <asp:TextBox ID="txtQta" Text="0" Width="50%" AutoPostBack="true" TextMode="Number" OnTextChanged="txtQta_TextChanged" runat="server"></asp:TextBox>                                  
                                </ItemTemplate>
                                <ItemStyle Width="8.333333%" />
                            </asp:TemplateField>
        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView> 
                     </asp:Panel>
         </ContentTemplate>
             </asp:UpdatePanel>
                      </fieldset>
                          
              </ContentTemplate>
          </asp:UpdatePanel>
            <br /><br />
            <asp:LinkButton ID="btnOrdina" CssClass="btn btn-success" OnClick="btnOrdina_Click" runat="server">Ordina</asp:LinkButton>
            <asp:LinkButton ID="btnScarica" CssClass="btn btn-success" OnClick="btnScarica_Click" runat="server">Scarica</asp:LinkButton>
   
        </div>
            
    </div>
    </asp:Content>