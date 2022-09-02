using Database_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Database_Project.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM EMPLOYEE FULL OUTER JOIN LOGIN_EMPLOYEE ON EMPLOYEE.EMPLOYEE_ID = LOGIN_EMPLOYEE.EMPLOYEE_ID";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString))
            using (var comm = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(comm))
            {
                comm.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Employee employee)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[EMPLOYEE]
                                                             ([EMPLOYEE_F_NAME]
                                                             ,[EMPLOYEE_L_NAME]
                                                             ,[EMPLOYEE_DOB]
                                                             ,[EMPLOYEE_STATE]
                                                             ,[EMPOYEE_CITY]
                                                             ,[EMPLOYEE_STREET]
                                                             ,[EMPLOYEE_AREA_CODE]
                                                             ,[EMPLOYEE_PHONE_NUMBER]
                                                             ,[CLINIC_ID]) VALUES(
                                                            '" + employee.EmployeeFName + @"'
                                                           ,'" + employee.EmployeeLName + @"'
                                                           ,'" + employee.EmployeeDOB + @"'
                                                           ,'" + employee.EmployeeState + @"'
                                                           ,'" + employee.EmployeeCity + @"'
                                                           ,'" + employee.EmployeeStreet + @"'
                                                           ,'" + employee.EmployeeAreaCode + @"'
                                                           ,'" + employee.EmployeePhoneNumber + @"'
                                                           ,'" + employee.ClinicId + @"')";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Put(Employee employee)
        {
            try
            {
                string query = @"UPDATE EMPLOYEE SET 
                EMPLOYEE_F_NAME='" + employee.EmployeeFName + @"',
                EMPLOYEE_L_NAME='" + employee.EmployeeLName + @"',
                EMPLOYEE_DOB='" + employee.EmployeeDOB + @"',
                EMPLOYEE_STATE='" + employee.EmployeeState+ @"',
                EMPOYEE_CITY='" + employee.EmployeeCity + @"',
                EMPLOYEE_STREET='" + employee.EmployeeStreet + @"',
                EMPLOYEE_AREA_CODE='" + employee.EmployeeAreaCode + @"',
                EMPLOYEE_PHONE_NUMBER='" + employee.EmployeePhoneNumber + @"',
                CLINIC_ID='" + employee.ClinicId + @"'
                WHERE EMPLOYEE_ID=" + employee.EmployeeId + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString))
                using (var comm = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(comm))
                {
                    comm.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                Console.WriteLine("This is C#");
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM EMPLOYEE WHERE EMPLOYEE_ID=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString))
                using (var comm = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(comm))
                {
                    comm.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
