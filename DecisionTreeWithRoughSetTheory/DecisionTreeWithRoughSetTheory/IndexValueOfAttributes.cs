using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DecisionTreeWithRoughSetTheory
{
    class IndexValueOfAttributes
    {
        public IndexValueOfAttributes(string value, List <int> indexOfValue)
        {
            Value = value;
            IndexOfValue = indexOfValue;
        }
        public string Value { get; set; }
        public List<int> IndexOfValue { get; set; }

        public static IndexValueOfAttributes GetIndexValueOfAttributes(DataTable data, string value, int columnIndex)
        {
           // Console.WriteLine("Gia tri: " + value);
            
            List<int> index = new List<int>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][columnIndex].ToString().Equals(value))
                    index.Add(i);
            }
           // Console.WriteLine("So vi tri: " + index.Count);
           // foreach (var item in index)
           //     Console.Write(item + " ");
            IndexValueOfAttributes IndexValue = new IndexValueOfAttributes(value, index);
            return IndexValue;

        }
    }
}
