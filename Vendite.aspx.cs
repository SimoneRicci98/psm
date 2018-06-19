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

public partial class Vendite : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    List<string> ID_Vendita = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        tabella();
    }
    public void tabella()
    {
        int i = 0;
        help.disconnetti();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4]
           {new DataColumn("Acquirente"),
            new DataColumn("Totale"),
            new DataColumn("Data"),
            new DataColumn("Visualizza")});
        help.connetti();
        help.assegnaComando("SELECT * FROM Vendite,Utenti WHERE Acquirente=ID_Utente ORDER BY Data");
        rs = help.estraiDati();
        while (rs.Read())
        {
            ID_Vendita.Add(rs["ID_Vendita"].ToString());
            dt.Rows.Add(rs["Nome"].ToString() + " " + rs["Cognome"].ToString(),
                rs["Totale"].ToString() + " €",
                rs["Data"].ToString(),
                "Visualizza");
            i++;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ViewState["CurrentTable"] = dt;
        help.disconnetti();

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        double prezzotot = 0;
        int qtatot = 0;
        int id = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[id];
        if (e.CommandName == "Elimina")
        {
            help.connetti();
            help.assegnaComando("DELETE FROM Dettagli_Vendita WHERE Codice_Vendita=" + ID_Vendita[id]);
            help.eseguicomando();
            help.disconnetti();
            help.connetti();
            help.assegnaComando("DELETE FROM Vendite WHERE ID_Vendita=" + ID_Vendita[id]);
            help.eseguicomando();
            help.disconnetti();
            tabella();
        }
        else
        {
            help.connetti();
            help.assegnaComando("SELECT * FROM Dettagli_Vendita,Articoli WHERE Codice_Vendita=" + ID_Vendita[id] + " AND Cod_Articolo=Codice");
            rs = help.estraiDati();
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
    "</style>" + "<p  style=\"text-align:center; margin-top:2%; margin-bottom:2%; font-size:40px\">PSM.IT</p></br><table id=\"customers\" style=\"margin-top:3%\"><tr>";
            html += "<th>Codice articolo</th><th>Descrizione</th><th>Colore</th><th>Taglia</th><th>Quantità</th><th>Prezzo</th>";
            html += "</tr>";
            while (rs.Read())
            {
                html += "<tr>";
                html += "<td>" + rs["Codice"].ToString() + "</td>";
                html += "<td>" + rs["Descrizione"].ToString() + "</td>";
                html += "<td>" + rs["Colore"].ToString() + "</td>";
                html += "<td>" + rs["Taglia"].ToString() + "</td>";
                html += "<td>" + rs["Quantità"].ToString() + "</td>";
                html += "<td>" + rs["Prezzo_Vendita"].ToString() + " €</td>";
                html += "</tr>";
                prezzotot += double.Parse(rs["Prezzo_Vendita"].ToString()) * int.Parse(rs["Quantità"].ToString());
                qtatot += int.Parse(rs["Quantità"].ToString());
            }
            html += "</table>";
            html += "<p style=\"text-align:right\">Quantità aticoli " + qtatot + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Prezzo totale " + prezzotot + " €</p>";
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            pdf.Save(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=Fattura " + ID_Vendita[id] + " per " + row.Cells[0].Text + ".pdf");
            Response.TransmitFile(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
            Response.End();
            System.IO.File.Delete("~/App_Data/ReportHtml/Report.pdf");
        }

    }
}