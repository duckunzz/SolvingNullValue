using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Missing_Data
{
    public class Program
    {
        public static string strConn = "Data Source=LUMOS;Initial Catalog=DataMissing;user=DucTran;pwd=123";
        public static DataTable data, dataConvert;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Missing_Data());
            new Missing_Data().ShowDialog();
            
        }

        public static DataTable convertDataToCode(DataTable data)
        {
            
            for (int i = 0; i < data.Rows.Count; i++)
                for (int j = 3; j < data.Columns.Count; j++)
                {
                    data.Rows[i][j] = convertRealDataToCode.checkNameOfAtrributeForConvert(data, data.Columns[j].ToString(), float.Parse(data.Rows[i][j].ToString()));
                }
            return data;
        }
        
    }
}
