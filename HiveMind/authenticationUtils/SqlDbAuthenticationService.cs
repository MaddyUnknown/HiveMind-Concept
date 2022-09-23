using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using HiveMind.Model;
using HiveMind.ApplicationException;

namespace HiveMind.AuthenticateUtils
{
    public class SqlDbAuthenticationService : BaseAuthenticationService
    {
        private string connectionStr;
        public SqlDbAuthenticationService(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }

        public override bool Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new KeyedException("authentication.input.empty");
            }

            int count=0;
            using (SqlConnection con = new SqlConnection(this.connectionStr))
            {
                
                con.Open();
                var transaction = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(ID) FROM USERS WHERE EMAIL = @email AND PASSWORD = @password", con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", Encrypt(password));
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new KeyedException("sql.error.generic");
                }
            }
            if(count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override string CancelToken(string email)
        {
            throw new KeyedException("implementation.incomplete");
        }

        public override User UserDetials(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new KeyedException("input.invalid.one", email);
            }

            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(this.connectionStr))
            {

                con.Open();
                var transaction = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID, NAME, EMAIL FROM USERS WHERE EMAIL = @email", con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        User user = new User();
                        user.Name = sqlReader["NAME"].ToString();
                        user.Email = sqlReader["EMAIL"].ToString();
                        try
                        {
                            user.Id = Convert.ToInt32(sqlReader["ID"].ToString());
                        }
                        catch
                        {
                            user.Id = -1;
                        }
                        users.Add(user);
                    }
                    sqlReader.Close();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new KeyedException("sql.error.generic");
                }
                finally
                {
                    con.Close();
                }
            }

            if (users.Count == 0)
            {
                throw new KeyedException("user.data.notfound.for.email", email);
            }
            else if (users.Count > 1)
            {

                throw new KeyedException("user.data.multiplefound.for.email", email);
            }
            else
            {
                return users[0];
            }
        }

        public override bool UserRegistration(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
            {
                throw new KeyedException("registration.input.empty");
            }

            using (SqlConnection con = new SqlConnection(this.connectionStr))
            {
                con.Open();
                var transaction = con.BeginTransaction();
                SqlCommand queryCmd = new SqlCommand("SELECT COUNT(ID) FROM USERS WHERE EMAIL = @email", con);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO USERS(NAME, EMAIL, PASSWORD) VALUES(@name, @email, @password)", con);
                try
                {
                    queryCmd.Transaction = transaction;
                    insertCmd.Transaction = transaction;


                    queryCmd.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(queryCmd.ExecuteScalar());

                    if(count == 0)
                    {
                        insertCmd.Parameters.AddWithValue("@name", name);
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@password", Encrypt(password));
                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw new KeyedException("sql.error.generic");
                }
                finally
                {
                    con.Close();
                }
            }


        }
    }
}
