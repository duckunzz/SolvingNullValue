using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Missing_Data
{
    class Database
    {
        //Hien thi data
        public static DataTable Data_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_DS", Program.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        public static DataTable searchData(string ID)
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_TimKiem", Program.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        //Them du lieu
        public static void addData(string ID, string Year, string Month, string Dry, string Max, string Min, string Rain, string Humidity, string Evaporation, string Sun, string Pressure, string Dust, string Suspend, string Rising)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Data_Them", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@DYear", SqlDbType.Int).Value = Year;
            cmd.Parameters.Add("@DMonth", SqlDbType.Int).Value = Month;
            cmd.Parameters.Add("@DustStorm", SqlDbType.Float).Value = Dust;
            cmd.Parameters.Add("@SuspendDust", SqlDbType.Float).Value = Suspend;
            cmd.Parameters.Add("@RisingDust", SqlDbType.Float).Value = Rising;
            cmd.Parameters.Add("@Rain", SqlDbType.Float).Value = Rain;
            cmd.Parameters.Add("@SunShine", SqlDbType.Float).Value = Sun;
            cmd.Parameters.Add("@DryTemperature", SqlDbType.Float).Value = Dry;
            cmd.Parameters.Add("@MaxTemperature", SqlDbType.Float).Value = Max;
            cmd.Parameters.Add("@MinTemperature", SqlDbType.Float).Value = Min;
            cmd.Parameters.Add("@Humidity", SqlDbType.Float).Value = Humidity;
            cmd.Parameters.Add("@Evaporation", SqlDbType.Float).Value = Evaporation;
            cmd.Parameters.Add("@Pressure", SqlDbType.Float).Value = Pressure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Chinh sua du lieu
        public static void editData(string ID, string Year, string Month, string Dry, string Max, string Min, string Rain, string Humidity, string Evaporation, string Sun, string Pressure, string Dust, string Suspend, string Rising)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Data_Sua", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@DYear", SqlDbType.Int).Value = Year;
            cmd.Parameters.Add("@DMonth", SqlDbType.Int).Value = Month;
            cmd.Parameters.Add("@DustStorm", SqlDbType.Float).Value = Dust;
            cmd.Parameters.Add("@SuspendDust", SqlDbType.Float).Value = Suspend;
            cmd.Parameters.Add("@RisingDust", SqlDbType.Float).Value = Rising;
            cmd.Parameters.Add("@Rain", SqlDbType.Float).Value = Rain;
            cmd.Parameters.Add("@SunShine", SqlDbType.Float).Value = Sun;
            cmd.Parameters.Add("@DryTemperature", SqlDbType.Float).Value = Dry;
            cmd.Parameters.Add("@MaxTemperature", SqlDbType.Float).Value = Max;
            cmd.Parameters.Add("@MinTemperature", SqlDbType.Float).Value = Min;
            cmd.Parameters.Add("@Humidity", SqlDbType.Float).Value = Humidity;
            cmd.Parameters.Add("@Evaporation", SqlDbType.Float).Value = Evaporation;
            cmd.Parameters.Add("@Pressure", SqlDbType.Float).Value = Pressure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Xoa du lieu
        public static void deleteData(string ID)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Data_Xoa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
