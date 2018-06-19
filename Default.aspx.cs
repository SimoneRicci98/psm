using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfSharp;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;

public partial class _Default : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["Utente"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if(!IsPostBack)
        {
            ViewState["tabella"] = null;
            drpCat.Items.Add("");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Categoria) FROM Articoli");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpCat.Items.Add(rs["Categoria"].ToString());
            }
            help.disconnetti();
            drpMarca.Items.Add("");
            help.connetti();
            help.assegnaComando("SELECT DISTINCT(Marca) FROM Articoli");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpMarca.Items.Add(rs["Marca"].ToString());
            }
            help.disconnetti();
        }
        tabella();
    }
    protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void grpProdotti_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void g1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = grdArticoli.Rows[id];
        help.connetti();
        help.assegnaComando("SELECT ID_Articolo FROM Articoli WHERE Codice='"+ row.Cells[1].Text+"'");
        rs = help.estraiDati();
        rs.Read();
        Session["ID_Articolo"] = rs["ID_Articolo"].ToString();
        Response.Redirect("Modifica.aspx");
        help.disconnetti();
    }
    public void tabella()
    {
        help.connetti();
        help.assegnaComando("CREATE VIEW Vista AS SELECT Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita,SUM(Quantità_Magazzino) AS Somma FROM Articoli,Taglie_Quantità " +
            "WHERE Codice=Cod_Prod GROUP BY Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita");
        help.eseguicomando();
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELECT * " +
            "FROM Vista ORDER BY Codice");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[12]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Descrizione"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Quantità_Campagne"),
            new DataColumn("QtaMag"),
            new DataColumn("prova"),
            new DataColumn("Modifica")});
       
        while (rs.Read())
        {
            string img = "";
            if (rs["Immagine"].ToString().Substring(0, 4).ToLower() != "http")
            {
                img = "~/Immagini/" + rs["Immagine"];
            }
            else
            {
                img = rs["Immagine"].ToString();
            }
            dt.Rows.Add(ResolveUrl(img),
                rs["Codice"].ToString(),
                rs["Marca"].ToString(),
                rs["Descrizione"].ToString(),
                rs["Categoria"].ToString(),
                rs["Colore"].ToString(),
                rs["Prezzo_Cartellino"].ToString() + " €",
                rs["Prezzo_Vendita"].ToString() + " €",
                rs["Somma"].ToString(), rs["Somma"].ToString());
        }
        ViewState["tabella"] = dt;
        grdArticoli.DataSource = dt;
        grdArticoli.DataBind();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DROP VIEW Vista");
        help.eseguicomando();
        help.disconnetti();
    }

    public void tabella(string Descr, string Marca, string Cat, string PrezzoDa, string PrezzoA, string Cod)
    {
        help.connetti();
        help.assegnaComando("CREATE VIEW Vista AS SELECT Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita,SUM(Quantità_Magazzino) AS Somma FROM Articoli,Taglie_Quantità " +
            "WHERE Codice=Cod_Prod GROUP BY Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita");
        help.eseguicomando();
        help.disconnetti();
        string queryDescr = "";
        string queryMarca = "";
        string queryCat = "";
        string queryCod = "";
        if (Descr!=string.Empty)
        {
             queryDescr = " AND Descrizione LIKE '%"+Descr+"%'";
        }
        if(Marca!=string.Empty)
        {
            queryMarca = " AND Marca='" + Marca + "'";
        }
        if(Cat!=string.Empty)
        {
            queryCat = " AND Categoria='" + Cat + "'";
        }
        if(Cod!=string.Empty)
        {
            queryCod = "AND Codice LIKE '%" + Cod + "%'";
        }
        help.connetti();
        help.assegnaComando("SELECT * " +
            "FROM Vista WHERE Prezzo_Vendita BETWEEN " + PrezzoDa + " AND " + PrezzoA + queryCat + queryDescr + queryMarca + queryCod+" ORDER BY Codice");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[12]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Descrizione"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Quantità_Campagne"),
            new DataColumn("QtaMag"),
            new DataColumn("prova"),
            new DataColumn("Modifica")});

        while (rs.Read())
        {
            string img = "";
            if (rs["Immagine"].ToString().Substring(0, 4).ToLower() != "http")
            {
                img = "~/Immagini/" + rs["Immagine"];
            }
            else
            {
                img = rs["Immagine"].ToString();
            }
            dt.Rows.Add(ResolveUrl(img),
                rs["Codice"].ToString(),
                rs["Marca"].ToString(),
                rs["Descrizione"].ToString(),
                rs["Categoria"].ToString(),
                rs["Colore"].ToString(),
                rs["Prezzo_Cartellino"].ToString() + " €",
                rs["Prezzo_Vendita"].ToString() + " €",
                rs["Somma"].ToString(), rs["Somma"].ToString());
        }
        ViewState["tabella"] = dt;
        grdArticoli.DataSource = dt;
        grdArticoli.DataBind();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DROP VIEW Vista");
        help.eseguicomando();
        help.disconnetti();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        tabella(txtDesc.Text, drpMarca.SelectedValue.ToString(), drpCat.SelectedValue.ToString(), txtPrezzoDa.Text, txtPrezzoA.Text,txtCod.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        tabella();
    }

    protected void btnScarica_Click(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("CREATE VIEW Vista AS SELECT Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita,SUM(Quantità_Magazzino) AS Somma FROM Articoli,Taglie_Quantità " +
            "WHERE Codice=Cod_Prod GROUP BY Immagine,Codice,Marca,Descrizione,Categoria,Colore,Prezzo_Cartellino,Prezzo_Vendita");
        help.eseguicomando();
        help.disconnetti();
        string queryDescr = txtDesc.Text;
        string queryMarca = drpMarca.SelectedValue;
        string queryCat = drpCat.SelectedValue;
        string queryCod = txtCod.Text;
        if (queryDescr != string.Empty)
        {
            queryDescr = " AND Descrizione LIKE '%" + queryDescr + "%'";
        }
        if (queryMarca != string.Empty)
        {
            queryMarca = " AND Marca='" + queryMarca + "'";
        }
        if (queryCat != string.Empty)
        {
            queryCat = " AND Categoria='" + queryCat + "'";
        }
        if (queryCod != string.Empty)
        {
            queryCod = "AND Codice LIKE '%" + queryCod + "%'";
        }

        int qtatot = 0;
        double valoretot = 0;
        string html = "<style>" +
          "#customers {" +
            "font - family: \"Trebuchet MS\", Arial, Helvetica, sans - serif;" +
       "border - collapse: collapse;" +
        "width: 100 %;" +
    "}" +

"#customers td, #customers th {" +
    "border: 1px solid #ddd;" +
    "padding: 8px;" +
"}" +

"#customers tr:nth-child(even){background-color: #f2f2f2;}" +

"# customers tr:hover {background-color: #ddd;}" +

"# customers th {" +
"padding-top: 12px;" +
    "padding-bottom: 12px;" +
    "text-align: left;" +
    "background-color: #4CAF50;" +
    "color: white;" +
"}" +
"</style>" + "<p  style=\"text-align:center; margin-top:2%; margin-bottom:2%; font-size:40px\">PSM.IT</p></br><table id=\"customers\"><tr>";

        html += "<th>Codice</th><th>Marca</th><th>Descrizione</th><th>Categoria</th><th>Colore</th><th>Prezzo cartellino</th><th>Prezzo vendita</th><th>Quantità magazzino</th>";
        html += "</tr>";
        help.connetti();
        help.assegnaComando("SELECT * " +
            "FROM Vista WHERE Prezzo_Vendita BETWEEN " + txtPrezzoDa.Text + " AND " + txtPrezzoA.Text + queryCat + queryDescr + queryMarca + queryCod + " ORDER BY Codice");
        rs = help.estraiDati();

        while (rs.Read())
        {
            html += "<tr>";
            html += "<td>" + rs["Codice"].ToString() + "</td>";
            html += "<td>" + rs["Marca"].ToString() + "</td>";
            html += "<td>" + rs["Descrizione"].ToString() + "</td>";
            html += "<td>" + rs["Categoria"].ToString() + "</td>";
            html += "<td>" + rs["Colore"].ToString() + "</td>";
            html += "<td>" + rs["Prezzo_Cartellino"].ToString() + "</td>";
            html += "<td>" + rs["Prezzo_Vendita"].ToString() + "</td>";
            html += "<td>" + rs["Somma"].ToString() + "</td>";
            html += "</tr>";
            qtatot += int.Parse(rs["Somma"].ToString());
            valoretot += int.Parse(rs["Somma"].ToString()) * double.Parse(rs["Prezzo_Vendita"].ToString());
        }
        help.disconnetti();
        help.connetti();
        help.assegnaComando("DROP VIEW Vista");
        help.eseguicomando();
        help.disconnetti();
        html += "</table>";
        html += "<p style=\"text-align:right\">Quantità aticoli " + qtatot + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Prezzo totale " + valoretot + " €</p>";
        PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A3);
        pdf.Save(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=Report.pdf");
        Response.TransmitFile(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
        Response.End();
        System.IO.File.Delete("~/App_Data/ReportHtml/Report.pdf");
    }
}