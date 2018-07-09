using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Missing_Data
{
    class Attributes
    {
        /*
         * Thuoc tinh va cac gia tri cua thuoc tinh
         * Vi du: 
         * Thuoc tinh: Wind voi 2 gia tri
         * CO, KHONG
        */


        public Attributes(string name, List<string> differentAttributenames, List<IndexValueOfAttributes> indexOfDifferentAttributeNames)
        {
            Name = name;
            DifferentAttributeNames = differentAttributenames;
            IndexOfDifferentAttributeNames = indexOfDifferentAttributeNames;
        }

        //Xac dinh gia tri cua thuoc tinh
        public static List<string> GetDifferentAttributeNamesOfColumn(DataTable data, int columnIndex)
        {
            List<string> differentAttributes = new List<string>();
            List<string> DecisionAttributeValues = new List<string>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                //Kiem tra co gia tri thuoc tinh giong nhau khong? Khong co thi them vao differentAttributes
                var found = differentAttributes.Any(t => t.ToUpper().Equals(data.Rows[i][columnIndex].ToString().ToUpper()));

                if (!found)
                {
                    differentAttributes.Add(data.Rows[i][columnIndex].ToString());

                    if (data.Columns.Count - 1 == columnIndex)
                        DecisionAttributeValues.Add(data.Rows[i][columnIndex].ToString());
                }
            }
            return differentAttributes;
        }
        //Lay chi so cua moi gia tri khac nhau cua thuoc tinh
        public static List<IndexValueOfAttributes> GetIndexValueOfAttribute(DataTable data, List<string> differentAttributenames, int columnIndex)
        {
           
            List<IndexValueOfAttributes> IndexOfDifferentAttributeNames = new List<IndexValueOfAttributes>();
            foreach (var item in differentAttributenames)
            {
                IndexOfDifferentAttributeNames.Add(IndexValueOfAttributes.GetIndexValueOfAttributes(data, item, columnIndex));
                
            }

            return IndexOfDifferentAttributeNames;
        }
        //Cac getter, setter
        public string Name { get; set; }

        public List<string> DifferentAttributeNames { get; set; }
        public List<IndexValueOfAttributes> IndexOfDifferentAttributeNames { get; set; }

        public int PosValue { get; set; }


    }
}
