using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

public class dbHelper
{
    //OleDbConnection connDb;
    SqlConnection connDb;
    SqlCommand istruzioneSQL;

    public bool Connesso()
    {
        ConnectionState state = connDb.State;
        if (state == ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


public dbHelper() //costruttore con parametro
	{

        connDb=new SqlConnection();

	}
    public void connetti()
    {
        connDb.ConnectionString = "Server=hostingmssql03;Database=promostile_it_PSM;UID=promostile_it_admin;PWD=pwd_db_psm;Connect Timeout=0;";
        connDb.Open();
    } //metodo di connessione
    public void disconnetti()
    {
        connDb.Close();
    } //metodo di disconnessione

    public void assegnaComando(string istruzione) //istruzione di comando SQL
    {
        //MessageBox.Show("dentro assegnacomando");
        istruzioneSQL=new SqlCommand();
        //MessageBox.Show("inizialittato istruzionesql");
        istruzioneSQL.CommandText = istruzione;
       //MessageBox.Show("assegnato comando "+istruzioneSQL.CommandText);
        istruzioneSQL.Connection = connDb;
       // MessageBox.Show("comando assegnato");
    }

    public SqlDataReader estraiDati()
    {
        SqlDataReader rsDati;
        rsDati = istruzioneSQL.ExecuteReader();
        return rsDati;
    }
    public void eseguicomando()
    {
       // MessageBox.Show("dentro eseguicomando");
        istruzioneSQL.ExecuteNonQuery();
        //MessageBox.Show("eseguito comando");
    }

}
