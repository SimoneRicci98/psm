<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreaCampagna.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <div class="col-md-offset-1 col-md-10" style="margin-top:3%;margin-bottom:3%">
    <asp:Table runat="server" CssClass ="table-hover table-responsive table">
        <asp:TableRow>
            <asp:TableCell>
                Nome campagna
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNomeCampagna" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow> 
                <asp:TableRow>
            <asp:TableCell>
                Seleziona deal
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="drpDeal" runat="server"></asp:DropDownList><br /><br />
                <asp:TextBox ID="txtNuovoDeal" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow> 
                <asp:TableRow>
            <asp:TableCell>
                Data inizio
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDataInizio" TextMode="Date" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow> 
                <asp:TableRow>
            <asp:TableCell>
                Data fine
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDataFine" runat="server" TextMode="Date"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow> 
    </asp:Table>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Update1">
            <ContentTemplate>
                <asp:Table runat="server" CssClass ="table-hover table-responsive table">
        <asp:TableRow>
            <asp:TableCell Width="18%">
                Articolo<br /><br />
                <asp:DropDownList ID="drpArticoli" OnSelectedIndexChanged="drpArticoli_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell Width="15%">
                Taglie<br /><br />
                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="drpTaglie_SelectedIndexChanged" ID="drpTaglie" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell Width="15%">
                Quantità in magazzino<br /><br />
                <asp:Label ID="lblQta" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="15%">
                Prezzo vendita <br /><br />
                <asp:Label ID="lblPrezVend" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="15%">
                Prezzo campagna <br /><br />
                <asp:TextBox ID="txtPrezzo" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="15%">
                Quantità campagna <br /><br />
                <asp:TextBox ID="txtQtaCamp" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="10%"><br />
                <asp:LinkButton ID="btnAggProd"  OnClick="btnAggProd_Click" CssClass="btn btn-success" runat="server">Aggiungi</asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    
        <asp:GridView ID="grdProdCamp" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="g1_RowCommand"  CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_Articolo" HeaderText="ID Articolo" />
                <asp:BoundField DataField="Articolo" HeaderText="Articolo" />
                <asp:BoundField DataField="Taglia" HeaderText="Taglia" />
                <asp:BoundField DataField="Quantità" HeaderText="Quantità" />
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" />
                <asp:ButtonField Text="Elimina" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView><br /><br />
           </ContentTemplate>
        </asp:UpdatePanel> 
        <asp:Button ID="btnCreaCampagna" runat="server" Text="Crea campagna!" CssClass="btn btn-success" OnClick="btnCreaCampagna_Click" />

    </div>

</asp:Content>