using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestisciCampagna : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpTaglie.Items.Add("----");
            drpProd.Items.Add("-----");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(cod_Articolo) FROM Dettagli_Campagna WHERE Cod_Campagna=" + Session["Campagna"].ToString());
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpProd.Items.Add(rs["cod_Articolo"].ToString());
            }
            help.disconnetti();

        }
    }

    protected void btnConferma_Click(object sender, EventArgs e)
    {       
        int num;
        if (int.TryParse(txtQta.Text, out num))
        {
            help.connetti();
            help.assegnaComando("UPDATE Dettagli_Campagna SET Quantità=Quantità-" + txtQta.Text.Trim() + " WHERE cod_Articolo ='" + lblCod.Text + "' AND Cod_Campagna=" + Session["Campagna"].ToString() +
                " AND Taglia = '" + drpTaglie.SelectedValue + "'");
            help.eseguicomando();
            help.disconnetti();
            lblQta.Text = Convert.ToString(int.Parse(lblQta.Text) - int.Parse(txtQta.Text));
            txtQta.Text = "0";
        }    
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        int i = 0;
        help.connetti();
        help.assegnaComando("SELECT COUNT(*) AS Conta FROM Dettagli_Campagna WHERE Cod_Campagna=" + Session["Campagna"]);
        rs = help.estraiDati();
        rs.Read();
        int righe = int.Parse(rs["Conta"].ToString());
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT cod_Articolo,Quantità,Taglia FROM Dettagli_Campagna WHERE Cod_Campagna=" + Session["Campagna"]);
        string[,] aggiornaQta = new string[righe, 4];
        rs = help.estraiDati();
        while (rs.Read())
        {
            aggiornaQta[i, 0] = rs["Cod_Articolo"].ToString();
            aggiornaQta[i, 1] = rs["Quantità"].ToString();
            aggiornaQta[i, 2] = rs["Taglia"].ToString();
            i++;
        }
        help.disconnetti();
        i = 0;
        for (i = 0; i < righe; i++)
        {
            help.connetti();
            help.assegnaComando("UPDATE Taglie_Quantità SET Quantità_Magazzino=Quantità_Magazzino+" + aggiornaQta[i, 1] + "WHERE Cod_Prod='" + aggiornaQta[i, 0] + "' AND Taglie='"+ aggiornaQta[i, 2]+"'");
            help.eseguicomando();
            help.disconnetti();
        }
        help.connetti();
        help.assegnaComando("DELETE FROM Campagne WHERE ID_Campagna=" + Session["Campagna"]);
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Dettagli_Campagna WHERE Cod_Campagna=" + Session["Campagna"]);
        help.eseguicomando();
        help.disconnetti();
        Response.Redirect("VisualizzaCampagne.aspx");
    }

    protected void btnTornaIndietr_Click(object sender, EventArgs e)
    {
        Response.Redirect("VisualizzaCampagne.aspx");
    }

    protected void drpProd_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCod.Text = "";
        lblDescr.Text = "";
        lblMarca.Text = "";
        lblPrezzo.Text = "";
        lblQta.Text = "";
        drpTaglie.Items.Clear();
        drpTaglie.Items.Add("----");
        help.connetti();
        help.assegnaComando("SELECT Taglia FROM Dettagli_Campagna WHERE Cod_Campagna=" + Session["Campagna"].ToString() +
            "AND Cod_Articolo='" + drpProd.SelectedValue + "'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            drpTaglie.Items.Add(rs["Taglia"].ToString());
        }
        help.disconnetti();

    }

    protected void drpTaglie_SelectedIndexChanged(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT * FROM Dettagli_Campagna, Articoli WHERE Cod_Campagna=" + Session["Campagna"].ToString() +
            " AND cod_Articolo ='" + drpProd.SelectedValue + "' AND Taglia = '" + drpTaglie.SelectedValue + "' AND cod_Articolo=Codice");
        rs = help.estraiDati();
        rs.Read();
        lblCod.Text = rs["cod_Articolo"].ToString();
        lblDescr.Text = rs["Descrizione"].ToString();
        lblMarca.Text = rs["Marca"].ToString();
        lblPrezzo.Text = rs["Prezzo"].ToString();
        lblQta.Text = rs["Quantità"].ToString();
        help.disconnetti();

    }

    protected void drpColore_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}