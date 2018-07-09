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
using System.Runtime.InteropServices;
using System.IO;


namespace Missing_Data
{
    //Solving_Null_Values solv = new Solving_Null_Values();
    
    public partial class Missing_Data : Form
    {
        
        BindingSource xl = new BindingSource();
        //Dem so du lieu thieu
        int nullValue = 0;
        static string nullAttribute = "";
       
        public Missing_Data()
        {
            InitializeComponent();
            //Program.data = Data_DS();
            dataWeather.DataSource = Data_DS();
            //Program.data = Data_DS();
            //txtValue.Text = Program.data.Columns[2].ToString();
            hienthiDSData();

        }
        private void Missing_Data_Load(object sender, EventArgs e)
        {
            position();
        }
        //Hien thi data
        public static DataTable Data_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_DS", Program.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        public DataTable searchData(string ID)
        {
            SqlDataAdapter adap = new SqlDataAdapter("Data_TimKiem", Program.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }

        void hienthiDSData()
        {
            //xl.DataSource = Program.data;
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
        public bool check(string Year, string Month, string Dust, string Suspend, string Rising, string Rain, string Sun, string Dry, string Max, string Min, string Humidity, string Evaporation, string Pressure, string value)
        {
            nullValue = 0;
            if (Dust == "")
            {
                nullAttribute = "DustStorm";
                txtDust.Text = value;
                nullValue++;
            }
          
            if (Suspend == "")
            {
                nullAttribute = "SuspendDust";
                txtSuspend.Text = value;
                nullValue++;
            }
          
            if (Rising == "")
            {
                nullAttribute = "RisingDust";
                txtRising.Text = value;
                nullValue++;
            }
           
            if (Rain == "")
            {
                nullAttribute = "Rain";
                txtRain.Text = value;
                nullValue++;
            }
           
            if (Sun == "")
            {
                nullAttribute = "SunShine";
                txtSun.Text = value;
                nullValue++;
            }
          
            if (Dry == "")
            {
                nullAttribute = "DryTemperature";
                txtDry.Text = value;
                nullValue++;
            }
           
            if (Max == "")
            {
                nullAttribute = "MaxTemperature";
                txtMax.Text = value;
                nullValue++;
            }
           
            if (Min == "")
            {
                nullAttribute = "MinTemperature";
                txtMin.Text = value;
                nullValue++;
            }
            if (Humidity == "")
            {
                nullAttribute = "Humidity";
                nullValue++;
            }
          
            if (Evaporation == "")
            {
                nullAttribute = "Evaporation";
                txtEvaporation.Text = value;
                nullValue++;
            }
          
            if (Pressure == "")
            {
                nullAttribute = "Pressure";
                txtPressure.Text = value;
                nullValue++;
            }
           
            if (Month == "")
            {
                nullValue++;
            }
            if (Year == "")
            { 
                nullValue++;
            }
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
        public void editData(string ID, string Year, string Month, string Dry, string Max, string Min, string Rain, string Humidity, string Evaporation, string Sun, string Pressure, string Dust, string Suspend, string Rising)
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
        public void deleteData(string ID)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
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
           
            if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text, "") == false)
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
            
            if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text,"") == false)
            {
                editData(txtID.Text, txtYear.Text, txtMonth.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtRain.Text, txtHumidity.Text, txtEvaporation.Text, txtSun.Text, txtPressure.Text, txtDust.Text, txtSuspend.Text, txtRising.Text);
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataWeather.DataSource = Data_DS();
                hienthiDSData();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn chương trình dự đoán cho giá trị thiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    solvingNullValues();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                deleteData(txtID.Text);
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataWeather.DataSource = Data_DS();
                hienthiDSData();
            }      
        }

        private void solvingNullValues()
        {
            if (txtMonth.Text == "" || txtYear.Text == "")
            {
                /*
                    Nguyen tac cua uoc tinh du lieu thieu thang, nam se dua vao thang, nam cua hang truoc do
                    Nho vao viec nhap du lieu thang, nam lien tuc
                 */
                int month = 0, year = 0;

                if (txtID.Text == (dataWeather.CurrentRow.Index + 1).ToString())
                {
                    //Truong hop sua, select row la hang truoc do, luu y sua hang 1 se bi loi
                    //Lay du lieu thang cua ban ghi phia tren
                    month = Convert.ToInt32(dataWeather.Rows[dataWeather.CurrentRow.Index - 1].Cells[2].Value.ToString());
                    //Lay du lieu nam cua ban ghi phia tren
                    year = Convert.ToInt32(dataWeather.Rows[dataWeather.CurrentRow.Index - 1].Cells[1].Value.ToString());
                }
                else
                {
                    //Truong hop them, select row luon la hang cuoi
                    //Lay du lieu thang cua ban ghi cuoi cung
                    month = Convert.ToInt32(dataWeather.CurrentRow.Cells[2].Value.ToString());
                    //Lay du lieu nam cua ban ghi cuoi cung
                    year = Convert.ToInt32(dataWeather.CurrentRow.Cells[1].Value.ToString());
                }
              
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
            }
            else
            {
                MessageBox.Show("Vui lòng nhấn Training dữ liệu với Rough Set Theory để chương trình có thể dự đoán!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
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

        private void btnNhan_Click(object sender, EventArgs e)
        {
            
        }

        private void btnID3_Click(object sender, EventArgs e)
        {
            var decisionTree = new Tree();
            Program.data = Data_DS();
            Tree.WriteToCsvFile(Program.data,"F:\\ThucTap_57CNTT2\\Program\\Missing_Data\\Missing_Data\\export\\test1.csv");
            Program.data = Program.convertDataToCode(Program.data);
            //dataWeather.DataSource = Program.data;
            DataTable dataTrain = DataTraining(Program.data, nullAttribute);
            Tree.WriteToCsvFile(Program.data,"F:\\ThucTap_57CNTT2\\Program\\Missing_Data\\Missing_Data\\export\\test.csv");

           // decisionTree.Root = Tree.Learn(dataTrain,"");
            if (MessageBox.Show("Bạn có muốn xem quá trình Training Data? Giá trị dự đoán phải nhập thủ công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                console(dataTrain);
            }
            else
            {
                decisionTree.Root = Tree.Learn(dataTrain, "");
                MessageBox.Show("Quá trình Training hoàn thành!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
                
            var valuesForQuery = new Dictionary<string, string>();
            for (int i = 0; i < dataTrain.Columns.Count - 1; i++)
            {  
                if (dataTrain.Columns[i].ToString().Equals("DMonth") != true)
                    valuesForQuery.Add(dataTrain.Columns[i].ToString(), convertRealDataToCode.checkNameOfAtrributeForConvert(dataTrain, dataTrain.Columns[i].ToString(), float.Parse(getValue(dataTrain.Columns[i].ToString()))).ToString());
                else
                {
                    valuesForQuery.Add(dataTrain.Columns[i].ToString(), txtMonth.Text.ToString());
                }
            }
            var result = Tree.CalculateResult(decisionTree.Root, valuesForQuery, "");
            if (result.ToString().Equals("unknown")!= true)
            {
                nullValue--;
                string valueResult= "", setResult = "";
                int vt = 0;
                for (int i = result.Length - 1; i >= 0; i--)
                    if (result[i].ToString().Equals("-") != true && result[i].ToString().Equals(">") != true)
                        vt = i;
                    else
                        break;
                for (int i = vt; i < result.Length; i++)
                    valueResult += result[i].ToString();
                setResult = convertCodeToRealData.checkNameOfAtrributeForConvert(nullAttribute.ToString(), float.Parse(valueResult.ToString())).ToString();
                check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text, setResult.ToString());
            }
            else
            {
                MessageBox.Show("Xin lỗi không thể dự đoán được giá trị thiếu! Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
        }

        private string getValue(string value)
        {
            if (value.Equals("DustStorm"))
                return txtDust.Text.ToString();
            if (value.Equals("SuspendDust"))
                return txtSuspend.Text.ToString();
            if (value.Equals("RisingDust"))
                return txtRising.Text.ToString();
            if (value.Equals("Rain"))
                return txtRain.Text.ToString();
            if (value.Equals("SunShine"))
                return txtSun.Text.ToString();
            if (value.Equals("DryTemperature"))
                return txtDry.Text.ToString();
            if (value.Equals("MaxTemperature"))
                return txtMax.Text.ToString();
            if (value.Equals("MinTemperature"))
                return txtMin.Text.ToString();
            if (value.Equals("Humidity"))
            return txtHumidity.Text.ToString();
            if (value.Equals("Evaporation"))
               return txtEvaporation.Text.ToString();
            if (value.Equals("Pressure"))
                return txtPressure.Text.ToString();
                if (value.Equals("DMonth"))
                    return txtMonth.Text.ToString();
                return null;
        }
        public static DataTable DataTraining (DataTable data, String nullField)
        {
            
            int vt = 0;
            List<string> values = new List<string>();
            DataTable dataTraining = new DataTable();
            for (int i = 2; i < data.Columns.Count; i++)
            {
                if (data.Columns[i].ToString().Equals(nullField) != true)
                    values.Add(data.Columns[i].ToString());
                else
                    vt = i;             
            }
            values.Add(data.Columns[vt].ToString());
            
            foreach (string item in values)
            {
                dataTraining.Columns.Add(item);
                            
            }
            for (int i = 0; i < dataTraining.Columns.Count; i++)
            {
                Console.Write(dataTraining.Columns[i].ToString()+ " ");
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string[] value = new string[data.Columns.Count - 2];
                for (int j = 2; j < data.Columns.Count; j++)
                {
                    if (data.Columns[j].ToString().Equals(nullField) != true)
                        value[j - 2] = data.Rows[i][j].ToString();
                }
                value[data.Columns.Count - 3] = data.Rows[i][vt].ToString();
                dataTraining.Rows.Add(value);
            }
            return dataTraining;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public static  void console(DataTable data)
        {
            AllocConsole();
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowWidth = Console.LargestWindowWidth - 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DECISON TREE USING ROUGH SET THEORY");
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1 - Training data");
                Console.WriteLine("2 - Kết thúc chương trình");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Mời nhập lựa chọn");
                Console.ResetColor();
                String input = ReadLineTrimmed();

                switch (input)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTraining data");
                        Console.ResetColor();
                        Console.WriteLine("TRUONG THIEU " + nullAttribute);
                        CreateTreeAndHandleUserOperation(data);
                        break;
                    case "2":
                        EndProgram();
                        break;

                    default:
                        DisplayErrorMessage("Wrong input");
                        break;
                }
            } while (true);
        }
        private static void CreateTreeAndHandleUserOperation(DataTable data)
        {
            var decisionTree = new Tree();
            decisionTree.Root = Tree.Learn(data, "");
            var returnToMainMenu = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDecision Tree được tạo!");
            Console.ResetColor();
            do
            {
                var valuesForQuery = new Dictionary<string, string>();

                // loop for data input for the query and some special commands
                for (int i = 0; i < data.Columns.Count - 1; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //sua
                    Console.WriteLine("\nMời nhập giá trị cho thuộc tính " + data.Columns[i] + " hoặc gõ HELP để xem gợi ý!");
                    Console.ResetColor();

                    var input = ReadLineTrimmed();

                    if (input.ToUpper().Equals("ENDPROGRAM"))
                    {
                        EndProgram();
                    }
                    else if (input.ToUpper().Equals("PRINT"))
                    {
                        Console.WriteLine();
                        Tree.Print(decisionTree.Root, decisionTree.Root.Name.ToUpper(), data);
                        Tree.ExportTree("F:\\ThucTap_57CNTT2\\Program\\Missing_Data\\Missing_Data\\export\\Tree.txt");
                        i--;
                    }
                    else if (input.ToUpper().Equals("MAINMENU"))
                    {
                        returnToMainMenu = true;
                        Console.WriteLine();

                        break;
                    }
                    else if (input.ToUpper().Equals("HELP"))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Gõ Print để in cây");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Gõ EndProgram để kết thúc chương trình");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Gõ MainMenu để quay lại MainMenu");
                        i--;
                    }
                    else if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                    {
                        DisplayErrorMessage("Giá trị của thuộc tính không được rỗng hoặc là khoảng trắng!");
                        i--;
                    }
                    else
                    {
                        valuesForQuery.Add(data.Columns[i].ToString(), input);
                    }
                }

                // Thực hiện việc ước lượng giá trị cho thuộc tính quyết định, nếu người dùng nhập vào các giá trị cho các thuộc tính
                if (!returnToMainMenu)
                {
                    var result = Tree.CalculateResult(decisionTree.Root, valuesForQuery, "");

                    Console.WriteLine();

                    if (result.Contains("Thuộc tính không tìm thấy"))
                    {
                        DisplayErrorMessage("Không thể xác định giá trị cho trường còn thiếu!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Kết quả dự đoán của chương trình cho giá trị còn thiếu!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(result);
                        Console.ResetColor();
                    }
                }
            } while (!returnToMainMenu);
        }

        private static string ReadLineTrimmed()
        {
            return Console.ReadLine().TrimStart().TrimEnd();
        }

        private static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //sua
            Console.WriteLine("\n" + errorMessage);
            Console.ResetColor();
        }

        private static void EndProgram()
        {
          
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        //To chuc du lieu
        //Name of Condition feature name
        //Mang cac thuoc tinh
        //
        //Algorithm feature selection using Bees algorithm and rough set theory 
        /*
        private string[] beeAlgorithm(int decision)
        {
            string []nameConditionFeature = new string [13];
            int p = 101;
            int conditionfeature = 13;
            int [,] x = new int [p,conditionfeature];
            string []featureSelection = new string [12];
            int featureSelectionCounter = 0;
            int []quality= new int [101];
            int [] xgbest = new int[2];

            //Khoi tao vung tim kiem ngau nhien
            for (int i = 0; i < p; i++)
            {
                int choose;
                choose = new Random().Next(0, 12);
                if (choose != decision)
                    x[i, choose] = 1;
            }
            
            //Tinh fitness cua thuoc tinh
            for (int i = 0; i < p; i++)
            {
                int num = 0;
                string []left = new string [conditionfeature];
                for (int j=0; j<conditionfeature; j++)
                {
                    if (j != decision && x[i,j] == 1)
                    {
                        left[num] = nameConditionFeature[j];
                        num++;
                    }
                }
                if (num > 0)
                {
                    quality[i] = denpendency(left, decision); // Call 3.11
                }
            }

            int large = -1;
            int largePos = -1;

            for (int i = 0; i < p; i++)
            {
                int numOfOne = 0;
                for (int ii= 0; ii < conditionfeature; ii++)
                {
                    if (x[i,ii] == 1)
                    {
                        numOfOne++;
                    }
                }
                if (quality[i] > large)
                {
                    largePos = i;
                }
            }
            xgbest[0] = large;
            xgbest[1] = largePos;
            int bestBeeCounter = 0; //Mang chua attribute dac trung giam dan
            string []bestBees = new string [13];
            for (int j = 0; j < conditionfeature; j++)
            {
                if (j != decision && x[xgbest[1],j] == 1)
                {
                    bestBees[bestBeeCounter] = nameConditionFeature[j];
                    bestBeeCounter++;
                }
            }
            //Luu thuoc tinh co anh huong lon nhat
            for (int i = 0; i < bestBeeCounter; i++)
            {
                if (belong(bestBees[i],featureSelection) == false) // funtion belong
                {
                    featureSelection[featureSelectionCounter] = bestBees[i];
                    featureSelectionCounter++;
                }
            }
            //Dung thuat toan
            if (reduct(featureSelection, decision)) // call reduct function
                //exit loop
                System.Console.Write("");
            //Chon lang gieng
            int []forNeighborhood = new int [12];
            int forNeighborhoodId = 0;
            for (int i = 0; i < p; i++)
            {
                if (i != xgbest[1])
                {
                    forNeighborhood[forNeighborhoodId] = i;
                    forNeighborhoodId = forNeighborhoodId + 1;

                }
            }
            //Tim kiem lang gieng
            for (int i =0; i < p; i++)
            {
                int num = 0;
                string []left = new string[conditionfeature];
                for (int j = 0; j < conditionfeature; i++)
                {
                    left[num] = nameConditionFeature[j];
                    num++;
                }
                if (num > 0)
                    quality[i] = denpendency(left,decision);
            }
            large = -1;
            largePos = -1;
            for (int i = 0; i < p; i++)
            {
                int numOfOne = 0;
                for (int ii = 0; ii < conditionfeature; ii++)
                {
                    if (x[i,ii] == 1)
                    {
                        numOfOne++;
                    }
                }
                if (quality[i] > large && numOfOne == featureSelectionCounter+1)
                {
                    large = quality[i];
                    largePos = i;
                }
            }
            xgbest[0] = large;
            xgbest[1] = largePos;
            int bestBeeCounter2 = 0;
            string []bestBees2 = new string [13];
            for (int j = 0; j < conditionfeature; j++)
            {
                if (j != decision && x[xgbest[1],j] == 1)
                {
                    bestBees2[bestBeeCounter2] = nameConditionFeature[j];
                    bestBeeCounter2++;
                }
            }
            //Xoa nhung thuoc tinh it co anh huong
            for (int i =0; i <p; i++)
            {
                for (int j=0; j < conditionfeature; j++)
                {
                    if (j != decision && belong(j, codeofBee2) == false)
                        x[i,j] = 0;

                }
            }
            //Random Search
            for (int i = 0; i < p; i++)
            {
                int numOfOne = 0;
                for (int ii = 0; ii < conditionfeature; ii++)
                {
                    if (x[i,ii] == 1)
                    {
                        numOfOne++;
                    }
                    if (quality[i] != denpendency(AllConditionFeature, decision) && numOfOne < featureSelectionCounter)
                    {
                        int choose2 = new Random().Next(0,conditionfeature-1);
                        if (choose2 != decision)
                        {
                            x[i,choose2] = 1;
                        }
                    }
                }
            }
                return featureSelection;
        }
        //Dependency caculation
        private float denpendency(int []conditionfeature, int decision)
        {
            string  []x;
            x = indiscernibility(decision); // call 
            int n = numberofdecisionclass;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                lower[] = lowerApproximation(x[i],conditionfeature); //call
                sum += lengthoflower;
            }
            //
            int u = 192; // numberofobjectinlearningtable
            float Dependency = sum/u;
            return Dependency;
        }
        //indiscernibility
        private string [] indiscernibility(int decision)
        {
            //
            int n = decision;
            int[,] indClasses;

            return;
        }*/
        
        /*public static void getValue(DataTable data)
        {
            
            txtValue.Text = "";
            txtValue.Text = data.Rows.Count.ToString() + " " + data.Columns.Count.ToString();
        }*/
    }
    
}
