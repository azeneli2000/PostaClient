using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class OrderBusiness
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["StudentModelContext"].ConnectionString + "MultipleActiveResultSets = true;";
        public List<Order> Orders
        {
            get
            {
                List<Order> ord = new List<Order>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sqlstring = "SELECT Orderid ,Adresa_marresi,Pickup,Driverid_pickup,Ora_pickup,Kthyer_mag,Driverid_kthyer,Ora_kthyer_mag,Magazinaid,Dorezuar,Driverid_dorezimi,Ora_dorezimi,Paguan,Klientiid,Llojiid,Zonaid,Cmimi,Valuta,Data,Pesha,Shenime,Telefon,Zonat.Emertimi As ZonatE,Llojet.Emertimi As LlojetE,Barcode,BarCodeImage,Emri_marresi,Vlera FROM Orders,Llojet,Zonat Where YEAR(Data) = " + DateTime.UtcNow.Year + " AND MONTH(Data) = " + DateTime.UtcNow.Month + " AND DAY(Data) = " + DateTime.UtcNow.Day + " AND Orders.Llojiid = Llojet.Id_lloji AND Orders.Zonaid = Zonat.Id_Zona";

                    SqlCommand cmd = new SqlCommand(sqlstring, conn);

                    //SqlCommand cmd = new SqlCommand("SELECT * FROM Orders Where YEAR(Data) = " + DateTime.UtcNow.Year + " AND MONTH(Data) = " + DateTime.UtcNow.Month + " AND DAY(Data) = " + DateTime.UtcNow.Day, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Order o = new Order();
                        o.idOrder = Convert.ToInt64(reader["Orderid"].ToString());
                        o.adresaMarresi = reader["Adresa_marresi"].ToString();
                        o.pickUp = Convert.ToBoolean(reader["Pickup"].ToString());

                        if (reader["Driverid_pickup"].ToString() != "")
                            o.DriverIdPickUp = Convert.ToInt64(reader["Driverid_pickup"].ToString());
                        if (reader["Ora_pickup"].ToString() != "")
                            o.OraPickUp = Convert.ToDateTime(reader["Ora_pickup"].ToString());
                        if (reader["Kthyer_mag"].ToString() != "")
                            o.KthyerMag =  Convert.ToBoolean(reader["Kthyer_mag"].ToString());
                        if (reader["Driverid_kthyer"].ToString() != "")
                            o.DriverIdKthyerMag = Convert.ToInt64(reader["Driverid_kthyer"].ToString());
                        if (reader["Ora_kthyer_mag"].ToString() != "")
                            o.OraKthyerMag = Convert.ToDateTime(reader["Ora_kthyer_mag"].ToString());
                        if (reader["Magazinaid"].ToString() != "")
                            o.IdMagazina = Convert.ToInt64(reader["Magazinaid"].ToString());
                        o.Dorzuar = Convert.ToBoolean(reader["Dorezuar"].ToString());
                        if (reader["Driverid_dorezimi"].ToString() != "")
                            o.DriverIdDorezimi = Convert.ToInt64(reader["Driverid_dorezimi"].ToString());
                        if (reader["Ora_dorezimi"].ToString() != "")
                            o.OraDorezimi = Convert.ToDateTime(reader["Ora_dorezimi"].ToString());
                        o.Paguan = reader["Paguan"].ToString();
                        o.IdKlienti = Convert.ToInt64(reader["Klientiid"].ToString());
                        o.IdLloji = Convert.ToInt64(reader["Llojiid"].ToString());
                        o.IdZona = Convert.ToInt64(reader["Zonaid"].ToString());
                        o.Cmimi = Convert.ToDecimal(reader["Cmimi"].ToString());
                        o.Valua = reader["Valuta"].ToString();
                        o.DataOraOrder = Convert.ToDateTime(reader["Data"].ToString());
                        o.ZonaEmertimi = reader["ZonatE"].ToString();
                        o.LlojiEmertimi = reader["LlojetE"].ToString();
                        o.Telefon = reader["Telefon"].ToString();
                        o.Pesha = Convert.ToDecimal(reader["Pesha"].ToString());
                        o.EmriMarresi = reader["Emri_marresi"].ToString();
                        o.Barcode = reader["Barcode"].ToString();
                        o.ImageUrl = reader["BarCodeImage"] != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])reader["BarCodeImage"]) : "";
                        o.Vlera = Convert.ToDecimal(reader["Vlera"].ToString());
                        ord.Add(o);
                    }
                    conn.Close();
                    return ord;
                }
            }
        }
        public List<Order> OrdersByDate(DateTime dateF, DateTime dataM)
        {
            List<Order> ord = new List<Order>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlstring = "SELECT Orderid ,Adresa_marresi,Pickup,Driverid_pickup,Ora_pickup,Kthyer_mag,Driverid_kthyer,Ora_kthyer_mag,Magazinaid,Dorezuar,Driverid_dorezimi,Ora_dorezimi,Paguan,Klientiid,Llojiid,Zonaid,Cmimi,Valuta,Data,Pesha,Shenime,Telefon,Zonat.Emertimi As ZonatE,Llojet.Emertimi As LlojetE,Barcode,BarCodeImage,Emri_marresi,Vlera FROM Orders,Llojet,Zonat Where Data >= '" + dateF.Year + "-" + dateF.Month + "-" + dateF.Day + "' AND Data <= '" + dataM.Year + "-" + dataM.Month + "-" + dataM.Day + " 23:59:59' AND Orders.Llojiid = Llojet.Id_lloji AND Orders.Zonaid = Zonat.Id_Zona";
                SqlCommand cmd = new SqlCommand(sqlstring, conn);
                // SqlCommand cmd = new SqlCommand("SELECT * FROM Orders Where Data >= '" + dateF.Year + "-" + dateF.Month+  "-" + dateF.Day +"' AND Data <= '"  + dataM.Year + "-" + dataM.Month + "-" + dataM.Day + " 23:59:59'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order o = new Order();
                    o.idOrder = Convert.ToInt64(reader["Orderid"].ToString());
                    o.adresaMarresi = reader["Adresa_marresi"].ToString();
                    o.pickUp = Convert.ToBoolean(reader["Pickup"].ToString());

                    if (reader["Driverid_pickup"].ToString() != "")
                        o.DriverIdPickUp = Convert.ToInt64(reader["Driverid_pickup"].ToString());
                    if (reader["Ora_pickup"].ToString() != "")
                        o.OraPickUp = Convert.ToDateTime(reader["Ora_pickup"].ToString());
                    if (reader["Kthyer_mag"].ToString() != "")
                        o.KthyerMag = o.pickUp = Convert.ToBoolean(reader["Kthyer_mag"].ToString());
                    if (reader["Driverid_kthyer"].ToString() != "")
                        o.DriverIdKthyerMag = Convert.ToInt64(reader["Driverid_kthyer"].ToString());
                    if (reader["Ora_kthyer_mag"].ToString() != "")
                        o.OraKthyerMag = Convert.ToDateTime(reader["Ora_kthyer_mag"].ToString());
                    if (reader["Magazinaid"].ToString() != "")
                        o.IdMagazina = Convert.ToInt64(reader["Magazinaid"].ToString());
                    o.Dorzuar = Convert.ToBoolean(reader["Dorezuar"].ToString());
                    if (reader["Driverid_dorezimi"].ToString() != "")
                        o.DriverIdDorezimi = Convert.ToInt64(reader["Driverid_dorezimi"].ToString());
                    if (reader["Ora_dorezimi"].ToString() != "")
                        o.OraDorezimi = Convert.ToDateTime(reader["Ora_dorezimi"].ToString());
                    o.Paguan = reader["Paguan"].ToString();
                    o.IdKlienti = Convert.ToInt64(reader["Klientiid"].ToString());
                    o.IdLloji = Convert.ToInt64(reader["Llojiid"].ToString());
                    o.IdZona = Convert.ToInt64(reader["Zonaid"].ToString());
                    o.Cmimi = Convert.ToDecimal(reader["Cmimi"].ToString());
                    o.Valua = reader["Valuta"].ToString();
                    o.DataOraOrder = Convert.ToDateTime(reader["Data"].ToString());
                    o.ZonaEmertimi = reader["ZonatE"].ToString();
                    o.LlojiEmertimi = reader["LlojetE"].ToString();
                    o.Telefon = reader["Telefon"].ToString();
                    o.Shenime = reader["Shenime"].ToString();
                    o.Pesha = Convert.ToDecimal(reader["Pesha"].ToString());
                    o.EmriMarresi = reader["Emri_marresi"].ToString();
                    //barrkodi
                    o.Barcode = reader["Barcode"].ToString();
                    o.ImageUrl = reader["BarCodeImage"] != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])reader["BarCodeImage"]) : "";
                    o.Vlera = Convert.ToDecimal(reader["Vlera"].ToString());

                    ord.Add(o);
                }
                conn.Close();

                return ord;
            }

            

        }


        public void shto(Order ord)
        {
            Utility u = new Utility();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Int64 i = Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString());
                string sqlInsert = "insert into Orders (Adresa_marresi,Pickup,Driverid_pickup,Ora_pickup,Kthyer_mag,Driverid_kthyer,Ora_kthyer_mag,Magazinaid,Dorezuar,Driverid_dorezimi,Ora_dorezimi,Paguan,Klientiid,Llojiid,Zonaid,Cmimi,Valuta,Data) values ('" + ord.adresaMarresi + "','False',null,null,'False',null,null,null,'False',null,null,'" + ord.Paguan + "'," + Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString()) + "," + ord.IdLloji + "," + 1007 + ",100,'Lek',04/12/20018)";
                string a = "";
                string sqlUpdateCmimin = "update Klienti set Detyrimi = " + (u.GetDetyrimiKlienti(Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString())) + ord.Cmimi).ToString() + "where Id_klienti = " + Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString());
                barcodecs bar = new barcodecs();
                SqlCommand cmd = new SqlCommand("insert into Orders (Adresa_marresi,Pickup,Driverid_pickup,Ora_pickup,Kthyer_mag,Driverid_kthyer,Ora_kthyer_mag,Magazinaid,Dorezuar,Driverid_dorezimi,Ora_dorezimi,Paguan,Klientiid,Llojiid,Zonaid,Cmimi,Valuta,Data,Pesha,Telefon,Shenime,Barcode,BarCodeImage,Emri_marresi,Vlera,KonfirmimShoferi,KthyerNgaKlienti) values ('" + ord.adresaMarresi + "','False',null,null,'False',null,null,null,'False',null,null,'" + ord.Paguan + "'," + Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString()) + "," + ord.IdLloji + "," + ord.IdZona + "," + ord.Cmimi + ",'LEK','" + DateTime.Now + "'," + ord.Pesha + ",@telefon,@shenime,@barcode,@barcodeimage,@emrimarresi,@vlera,'False','False')", conn);
                SqlCommand cmdUpdateCmimi = new SqlCommand(sqlUpdateCmimin,conn);
                cmd.Parameters.Add("@adresaMarresi", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@adresaMarresi"].Value = ord.adresaMarresi;

                cmd.Parameters.Add("@paguan", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@paguan"].Value = ord.Paguan;

                cmd.Parameters.Add("@idLloji", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@idLloji"].Value = ord.IdLloji;

                cmd.Parameters.Add("@idZona", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@idZona"].Value = ord.IdZona;

                cmd.Parameters.Add("@cmimi", System.Data.SqlDbType.Decimal);
                cmd.Parameters["@cmimi"].Value = ord.Cmimi;

                cmd.Parameters.Add("@telefon", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@telefon"].Value = ord.Telefon;


                cmd.Parameters.Add("@shenime", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@shenime"].Value = (object)ord.Shenime ?? DBNull.Value;
                //  cmd.Parameters["@shenime"].Value = ord.Shenime;

                cmd.Parameters.Add("@barcode", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@barcode"].Value = bar.generateBarcode();

                cmd.Parameters.Add("@barcodeimage", System.Data.SqlDbType.Image);
                cmd.Parameters["@barcodeimage"].Value = bar.getBarcodeImage(bar.generateBarcode(), "");

                cmd.Parameters.Add("@emrimarresi", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@emrimarresi"].Value = ord.EmriMarresi;

                cmd.Parameters.Add("@vlera", System.Data.SqlDbType.Decimal);
                cmd.Parameters["@vlera"].Value = ord.Vlera;

                conn.Open();
                cmd.ExecuteNonQuery();
                cmdUpdateCmimi.ExecuteNonQuery();

                conn.Close();
            }
        }

        public string gjej_cmimin (string idLloji,string idZona,string pesha)
            {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //keto parmetra mund te memorizohen nje xml
                int kgStanded = 2;
                decimal lekeKgShtese = 10;

                string sqlstringCmimi = "Select Cmimi from Cmimet Where Id_zona = " + Convert.ToInt64( idZona) + " And Id_lloji = " + Convert.ToInt64(idLloji)  ;
                SqlCommand cmdCmimi = new SqlCommand(sqlstringCmimi, conn);
                string sqlstringSkonto = "Select Perqindje_skonto from Skonto Where Zonaid = " + Convert.ToInt64(idZona) + " And Llojiid = " + Convert.ToInt64(idLloji) + " And Klientiid = " + Convert.ToInt64(HttpContext.Current.Session["idklienti"].ToString());
                SqlCommand cmdSkonto = new SqlCommand(sqlstringCmimi, conn);
                conn.Open();
                decimal p = Convert.ToDecimal( cmdCmimi.ExecuteScalar());
                decimal s = Convert.ToDecimal(cmdSkonto.ExecuteScalar());
                conn.Close();
                if (Convert.ToDecimal(pesha) < lekeKgShtese)
                {
                 
                    return ((p - p * s).ToString());
                  
                }
                else
                {
                   
                    return (((lekeKgShtese * (Convert.ToDecimal(pesha) - kgStanded) + p) - (lekeKgShtese * (Convert.ToDecimal(pesha) - kgStanded) + p) * s).ToString());

                }
            }


            }



    }
}
