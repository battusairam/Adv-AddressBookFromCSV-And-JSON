using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class DataBaseService
    {
        private const string connectionString = "data source=DESKTOP-HDRGJGO\\SQLEXPRESS; initial catalog=AddressBookDB; integrated security=true;";

        public void CreateDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-HDRGJGO\\SQLEXPRESS; initial catalog=master; integrated security=true;");
                con.Open();

                string query = "create database AddressBookDB;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Base Created Sussfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void CreateTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=AddressBookDB; integrated security=true;");
                con.Open();

                string query = "create table AddressBookData(" +
                 "Columns_Id int identity(1,1) Primary key," +
                 "FirstName varchar(200)," +
                 "LastName varchar(100)," +
                 "Address varchar(200)," +
                 "City varchar(200)," +
                 "State varchar(200)," +
                 "Zip int," +
                 "Phone varchar(500)," +
                 "Email varchar(500)" +
                 ")";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sussessfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void InsertContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO AddressBookData (FirstName, LastName, Address, City, State, Zip, Phone, Email) " +
                                   "VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @Phone, @Email)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Address", contact.Address);
                    cmd.Parameters.AddWithValue("@City", contact.City);
                    cmd.Parameters.AddWithValue("@State", contact.State);
                    cmd.Parameters.AddWithValue("@Zip", contact.Zip); 
                    cmd.Parameters.AddWithValue("@Phone", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", contact.Email);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Contact inserted successfully in the database!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while inserting contact into the database: {ex.Message}");
            }
        }
    }

}
