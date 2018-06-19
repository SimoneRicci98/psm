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
    protected void Page_Load(object sender, EventArgs e)
    {
        tabella();
    }

    public void tabella()
    {
        help.disconnetti();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5]
           {new DataColumn("NomeC"),
            new DataColumn("Deal"),
            new DataColumn("DataI"),
            new DataColumn("DataF"),
            new DataColumn("Gestisci")});
        help.connetti();
        help.assegnaComando("SELECT * FROM Campagne");
        rs = help.estraiDati();
        while (rs.Read())
        {
            dt.Rows.Add(rs["Nome"].ToString(),
                rs["Deal"].ToString(),
                rs["Data_Inizio"].ToString(),
                rs["Data_Fine"].ToString(),
                "Gestisci");
        }
        grdCamp.DataSource = dt;
        grdCamp.DataBind();
        ViewState["CurrentTable"] = dt;
        help.disconnetti();

    }

    protected void grdCamp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = grdCamp.Rows[id];
        help.connetti();
        help.assegnaComando("SELECT ID_Campagna FROM Campagne WHERE Nome='" + row.Cells[0].Text + "'");
        rs = help.estraiDati();
        rs.Read();
        Session["Campagna"] = rs["ID_Campagna"].ToString();
        help.disconnetti();
        Response.Redirect("GestisciCampagna.aspx");       
    }
}
