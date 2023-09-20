using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace fullstack.Pages.client
{
    public class IndexModel : PageModel
    {
        public List<clientInfo> listclient= new List<clientInfo>();
        public void OnGet()
        {
			try
			{
				string connectionString = "Data Source = PRAJWAL\\SQLEXPRESS01; Initial Catalog = fullstack; Integrated Security = True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "SELECT * FROM clients";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								clientInfo clientInfo = new clientInfo();
								clientInfo.id = reader.GetInt32(0).ToString();
								clientInfo.name = reader.GetString(1);
								clientInfo.email = reader.GetString(2);
								clientInfo.phone = reader.GetString(3);
								clientInfo.address = reader.GetString(4);
								clientInfo.created_at = reader.GetDateTime(5).ToString();

								listclient.Add(clientInfo);
							}
						}
					}
				}
			}
			catch (Exception ex)
            {
                Console.WriteLine("Exception:" +ex. ToString());
            }
        }
    }

    public class clientInfo
    {
       
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string created_at;
    }
}
