using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Missing_Data
{
    class DataTraining
    {
        public static DataTable DataTrain(DataTable data, String nullField)
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
                Console.Write(dataTraining.Columns[i].ToString() + " ");
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
    }
}
