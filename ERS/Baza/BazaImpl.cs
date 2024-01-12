using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comon.Model;

namespace Baza
{
    public class BazaImpl : IBaza
    {
        private static SqlConnection connection = null;
        private static string connectionString;
        private static BazaImpl instance = null;

        public BazaImpl()
        {
            GetConnection();

        }

        public static BazaImpl GetBaza()
        {
            if (instance == null)
            {
                instance = new BazaImpl();
            }

            return instance;
        }

        public bool Konektuj()
        {
            try
            {
                connectionString = "Data Source=DESKTOP-IG1L4L1\\SQLEXPRESS;Initial Catalog=ProjekatBaza;Integrated Security=True;";
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void GetConnection()
        {
            if (connection == null)
            {
                if (Konektuj())
                {
                    Console.WriteLine("Uspesno smo se konektovali");
                }
                else
                {
                    Console.WriteLine("Nismo uspostavili konekciju");
                }
            }

        }
        public static int CountAudit()
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Select count(*) from Audit";




                return (int)command.ExecuteScalar();

            }

        }

        public int getNextAuditId()
        {

            return BazaImpl.CountAudit() + 1;
        }
        public void DeleteAudit(int id)
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Delete from Audit where AuditId=@AuditId";


                command.Parameters.AddWithValue("@AuditId", id);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteAllAudit()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM audit";
                command.ExecuteNonQuery();
            }
        }
        public void UpdateAudit(Audit d, int id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Update Audit set VremePokusajaUcitavanja=@VremePokusaja,ImeFajlova=@ImeFajlova, Lokacija=@Lokacija1, BrojRedova=@BrojRedova1 where AuditId=@AuditId";

                command.Parameters.AddWithValue("@VremePokusaja", d.Vreme_Pokusaja_ucitavanja);
                command.Parameters.AddWithValue("@ImeFajlova", d.Ime);
                command.Parameters.AddWithValue("@Lokacija1", d.Lokacija);
                command.Parameters.AddWithValue("@BrojRedova", d.brojRedova);
                command.Parameters.AddWithValue("@AuditId1", id);

                command.ExecuteNonQuery();
            }
        }
        public void InsertAudit(Audit d)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Audit (VremePokusajaUcitavanja,ImeFajlova,Lokacija,BrojRedova) VALUES (@VremePokusaja,@ImeFajlova,@Lokacija1,@BrojRedova)";


                command.Parameters.AddWithValue("@VremePokusaja", d.Vreme_Pokusaja_ucitavanja);
                command.Parameters.AddWithValue("@ImeFajlova", d.Ime);
                command.Parameters.AddWithValue("@Lokacija1", d.Lokacija);
                command.Parameters.AddWithValue("@BrojRedova", d.brojRedova);


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }

        }

        public List<Audit> GetAudit()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Audit> audits = new List<Audit>();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Audit";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Audit audit = new Audit(reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                        audits.Add(audit);
                    }
                    return audits;
                }

            }

        }
        public List<Prognoza> ProgGeoPodrucje(DateTime datum, string geoOblast)
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Prognoza> prognoze = new List<Prognoza>();
                command.Connection = connection;
                command.CommandText = "SELECT Sat, PPotrosnja FROM Prognoza where Datum = @datum and GeografskaOblast = @GeografskaOblast and OPotrosnja = 0";
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@GeografskaOblast", geoOblast);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int Sat = reader.GetInt32(0);
                        float PPotrosnja = (float)reader.GetDouble(1);

                        Prognoza p = new Prognoza();
                        p.Sat = Sat;
                        p.PPotrosnja = PPotrosnja;
                        p.GeografskaOblast = geoOblast;
                        p.Datum = datum;
                        p.OPotrosnja = 0;
                        p.Odstupanje = 0;
                        prognoze.Add(p);
                    }
                    return prognoze;
                }

            }
        }

        public List<Prognoza> OstvGeoPodrucje(DateTime datum,string geoOblast)
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Prognoza> prognoze = new List<Prognoza>();
                command.Connection = connection;
                command.CommandText = "SELECT Sat, OPotrosnja FROM Prognoza where Datum = @datum and GeografskaOblast = @GeografskaOblast and PPotrosnja = 0";
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@GeografskaOblast", geoOblast);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                       
                        int Sat = reader.GetInt32(0);
                        float OPotrosnja =(float) reader.GetDouble(1);
                        
                        Prognoza p = new Prognoza();
                        p.Sat= Sat;
                        p.OPotrosnja= OPotrosnja;
                        p.GeografskaOblast= geoOblast;
                        p.Datum = datum;
                        p.PPotrosnja = 0;
                        p.Odstupanje = 0;
                        prognoze.Add(p);
                    }
                    return prognoze;
                }

            }
        }

        public List<GeoPodrucje> evidencijaGeoPodrucja()
        {
            using (SqlCommand command = new SqlCommand())
            {
                List<GeoPodrucje> oblasti = new List<GeoPodrucje>();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM GeografskaPodrucja";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ime = reader.GetString(1);
                        string sifra = reader.GetString(2);
                        GeoPodrucje GOblast = new GeoPodrucje(sifra,ime,0);
                        oblasti.Add(GOblast);
                    }
                    return oblasti;
                }

            }
        }



        public void InsertGeoPodrucje(GeoPodrucje GPodrucje)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO GeografskaPodrucja (Ime,Sifra) VALUES (@Ime,@Sifra)";


                command.Parameters.AddWithValue("@Ime", GPodrucje.Ime);
                command.Parameters.AddWithValue("@Sifra", GPodrucje.Sifra);
               



                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }

        }

        public void UpdateGeoPodrucje(GeoPodrucje Gpodrucje)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE audit SET sifra=@sifra,ime=@ime WHERE sifra = @sifra";
                command.Parameters.AddWithValue("@sifra", Gpodrucje.Sifra);
                command.Parameters.AddWithValue("@ime", Gpodrucje.Ime);


                command.ExecuteNonQuery();
            }
        }

        public void DeleteGeoPodrucje(int sifra)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM GeografskaOblast WHERE sifra = @sifra";
                command.Parameters.AddWithValue("@sifra", sifra);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllGeoPodrucje()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM GeografskaOblast";
                command.ExecuteNonQuery();
            }
        }

        public List<GeoPodrucje> GetGeografskaOblast()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<GeoPodrucje> oblasti = new List<GeoPodrucje>();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM GeografskaPodrucja";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GeoPodrucje GOblast = new GeoPodrucje(reader.GetString(1), reader.GetString(2), 0);
                        oblasti.Add(GOblast);
                    }
                    return oblasti;
                }

            }


        }

        public void InsertPrognoza(Prognoza prognoza)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Prognoza(GeografskaOblast,Datum,Sat,PPotrosnja, OPotrosnja, Odstupanje) VALUES(@GeografskaOblast, @Datum, @Sat, @PPotrosnja, @OPotrosnja, @Odstupanje)";

                command.Parameters.AddWithValue("@GeografskaOblast", prognoza.GeografskaOblast);
                command.Parameters.AddWithValue("@Datum", prognoza.Datum);
                command.Parameters.AddWithValue("@Sat", prognoza.Sat);
                command.Parameters.AddWithValue("@PPotrosnja", prognoza.PPotrosnja);
                command.Parameters.AddWithValue("@OPotrosnja", prognoza.OPotrosnja);
                command.Parameters.AddWithValue("@Odstupanje", prognoza.Odstupanje);




                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }

        public void UpdatePrognoza(Prognoza prognoza)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE prognoza SET GeografskaOblast=@GeografskaOblast,Datum=@Datum, Sat=@Sat, PrognoziranaP=@PPotrosnja, OstvarenaP=@OPotrosnja, Odstupanje=@Odstupanje WHERE GeografskaOblast = @GeografskaOblast";
                command.Parameters.AddWithValue("@GeografskaOblast", prognoza.GeografskaOblast);
                command.Parameters.AddWithValue("@Datum", prognoza.Datum);
                command.Parameters.AddWithValue("@Sat", prognoza.Sat);
                command.Parameters.AddWithValue("@PPotrosnja", prognoza.PPotrosnja);
                command.Parameters.AddWithValue("@OPotrosnja", prognoza.OPotrosnja);
                command.Parameters.AddWithValue("@Odstupanje", prognoza.Odstupanje);


                command.ExecuteNonQuery();
            }
        }

        public void DeletePrognoza(string GeoPodrucje)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM Prognoza WHERE GeografskaOblast = @GeografskaOblast";
                command.Parameters.AddWithValue("@GeografskaOblast", GeoPodrucje);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllPrognoza()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM Prognoza";
                command.ExecuteNonQuery();
            }
        }
        public List<Prognoza> GetPrognoza()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Prognoza> prognoze = new List<Prognoza>();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Prognoza";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Prognoza prognoza = new Prognoza(reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), (float)reader.GetDouble(4), (float)reader.GetDouble(5), (float)reader.GetDouble(6)); 
                        prognoze.Add(prognoza);
                    }
                    return prognoze;
                }

            }
        }


    }
}
    



