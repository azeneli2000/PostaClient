using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class Utility
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentModelContext"].ConnectionString + "MultipleActiveResultSets = true;";

        public List<Lloji> GetLlojet()
        {
            List<Lloji> zo = new List<Lloji>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Llojet", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lloji l = new Lloji();
                    l.id = Convert.ToInt64(reader["Id_lloji"].ToString());
                    l.emri = reader["Emertimi"].ToString();

                    zo.Add(l);
                }
                conn.Close();
                return zo;

            }
        }


        public List<Zona> GetZonat()
        {

            List<Zona> zo = new List<Zona>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Zonat", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Zona z = new Zona();
                    z.id = Convert.ToInt64(reader["Id_Zona"].ToString());
                    z.emri = reader["Emertimi"].ToString();

                    zo.Add(z);
                }
                conn.Close();
                return zo;
            }
        }
        public decimal GetDetyrimiKlienti(Int64 idKlienti)
        {

            List<Zona> zo = new List<Zona>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select Detyrimi from Klienti Where Id_klienti = " + idKlienti , conn);
                conn.Open();
                decimal det =  (Convert.ToDecimal( cmd.ExecuteScalar()));
              
                conn.Close();
                return det;
            }
        }

    }
}
