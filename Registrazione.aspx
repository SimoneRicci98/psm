<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrazione.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Registrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-3" style="font-size:18px">
            <asp:Label ID="lblReg" runat="server" Text="Non hai un account? Registrati!"></asp:Label>
         <br />
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Nome
             </div>
             <div class="col-md-3">
                 <asp:TextBox ID="txtNome" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNome" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Cognome
             </div>
             <div class="col-md-3">
                 <asp:TextBox ID="txtCognome" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCognome" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Email
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtEmail" runat="server" Width="100%" CssClass="form-control" TextMode="Email"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtEmail" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Ragione sociale
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtRagSoc" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtRagSoc" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Partita iva
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtIva" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtIva" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
              <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Codice fiscale
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtCodF" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCodF" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Indirizzo fatturazione
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtIndirizzo" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtIndirizzo" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Numero telefono
             </div>
             <div class="col-md-3">
                <asp:TextBox ID="txtNum" runat="server" Width="100%" CssClass="form-control" ></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNum" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Password
             </div>
             <div class="col-md-3">
                 <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtPass" CssClass="alert-danger"></asp:RequiredFieldValidator>
             </div>
         </div>
         <div class="col-md-3">

             <asp:Button ID="Button1" runat="server" Text="Registrati!" OnClick="Button1_Click" CssClass="btn btn-success" />

             <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>

         </div>
     </div>
</asp:Content>