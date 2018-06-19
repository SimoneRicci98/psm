using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    String QtaMag="";
    string codice = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string prodotto = Session["ID_Articolo"].ToString();
        help.connetti();
        help.assegnaComando("SELECT * FROM Articoli WHERE ID_Articolo ='" + prodotto + "'");
        rs = help.estraiDati();
        rs.Read();
        codice=rs["Codice"].ToString();
        lblCod.Text = codice;
        lblCat.Text = rs["Categoria"].ToString();
        lblColore.Text = rs["Colore"].ToString();
        lblDescr.Text = rs["Descrizione"].ToString();
        lblMarca.Text = rs["Marca"].ToString();
        lblPrezzoCart.Text = rs["Prezzo_Cartellino"].ToString()+"€";
        lblPrezzoVend.Text = rs["Prezzo_Vendita"].ToString()+"€";
        help.disconnetti();

        if(!IsPostBack)
        {
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Taglia_Sped) FROM Articoli");
            rs = help.estraiDati();
            drpTagliaSpedizione.Items.Add(string.Empty);
            while (rs.Read())
            {
                drpTagliaSpedizione.Items.Add(rs["Taglia_Sped"].ToString());
            }
            help.disconnetti();

            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Prod_Sped) FROM Articoli");
            rs = help.estraiDati();
            drpProdSPedizione.Items.Add(string.Empty);
            while (rs.Read())
            {
                drpProdSPedizione.Items.Add(rs["Prod_Sped"].ToString());
            }
            help.disconnetti();
            drpTaglie.Items.Clear();
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Taglie) FROM Taglie_Quantità WHERE Cod_Prod='" + codice + "'");
            rs = help.estraiDati();
            drpTaglie.Items.Add(string.Empty);
            while (rs.Read())
            {
                drpTaglie.Items.Add(rs["Taglie"].ToString());
            }
            help.disconnetti();
        }
    }


    protected void btn_Acquista(object sender, EventArgs e)
    {
        if(txtColore.Text!=string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Colore='" + txtColore.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if(txtCat.Text!=string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Categoria='"+txtCat.Text+ "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtCod.Text != string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Codice='" + txtCod.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
            help.connetti();
            help.assegnaComando("UPDATE Taglie_Quantità SET cod_Prod='"+ txtCod.Text+ "' WHERE Cod_Prod='"+codice+"'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtDesc.Text != string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Descrizione='" + txtDesc.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtMarca.Text != string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Marca='" + txtMarca.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtPrezCart.Text != string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Prezzo_Cartellino='" + txtPrezCart.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtPrezVen.Text != string.Empty)
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Prezzo_Vendita='" + txtPrezVen.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        if (txtNuovaTagliaSped.Text != "Nuova taglia spedizione")
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Taglia_Sped='" + txtNuovaTagliaSped.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        else
        {
            if (drpTagliaSpedizione.SelectedValue != string.Empty)
            {
                help.connetti();
                help.assegnaComando("UPDATE Articoli SET Taglia_Sped='" + drpTagliaSpedizione.SelectedValue + "' WHERE Codice='" + codice + "'");
                help.eseguicomando();
                help.disconnetti();
            }
        }
        if (txtNuovoPrdSped.Text != "Nuovo prodotto spedizione")
        {
            help.connetti();
            help.assegnaComando("UPDATE Articoli SET Prod_Sped='" + txtNuovoPrdSped.Text + "' WHERE Codice='" + codice + "'");
            help.eseguicomando();
            help.disconnetti();
        }
        else
        {
            if(drpProdSPedizione.SelectedValue!=string.Empty)
            {
                help.connetti();
                help.assegnaComando("UPDATE Articoli SET Prod_Sped='" + drpProdSPedizione.SelectedValue + "' WHERE Codice='" + codice + "'");
                help.eseguicomando();
                help.disconnetti();
            }
        }
        if (flpImmagine.HasFile)
        {
            string[] exten = { ".jpg", ".png", ".gif", ".jpeg" };

            string fileExten = flpImmagine.FileName.Substring(flpImmagine.FileName.IndexOf('.')).ToLower();

            if (flpImmagine.HasFile)
            {
                for (int i = 0; i < exten.Length - 1; i++)
                {
                    if (exten[i] == fileExten)
                    {
                        flpImmagine.PostedFile.SaveAs(Server.MapPath("~/Immagini/" + flpImmagine.FileName));
                        help.connetti();
                        help.assegnaComando("UPDATE Articoli SET Immagine='" + flpImmagine.FileName + "' WHERE ID_Articolo='" + Session["ID_Articolo"].ToString() + "'");
                        help.eseguicomando();
                        help.disconnetti();
                    }
                }
            }

        }
        if (drpTaglie.SelectedValue != string.Empty)
        {
            if (txtQtaMag.Text != string.Empty)
            {
                help.connetti();
                help.assegnaComando("UPDATE Taglie_Quantità SET Quantità_Magazzino=" + txtQtaMag.Text + " WHERE Cod_Prod='" + codice + "' AND Taglie='" + drpTaglie.SelectedValue + "'");
                help.eseguicomando();
                help.disconnetti();
            }
        }
        else
        {
            if (txtTaglie.Text != string.Empty)
            {

                string[] nuoveTaglie = txtTaglie.Text.Split(',');
                string[] nuoveQta = txtQtaMag.Text.Split(',');
                if (nuoveQta.Length == nuoveTaglie.Length)
                {
                    for (int i = 0; i < nuoveTaglie.Length; i++)
                    {
                        help.connetti();
                        help.assegnaComando("INSERT INTO Taglie_Quantità VALUES('" + codice + "','" + nuoveTaglie[i] + "'," + nuoveQta[i] + ")");
                        help.eseguicomando();
                        help.disconnetti();
                    }
                }
                else
                {
                    MessageBox.Show("Taglie e quantità non corrispondono");
                }
            }
        }
        MessageBox.Show("Modifiche effettuate");
        Response.AppendHeader("Refresh", "1;url=Default.aspx");
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("DELETE FROM Articoli WHERE ID_Articolo='" + Session["ID_Articolo"].ToString() + "'");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DELETE FROM Taglie_Quantità WHERE Cod_Prod='" + codice + "'");
        help.eseguicomando();
        help.disconnetti();
        Response.Redirect("Default.aspx");
    }

    protected void btnRimuoviTaglia_Click(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("DELETE FROM Taglie_Quantità WHERE Taglie='"+drpTaglie.SelectedValue+"' AND Cod_Prod='" + codice + "'");
        help.eseguicomando();
        help.disconnetti();
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void drpTaglie_SelectedIndexChanged(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT Quantità_Magazzino FROM Taglie_Quantità WHERE Cod_Prod='"+codice+"' AND Taglie='"+drpTaglie.SelectedValue+"'");
        rs = help.estraiDati();
        rs.Read();
        lblQtaMag.Text = rs["Quantità_Magazzino"].ToString();
        help.disconnetti();
    }
}