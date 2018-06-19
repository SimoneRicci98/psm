<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Amministrazione.aspx.cs" Inherits="Amministrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-12" style="margin-top:2%">
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
            <asp:LinkButton ID="btnAggiungiArticoli" Visible="false" OnClick="btnAddArt" runat="server" CssClass="btn btn-success" Width="100%"><span class="glyphicon glyphicon-plus"></span>&nbsp Aggiungi articoli</asp:LinkButton>
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
        <asp:LinkButton ID="btnAggiungiCampagne" Visible="false" OnClick="btnAddCamp" runat="server" CssClass="btn btn-success" Width="100%" ><span class="glyphicon glyphicon-plus"></span>&nbsp Aggiungi campagne</asp:LinkButton>
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
            <asp:LinkButton ID="btnAggiungiTracking" OnClick="btnAggiungiTracking_Click"  Visible="false" runat="server" CssClass="btn btn-success" Width="100%"><span class="glyphicon glyphicon-plus"></span>&nbsp Aggiungi tracking</asp:LinkButton>
            </div></div>
        </div>
    <div class="col-md-12" style="margin-top:2%">
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
        <asp:LinkButton ID="btnGestisciArticoli" OnClick="btnGestArt"  runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Gestisci articoli</asp:LinkButton>
        </div></div>
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
        <asp:LinkButton ID="btnGestisciCampagne" OnClick="btnGestCamp"  runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Gestisci campagne</asp:LinkButton>
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="align-items:center">
            <asp:LinkButton ID="btnGestisciOrdini" OnClick="btnGestOrdini"  runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Gestisci ordini</asp:LinkButton>
            </div></div>
        </div>
        <div class="col-md-12" style="margin-top:2%">
            <div class="col-md-4">
                <div class="col-md-12" style="align-items:center">
                  <asp:LinkButton ID="btnAggOrdine" OnClick="btnAggOrdine_Click"  runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Nuovo ordine</asp:LinkButton>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-12" style="align-items:center">
                  <asp:LinkButton ID="btnVendite" OnClick="btnVendite_Click" runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Vendite</asp:LinkButton>
                </div>
            </div>
           <div class="col-md-4">
                <div class="col-md-12" style="align-items:center">
                  <asp:LinkButton ID="btnClienti" OnClick="btnClienti_Click" runat="server" CssClass="btn btn-success" Width="100%"><i class="fa fa-file-text"></i>&nbsp Clienti</asp:LinkButton>
                </div>
            </div>
        </div>
</asp:Content>