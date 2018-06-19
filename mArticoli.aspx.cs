using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using PdfSharp;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Text.RegularExpressions;
using System.Diagnostics;

public partial class Amministrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    public struct articoli
    {
        string immagine;
        string codice;
        string marca;
        string categoria;
        string colore;
        string prezzo_c;
        double prezzo;
        string taglia;
        int qta;
        int qtamag;
        public articoli(string immagine,
        string codice,
        string marca,
        string categoria,
        string colore,
        string prezzo_c,
        double prezzo,
        string taglia,
        int qta,
        int qtamag)
        {
            this.categoria = categoria;
            this.colore = colore;
            this.immagine = immagine;
            this.marca = marca;
            this.prezzo_c = prezzo_c;
            this.codice = codice;
            this.prezzo = prezzo;
            this.qta = qta;
            this.qtamag = qtamag;
            this.taglia = taglia;
        }
        public void SetQta(int Qta)
        {
            this.qta = Qta;
        }
        public void SetQtaMag(int QtaMag)
        {
            this.qtamag = QtaMag;
        }
        public string GetCodice()
        {
            return codice;
        }
        public double GetPrezzo()
        {
            return prezzo;
        }
        public int GetQta()
        {
            return qta;
        }
        public int GetQtaMag()
        {
            return qtamag;
        }
        public string GetTaglia()
        {
            return taglia;
        }
        public string GetImmagine()
        {
            return immagine;
        }
        public string GetMarca()
        {
            return marca;
        }
        public string GetCat()
        {
            return categoria;
        }
        public string GetColore()
        {
            return colore;
        }
        public string GetPrezzo_C()
        {
            return prezzo_c;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                ViewState["tabella"] = null;
                ViewState["prezzotot"] = 0;
                ViewState["qta"] = 0;
                tabella();

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
       
        
    }

    

    protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.Style.Add("height", "150px");
            }
            TextBox txtQta = (TextBox)e.Row.Cells[9].FindControl("txtQta");
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = txtQta.UniqueID;
            trigger.EventName = "TextChanged";
            update1.Triggers.Add(trigger);
        }
    }

    protected void btnAddArt(object sender, EventArgs e)
    {
        Response.Redirect("AggiungiArticoli.aspx");
    }


    public void tabella()
    {
        help.connetti();
        help.assegnaComando("SELECT COUNT (*) as Conta " +
            "FROM Articoli, Taglie_Quantità WHERE Codice=Cod_Prod");
        rs = help.estraiDati();
        rs.Read();
        int righe = int.Parse(rs["Conta"].ToString());

        help.disconnetti();
        articoli[] listaarticoli = new articoli[righe];
        int i = 0;
        help.connetti();
        help.assegnaComando("SELECT * " +
            "FROM Articoli, Taglie_Quantità WHERE Codice=Cod_Prod");
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Taglie"),
            new DataColumn("Qta_Mag"),
            new DataColumn("Acquisto")});
        rs = help.estraiDati();
        while(rs.Read())
        {
            dt.Rows.Add(ResolveUrl("~/Immagini/" + rs["Immagine"]),
            rs["Codice"],
            rs["Marca"],
            rs["Categoria"],
            rs["Colore"],
            rs["Prezzo_Cartellino"] + " €",
            rs["Prezzo_Vendita"] + " €",
            rs["Taglie"],
            rs["Quantità_Magazzino"],
            string.Empty);
            articoli art = new articoli(rs["Immagine"].ToString(),
                rs["Codice"].ToString(),
                rs["Marca"].ToString(),
                rs["Categoria"].ToString(),
                rs["Colore"].ToString(),
                rs["Prezzo_Cartellino"].ToString(),
                double.Parse(rs["Prezzo_Vendita"].ToString()),
                rs["Taglie"].ToString(),
                0,
                int.Parse(rs["Quantità_Magazzino"].ToString()));
            listaarticoli[i] = art;
            i++;
        }
        Session["listaarticoli"] = listaarticoli;
        help.disconnetti();
        grdArticoli.DataSource = dt;
        grdArticoli.DataBind();

        for (i = 0; i < righe; i++)
        {
            TextBox qtaAcquisto = (TextBox)grdArticoli.Rows[i].Cells[9].FindControl("txtQta");
            qtaAcquisto.Text = "0";
        }
        ViewState["tabella"] = dt;
    }

    public void tabella(string Marca, articoli[] listaarticoli)
    {
        try
        { 
            string queryMarca = Marca;

            help.connetti();
            help.assegnaComando("SELECT COUNT (*) as Conta " +
                "FROM Articoli,Taglie_Quantità  WHERE Marca='" + Marca + "' AND Codice=Cod_Prod");
            rs = help.estraiDati();
            rs.Read();
            int righe = int.Parse(rs["Conta"].ToString());
            help.disconnetti();

            string[,] articoli = new string[righe, 8];
            int i = 0;
            help.connetti();
            help.assegnaComando("SELECT * " +
                "FROM Articoli,Taglie_Quantità WHERE Marca='" + Marca + "' AND Codice=Cod_Prod");
            rs = help.estraiDati();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10]
               {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Taglie"),
            new DataColumn("Qta_Mag"),
            new DataColumn("Acquisto")});
            while (rs.Read())
            {
                dt.Rows.Add(ResolveUrl("~/Immagini/" + rs["Immagine"]),
             rs["Codice"],
             rs["Marca"],
             rs["Categoria"],
             rs["Colore"],
             rs["Prezzo_Cartellino"] + " €",
             rs["Prezzo_Vendita"] + " €",
             rs["Taglie"],
             rs["Quantità_Magazzino"],
             string.Empty);

            }
            grdArticoli.DataSource = dt;
            grdArticoli.DataBind();

            for (i = 0; i < righe; i++)
            {
                string qta = "0";
                bool trovato = false;
                foreach (articoli art in listaarticoli) if (!trovato)
                {
                    if (art.GetCodice() == grdArticoli.Rows[i].Cells[1].Text)
                    {
                         if (art.GetTaglia() == grdArticoli.Rows[i].Cells[8].Text)
                         {
                                trovato = true;
                                qta = art.GetQta().ToString();
                         }
                    }
                }

                TextBox qtaAcquisto = (TextBox)grdArticoli.Rows[i].Cells[9].FindControl("txtQta");
                qtaAcquisto.Text = qta;
            }
        }
        catch (Exception ex)
        { Response.Write("      " + ex.ToString()); }
    }

    public void tabella(articoli[] listaarticoli)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Taglie"),
            new DataColumn("Qta_Mag"),
            new DataColumn("Acquisto")});

        foreach(articoli art in listaarticoli)
        {
            dt.Rows.Add(ResolveUrl("~/Immagini/" + art.GetImmagine()),
            art.GetCodice(),
            art.GetMarca(),
            art.GetCat(),
            art.GetColore(),
            art.GetPrezzo_C() + " €",
            art.GetPrezzo() + " €",
            art.GetTaglia(),
            art.GetQtaMag(),
            string.Empty);
        }
        grdArticoli.DataSource = dt;
        grdArticoli.DataBind();
        int i = 0;
        foreach(articoli art in listaarticoli)
        {
            TextBox qtaAcquisto = (TextBox)grdArticoli.Rows[i].Cells[9].FindControl("txtQta");
            qtaAcquisto.Text = art.GetQta().ToString();
            i++;
        }
        ViewState["tabella"] = dt;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        tabella(drpMarca.SelectedValue.ToString(),(articoli[])Session["listaarticoli"]);
    }


    protected void grdArticoli_SelectedIndexChanged(object sender, EventArgs e)
    {


    }


    protected void btnOrdina_Click(object sender, EventArgs e)
    {
        try
        {
            articoli[] listaarticoli = (articoli[])Session["listaarticoli"];
            foreach (articoli art in listaarticoli)
            {
                if(art.GetQta()>0)
                {
                    help.connetti();
                    help.assegnaComando("INSERT INTO Carrello VALUES(" + Session["Utente"].ToString()
                        + ",'" + art.GetCodice()
                        + "','" + art.GetTaglia()
                        + "'," + art.GetQta()
                        + ",'" + art.GetPrezzo() + "','si')");
                    help.eseguicomando();
                    help.disconnetti();
                    help.connetti();
                    help.assegnaComando("UPDATE Taglie_Quantità SET QUantità_Magazzino=Quantità_Magazzino-" + art.GetQta() + " WHERE Cod_Prod='" +
                        art.GetCodice() + "' AND Taglie='" + art.GetTaglia()+ "'");
                    help.eseguicomando();
                    help.disconnetti();
                }
            }

           /* SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Timeout = 1000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("promostileordini@gmail.com", "P4ssw0rd");

            MailMessage email = new MailMessage();

            email.To.Add("promostileordini@gmail.com");
            help.connetti();
            help.assegnaComando("SELECT Email,Nome,Cognome,Ragione_Sociale FROM Utenti WHERE ID_Utente=" + Session["Utente"].ToString());
            rs = help.estraiDati();
            rs.Read();
            string Nome = rs["Nome"].ToString();
            string Cognome = rs["Cognome"].ToString();
            string rag_soc = rs["Ragione_Sociale"].ToString();
            string mail = rs["Email"].ToString();
            help.disconnetti();
            email.From = new MailAddress(mail);
            email.Subject = "Nuovo ordine da psm.promostile.it";
            email.Body = "Ordine ricevuto da: " + Nome + " " + Cognome + " per conto di " + rag_soc + ", visualizzalo nel pannello di controllo di psm.promostile.it !";
            client.Send(email);*/
            MessageBox.Show("Ordine inviato");
            Response.AppendHeader("Refresh", "0;url=Articoli.aspx");
        }
        catch
        {
            MessageBox.Show("C'è stato un errore nell'invio dell'ordine");
        }
    }

    protected void btnScarica_Click(object sender, EventArgs e)
    {
        articoli[] listaarticoli = (articoli[])Session["listaarticoli"];
        int qtatot = 0;
        double prezzotot = 0;
        bool ordina = false;
        string html = "<style>"+
          "#customers {"+
            "font - family: \"Trebuchet MS\", Arial, Helvetica, sans - serif;"+
       "border - collapse: collapse;"+
        "width: 100 %;"+
    "}"+

"#customers td, #customers th {"+
    "border: 1px solid #ddd;"+
    "padding: 8px;"+
"}"+

"#customers tr:nth-child(even){background-color: #f2f2f2;}"+

"# customers tr:hover {background-color: #ddd;}"+

"# customers th {"+
"padding-top: 12px;"+
    "padding-bottom: 12px;"+
    "text-align: left;"+
    "background-color: #4CAF50;"+
    "color: white;"+
"}"+
"</style>"+ "<p  style=\"text-align:center; margin-top:2%; margin-bottom:2%; font-size:40px\">PSM.IT</p></br><table id=\"customers\"><tr>";
        html += "<th>Codice</th><th>Marca</th><th>Categoria</th><th>Colore</th><th>Prezzo cartellino</th><th>Prezzo vendita</th><th>Taglia</th><th>Quantità acquisto</th>";
        html += "</tr>";
        foreach(articoli art in listaarticoli)
        {
            if (art.GetQta() > 0)
            {
                ordina = true;
                html += "<tr>";
                html += "<td>" + art.GetCodice() + "</td>";
                html += "<td>" + art.GetMarca() + "</td>";
                html += "<td>" + art.GetCat() + "</td>";
                html += "<td>" + art.GetColore() + "</td>";
                html += "<td>" + art.GetPrezzo_C()+ " €</td>";
                html += "<td>" + art.GetPrezzo() + " €</td>";
                html += "<td>" + art.GetTaglia() +"</td>";
                html += "<td>" + art.GetQta() + "</td>";
                html += "</tr>";
                prezzotot += art.GetPrezzo() * art.GetQta();
                qtatot += art.GetQta();
            }

        }
        html += "</table>";
        html += "<p style=\"text-align:right\">Quantità aticoli "+qtatot+ " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Prezzo totale " + prezzotot + " €</p>";
        if (ordina)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf(html,PageSize.A3);
            
            pdf.Save(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=Report.pdf");
            Response.TransmitFile(Server.MapPath("~/App_Data/ReportHtml/Report.pdf"));
            Response.End();
            System.IO.File.Delete("~/App_Data/ReportHtml/Report.pdf");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        drpMarca.SelectedIndex = 0;
        tabella((articoli[])Session["listaarticoli"]);
        /*grdArticoli.DataSource= (DataTable)ViewState["tabella"];
        grdArticoli.DataBind();*/
    }

    protected void txtQta_TextChanged(object sender, EventArgs e)
    {
        articoli[] listaarticoli = (articoli[])Session["listaarticoli"];
        TextBox thisTextBox = (TextBox)sender;
        GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
        int row = thisGridViewRow.RowIndex;
        int i = 0;
        int num;
        int righe = 0;
        bool trovato = false;
        if (int.TryParse(thisTextBox.Text, out num))
        {
            if (int.Parse(thisTextBox.Text) >= 0)
            {
                foreach (articoli art in listaarticoli)
                {
                    righe++;
                }
                while (i < righe && !trovato)
                {
                    if (listaarticoli[i].GetCodice() == thisGridViewRow.Cells[1].Text)
                    {
                        if (listaarticoli[i].GetTaglia() == thisGridViewRow.Cells[8].Text)
                        {
                            trovato = true;
                        }
                    }
                    if (!trovato)
                    {
                        i++;
                    }
                }
                int app = 0;
                if (int.Parse(thisTextBox.Text) <= listaarticoli[i].GetQtaMag())
                {
                    if (int.Parse(thisTextBox.Text) <= listaarticoli[i].GetQta())
                    {
                        app = listaarticoli[i].GetQta() - int.Parse(thisTextBox.Text);
                        listaarticoli[i].SetQtaMag(listaarticoli[i].GetQtaMag() + app);
                        ViewState["qta"] = (int)ViewState["qta"] - app;
                        ViewState["prezzotot"] = double.Parse(ViewState["prezzotot"].ToString()) - (app * listaarticoli[i].GetPrezzo());
                    }
                    else
                    {
                        app = int.Parse(thisTextBox.Text) - listaarticoli[i].GetQta();
                        listaarticoli[i].SetQtaMag(listaarticoli[i].GetQtaMag() - app);
                        ViewState["qta"] = (int)ViewState["qta"] + app;
                        ViewState["prezzotot"] = double.Parse(ViewState["prezzotot"].ToString()) + (app * listaarticoli[i].GetPrezzo());
                    }
                    listaarticoli[i].SetQta(int.Parse(thisTextBox.Text));
                    Label1.Text = ViewState["prezzotot"].ToString();
                    Label2.Text = ViewState["qta"].ToString();
                    thisGridViewRow.Cells[9].Text = listaarticoli[i].GetQtaMag().ToString();
                    update1.Update();
                }
            }
        }
        else
        {
            thisTextBox.Text = "0";
        }
            
    }
    protected void grdArticoli_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}