using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShoferiDetyrimBusiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentModelContext"].ConnectionString;

        public List<ShoferiDetyrim> Shoferet(Int64 idKlienti)
        {

            //gjen listen e shofereve qe i perkasin agjensise
            List<ShoferiDetyrim> shof = new List<ShoferiDetyrim>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id_shoferi,EmriShoferi,MbiemriShoferi,Detyrimi FROM Shoferet where Id_klienti = " + idKlienti + " And Shoferet.Aktiv = 'True" + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShoferiDetyrim s = new ShoferiDetyrim();
                    s.id = Convert.ToInt64(reader["Id_shoferi"].ToString());

                    s.detyrimi = Convert.ToDecimal(reader["Detyrimi"].ToString());
                    s.emri = reader["EmriShoferi"].ToString() + " " + reader["MbiemriShoferi"].ToString();
                    shof.Add(s);
                }
                return shof;

            }
        }


        public void modifiko(ShoferiDetyrim shofer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update Shoferet set Detyrimi = " + (shofer.detyrimi - shofer.dorezuar).ToString() + " where Id_shoferi = @Id", conn);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@Id"].Value = shofer.id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }
    }
}
