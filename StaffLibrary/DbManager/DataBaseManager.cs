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
        


        public void ExecuteInsertStoredProcedure<T>(T obj) where T : Staff
        {

            //var connection = new SqlConnection(ConnString);
            //var cmd = new SqlCommand("SPInsertStaff", connection);

            //cmd.Parameters.AddWithValue("@Name", obj.Name);
            //cmd.Parameters.AddWithValue("@Code", obj.EmpCode);
            //cmd.Parameters.AddWithValue("@Type", obj.StaffType);
            //cmd.Parameters.AddWithValue("@PhoneNumber", obj.ContactNumber);
            //cmd.Parameters.AddWithValue("@DateOfJoin", obj.DateOfJoin);
            //if (obj is TeachingStaff)
            //{
            //    TeachingStaff staff = (TeachingStaff)Convert.ChangeType(obj, obj.GetType());
            //    cmd.Parameters.AddWithValue("@Subject", staff.Subject);
            //}else if(obj is AdministrativeStaff)
            //{
            //    AdministrativeStaff staff = (AdministrativeStaff)Convert.ChangeType(obj, obj.GetType());
            //    cmd.Parameters.AddWithValue("@Role", staff.Role);
            //}
            //else
            //{
            //    SupportStaff staff = (SupportStaff)Convert.ChangeType(obj, obj.GetType());
            //    cmd.Parameters.AddWithValue("@Department", staff.Department);
            //}
            //connection.Open();
            //connection.ExecuteNonQuery();

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPInsertStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Code", obj.EmpCode);
                    cmd.Parameters.AddWithValue("@Type", obj.StaffType);
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfJoin", obj.DateOfJoin);
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
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
