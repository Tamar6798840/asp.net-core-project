using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Menager;

public class DataAccess
{
     static string connectionStr = "Data Source = SRV2/PUPILS; Initial Catalog = STshop; Integrated Security = True";
     SqlConnection connection = new SqlConnection(connectionStr);
   
   public string GetAllProduct()
    { 
        using (connection)
        {
            SqlCommand command = new SqlCommand("select * from products",connection);
            //command.Connection.Open();
            //command.ExecuteNonQuery();
            string res = "";
            try
            {
               connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    { 
                        res += reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
        } 
    }
}
