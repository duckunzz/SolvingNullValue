using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;


namespace Missing_Data
{
    //Solving_Null_Values solv = new Solving_Null_Values();
    
    public partial class Missing_Data : Form
    {
        public static string strConn = "Data Source=LUMOS;Initial Catalog=DataMissing;user=DucTran;pwd=123";
        BindingSource xl = new BindingSource();
        //Dem so du lieu thieu
        int nullValue = 0;
       
        public Missing_Data()
        {
            InitializeComponent();
            dataWeather.DataSource = Data_DS();
            hienthiDSData();

        }
        private void Missing_Data_Load(object sender, EventArgs e)
        {
            
            position();
        }
        //Hien thi data
        public DataTable Data_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_DS", strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        public DataTable searchData(string ID)
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_TimKiem", strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        void hienthiDSData()
        {
            xl.DataSource = dataWeather.DataSource;
            dataWeather.Columns[0].HeaderText = "id";
            dataWeather.Columns[1].HeaderText = "year";
            dataWeather.Columns[2].HeaderText = "month";
            dataWeather.Columns[3].HeaderText = "dust_storm";
            dataWeather.Columns[4].HeaderText = "suspend_dust";
            dataWeather.Columns[5].HeaderText = "rising_dust";
            dataWeather.Columns[6].HeaderText = "rain";
            dataWeather.Columns[7].HeaderText = "sun_shine";
            dataWeather.Columns[8].HeaderText = "dry_temp";
            dataWeather.Columns[9].HeaderText = "max_temp";
            dataWeather.Columns[10].HeaderText = "min_temp";
            dataWeather.Columns[11].HeaderText = "humidity";
            dataWeather.Columns[12].HeaderText = "evaporation";
            dataWeather.Columns[13].HeaderText = "pressure";
            dataWeather.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;

            dataWeather.Columns[0].Width = 57;
            dataWeather.Columns[1].Width = 70;
            dataWeather.Columns[2].Width = 70;
            dataWeather.Columns[3].Width = 100;
            dataWeather.Columns[4].Width = 130;
            dataWeather.Columns[5].Width = 100;
            dataWeather.Columns[6].Width = 70;
            dataWeather.Columns[7].Width = 100;
            dataWeather.Columns[8].Width = 100;
            dataWeather.Columns[9].Width = 100;
            dataWeather.Columns[10].Width = 100;
            dataWeather.Columns[11].Width = 100;
            dataWeather.Columns[12].Width = 100;
            dataWeather.Columns[13].Width = 100;
            
        }
        //Kiem tra Null Value
        public bool check(string Year, string Month, string Dust, string Suspend, string Rising, string Rain, string Sun, string Dry, string Max, string Min, string Humidity, string Evaporation, string Pressure)
        {
            ArrayList data = new ArrayList();
            data.Add(Year);
            data.Add(Month);
            data.Add(Dust);
            data.Add(Suspend);
            data.Add(Rising);
            data.Add(Rain);
            data.Add(Sun);
            data.Add(Dry);
            data.Add(Max);
            data.Add(Min);
            data.Add(Humidity);
            data.Add(Evaporation);
            data.Add(Pressure);
            foreach (string i in data)
                if (i == "")
                    nullValue++;
            if (nullValue > 0)
            {
                MessageBox.Show("Phát hiện thấy " + nullValue + " ô dữ liệu thiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;    
                            
        }
        //Them du lieu
        public void addData(string ID, string Year, string Month, string Dry , string Max , string Min, string Rain, string Humidity, string Evaporation, string Sun, string Pressure, string Dust, string Suspend, string Rising)
        {
            SqlConnection conn = new SqlConnection(strConn);
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
        public void editData(string ID, string Year, string Month, string Dry, string Max, string Min, string Rain, string Humidity, string Evaporation, string Sun, string Pressure, string Dust, string Suspend, string Rising)
        {
            SqlConnection conn = new SqlConnection(strConn);
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
        public void deleteData(string ID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Data_Xoa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
          
        //Xu ly cac button First, Next, Previous, Last
        private void rowselect()
        {
            dataWeather.ClearSelection();
            //Chi ra dong duoc chon va chon dong
            dataWeather.Rows[xl.Position].Selected = true;
            position();
        }

        private void position()
        {
            xl.DataSource = dataWeather.DataSource;
            lblCurrentRow.Text = (xl.Position + 1).ToString();
            lblRowCount.Text = (xl.Count).ToString();
            dataWeather.FirstDisplayedScrollingRowIndex = xl.Position;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            xl.MoveFirst();
            rowselect();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, dataWeather.CurrentRow.Index+1);
            xl.MoveNext();

            //dataWeather_CellClick(dataWeather, args);
            rowselect();


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            xl.MovePrevious();
            rowselect();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            xl.MoveLast();
            rowselect();
            
        }

        

        //Xu ly su kien Cell Click
        private void dataWeather_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cell_click();
        }
        private void cell_click()
        {
            txtID.Text = dataWeather.CurrentRow.Cells[0].Value.ToString();
            txtYear.Text = dataWeather.CurrentRow.Cells[1].Value.ToString();
            txtMonth.Text = dataWeather.CurrentRow.Cells[2].Value.ToString();
            txtDust.Text = dataWeather.CurrentRow.Cells[3].Value.ToString();
            txtSuspend.Text = dataWeather.CurrentRow.Cells[4].Value.ToString();
            txtRising.Text = dataWeather.CurrentRow.Cells[5].Value.ToString();
            txtRain.Text = dataWeather.CurrentRow.Cells[6].Value.ToString();
            txtSun.Text = dataWeather.CurrentRow.Cells[7].Value.ToString();
            txtDry.Text = dataWeather.CurrentRow.Cells[8].Value.ToString();
            txtMax.Text = dataWeather.CurrentRow.Cells[9].Value.ToString();
            txtMin.Text = dataWeather.CurrentRow.Cells[10].Value.ToString();
            txtHumidity.Text = dataWeather.CurrentRow.Cells[11].Value.ToString();
            txtEvaporation.Text = dataWeather.CurrentRow.Cells[12].Value.ToString();
            txtPressure.Text = dataWeather.CurrentRow.Cells[13].Value.ToString();
            lblCurrentRow.Text = (dataWeather.CurrentCell.RowIndex + 1).ToString();
            lblRowCount.Text = (xl.Count).ToString();
        }

        //Xu ly cac button them xoa sua du lieu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID1.Text = txtID.Text;
            txtYear1.Text = txtYear.Text;
            txtMonth1.Text = txtMonth.Text;
            if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text) == false)
            {
                addData(txtID.Text, txtYear.Text, txtMonth.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtRain.Text, txtHumidity.Text, txtEvaporation.Text, txtSun.Text, txtPressure.Text, txtDust.Text, txtSuspend.Text, txtRising.Text);
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataWeather.DataSource = Data_DS();
                hienthiDSData();
            }
            else
            {
                MessageBox.Show("Bạn có muốn ước lượng các giá trị thiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                solvingNullValues();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtID1.Text = txtID.Text;
            txtYear1.Text = txtYear.Text;
            txtMonth1.Text = txtMonth.Text;
            if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text) == false)
            {
                editData(txtID.Text, txtYear.Text, txtMonth.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtRain.Text, txtHumidity.Text, txtEvaporation.Text, txtSun.Text, txtPressure.Text, txtDust.Text, txtSuspend.Text, txtRising.Text);
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataWeather.DataSource = Data_DS();
                hienthiDSData();
            }
            else
            {
                MessageBox.Show("Bạn có muốn ước lượng các giá trị thiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                solvingNullValues();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            deleteData(txtID.Text);
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataWeather.DataSource = Data_DS();
            hienthiDSData();
        }

        private void solvingNullValues()
        {
            /*
                Nguyen tac cua uoc tinh du lieu thieu thang, nam se dua vao thang, nam cua hang truoc do
                Nho vao viec nhap du lieu thang, nam lien tuc
             */
            int month = 0, year = 0;
            if (txtID.Text == xl.Count.ToString())
            {
                //Truong hop sua, select row la hang truoc do, luu y sua hang 1 se bi loi
                //Lay du lieu thang cua ban ghi phia tren
                month = Convert.ToInt32(dataWeather.Rows[xl.Position - 1].Cells[2].Value.ToString());
                //Lay du lieu nam cua ban ghi phia tren
                year = Convert.ToInt32(dataWeather.Rows[xl.Position - 1].Cells[1].Value.ToString());
            }
            else
            {
                //Truong hop them, select row luon la hang cuoi
                //Lay du lieu thang cua ban ghi phia tren
                month = Convert.ToInt32(dataWeather.CurrentRow.Cells[2].Value.ToString());
                //Lay du lieu nam cua ban ghi phia tren
                year = Convert.ToInt32(dataWeather.CurrentRow.Cells[1].Value.ToString());
            }
            txtID1.Text = txtID.Text;
            txtYear1.Text = year.ToString();
            txtMonth1.Text = month.ToString();
            if (month == 12)
            {
                if (txtYear.Text == "")
                {
                    txtYear.Text = (year + 1).ToString();
                    nullValue--;
                }
                if (txtMonth.Text == "")
                {
                     txtMonth.Text = "1";
                    nullValue--;
                }
            }
            else
            {
                if (txtYear.Text == "")
                {
                    txtYear.Text = year.ToString();
                    nullValue--;
                }
                if (txtMonth.Text == "")
                {
                    txtMonth.Text = (month + 1).ToString();
                    nullValue--;
                }
            }
           // txtID1.Text = txtID.Text;
            //txtYear1.Text = txtYear.Text;
            //txtMonth1.Text = txtMonth.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataWeather.DataSource = Data_DS();
            if (txtID.Text == "")
                MessageBox.Show("Nhập ID cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                dataWeather.DataSource = searchData(txtID.Text);
            hienthiDSData();

        }

        
    }
}
