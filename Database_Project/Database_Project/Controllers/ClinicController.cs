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
    public class ClinicController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM CLINIC";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString)) 
            using (var comm = new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(comm))
            {
                comm.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Clinic clinic)
        {
            try
            {
                string query = @"INSERT INTO CLINIC VALUES(
                                                            '" + clinic.ClinicName + @"'
                                                           ,'" + clinic.ClinicState + @"'
                                                           ,'" + clinic.ClinicCity + @"'
                                                           ,'" + clinic.ClinicStreet + @"'
                                                           ,'" + clinic.ClinicAreaCode + @"'
                                                           ,'" + clinic.ClinicPhoneNumber + @"')";
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

        public string Put(Clinic clinic)
        {
            try
            {
                string query = @"UPDATE CLINIC SET 
                CLINIC_NAME='"+clinic.ClinicName+@"',
                CLINIC_STATE='"+clinic.ClinicState+ @"',
                CLINIC_CITY='"+clinic.ClinicCity+ @"',
                CLINIC_STREET='" + clinic.ClinicStreet + @"',
                CLINIC_AREA_CODE='" + clinic.ClinicAreaCode + @"',
                CLINIC_PHONE_NUMBER='" + clinic.ClinicPhoneNumber + @"'
                WHERE CLINIC_ID="+clinic.ClinicId+@"";
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
                string query = @"DELETE FROM CLINIC WHERE CLINIC_ID="+id+@"";
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
