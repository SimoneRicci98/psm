using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Amministrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Utente"].ToString()!="1" && Session["Utente"]!= null)
        {
            if(Session["Utente"].ToString() != "3")
            {
                MessageBox.Show("NON HAI I PERMESSI NECESSARI PER QUESTA PAGINA");
                Response.AppendHeader("Refresh", "0;url=Default.aspx");
            }
            else
            {
                btnAggiungiArticoli.Visible = true; // +++++++ PER NUOVI ARTICOLI
                btnAggiungiCampagne.Visible = true; //++++ PER NUOVE CAMPAGNE
                btnAggiungiTracking.Visible = true; //+++++++++ QUANDO SARà DISPONIBILE IL TRACKING
                btnGestisciArticoli.Visible = true; //++++++++++ PER VISUALIZZARE/ELIMINARE GLI ARTICOLI ESISTENTI
                btnGestisciCampagne.Visible = true; // ++++++++++ PER VISUALIZZARE/ELIMINARE LE CAMPAGNE ESISTENTI
                btnGestisciOrdini.Visible = true; //+++++++++++++++ NELLA PAGINA INSERIRE PULSANTE PER NUOVO ORDINE++++++++++++
            }
        }

    }

    /*public string NumOrdini()
    {
        help.connetti();
        help.assegnaComando("SELECT COUNT(DISTINCT(ID_Utente)) AS CONTA FROM Utenti,Carrello WHERE Cod_Utente = ID_Utente AND Ordinato='si'");
        rs = help.estraiDati();
        rs.Read();
        string numordini = rs["CONTA"].ToString();
        help.disconnetti();
        return numordini;
    }*/
    protected void btnAddArt(object sender, EventArgs e)
    {
        Response.Redirect("AggiungiArticoli.aspx");
    }
    protected void btnAddCamp(object sender, EventArgs e)
    {
        Response.Redirect("CreaCampagna.aspx");
    }
    protected void btnGestArt(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnGestCamp(object sender, EventArgs e)
    {
        Response.Redirect("VisualizzaCampagne.aspx");
    }
    protected void btnGestOrdini(object sender, EventArgs e)
    {
        Response.Redirect("GestisciOrdini.aspx");
    }

    protected void btnAggOrdine_Click(object sender, EventArgs e)
    {
        Response.Redirect("Articoli.aspx");
    }

    protected void btnVendite_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vendite.aspx");
    }

    protected void btnClienti_Click(object sender, EventArgs e)
    {
        Response.Redirect("Clienti.aspx");
    }

    protected void btnAggiungiTracking_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=Spedizioni.xlsx");
        Response.TransmitFile(Server.MapPath("~/App_Data/Spedizioni.xlsx"));
        Response.End();
    }
}