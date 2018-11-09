using System;
using System.Text;

using Npgsql;
using System.Data;
using NpgsqlTypes;
using Npgsql.TypeMapping;
using System.Security.Cryptography;
namespace CelebrityMotivation.Classes
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string firstName,string lastName, string email, string pass)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = EncryptData(pass);


            


                
        }

        private string EncryptData(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }


        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }


        public static void InsertUser(User user)
        {
            ///tmp/.s.PGSQL.5432
            /// 127.0.0.1:5432
            var connString = "server=127.0.0.1;port=5432;Username=testadmin;Password=password;Database=first_test_db";
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {

                    Console.WriteLine("b4 open");
                    conn.Open();
                    Console.WriteLine("after open");
                    // Insert some data
                    using (var cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO account (first_name,last_name,email,password) VALUES ('"+user.FirstName+"'"+','+ "'" + user.LastName + "'"+ ',' + "'" + user.Email + "'"+ ',' + "'"+user.Password+"'"+")";
                        cmd.ExecuteNonQuery();
                        
                    }
                    conn.Close();
                    // Retrieve all rows
                    //using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
                    //using (var reader = cmd.ExecuteReader())
                      //  while (reader.Read())
                        //    Console.WriteLine(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
        }

    }
}
