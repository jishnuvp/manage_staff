using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using StaffLibrary;

namespace StaffLibrary.DbManager
{
    public class DataBaseManager
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private SqlConnection Conn = new SqlConnection(ConnString);
        


        public bool ExecuteInsertStoredProcedure<T>(T obj) where T : Staff
        {
            bool flag = true;
            int count = 0;
            
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPInsertStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Code", obj.EmpCode);
                    cmd.Parameters.AddWithValue("@Type", obj.StaffType.ToString());
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfJoin", obj.DateOfJoin);

                    SqlParameter returnParameter = cmd.Parameters.Add("Counter", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    if (obj is TeachingStaff)
                    {
                        TeachingStaff staff = (TeachingStaff)Convert.ChangeType(obj, obj.GetType());
                        cmd.Parameters.AddWithValue("@Subject", staff.Subject);
                        cmd.Parameters.AddWithValue("@Role", "");
                        cmd.Parameters.AddWithValue("@Department", "");
                    }
                    else if (obj is AdministrativeStaff)
                    {
                        AdministrativeStaff staff = (AdministrativeStaff)Convert.ChangeType(obj, obj.GetType());
                        cmd.Parameters.AddWithValue("@Role", staff.Role);
                        cmd.Parameters.AddWithValue("@Department", "");
                        cmd.Parameters.AddWithValue("@Subject", "");
                    }
                    else
                    {
                        SupportStaff staff = (SupportStaff)Convert.ChangeType(obj, obj.GetType());
                        cmd.Parameters.AddWithValue("@Department", staff.Department);
                        cmd.Parameters.AddWithValue("@Subject", "");
                        cmd.Parameters.AddWithValue("@Role", "");
                    }
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        count = (int)returnParameter.Value;
                    }
                    catch (SqlException sqlExc)
                    {

                    }
                    if(count > 0)
                        flag = false;
                    return flag;
                }
            }
        }
    }
}
