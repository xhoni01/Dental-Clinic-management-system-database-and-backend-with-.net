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
    public class LoginController : ApiController
    {
        public string Post(LoginEmployee login)
        {
            try
            {
                string query = @"INSERT INTO LOGIN_EMPLOYEE VALUES(
                                                            '" + login.username + @"'
                                                           ,'" + login.EmployeeId + @"'
                                                           ,'" + login.EmployeePassword + @"'
                                                           ,'" + login.EmployeeRole + @"')";
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

        public string Put(LoginEmployee login)
        {
            try
            {
                string query = @"UPDATE LOGIN_EMPLOYEE SET 
                EMPLOYEE_USERNAME='" + login.username + @"',
                EMPLOYEE_PASSWORD='" + login.EmployeePassword + @"',
                EMPLOYEE_ROLE='" + login.EmployeeRole + @"'
                WHERE EMPLOYEE_ID=" + login.EmployeeId + @"";
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
    }
}
