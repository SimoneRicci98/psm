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
    double tot = 0;
    string ID_U="";
    int righe = 0;
    string[,] articoli = new string[100,4];
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            drpAcquirenti.Items.Add("--Seleziona--");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(ID_Utente),Nome,Cognome,Ragione_Sociale FROM Utenti,Carrello WHERE Cod_Utente = ID_Utente AND Ordinato='si'");
            rs = help.estraiDati();
            
            while (rs.Read())
            {
                drpAcquirenti.Items.Add((rs["ID_Utente"].ToString()+" "+rs["Nome"].ToString() + " " + rs["Cognome"].ToString() + " --> " + rs["Ragione_Sociale"].ToString()));
            }
            help.disconnetti();
        }
        try
        {
            ID_U = drpAcquirenti.SelectedValue.ToString().Substring(0, 1);
            tabella();
            lblTot.Text = tot.ToString() + " €";
        }
        catch
        {

        }
    }
    public void tabella()
    {
        int i = 0;
        help.disconnetti();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[7]
           {new DataColumn("img"),
            new DataColumn("Articolo"),
            new DataColumn("Descrizione"),
            new DataColumn("Marca"),
            new DataColumn("Taglia"),
            new DataColumn("Quantità"),
            new DataColumn("Prezzo")});
        help.connetti();
        help.assegnaComando("SELECT * FROM Carrello, Articoli WHERE Cod_Utente=" + ID_U + " AND " +
            "Cod_Articolo = Codice AND Ordinato='si'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            articoli[i, 0] = rs["Cod_Articolo"].ToString();
            articoli[i, 1] = rs["Quantità"].ToString();
            articoli[i, 2] = rs["Taglia"].ToString();
            articoli[i, 3] = rs["Descrizione"].ToString();
            dt.Rows.Add(ResolveUrl(rs["Immagine"].ToString()),
                rs["Cod_Articolo"].ToString(),
                rs["Descrizione"].ToString(),
                rs["Marca"].ToString(),
                rs["Taglia"].ToString(),
                rs["Quantità"].ToString(),
                rs["Prezzo"].ToString());
            tot += Convert.ToDouble(rs["Prezzo"].ToString())*Convert.ToDouble(rs["Quantità"].ToString());
            i++;
        }
        grdCarrello.DataSource = dt;
        grdCarrello.DataBind();
        ViewState["CurrentTable"] = dt;
        help.disconnetti();

    }

    protected void btn_Conferma(object sender, EventArgs e)
    {
        DataTable table = ViewState["CurrentTable"] as DataTable;
        try
        {
            help.connetti();
            help.assegnaComando("INSERT INTO Vendite(Acquirente,Totale,Data) VALUES(" + ID_U + ",'" + tot + "','" + System.DateTime.Today.ToShortDateString() + "')");
            help.eseguicomando();
            help.disconnetti();
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                help.connetti();
                help.assegnaComando("INSERT INTO Dettagli_Vendita VALUES((SELECT MAX(ID_Vendita) FROM Vendite),'" + articoli[i, 0] + "'," + articoli[i, 1] + ",'" + articoli[i, 2] + "','"+ articoli[i, 3]+"')");
                help.eseguicomando();
                help.disconnetti();
                i++;
            }
            help.connetti();
            help.assegnaComando("DELETE FROM Carrello WHERE Cod_Utente=" + ID_U+" AND Ordinato='si'");
            help.eseguicomando();
            help.disconnetti();
            MessageBox.Show("Ordine confermato");
        }
        catch(Exception ex)
        {
            help.disconnetti();
            Response.Write(ex.ToString()); 
        }

    }

    protected void btn_Elimina(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            DataTable table = ViewState["CurrentTable"] as DataTable;
            foreach (DataRow row in table.Rows)
            {
                help.connetti();
                help.assegnaComando("UPDATE Taglie_Quantità SET Quantità_Magazzino=Quantità_Magazzino+"+articoli[i,1]+" WHERE " +
                    "Cod_Prod='"+ articoli[i, 0] +"' AND Taglie='"+ articoli[i, 2]+"'");
                help.eseguicomando();
                help.disconnetti();
                i++;
            }
            help.connetti();
            help.assegnaComando("DELETE FROM Carrello WHERE Cod_Utente=" + ID_U + " AND Ordinato='si'");
            help.eseguicomando();
            help.disconnetti();
           
            MessageBox.Show("Ordine eliminato");
            Response.AppendHeader("Refresh", "0;url=GestisciOrdini.aspx");
        }
        catch (Exception ex)
        {
            help.disconnetti();
            MessageBox.Show(ex.ToString());
        }
    }

    protected void drpAcquirenti_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tabella();
        }
        catch
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}
