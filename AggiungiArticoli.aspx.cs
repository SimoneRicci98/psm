using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class GestisciProdotti : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    bool continua = false;
    bool prdsped = true;
    bool tagliasped = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpProdSPedizione.Items.Clear();
            drpProdSPedizione.Items.Add("Seleziona una taglia");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT Prod_Sped FROM Articoli");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpProdSPedizione.Items.Add(rs["Prod_Sped"].ToString());
            }
            help.disconnetti();
            drpTagliaSpedizione.Items.Clear();
            drpTagliaSpedizione.Items.Add("Seleziona una taglia");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT Taglia_Sped FROM Articoli");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpTagliaSpedizione.Items.Add(rs["Taglia_Sped"].ToString());
            }
            help.disconnetti();
        }
    }

    protected void btn_Salva(object sender, EventArgs e)
    {
        string prodSped = "";
        string tagliaSped = "";
        if(drpProdSPedizione.SelectedValue == "Seleziona una taglia" || txtNuovoPrdSped.Text== "Nuovo prodotto spedizione")
        {
            if(drpProdSPedizione.SelectedValue != "Seleziona una taglia")
            {
                prodSped = drpProdSPedizione.SelectedValue;
            }
            else
            {
                if (txtNuovoPrdSped.Text != "Nuova taglia spedizione")
                {
                    prodSped = txtNuovoPrdSped.Text;
                }
                else
                {
                    prdsped =false;
                }
            }
            
        }
        if (drpTagliaSpedizione.SelectedValue == "Seleziona una taglia" || txtNuovaTagliaSped.Text == "Nuova taglia spedizione")
        {
            if (drpTagliaSpedizione.SelectedValue != "Seleziona una taglia")
            {
                tagliaSped = drpTagliaSpedizione.SelectedValue;
            }
            else
            {
                if (txtNuovaTagliaSped.Text != "Nuova taglia spedizione")
                {
                    tagliaSped = txtNuovaTagliaSped.Text;
                }
                else
                {
                    tagliasped = false;
                }
            }

        }

        if (txtCodice.Text == string.Empty ||
            txtCat.Text == string.Empty ||
            txtColore.Text == string.Empty ||
            txtDescr.Text == string.Empty ||
            txtMarca.Text == string.Empty ||
            txtPrezzoCartellino.Text == string.Empty ||
            txtPrezzoVenita.Text == string.Empty ||
            txtQta.Text == string.Empty ||
            txtTaglie.Text == string.Empty ||
            !prdsped ||
            !tagliasped ||
            !flpImmagine.HasFile)
        {
            MessageBox.Show("Compilare tutti i campi!");
        }
        else
        {
            continua = true;
        }

        try
        {
            string[] exten = { ".jpg", ".png", ".gif", ".jpeg" };

            string fileExten = flpImmagine.FileName.Substring(flpImmagine.FileName.IndexOf('.')).ToLower();

            bool fileOK = false;

            if (flpImmagine.HasFile)
            {
                for (int i = 0; i < exten.Length - 1; i++)
                {
                    if (exten[i] == fileExten)
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK && continua)
            {
                string[] taglie = txtTaglie.Text.Split(',');
                string[] qta = txtQta.Text.Split(',');
                help.connetti();
                help.assegnaComando("INSERT INTO Articoli (Codice,Prezzo_Cartellino,Prezzo_Vendita,Categoria,Colore,Marca,Descrizione,Taglia_Sped,Prod_Sped,Immagine)" +
                    " VALUES ('" + txtCodice.Text + "','"
                    + txtPrezzoCartellino.Text + "','"
                    + txtPrezzoVenita.Text + "','"
                    + txtCat.Text + "','"
                    + txtColore.Text + "','"
                    + txtMarca.Text + "','"
                    + txtDescr.Text + "','"
                    + tagliaSped + "','"
                    + prodSped + "','"
                    + flpImmagine.FileName + "')");
                help.eseguicomando();
                help.disconnetti();
                for(int i=0;i<taglie.Length;i++)
                {
                    help.connetti();
                    help.assegnaComando("INSERT INTO taglie_quantità VALUES ('"+ txtCodice.Text+"','"+taglie[i].ToString()+"',"+qta[i].ToString()+")");
                    help.eseguicomando();
                    help.disconnetti();
                }

                flpImmagine.PostedFile.SaveAs(Server.MapPath("~/Immagini/" + flpImmagine.FileName));
                MessageBox.Show("Prodotto caricato correttamenete");
                Response.AppendHeader("Refresh", "1;url=AggiungiArticoli.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }
}
