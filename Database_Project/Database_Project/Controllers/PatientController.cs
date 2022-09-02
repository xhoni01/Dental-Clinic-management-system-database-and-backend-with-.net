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
    public class PatientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [PATIENT_FIRST_NAME] ,[PATIENT_LAST_NAME] ,[PATIENT_STATE] ,[PATIENT_CITY] ,[PATIENT_STREET] ,[PATIENT_AREA_CODE]
                           [PATIENT_PHONE_NUMBER],[PATIENT_EMAIL],[TREATMENT_DESCRIPTION] FROM PATIENT JOIN PATIENT_TREATMENT ON PATIENT.PATIENT_PERSONAL_NUMBER=PATIENT_TREATMENT.PATIENT_PERSONAL_NUMBER
                           JOIN TREATMENT ON PATIENT_TREATMENT.TREATMENT_ID=TREATMENT.TREATMENT_ID";
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
        public string Post(Patient pat)
        {
            try
            {
                string query = @"INSERT INTO PATIENT(PATIENT_PERSONAL_NUMBER,PATIENT_FIRST_NAME,PATIENT_LAST_NAME,PATIENT_STATE,PATIENT_CITY,PATIENT_STREET,PATIENT_AREA_CODE,PATIENT_PHONE_NUMBER,PATIENT_EMAIL) VALUES(
                                                           '" + pat.PatientPhoneNumber+ @"'
                                                           ,'" + pat.PatientFName + @"'
                                                           ,'" + pat.PatientLName + @"'
                                                           ,'" + pat.PatientState+ @"'
                                                           ,'" + pat.PatientCity+ @"'
                                                           ,'" + pat.PatientStreet + @"'
                                                           ,'" + pat.PatientAreaCode + @"'
                                                           ,'" + pat.PatientPhoneNumber + @"'
                                                           ,'" + pat.PatientEmail + @"'
                                                           )";
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

        public string Put(Patient pat)
        {
            try
            {
                string query = @"UPDATE EMPLOYEE SET 
                PATIENT_FIRST_NAME='" + pat.PatientFName + @"',
                PATIENT_LAST_NAME='" + pat.PatientLName + @"',
                PATIENT_STATE='" + pat.PatientState + @"',
                PATIENT_CITY='" + pat.PatientCity + @"',
                PATIENT_STREET='" + pat.PatientStreet + @"',
                PATIENT_AREA_CODE='" + pat.PatientAreaCode + @"',
                PATIENT_PHONE_NUMBER='" + pat.PatientPhoneNumber + @"',
                PATIENT_EMAIL='" + pat.PatientEmail + @"',
                WHERE PATIENT_PERSONAL_NUMBER=" + pat.PatientPersonalNumber + @"";
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
                string query = @"DELETE FROM PATIENT WHERE PATIENT_PERSONAL_NUMBER=" + id + @"";
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
