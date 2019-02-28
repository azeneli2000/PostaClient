using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class PerdoruesiBusiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentModelContext"].ConnectionString;

        public List<Perdoruesi> Perdoruesit
        {
            get
            {
                List<Perdoruesi> perd = new List<Perdoruesi>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Klienti", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Perdoruesi p = new Perdoruesi();
                        p.id = Convert.ToInt64(reader["Id_klienti"].ToString());
                        p.perdoruesi = reader["Perdoruesi"].ToString(); 
                        p.password = reader["Password"].ToString();
                        p.adresa = reader["Adresa"].ToString();
                        p.agjensi = Convert.ToBoolean(reader["Agjensi"].ToString());
                        p.aktiv = Convert.ToBoolean(reader["Aktiv"].ToString());
                        p.emri = reader["Emri"].ToString();
                        p.shenime = reader["Shenime"].ToString();
                        p.idMagazina = Convert.ToInt64(reader["Id_magazina"].ToString());
                        p.detyrimi = Convert.ToDecimal(reader["Detyrimi"].ToString());
                        perd.Add(p);
                    }
                    return perd;
                }
            }
        }
    }
}
