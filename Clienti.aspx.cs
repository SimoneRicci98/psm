using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clienti : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        tabella();
    }
    public void tabella()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[8]
           {new DataColumn("Nome"),
            new DataColumn("Cognome"),
            new DataColumn("Ragione_Sociale"),
            new DataColumn("Email"),
            new DataColumn("Partita_iva"),
            new DataColumn("Cod_Fisc"),
            new DataColumn("Indirizzo_Fatt"),
            new DataColumn("Num_Tel")});
        help.connetti();
        help.assegnaComando("SELECT Nome,Cognome,Ragione_Sociale AS 'Ragione sociale',Email,Partita_iva AS 'Partita iva', Cod_Fisc AS 'Codice Fiscale',Indirizzo_Fatt AS 'Indirizzo fatturazione', Num_Tel AS 'Numero telefono' FROM Utenti ORDER BY Nome");
        rs = help.estraiDati();
        while (rs.Read())
        {
            dt.Rows.Add(rs["Nome"].ToString(),
                rs["Cognome"].ToString(),
                rs["Ragione sociale"].ToString(),
                rs["Email"].ToString(),
                rs["Partita iva"].ToString(),
                rs["Codice Fiscale"].ToString(),
                rs["Indirizzo fatturazione"].ToString(),
                rs["Numero telefono"].ToString());
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ViewState["CurrentTable"] = dt;
        help.disconnetti();

    }
    public void tabella(string RagSoc,string nome, string cognome)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[8]
           {new DataColumn("Nome"),
            new DataColumn("Cognome"),
            new DataColumn("Ragione_Sociale"),
            new DataColumn("Email"),
            new DataColumn("Partita_iva"),
            new DataColumn("Cod_Fisc"),
            new DataColumn("Indirizzo_Fatt"),
            new DataColumn("Num_Tel")});
        help.connetti();
        help.assegnaComando("SELECT Nome,Cognome,Ragione_Sociale AS 'Ragione sociale',Email,Partita_iva AS 'Partita iva', Cod_Fisc AS 'Codice Fiscale',Indirizzo_Fatt AS 'Indirizzo fatturazione', Num_Tel AS 'Numero telefono' FROM Utenti WHERE Nome='"+nome+"' AND Cognome='"+cognome+"' AND Ragione_Sociale='"+RagSoc+"'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            dt.Rows.Add(rs["Nome"].ToString(),
                rs["Cognome"].ToString(),
                rs["Ragione sociale"].ToString(),
                rs["Email"].ToString(),
                rs["Partita iva"].ToString(),
                rs["Codice Fiscale"].ToString(),
                rs["Indirizzo fatturazione"].ToString(),
                rs["Numero telefono"].ToString());
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ViewState["CurrentTable"] = dt;
        help.disconnetti();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[id];
        help.connetti();
        help.assegnaComando("DELETE FROM Utenti WHERE Nome='" + row.Cells[0].Text + "' AND Cognome='" + row.Cells[1].Text + "' AND Ragione_Sociale='" + row.Cells[2].Text + "'");
        help.eseguicomando();
        help.disconnetti();
        tabella();
    }

}