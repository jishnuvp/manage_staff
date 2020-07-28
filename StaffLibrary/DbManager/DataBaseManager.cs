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

        // function for add staff
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

        // function to view staff by category
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
                            name = dr["Name"].ToString();
                            code = dr["Code"].ToString();
                            emptType = temp;
                            number = dr["PhoneNumber"].ToString();
                            dateOfJoin = (DateTime)dr["DateOfJoin"];

                            if (StaffTypes.Teaching == temp)
                            {
                                subject = dr["Subject"].ToString();
                                TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Administrative == temp)
                            {
                                role = dr["Role"].ToString();
                                AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Support == temp)
                            {
                                department = dr["Department"].ToString();
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

        // function to fetch the details of single staff with specified staff type
        public List<Staff> ExecuteViewSingleStaffProcedure(string empCode, StaffTypes type)
        {
            List<Staff> StaffList = new List<Staff>();
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            //object obj;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPViewSingleStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", empCode);
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            var temp = (StaffTypes)Enum.Parse(typeof(StaffTypes), dr["type"].ToString());
                            name = dr["Name"].ToString();
                            code = dr["Code"].ToString();
                            emptType = temp;
                            number = dr["PhoneNumber"].ToString();
                            dateOfJoin = (DateTime)dr["DateOfJoin"];

                            if (StaffTypes.Teaching == temp)
                            {
                                subject = dr["Subject"].ToString();
                                TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Administrative == temp)
                            {
                                role = dr["Role"].ToString();
                                AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Support == temp)
                            {
                                department = dr["Department"].ToString();
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

        //function to delete a staff record

        public bool ExecuteDeleteStaffProcedure(string code)
        {
            bool status;
            int count;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPDeleteStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", code);
                    SqlParameter returnParameter = cmd.Parameters.Add("Counter", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        count = (int)returnParameter.Value;
                        if(count == 1)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (SqlException sqlExc)
                    {
                        status = false;
                    }
                }
            }
            return status;
        }

        // function to update staff info
        public void ExecuteUpdateStaffProcedure<T>(T obj) where T : Staff
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPUpdateStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Code", obj.EmpCode);
                    cmd.Parameters.AddWithValue("@Type", obj.StaffType.ToString());
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
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException sqlExc)
                    {

                    }
                }
            }
        }

        // function to fetch the details of single staff without specifying staff type
        public List<Staff> ExecuteGetStaffInfoProcedure(string empCode)
        {
            List<Staff> StaffList = new List<Staff>();
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            //object obj;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPGetStaffInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", empCode);
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            var temp = (StaffTypes)Enum.Parse(typeof(StaffTypes), dr["type"].ToString());
                            name = dr["Name"].ToString();
                            code = dr["Code"].ToString();
                            emptType = temp;
                            number = dr["PhoneNumber"].ToString();
                            dateOfJoin = (DateTime)dr["DateOfJoin"];

                            if (StaffTypes.Teaching == temp)
                            {
                                subject = dr["Subject"].ToString();
                                TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Administrative == temp)
                            {
                                role = dr["Role"].ToString();
                                AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Support == temp)
                            {
                                department = dr["Department"].ToString();
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

        public List<Staff> ExecuteGetSeniorStaffInfoProcedure(StaffTypes type)
        {
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            DataTable dt = new DataTable();
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPGetAllSeniorStaffInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            var temp = (StaffTypes)Enum.Parse(typeof(StaffTypes), dr["type"].ToString());
                            name = dr["Name"].ToString();
                            code = dr["Code"].ToString();
                            emptType = temp;
                            number = dr["PhoneNumber"].ToString();
                            dateOfJoin = (DateTime)dr["DateOfJoin"];

                            if (StaffTypes.Teaching == temp)
                            {
                                subject = dr["Subject"].ToString();
                                TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Administrative == temp)
                            {
                                role = dr["Role"].ToString();
                                AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin);
                                StaffList.Add(obj);
                            }
                            else if (StaffTypes.Support == temp)
                            {
                                department = dr["Department"].ToString();
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
