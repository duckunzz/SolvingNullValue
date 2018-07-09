using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Missing_Data
{
    class IndexValueOfAttributes
    {
        public IndexValueOfAttributes(string value, List<int> indexOfValue)
        {
            Value = value;
            IndexOfValue = indexOfValue;
        }
        public string Value { get; set; }
        public List<int> IndexOfValue { get; set; }

        public static IndexValueOfAttributes GetIndexValueOfAttributes(DataTable data, string value, int columnIndex)
        {
            
            List<int> index = new List<int>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][columnIndex].ToString().Equals(value))
                    index.Add(i);
            }
            
            IndexValueOfAttributes IndexValue = new IndexValueOfAttributes(value, index);
            return IndexValue;

        }
    }
}
