using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace RekawekApp
{
    public class DataAccessLayer
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudenciConnectionString"].ConnectionString);

        public DataSet DisplayData() {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Studenci");
            cmd.Connection = conn;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds;

        }

        public DataSet DisplayData(int id)
        {

            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Studenci WHERE Id_student = '{0}'", id));
            cmd.Connection = conn;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds;

        }

        public bool InsertData(string imie, string nazwisko, string numeralbumu)
        {
            //SqlCommand command = new SqlCommand(string.Format("INSERT INTO [dbo].[PACJENT] ([imie],[nazwisko],[PESEL],[Telefon]) VALUES('{0}','{1}','{2}','{3}')", this.Imie, this.Nazwisko, this.PESEL, this.Telefon), connection))
            //SqlCommand coooo = new SqlCommand(string.Format("INSERT INTO Studenci  ([Imie], [Nazwisko], [NumerAlbumu]) VALUES ('{0}', '{1}', '{2}')", imie, nazwisko, numeralbumu));
            string CmdString = "INSERT INTO Studenci (Imie, Nazwisko, NumerAlbumu) VALUES (@imie, @nazwisko, @numeralbumu)";
            SqlCommand command = new SqlCommand(CmdString, conn);
            command.Parameters.AddWithValue("@imie", imie);
            command.Parameters.AddWithValue("@nazwisko", nazwisko);
            command.Parameters.AddWithValue("@numeralbumu", numeralbumu);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool DeleteData(int id) {

            string CmdString = "DELETE FROM Studenci WHERE Id_student=@id";
            SqlCommand command = new SqlCommand(CmdString, conn);

            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            int ilosc = command.ExecuteNonQuery();
            if (ilosc > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool UpdateData(int id, string imie, string nazwisko, string numeralbumu)
        {

            string CmdString = "Update Studenci SET Imie=@imie, Nazwisko=@nazwisko, NumerAlbumu=@numeralbumu WHERE Id_student=@id";
            SqlCommand command = new SqlCommand(CmdString, conn);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@imie", imie);
            command.Parameters.AddWithValue("@nazwisko", nazwisko);
            command.Parameters.AddWithValue("@numeralbumu", numeralbumu);
            conn.Open();
            int ilosc = command.ExecuteNonQuery();
            if (ilosc > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}