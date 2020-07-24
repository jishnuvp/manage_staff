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
        public List<Staff> ExecuteViewStaffProcedure(StaffTypes type)
        {
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            DataTable dt = new DataTable();
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPViewCategoryStaff", con))
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try { 
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            var temp = (StaffTypes)Enum.Parse(typeof(StaffTypes), dr["type"].ToString());
                            name = dr["name"].ToString();
                            code = dr["code"].ToString();
                            emptType = temp;
                            number = dr["phone_number"].ToString();
                            dateOfJoin = (DateTime)dr["date_of_join"];

                            if (StaffTypes.Teaching == temp)
                            {
                                subject = dr["subject"].ToString();
                                TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Administrative == temp)
                            {
                                role = dr["role"].ToString();
                                AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Support == temp)
                            {
                                department = dr["department"].ToString();
                                SupportStaff obj = new SupportStaff(name, code, emptType, department, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                        }
                        return StaffList;
                    }
                    catch (SqlException sqlExc)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
