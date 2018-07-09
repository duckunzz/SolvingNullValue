using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DecisionTreeWithRoughSetTheory
{
    class ImportCSVFile
    {
        public static DataTable ImportFromCsvFile(string filePath)
        {
            var rows = 0;
            DataTable data = new DataTable();

            try
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
                {
                    while (!reader.EndOfStream)
                    {
                        //Doc du lieu cua tung dong
                        string line = reader.ReadLine();
                        //Kiem tra phan tu cuoi co phai la dau ; khong? Neu khong thi them vao dau ; de phan cach gia tri
                        if (line[line.Length - 1].Equals(';') != true)
                            line += ';';
                        //Moi gia tri se phan cach nhau bang dau ; vi gia tri cuoi la dau ; nen phai cat chuoi line ban dau
                        string[] values = line.Substring(0, line.Length - 1).Split(';');

                        foreach (string item in values)
                        {
                            if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                            {
                                throw new Exception("Giá trị không thể để trống!");
                            }

                            if (rows == 0)
                            {
                                data.Columns.Add(item);
                            }
                        }

                        if (rows > 0 )
                        {
                            
                                data.Rows.Add(values);
                           
                        }

                        rows++;

                        if (values.Length != data.Columns.Count)
                        {
                            throw new Exception("Độ dài của trường giá trị không khớp với trường thuộc tính!");
                        }
                    }
                }
                /*
                var differentValuesOfLastColumn = Attributes.GetDifferentAttributeNamesOfColumn(data, data.Columns.Count - 1);

                if (differentValuesOfLastColumn.Count > 2)
                {
                    throw new Exception("Cột cuối cùng là cột kết quả và chỉ được có hai giá trị khác nhau!");
                }*/
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
                data = null;
            }

            // if no rows are entered or data == null, return null
            return data == null ? null : data;
        }

        private static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //sua
            Console.WriteLine("Lỗi import dữ liệu!");
            Console.ResetColor();
        }
    }
}
