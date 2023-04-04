using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using apitest1.Models;


namespace apitest1.Controllers
{
    public class Apitest1Controller : ApiController
    {
        public HttpResponseMessage get()
        {
            DataTable table = new DataTable();
            string query = "SELECT * FROM alletech_city";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["alletech_city"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
                }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


    }
}

