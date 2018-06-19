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
        string descrizione;
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
        string descrizione,
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
            this.descrizione = descrizione;
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
        public string GetDescr()
        {
            return descrizione;
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

    public static class Utils
    {
        static Regex MobileCheck = new Regex(@"android|(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        static Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

        public static bool fBrowserIsMobile()
        {
            Debug.Assert(HttpContext.Current != null);

            if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                string u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

                if (u.Length < 4)
                    return false;

                if (MobileCheck.IsMatch(u) || MobileVersionCheck.IsMatch(u.Substring(0, 4)))
                    return true;
            }

            return false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

       /* if (Utils.fBrowserIsMobile())
        {
            //Response.Write("La pagina per i dispositivi mobili è in fase di creazione");
            Response.Redirect("mArticoli.aspx");
        }
        */
            if (!IsPostBack)
            {
                ViewState["tabella"] = null;
                ViewState["prezzotot"] = 0;
                ViewState["qta"] = 0;
                tabella();

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
       
        
    }

    

    protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.Style.Add("height", "70px");
            }
            TextBox txtQta = (TextBox)e.Row.Cells[10].FindControl("txtQta");
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
        dt.Columns.AddRange(new DataColumn[11]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Descrizione"),
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
            string img = "";
            if(rs["Immagine"].ToString().Substring(0,4).ToLower()!="http")
            {
                img = "~/Immagini/" + rs["Immagine"];
            }
            else
            {
                img = rs["Immagine"].ToString();
            }
            dt.Rows.Add(ResolveUrl(img),
            rs["Codice"],
            rs["Marca"],
            rs["Descrizione"],
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
                rs["Descrizione"].ToString(),
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

    public void tabella(string Descr, string Marca, string Cat, string PrezzoDa, string PrezzoA, string Cod, articoli[] listaarticoli)
    {
        try
        {
            string queryDescr = "";
            string queryMarca = "";
            string queryCat = "";
            string queryCod = "";
            if (Descr != string.Empty)
            {
                queryDescr = " AND Descrizione LIKE '%" + Descr + "%'";
            }
            if (Marca != string.Empty)
            {
                queryMarca = " AND Marca='" + Marca + "'";
            }
            if (Cat != string.Empty)
            {
                queryCat = " AND Categoria='" + Cat + "'";
            }
            if (Cod != string.Empty)
            {
                queryCod = " AND Codice ='" + Cod + "'";
            }

            help.connetti();
            help.assegnaComando("SELECT COUNT (*) as Conta " +
                "FROM Articoli,Taglie_Quantità WHERE Prezzo_Vendita BETWEEN " + PrezzoDa + " AND " + PrezzoA + queryCat + queryDescr + queryMarca + queryCod + " AND Codice=Cod_Prod");
            rs = help.estraiDati();
            rs.Read();
            int righe = int.Parse(rs["Conta"].ToString());
            help.disconnetti();

            string[,] articoli = new string[righe, 8];
            int i = 0;
            help.connetti();
            help.assegnaComando("SELECT * " +
                "FROM Articoli,Taglie_Quantità WHERE Prezzo_Vendita BETWEEN " + PrezzoDa + " AND " + PrezzoA + queryCat + queryDescr + queryMarca + queryCod + " AND Codice=Cod_Prod");
            rs = help.estraiDati();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[11]
               {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Descrizione"),
            new DataColumn("Categoria"),
            new DataColumn("Colore"),
            new DataColumn("Prezzo_Cartellino"),
            new DataColumn("Prezzo_Vendita"),
            new DataColumn("Taglie"),
            new DataColumn("Qta_Mag"),
            new DataColumn("Acquisto")});
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
                 rs["Codice"],
             rs["Marca"],
             rs["Descrizione"],
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

                TextBox qtaAcquisto = (TextBox)grdArticoli.Rows[i].Cells[10].FindControl("txtQta");
                qtaAcquisto.Text = qta;
            }
        }
        catch (Exception ex)
        { Response.Write("      " + ex.ToString()); }
    }

    public void tabella(articoli[] listaarticoli)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[11]
           {new DataColumn("Immagine"),
            new DataColumn("Codice"),
            new DataColumn("Marca"),
            new DataColumn("Descrizione"),
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
            art.GetDescr(),
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
            TextBox qtaAcquisto = (TextBox)grdArticoli.Rows[i].Cells[10].FindControl("txtQta");
            qtaAcquisto.Text = art.GetQta().ToString();
            i++;
        }
        ViewState["tabella"] = dt;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        tabella(txtDesc.Text, drpMarca.SelectedValue.ToString(), drpCat.SelectedValue.ToString(), txtPrezzoDa.Text, txtPrezzoA.Text, txtCod.Text, (articoli[])Session["listaarticoli"]);
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
        html += "<th>Codice</th><th>Marca</th><th>Descrizione</th><th>Categoria</th><th>Colore</th><th>Prezzo cartellino</th><th>Prezzo vendita</th><th>Taglia</th><th>Quantità acquisto</th>";
        html += "</tr>";
        foreach(articoli art in listaarticoli)
        {
            if (art.GetQta() > 0)
            {
                ordina = true;
                html += "<tr>";
                html += "<td>" + art.GetCodice() + "</td>";
                html += "<td>" + art.GetMarca() + "</td>";
                html += "<td>" + art.GetDescr() + "</td>";
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
        txtCod.Text = "";
        txtDesc.Text = "";
        txtPrezzoA.Text = "99999";
        txtPrezzoDa.Text = "0";
        drpCat.SelectedIndex = 0;
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