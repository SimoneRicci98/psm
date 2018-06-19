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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            help.connetti();
            help.assegnaComando("DELETE FROM Appoggio_Campagna");
            help.eseguicomando();
            help.disconnetti();
            drpArticoli.Items.Add("------");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Codice) FROM Articoli");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpArticoli.Items.Add(rs["Codice"].ToString());
            }
            help.disconnetti();

            drpDeal.Items.Add("------");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Deal) FROM Deal");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpDeal.Items.Add(rs["Deal"].ToString());
            }

            help.disconnetti();
        }
    }

    protected void g1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        help.connetti();
        help.assegnaComando("DELETE FROM Appoggio_Campagna WHERE Cod_Prod='"+grdProdCamp.Rows[id].Cells[0].Text+"'");
        help.eseguicomando();
        help.disconnetti();
        tabella();
    }


    protected void btnCreaCampagna_Click(object sender, EventArgs e)
    {
        try
        {
            if (DateTime.Compare(DateTime.Parse(txtDataInizio.Text), DateTime.Parse(txtDataFine.Text)) < 0)
            {
                DataTable table = ViewState["CurrentTable"] as DataTable;
                string deal = "";
                if (txtNuovoDeal.Text == string.Empty)
                {
                    deal = drpDeal.SelectedValue.ToString();
                }
                else
                {
                    deal = txtNuovoDeal.Text;
                    help.connetti();
                    help.assegnaComando("INSERT INTO Deal(Deal) VALUES('" + deal + "')");
                    help.eseguicomando();
                    help.disconnetti();
                }
                help.connetti();
                help.assegnaComando("INSERT INTO Campagne(Deal,Data_Inizio,Data_Fine,Nome)" +
                                    "VALUES('" + deal + "','" + txtDataInizio.Text + "','" + txtDataFine.Text + "','" + txtNomeCampagna.Text + "')");
                help.eseguicomando();
                help.disconnetti();

                foreach (DataRow row in table.Rows)
                {
                    string id_p = row.ItemArray[0] as string;
                    string taglia = row.ItemArray[2] as string;
                    string qta = row.ItemArray[3] as string;
                    string prezzo = row.ItemArray[4] as string;
                    help.connetti();
                    help.assegnaComando("INSERT INTO Dettagli_Campagna " +
                                        "VALUES((SELECT MAX(ID_Campagna) FROM Campagne),'" + id_p + "','" + prezzo + "','" + taglia + "'," + qta + ")");
                    help.eseguicomando();
                    help.disconnetti();
                    help.connetti();
                    help.assegnaComando("UPDATE Taglie_Quantità SET Quantità_Magazzino=Quantità_Magazzino-" + qta + " WHERE Cod_Prod='" + id_p + "' AND Taglie='" + taglia + "'");
                    help.eseguicomando();
                    help.disconnetti();
                }
                help.connetti();
                help.assegnaComando("DELETE FROM Appoggio_Campagna");
                help.eseguicomando();
                help.disconnetti();
                MessageBox.Show("Campagna creata");
                Response.AppendHeader("Refresh", "0;url=CreaCampagna.aspx");
            }
            else
            {
                MessageBox.Show("Date inserite in modo errato");
            }
        }
        catch
        { MessageBox.Show("C'è stato un errore nella creazione della campagna"); }
    }

    protected void drpArticoli_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblQta.Text = "";
        lblPrezVend.Text = "";
        txtQtaCamp.Text = "";
        txtPrezzo.Text = "";
        drpTaglie.Items.Clear();
        drpTaglie.Items.Add("------");
        help.connetti();
        help.assegnaComando("SELECT DISTINCT(Taglie) FROM Taglie_Quantità WHERE Cod_Prod='"+drpArticoli.SelectedValue+"'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            drpTaglie.Items.Add(rs["Taglie"].ToString());
        }
        help.disconnetti();
        Update1.Update();
    }

    protected void drpTaglie_SelectedIndexChanged(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT Quantità_Magazzino,Prezzo_Vendita FROM Taglie_Quantità,Articoli WHERE Cod_Prod='"+drpArticoli.SelectedValue+"' AND Taglie = '" + drpTaglie.SelectedValue.ToString() + "' AND Cod_Prod=Codice");
        rs = help.estraiDati();
        rs.Read();
        lblQta.Text = rs["Quantità_Magazzino"].ToString();
        lblPrezVend.Text = rs["Prezzo_Vendita"].ToString()+" €";
        help.disconnetti();
        Update1.Update();
    }

    protected void btnAggProd_Click(object sender, EventArgs e)
    {
        string cod = drpArticoli.SelectedValue;
        help.connetti();
        help.assegnaComando("SELECT Quantità_Magazzino FROM Taglie_Quantità WHERE Cod_Prod='"+cod+"' AND Taglie='"+ drpTaglie.SelectedValue+"'");
        rs = help.estraiDati();
        rs.Read();
        if(int.Parse(rs["Quantità_Magazzino"].ToString())>=int.Parse(txtQtaCamp.Text) && int.Parse(txtQtaCamp.Text)>0)
        {
            help.disconnetti();
            help.connetti();
            help.assegnaComando("INSERT INTO Appoggio_Campagna VALUES('" + drpArticoli.SelectedValue +
               "','" + drpTaglie.SelectedValue + "'," + txtQtaCamp.Text + ",'" + txtPrezzo.Text + "')");
            help.eseguicomando();
            help.disconnetti();
            tabella();
            lblQta.Text =Convert.ToString(int.Parse(lblQta.Text) - int.Parse(txtQtaCamp.Text));
            Update1.Update();
        }
        else
        {
            help.disconnetti();
            MessageBox.Show("Quantità troppo grande!");
        }
    }

    public void tabella()
    {
        DataTable dt = new DataTable();

        dt.Columns.AddRange(new DataColumn[6]
           {new DataColumn("ID_Articolo"),
            new DataColumn("Articolo"),
            new DataColumn("Taglia"),
            new DataColumn("Quantità"),
            new DataColumn("Prezzo"),
            new DataColumn("Elimina")});
        help.connetti();
        help.assegnaComando("SELECT * FROM Appoggio_Campagna,Articoli WHERE Cod_Prod=Codice");
        rs = help.estraiDati();
        while (rs.Read())
        {
            dt.Rows.Add(rs["Cod_Prod"],
            rs["Descrizione"],
            rs["Taglia"],
            rs["Quantità"],
            rs["Prezzo"]+" €",
            "Elimina");
        }
        help.disconnetti();
        ViewState["CurrentTable"] = dt;
        grdProdCamp.DataSource = dt;
        grdProdCamp.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpTaglie.Items.Clear();
        drpTaglie.Items.Add("------");
        help.connetti();
        help.assegnaComando("SELECT DISTINCT(Taglie) FROM Taglie_Quantità WHERE Cod_Prod='"+drpArticoli.SelectedValue+"'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            drpTaglie.Items.Add(rs["Taglie"].ToString());
        }
        help.disconnetti();
    }
}