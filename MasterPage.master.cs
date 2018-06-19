using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch
        { Response.Redirect("Login.aspx"); }
        if (Session["Utente"] != null)
        {
            btnLogOut.Visible = true;
        }


    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        btnLogOut.Visible = false;
        Response.Redirect("Default.aspx");
    }
    protected void btnAmministra(object sender, EventArgs e)
    {


    }

    protected void lnkPsm_Click(object sender, EventArgs e)
    {
        if (Session["Utente"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (Session["Utente"].ToString() == "1" || Session["Utente"].ToString() == "3") 
        {
            Response.Redirect("Amministrazione.aspx");
        }
        else
        {
            Response.Redirect("Articoli.aspx");
        }
    }
}
