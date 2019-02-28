using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class ShoferiBusiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentModelContext"].ConnectionString;

        public List<Shoferi> Shoferet(Int64 idKlienti)
        {
            
            //gjen listen e shofereve qe i perkasin agjensise
                List<Shoferi> shof = new List<Shoferi>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id_shoferi,EmriShoferi,MbiemriShoferi FROM Shoferet where Id_klienti = " + idKlienti +" And Shoferet.Aktiv = 'True" + "'", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Shoferi s = new Shoferi();
                        s.id = Convert.ToInt64(reader["Id_shoferi"].ToString());
                      
                       
                        s.emri = reader["EmriShoferi"].ToString() + " " + reader["MbiemriShoferi"].ToString();
                        shof.Add(s);
                    }
                    return shof;
                
            }
        }
    }
}
