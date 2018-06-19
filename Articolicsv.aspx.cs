using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;

public partial class GestisciProdotti : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    bool continua = false;
    bool prdsped = true;
    bool tagliasped = true;
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void btn_ImportCSV_Click(object sender, EventArgs e)
    {
        string filePath = string.Empty;
        if (CsvUpload.HasFile && CsvUpload.FileName.Substring(CsvUpload.FileName.IndexOf('.')).ToLower() == ".csv")
        {
            CsvUpload.PostedFile.SaveAs(Server.MapPath("~/App_Data/" + CsvUpload.FileName));
            GridCsv.DataSource = (DataTable)ReadToEnd(Server.MapPath("~/App_Data/" + CsvUpload.FileName));
            GridCsv.DataBind();
            lbl_ErrorMsg.Visible = false;
            File.Delete(Server.MapPath("~/App_Data/" + CsvUpload.FileName));
        }
        else
        {
            lbl_ErrorMsg.Visible = true;
        }

    }

    private object ReadToEnd(string filePath)
    {
        DataTable dtDataSource = new DataTable();
        string[] fileContent = File.ReadAllLines(filePath);
        if (fileContent.Count() > 0)
        {
            //Create data table columns
            string[] columns = fileContent[0].Split(';');
            for (int i = 0; i < columns.Count(); i++)
            {
                dtDataSource.Columns.Add(columns[i]);
            }

            //Add row data
            for (int i = 1; i < fileContent.Count(); i++)
            {
                string[] rowData = fileContent[i].Split(';');
                dtDataSource.Rows.Add(rowData);
            }
        }
        return dtDataSource;
    }
}
