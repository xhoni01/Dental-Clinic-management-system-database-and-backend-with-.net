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
    public class AppointmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT  [PATIENT_FIRST_NAME] ,[PATIENT_LAST_NAME] ,[PATIENT_STATE] ,[PATIENT_CITY] ,[PATIENT_STREET] ,[PATIENT_AREA_CODE]
                           [PATIENT_PHONE_NUMBER],[PATIENT_EMAIL],[APPOINTMENT_TIME], EMPLOYEE_F_NAME, EMPLOYEE_L_NAME FROM EMPLOYEE JOIN DENTIST ON EMPLOYEE.EMPLOYEE_ID=DENTIST.EMPLOYEE_ID
                           JOIN APPOINTMENT ON DENTIST.DENTIST_ID=APPOINTMENT.DENTIST_ID JOIN PATIENT ON APPOINTMENT.PATIENT_PERSONAL_NUMBER=PATIENT.PATIENT_PERSONAL_NUMBER";
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
        public string Post(Appointment app)
        {
            try
            {
                string query = @"INSERT INTO APPOINTMENT VALUES(
                                                            '" + app.AppointmentTime + @"'
                                                           ,'" + app.DentistId + @"'
                                                           ,'" + app.PatientPersonalNumber + @"')";
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
                string query = @"DELETE FROM APPOINTMENT WHERE APPOINTMENT_ID=" + id + @"";
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
