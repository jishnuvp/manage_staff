using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StaffLibrary.DbManager
{
    public class DataBaseManager
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private SqlConnection Conn = new SqlConnection(ConnString);



        public void ExecuteViewStoredProcedure()
        {
            using (var conn = new SqlConnection(ConnString))
            using (var command = new SqlCommand("SelectAllStaffs", Conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                Conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
