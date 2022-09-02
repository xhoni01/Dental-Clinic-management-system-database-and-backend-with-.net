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
    public class ProductController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM PRODUCT";
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
        public string Post(Product product)
        {
            try
            {
                string query = @"INSERT INTO PRODUCT VALUES(
                                                            '" + product.ProductName+ @"'
                                                           ,'" + product.ProductQOH + @"'
                                                           ,'" + product.ProductMin + @"'
                                                           ,'" + product.ClinicId + @"'
                                                           ,'" + product.ProductReorder + @"')";
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

        public string Put(Product product)
        {
            try
            {
                string query = @"UPDATE PRODUCT SET 
               
                PRODUCT_NAME='" + product.ProductName + @"',
                PRODUCT_QOH='" + product.ProductQOH + @"',
                PRODUCT_MIN='" + product.ProductMin + @"',
                CLINIC_ID='" + product.ClinicId + @"',
                PRODUCT_REORDER='" + product.ProductReorder + @"'
                WHERE PRODUCT_ID='" + product.ProductId + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["clinicdb"].ConnectionString))
                using (var comm = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(comm))
                {
                    comm.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                
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
                string query = @"DELETE FROM PRODUCT WHERE PRODUCT_ID=" + id + @"";
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
