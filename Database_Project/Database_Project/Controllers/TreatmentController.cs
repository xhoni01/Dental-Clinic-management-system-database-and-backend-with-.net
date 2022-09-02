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
    public class TreatmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT TREATMENT_DESCRIPTION, TREATMENT_COST FROM TREATMENT";
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
        public string Post(Treatment tt)
        {
            try
            {
                string query = @"INSERT INTO TREATMENT VALUES(
                                                            '" + tt.TreatmentDescription + @"'
                                                           ,'" + tt.TreatmentCost+ @"')";
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
        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM TREATMENT WHERE TREATMENT_ID=" + id + @"";
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
