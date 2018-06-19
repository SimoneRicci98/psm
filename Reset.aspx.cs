using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reset : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("DELETE FROM Appoggio_Campagna");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Carrello");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Taglie_Quantità");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Vendite");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Articoli");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Campagne");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Dettagli_Campagna");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Dettagli_Vendita");
        help.eseguicomando();
        help.disconnetti();
        Response.Redirect("Login.aspx");
    }
}