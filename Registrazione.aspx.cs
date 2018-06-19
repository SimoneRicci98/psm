using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Registrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            bool presente = false;
            string nome = txtNome.Text;
            string cognome = txtCognome.Text;
            string email = txtEmail.Text;
            string psw = txtPass.Text;
            string codfisc = txtCodF.Text;
            string piva = txtIva.Text;
            string ind = txtIndirizzo.Text;
            string ragsoc = txtRagSoc.Text;
            string numtel = txtNum.Text;

            if (nome != string.Empty
                && cognome != string.Empty
                && email != string.Empty
                && psw != string.Empty
                && codfisc != string.Empty
                && piva != string.Empty
                && ind != string.Empty
                && ragsoc != string.Empty
                && numtel != string.Empty)
            {
                double n;
                if (double.TryParse(numtel, out n))
                {
                    help.connetti();
                    help.assegnaComando("SELECT Email FROM Utenti");
                    rs = help.estraiDati();
                    while (rs.Read() && presente == false)
                    {
                        if (rs["Email"].ToString() == email)
                        {
                            lblErr.Text = "Email già presente";
                            presente = true;
                        }
                    }
                    help.disconnetti();
                    if (!presente)
                    {
                        help.connetti();
                        help.assegnaComando("INSERT INTO Utenti(Nome,Cognome,Email,Ragione_Sociale,Partita_iva,Cod_Fisc,Indirizzo_Fatt,Num_Tel,Psw)" +
                                            " VALUES('" + nome + "','" + cognome + "','" + email + "','" + ragsoc + "','" + piva + "','" + codfisc + "','" + ind + "','" + numtel + "','" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(psw, "md5") + "')");
                        help.eseguicomando();
                        help.disconnetti();
                        MessageBox.Show("operazione completata");
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    lblErr.Text = "Inserire un numero di telefono corretto";
                }
            }
            else
            {
                lblErr.Text = "Compila tutti i campi";
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

}
