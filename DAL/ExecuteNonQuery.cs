using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExecuteNonQuery
    {
        static string constring = ConnectionString.GetConnectionString();

        public static int InsertUpdateDelete(string command, Hashtable hashtable)
        {
            int rowsAffected = 0;
            try
            {
                using (var con = new SqlConnection(constring))
                {
                    using (var cmd = new SqlCommand(command, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (DictionaryEntry ht in hashtable)
                        {
                            cmd.Parameters.AddWithValue(ht.Key.ToString(), ht.Value);
                        }
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return rowsAffected;
        }
    }
}
