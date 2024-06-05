using Entities;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Repositories
{
    public class RatingRepositories : IRatingRepositories
    {
        StshopContext _StshopContext;
        public IConfiguration _configuration { get; }
        public RatingRepositories(StshopContext stshopContext, IConfiguration configuration)
        {
            _StshopContext = stshopContext;
            _configuration = configuration;
        }
       
        public async Task<Rating> AddRatingAsync(Rating rating)
        {


            string query = "INSERT INTO RATING(HOST, METHOD,PATH, REFERER, Record_Date,USER_AGENT)" +
                       "VALUES (@HOST,@METHOD,@PATH, @REFERER, @Record_Date,@USER_AGENT)";

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("STshop")))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NChar, 50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 50).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NChar, 50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NChar, 50).Value = rating.Referer;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NChar, 50).Value = rating.UserAgent;

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                return rating;
            }


        }
    }
}
