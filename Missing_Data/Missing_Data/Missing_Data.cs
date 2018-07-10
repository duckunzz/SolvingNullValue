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
    
    public partial class Missing_Data : Form
    {
        
        BindingSource xl = new BindingSource();
        //Dem so du lieu thieu
        int nullValue = 0;
        public static string nullAttribute = "";
       
        public Missing_Data()
        {
            InitializeComponent();       
            dataWeather.DataSource = Database.Data_DS();
            hienthiDSData();

        }
        private void Missing_Data_Load(object sender, EventArgs e)
        {
            position();
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
                txtHumidity.Text = value;
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
            if (nullValue > 0 && value == "")
            {
                MessageBox.Show("Phát hiện thấy " + nullValue + " ô dữ liệu thiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;    
                            
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

            xl.MoveNext();
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
            try
            {
                if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text, "") == false)
                {
                    Database.addData(txtID.Text, txtYear.Text, txtMonth.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtRain.Text, txtHumidity.Text, txtEvaporation.Text, txtSun.Text, txtPressure.Text, txtDust.Text, txtSuspend.Text, txtRising.Text);
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataWeather.DataSource = Database.Data_DS();
                    hienthiDSData();
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn chương trình dự đoán cho giá trị thiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        solvingNullValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm dữ liệu thất bại. \nVui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
           
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text, "") == false)
                {
                    Database.editData(txtID.Text, txtYear.Text, txtMonth.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtRain.Text, txtHumidity.Text, txtEvaporation.Text, txtSun.Text, txtPressure.Text, txtDust.Text, txtSuspend.Text, txtRising.Text);
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataWeather.DataSource = Database.Data_DS();
                    hienthiDSData();
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn chương trình dự đoán cho giá trị thiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        solvingNullValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại! \nVui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Database.deleteData(txtID.Text);
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataWeather.DataSource = Database.Data_DS();
                    hienthiDSData();
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại! \nVui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void solvingNullValues()
        {
            //Uoc luong cho gia tri ngay, hoac nam
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
                //Uoc luong gia tri khong phai ngay hoac nam
            else
            {
                if (nullValue >= 2)
                    MessageBox.Show("Xin lỗi chương trình chỉ có thể dự đoán cho một trường thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    nullValue--;
                    MessageBox.Show("Vui lòng nhấn Training với Decision Tree Using Rough Set để chương trình có thể dự đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }       
            }
        }
        //Tim kiem hang theo ID
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataWeather.DataSource = Database.Data_DS();
            if (txtID.Text == "")
                MessageBox.Show("Nhập ID cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                dataWeather.DataSource = Database.searchData(txtID.Text);
            hienthiDSData();

        }

        //Training du lieu
        private void btnDecisionTreeUsingRoughSet_Click(object sender, EventArgs e)
        {
            //Kiem tra xem co thuoc tinh quyet dinh chua, do chinh la truong thieu
            if (nullAttribute.ToString() != "")
            {
                var decisionTree = new Tree();
                Program.data = Database.Data_DS();
                ExportData.WriteToCsvFile(Program.data, "export\\Realdata.csv");
                MessageBox.Show("Xuất file dữ liệu gốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.data = Program.convertDataToCode(Program.data);
                ExportData.WriteToCsvFile(Program.data, "export\\CodedataConvert.csv");
                MessageBox.Show("Xuất file chuyển đổi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dataTrain = DataTraining.DataTrain(Program.data, nullAttribute);
                ExportData.WriteToCsvFile(dataTrain, "export\\dataTraining.csv");
                MessageBox.Show("Xuất file training đã chuyển đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Bạn có muốn xem quá trình Training Data? \nGiá trị dự đoán phải nhập thủ công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
         MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ViewTrainingData.console(dataTrain);
                }
                else
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    decisionTree.Root = Tree.Learn(dataTrain, "");
                    Tree.fileContent1 = new StringBuilder();
                    Tree.Print(decisionTree.Root, decisionTree.Root.Name.ToUpper(), dataTrain);
                    ExportData.ExportTree("export\\Rules.txt");
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    MessageBox.Show("Quá trình Training hoàn thành! \nXuất thành công file chứa các luật! \nThời gian tốn: " + elapsedMs + " ms.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Truy van de tim ra gia tri uoc luong cho truong thieu
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
                if (result.ToString().Equals("unknown") != true)
                {
                    //nullValue= -1;
                    string valueResult = "", setResult = "";
                    int vt = 0;
                    for (int i = result.Length - 1; i >= 0; i--)
                        if (result[i].ToString().Equals("-") != true && result[i].ToString().Equals(">") != true && result[i].ToString().Equals(" ") != true)
                            vt = i;
                        else
                            break;
                    for (int i = vt; i < result.Length; i++)
                        valueResult += result[i].ToString();
                    if (valueResult.ToString().Equals("unknown") != true && valueResult.Length > 0)
                    {
              
                        setResult = convertCodeToRealData.checkNameOfAtrributeForConvert(nullAttribute.ToString(), float.Parse(valueResult.ToString())).ToString();
                        MessageBox.Show("Giá trị đã được ước lượng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        setResult = "unknown";
                        MessageBox.Show("Xin lỗi không thể dự đoán được giá trị thiếu! Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    check(txtYear.Text, txtMonth.Text, txtDust.Text, txtSuspend.Text, txtRising.Text, txtRain.Text, txtSun.Text, txtDry.Text, txtMax.Text, txtMin.Text, txtHumidity.Text, txtEvaporation.Text, txtPressure.Text, setResult.ToString());
                }
                else
                {
                    //nullValue--;
                    MessageBox.Show("Xin lỗi không thể dự đoán được giá trị thiếu! \nVui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
                MessageBox.Show("Thiếu thông tin! \nQuá trình Training vẫn chưa thể tiến hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);   
        }

        public string getValue(string value)
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
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void btnBee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xin lỗi hiện tại chương trình vẫn chưa mở được tính năng Training này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        /*-------------------------------------------------------------------------------------------------------------------*/
        /*CODE VE THUAT TOAN DAN ONG*/
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
