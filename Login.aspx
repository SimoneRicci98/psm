<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-offset-3" style="font-size:18px">
<div class="row">
             <div class="col-md-2" style="text-align:right">
                 Email
             </div>
             <div class="col-md-3">
                 <asp:TextBox ID="TxtEmail" runat="server"  CssClass="form-control" TextMode="Email"></asp:TextBox>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-md-2" style="text-align:right">
                 Password
             </div>
             <div class="col-md-3">
                 <asp:TextBox ID="TxtPass" runat="server"  TextMode="Password" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
    <br />
         <div class="row">
    <div class="col-md-4">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Entra" OnClick="Button1_Click" CssClass="btn btn-success" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
    </div>
         </div>
<br />
         <div class="row">
    <div class="col-md-5" style="margin-top:3%">
       
        <asp:LinkButton ID="btnReg" CssClass ="btn btn-success" runat="server" Text="Registrati" OnClick="btnReg_Click">
        </asp:LinkButton>
    </div>
         </div>

         </div>
</asp:Content>
