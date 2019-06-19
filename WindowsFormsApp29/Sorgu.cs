using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp29
{
    class Sorgu
    {
        #region 1
        public static string cs = ConfigurationManager.ConnectionStrings["Onder"].ConnectionString;
        public static DataTable SQLSorguCalistir(string SQL)
        {
            SqlConnection con = null;
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(SQL, con);
                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = cmd;
                ada.Fill(dt);
                con.Open();
                //dt.Load(cmd.ExecuteReader());
            }
            catch (Exception hata)
            {
                throw new Exception("sorgu çalıştırılamadı: " + hata.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion 1
        #region 2
        public static int SQLNonSorguCalistir(string SQL)
        {
            SqlConnection con = null;
            int sonuc = -1;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                sonuc = cmd.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                
                return -1;
                throw new Exception("Sorgu hatası" + hata.Message);
            }
            finally
            {
                con.Close();
            }
            return sonuc;
        }
        #endregion 2
    }
}