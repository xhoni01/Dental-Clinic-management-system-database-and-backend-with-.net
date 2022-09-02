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
    public class DentistController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT EMPLOYEE_F_NAME, EMPLOYEE_L_NAME, EMPLOYEE_DOB,EMPLOYEE_STATE, EMPOYEE_CITY,EMPLOYEE_STREET,EMPLOYEE_AREA_CODE,EMPLOYEE_PHONE_NUMBER,
            DENTIST_ROLE, CLINIC_NAME FROM DENTIST JOIN EMPLOYEE ON DENTIST.EMPLOYEE_ID=EMPLOYEE.EMPLOYEE_ID 
            JOIN CLINIC ON EMPLOYEE.CLINIC_ID=CLINIC.CLINIC_ID";
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
        public string Post(Dentist dentist)
        {
            try
            {
                string query = @"INSERT INTO DENTIST VALUES(
                                                            '" + dentist.DentistId + @"'
                                                           ,'" + dentist.EmployeeId + @"'
                                                           ,'" + dentist.DentistRole + @"'')";
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

        public string Put(Dentist dentist)
        {
            try
            {
                string query = @"UPDATE DENTIST SET 
                DENTIST_ID='" + dentist.DentistId + @"',
                DENTIST_ROLE='" + dentist.DentistRole + @"',
                WHERE EMPLOYEE_ID=" + dentist.EmployeeId + @"";
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
                string query = @"DELETE FROM DENTIST WHERE EMPLOYEE_ID=" + id + @"";
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
                return ex.Message;
            }
        }
    }
}
