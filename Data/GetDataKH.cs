using Microsoft.Data.SqlClient;

namespace BlazorThucTap.Data
{
    public class GetDataKH
    {
        private string connectionString = "Data Source=DESKTOP-8M8MSCI;Initial Catalog=ThucTapBlazor2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public IEnumerable<CustomerInfo> GetAllKH()
        {
            List<CustomerInfo> lstKhachHang = new List<CustomerInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_getAllKH", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        CustomerInfo Cus = new CustomerInfo();
                        Cus.ID = Convert.ToInt32(rdr["ID"]);
                        Cus.TextName = rdr["TextName"].ToString();
                        Cus.TextUser = rdr["TextUser"].ToString();
                        Cus.TextEmail = rdr["TextEmail"].ToString();
                        Cus.TextPhone = rdr["TextPhone"].ToString();
                        Cus.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                        Cus.TextAddress = rdr["TextAddress"].ToString();
                        Cus.TextPass = rdr["TextPass"].ToString();
                        Cus.TotalAm = Convert.ToInt32(rdr["TotalAm"]);
                        Cus.IdBill = Convert.ToInt32(rdr["IdBill"]);
                        Cus.DateBuy = Convert.ToDateTime(rdr["DateBuy"]);
                        lstKhachHang.Add(Cus);
                    }
                    con.Close();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            return lstKhachHang;
        }
        public void AddCustomer(CustomerInfo Cus) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("p_AddTTKhach", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TextName", Cus.TextName);
                cmd.Parameters.AddWithValue("@TextUser", Cus.TextUser);
                cmd.Parameters.AddWithValue("@TextEmail", Cus.TextEmail);
                cmd.Parameters.AddWithValue("@TextPhone", Cus.TextPhone);
                cmd.Parameters.AddWithValue("@BirthDate", Cus.BirthDate);
                cmd.Parameters.AddWithValue("@TextAddress", Cus.TextAddress);
                cmd.Parameters.AddWithValue("@TextPass", Cus.TextPass);
                cmd.Parameters.AddWithValue("@TotalAm", Cus.TotalAm);
                cmd.Parameters.AddWithValue("@DateBuy", Cus.DateBuy);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateCus(CustomerInfo Cus)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateKH", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Cus.ID);
                cmd.Parameters.AddWithValue("@TextName", Cus.TextName);
                cmd.Parameters.AddWithValue("@TextUser", Cus.TextUser);
                cmd.Parameters.AddWithValue("@TextEmail", Cus.TextEmail);
                cmd.Parameters.AddWithValue("@TextPhone", Cus.TextPhone);
                cmd.Parameters.AddWithValue("@BirthDate", Cus.BirthDate);
                cmd.Parameters.AddWithValue("@TextAddress", Cus.TextAddress);
                cmd.Parameters.AddWithValue("@TextPass", Cus.TextPass);
                cmd.Parameters.AddWithValue("@TotalAm", Cus.TotalAm);
                cmd.Parameters.AddWithValue("@DateBuy", Cus.DateBuy);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public CustomerInfo GetCusData(int? id)
        {
            CustomerInfo Cus = new CustomerInfo();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_getKHbyID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Cus.ID = Convert.ToInt32(rdr["ID"]);
                        Cus.TextName = rdr["TextName"].ToString();
                        Cus.TextUser = rdr["TextUser"].ToString();
                        Cus.TextEmail = rdr["TextEmail"].ToString();
                        Cus.TextPhone = rdr["TextPhone"].ToString();
                        Cus.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                        Cus.TextAddress = rdr["TextAddress"].ToString();
                        Cus.TextPass = rdr["TextPass"].ToString();
                        Cus.IdBill = Convert.ToInt32(rdr["IdBill"]);
                        Cus.TotalAm = Convert.ToInt32(rdr["TotalAm"]);
                        Cus.DateBuy = Convert.ToDateTime(rdr["DateBuy"]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            return Cus;
        }
        public void DeleteCus(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeletKH", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        
    }
}