using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ID3_DecisionTree
{
    class Tree
    {
       
        public TreeNode Root { get; set; }

        //In cay ket qua
        public static void Print(TreeNode node, string result, DataTable data)
        {
             if (node.ChildNodes == null || node.ChildNodes.Count == 0)
            //if (node == null)
            {
                string[] seperatedResult = result.Split(' ');

                foreach (var item in seperatedResult)
                {
                    if (item.Equals(seperatedResult[0]))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (item.Equals("--") || item.Equals("-->"))
                    {
                        // empty if but better than checking at .ToUpper() and .ToLower() if
                    }
                    else if (checkDecisonAttributeValue(item, data))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (item.ToUpper().Equals(item))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    //
                    Console.Write(item);
                    Console.ResetColor();
                }

                Console.WriteLine();

                return;
            }

            foreach (TreeNode child in node.ChildNodes)
            {
                Print(child, result + " -- " + child.Edge.ToLower() + " --> " + child.Name.ToUpper(), data);
            }
        }
        //Check co phai gia tri cua thuoc tinh quyet dinh
        public static bool checkDecisonAttributeValue(string value, DataTable data)
        {
            List<string> DecisionAttributeValues = Attributes.GetDifferentAttributeNamesOfColumn(data, data.Columns.Count - 1);
            foreach (var item in DecisionAttributeValues)
                if (item.ToUpper().Equals(value))
                    return true;
            return false;
        }
        public static string CalculateResult(TreeNode root, IDictionary<string, string> valuesForQuery, string result)
        {
            bool valueFound = false;

            result += root.Name.ToUpper() + " -- ";

            if (root.IsLeaf)
            {
                result = root.Edge.ToLower() + " --> " + root.Name.ToUpper();
                valueFound = true;
            }
            else
            {
                foreach (TreeNode childNode in root.ChildNodes)
                {
                    foreach (var entry in valuesForQuery)
                    {
                        if (childNode.Edge.ToUpper().Equals(entry.Value.ToUpper()) && root.Name.ToUpper().Equals(entry.Key.ToUpper()))
                        {
                            valuesForQuery.Remove(entry.Key);
                            //
                            return result + CalculateResult(childNode, valuesForQuery, childNode.Edge.ToLower() + "--> ");
                        }
                    }
                }
            }

            // if the user entered an invalid attribute
            if (!valueFound)
            {
                result = "Không tìm thấy thuộc tính";
            }

            return result;
        }

        //Training cay quyet dinh, tim thuoc tinh phan nhanh
        public static TreeNode Learn(DataTable data, string edgeName)
        {
            TreeNode root = GetRootNode(data, edgeName);

            foreach (var item in root.NodeAttribute.DifferentAttributeNames)
            {
                // if a leaf, leaf will be added in this method
                bool isLeaf = CheckIfIsLeaf(root, data, item);

                // make a recursive call as long as the node is not a leaf
                if (!isLeaf)
                {
                    DataTable reducedTable = CreateSmallerTable(data, item, root.TableIndex);

                    root.ChildNodes.Add(Learn(reducedTable, item));
                }
            }

            return root;
        }

        private static bool CheckIfIsLeaf(TreeNode root, DataTable data, string attributeToCheck)
        {
            bool isLeaf = true;
            List<string> allEndValues = new List<string>();

            // get all leaf values for the attribute in question
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][root.TableIndex].ToString().Equals(attributeToCheck))
                {
                    allEndValues.Add(data.Rows[i][data.Columns.Count - 1].ToString());
                }
            }

            // check whether all elements of the list have the same value
            if (allEndValues.Count > 0 && allEndValues.Any(x => x != allEndValues[0]))
            {
                isLeaf = false;
            }

            // create leaf with value to display and edge to the leaf
            if (isLeaf)
            {
                root.ChildNodes.Add(new TreeNode(true, allEndValues[0], attributeToCheck));
            }

            return isLeaf;
        }

        private static DataTable CreateSmallerTable(DataTable data, string edgePointingToNextNode, int rootTableIndex)
        {
            DataTable smallerData = new DataTable();

            // add column titles
            for (int i = 0; i < data.Columns.Count; i++)
            {
                smallerData.Columns.Add(data.Columns[i].ToString());
            }

            // add rows which contain edgePointingToNextNode to new datatable
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][rootTableIndex].ToString().Equals(edgePointingToNextNode))
                {
                    var row = new string[data.Columns.Count];

                    for (var j = 0; j < data.Columns.Count; j++)
                    {
                        row[j] = data.Rows[i][j].ToString();
                    }

                    smallerData.Rows.Add(row);
                }
            }

            // remove column which was already used as node            
            smallerData.Columns.Remove(smallerData.Columns[rootTableIndex]);

            return smallerData;
        }
        // Xac dinh nut goc
        private static TreeNode GetRootNode(DataTable data, string edge)
        {
            List<Attributes> attributes = new List<Attributes>();
            int highestInformationGainIndex = -1;
            double highestInformationGain = double.MinValue;

            // Get all names, amount of attributes and attributes for every column        
            //Lay ten thuoc tinh, va gia tri cua tung thuoc tinh tuong ung voi moi cot trong data
            for (int i = 0; i < data.Columns.Count - 1; i++)
            {
                var differentAttributenames = Attributes.GetDifferentAttributeNamesOfColumn(data, i);
                //DS thuoc tinh, va gia tri
                attributes.Add(new Attributes(data.Columns[i].ToString(), differentAttributenames));
            }

            // Tinh Entropy (S)
            //Tinh do thuan nhat cua tap du lieu
            var tableEntropy = CalculateTableEntropy(data);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Độ thuần nhất của tập dữ liệu " + tableEntropy);
            //Tinh Entropy tung thuoc tinh
            for (int i = 0; i < attributes.Count; i++)
            {
   
                //Console.WriteLine("---------");
               // Console.WriteLine("Thuộc tính: " + attributes[i].Name);
                //attributes[i].InformationGain = GetGainForAllAttributes(data, i, tableEntropy);
                //Console.WriteLine("Giá trị Gain: " + attributes[i].InformationGain);
                //Console.WriteLine("---------");
                //Thuoc tinh co Entropy lon nhat se chon lam nut goc
                if (attributes[i].InformationGain > highestInformationGain)
                {
                    highestInformationGain = attributes[i].InformationGain;
                    highestInformationGainIndex = i;
                }
            }
            //Console.WriteLine("---------------------------");
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Thuộc tính lựa chọn: " + attributes[highestInformationGainIndex].Name);
            //Console.ResetColor();
            return new TreeNode(attributes[highestInformationGainIndex].Name, highestInformationGainIndex, attributes[highestInformationGainIndex], edge);
        }

        private static double GetGainForAllAttributes(DataTable data, int colIndex, double entropyOfDataset)
        {
            int totalRows = data.Rows.Count;
            var amountForDifferentValue = GetAmountOfEdgesAndTotalPositivResults(data, colIndex);
            List<double> stepsForCalculation = new List<double>();

            foreach (var item in amountForDifferentValue)
            {
                // helper for calculation
                double firstDivision = item[0, 1] / (double)item[0, 0];
                double secondDivision = (item[0, 0] - item[0, 1]) / (double)item[0, 0];

                // prevent dividedByZeroException
                if (firstDivision == 0 || secondDivision == 0)
                {
                    stepsForCalculation.Add(0.0);
                }
                else
                {
                    stepsForCalculation.Add(-firstDivision * Math.Log(firstDivision, 2) - secondDivision * Math.Log(secondDivision, 2));
                }
            }

            var gain = stepsForCalculation.Select((t, i) => amountForDifferentValue[i][0, 0] / (double)totalRows * t).Sum();

            gain = entropyOfDataset - gain;

            return gain;
        }

        //Tinh do thuan nhat cua tap du lieu
        private static double CalculateTableEntropy(DataTable data)
        {
            var totalRows = data.Rows.Count;
            //Gia tri khac nhau cua thuoc tinh quyet dinh
            var amountForDifferentValue = GetAmountOfEdgesAndTotalPositivResults(data, data.Columns.Count - 1);

            var stepsForCalculation = amountForDifferentValue
                .Select(item => item[0, 0] / (double)totalRows)
                .Select(division => -division * Math.Log(division, 2))
                .ToList();

            return stepsForCalculation.Sum();
        }

        private static List<int[,]> GetAmountOfEdgesAndTotalPositivResults(DataTable data, int indexOfColumnToCheck)
        {
            var foundValues = new List<int[,]>();
            var knownValues = CountKnownValues(data, indexOfColumnToCheck);

            foreach (var item in knownValues)
            {
                var amount = 0;
                var positiveAmount = 0;

                for (var i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i][indexOfColumnToCheck].ToString().Equals(item))
                    {
                        amount++;

                        // Counts the positive cases and adds the sum later to the array for the calculation
                        if (data.Rows[i][data.Columns.Count - 1].ToString().Equals(data.Rows[0][data.Columns.Count - 1]))
                        {
                            positiveAmount++;
                        }
                    }
                }

                int[,] array = { { amount, positiveAmount } };
                foundValues.Add(array);
            }

            return foundValues;
        }

        private static IEnumerable<string> CountKnownValues(DataTable data, int indexOfColumnToCheck)
        {
            var knownValues = new List<string>();

            // Them gia tri dau tien vao knownValues
            if (data.Rows.Count > 0)
            {
                knownValues.Add(data.Rows[0][indexOfColumnToCheck].ToString());
            }

            for (int j = 1; j < data.Rows.Count; j++)
            {
                var newValue = knownValues.All(item => !data.Rows[j][indexOfColumnToCheck].ToString().Equals(item));

                //Them newValue
                if (newValue)
                {
                    knownValues.Add(data.Rows[j][indexOfColumnToCheck].ToString());
                }
            }

            return knownValues;
        }
    }
}
