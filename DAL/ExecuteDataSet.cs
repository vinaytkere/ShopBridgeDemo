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
    public class ExecuteDataSet
    {
        static string constring = ConnectionString.GetConnectionString();

        public static DataSet Fetch(string command, Hashtable hashtable)
        {
            try
            {
                var ds = new DataSet();

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
                        var da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
