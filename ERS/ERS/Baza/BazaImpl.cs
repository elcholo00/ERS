using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza.Model;

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

            return BazaImpl.CountAudit()+1;
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
    }
}
    



