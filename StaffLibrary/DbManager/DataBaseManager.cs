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


        // function to view staff by category
        public List<Staff> FetchStaffByCategory(StaffTypes type)
        {
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPViewCategoryStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StaffList = PopulateStaff(reader);
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
        public List<Staff> FetchSingleStaffByType(int id, StaffTypes type)
        {
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPViewSingleStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StaffList = PopulateStaff(reader);
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

        public bool DeleteStaff(int id)
        {
            bool status;
            int count;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPDeleteStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlParameter returnParameter = cmd.Parameters.Add("Counter", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        count = (int)returnParameter.Value;
                        if (count == 1)
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
        public void UpdateStaff<T>(T obj) where T : Staff
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPUpdateStaff", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
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
        public List<Staff> FetchStaffInfo(int id)
        {
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPGetStaffInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StaffList = PopulateStaff(reader);
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

        // function to fetch senior staff info
        public List<Staff> FetchSeniorStaff(StaffTypes type)
        {
            List<Staff> StaffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPGetAllSeniorStaffInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", type.ToString());
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StaffList = PopulateStaff(reader);
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

        // function to populate objects from the result
        public static List<Staff> PopulateStaff(SqlDataReader reader)
        {
            int id;
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            DataTable dt = new DataTable();
            List<Staff> StaffList = new List<Staff>();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    var temp = (StaffTypes)Enum.Parse(typeof(StaffTypes), reader["type"].ToString());
                    name = reader["Name"].ToString();
                    code = reader["Code"].ToString();
                    id = (int)reader["Id"];
                    emptType = temp;
                    number = reader["PhoneNumber"].ToString();
                    dateOfJoin = (DateTime)reader["DateOfJoin"];

                    if (StaffTypes.Teaching == temp)
                    {
                        subject = reader["Subject"].ToString();
                        TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin, id);
                        StaffList.Add(obj);
                    }
                    else if (StaffTypes.Administrative == temp)
                    {
                        role = reader["Role"].ToString();
                        AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin, id);
                        StaffList.Add(obj);
                    }
                    else if (StaffTypes.Support == temp)
                    {
                        department = reader["Department"].ToString();
                        SupportStaff obj = new SupportStaff(name, code, emptType, department, number, dateOfJoin, id);
                        StaffList.Add(obj);
                    }

                }
                reader.NextResult();
            }
            return StaffList;

        }

        // function to check the empcode is exist or not
        public bool CheckCodeExistence(String code)
        {
            bool flag = false;
            int returnValue;

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPCheckStaffExistence", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", code);
                    SqlParameter returnParameter = cmd.Parameters.Add("@IsExist", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        returnValue = (int)returnParameter.Value;
                        if (returnValue != 0) flag = true; 
                        
                        return flag;
                    }
                    catch (SqlException sqlExc)
                    {
                        return flag;
                    }
                }
            }
        }

        // function to insert data into user defined table type
        public void AddStaffToType(List<Staff> StaffList)
        {
            DataTable DT = new DataTable();

            DT.Columns.Add(new DataColumn("Name", typeof(string)));
            DT.Columns.Add(new DataColumn("Code", typeof(string)));
            DT.Columns.Add(new DataColumn("Type", typeof(string)));
            DT.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));
            DT.Columns.Add(new DataColumn("DateOfJoin", typeof(DateTime)));
            DT.Columns.Add(new DataColumn("Subject", typeof(string)));
            DT.Columns.Add(new DataColumn("Role", typeof(string)));
            DT.Columns.Add(new DataColumn("Department", typeof(string)));

            foreach (var staff in StaffList)
            {
                DataRow DR = DT.NewRow();

                DR["Name"] = staff.Name;

                DR["Code"] = staff.EmpCode;

                DR["Type"] = staff.StaffType.ToString();

                DR["PhoneNumber"] = staff.ContactNumber;

                DR["DateOfJoin"] = staff.DateOfJoin;

                if(StaffTypes.Teaching == staff.StaffType)
                {
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    DR["Subject"] = teachingStaff.Subject;
                }
                else if(StaffTypes.Administrative == staff.StaffType)
                {
                    AdministrativeStaff adminStaff = (AdministrativeStaff)staff;
                    DR["Role"] = adminStaff.Role;
                }
                else if(StaffTypes.Support == staff.StaffType)
                {
                    SupportStaff supportStaff = (SupportStaff)staff;
                    DR["Department"] = supportStaff.Department;
                }

                DT.Rows.Add(DR);
            }
            InsertStaffs(DT); //calling datatable method here
        }

        // function to run bulk insertion

        public void InsertStaffs(DataTable dt)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SPStaffInsert", con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@typeSTaffs", dt); // passing Datatable

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
