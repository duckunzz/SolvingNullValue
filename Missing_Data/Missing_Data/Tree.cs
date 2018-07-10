using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Missing_Data
{
    class Tree
    {
        public static StringBuilder fileContent1;
        
        public TreeNode Root { get; set; }

        //In cay ket qua
        public static void Print(TreeNode node, string result, DataTable data)
        {
            if (node.ChildNodes == null || node.ChildNodes.Count == 0)
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
                    fileContent1.Append(item.ToString());
                    Console.ResetColor();
                }

                Console.WriteLine();
                fileContent1.Append(System.Environment.NewLine.ToString());
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
        
        public static bool checkRDT(DataTable data)
        {
            if (Attributes.GetDifferentAttributeNamesOfColumn(data, data.Columns.Count - 1).Count == 1)
            {
                
                return true;
            }
            else
                return false;
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
                        //DataTable reducedTable = CreateSmallerTable(data, item, root.TableIndex);
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
        //check he co thuan nhat
        private static bool checkData(DataTable data)
        {
            var differntAttributenames = Attributes.GetDifferentAttributeNamesOfColumn(data, data.Columns.Count - 1);
            if (differntAttributenames.Count != 1)
                return false;
            return true;

        }
        // Xac dinh nut goc
        private static TreeNode GetRootNode(DataTable data, string edge)
        {
            //Kiem tra he thong tin la thuan nhat?
            if (checkData(data))
            {
                
                for (int i = 0; i < data.Columns.Count; i++)
                    if (edge.ToString().Equals(data.Columns[i]))
                        return new TreeNode(true, edge, data.Rows[i][data.Columns.Count - 1].ToString());
            }
            
            List<Attributes> attributes = new List<Attributes>();
            var highestPos = 0;
            var highestPosIndex = 0;      
            //Lay ten thuoc tinh, va gia tri cua tung thuoc tinh tuong ung voi moi cot trong data

            for (int i = 0; i < data.Columns.Count; i++)
            {
                var differentAttributenames = Attributes.GetDifferentAttributeNamesOfColumn(data, i);
                var indexOfValueAttribute = Attributes.GetIndexValueOfAttribute(data, Attributes.GetDifferentAttributeNamesOfColumn(data, i), i);
                attributes.Add(new Attributes(data.Columns[i].ToString(), differentAttributenames, indexOfValueAttribute));

            }

            //Tinh Pos cho tung thuoc tinh
            for (int i = 0; i < attributes.Count - 1; i++)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Thuộc tính: " + attributes[i].Name);
                attributes[i].PosValue = CaculatePosValue(data, attributes[i], attributes[attributes.Count - 1]);
                Console.WriteLine("Giá trị Pos: " + attributes[i].PosValue);

                //Thuoc tinh co Pos lon nhat se chon lam nut goc
                if (attributes[i].PosValue > highestPos)
                {
                    highestPos = attributes[i].PosValue;
                    highestPosIndex = i;
                }
            }

            Console.WriteLine("---------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thuộc tính lựa chọn: " + attributes[highestPosIndex].Name);
            Console.ResetColor();
            return new TreeNode(attributes[highestPosIndex].Name, highestPosIndex, attributes[highestPosIndex], edge);
           
        }
        private static int CaculatePosValue(DataTable data, Attributes attribute, Attributes attributeDecision)
        {
            int PosValue = 0;
            List<List<int>> Pos = new List<List<int>>();
            for (int k = 0; k < attributeDecision.IndexOfDifferentAttributeNames.Count; k++)
            {
                for (int i = 0; i < attribute.IndexOfDifferentAttributeNames.Count; i++)
                {

                    if (checkPos(attribute.IndexOfDifferentAttributeNames[i].IndexOfValue, attributeDecision.IndexOfDifferentAttributeNames[k].IndexOfValue))
                    {
                        Pos.Add(attribute.IndexOfDifferentAttributeNames[i].IndexOfValue);
                        PosValue += Pos[Pos.Count - 1].Count;
                    }
                }
                
            }
            return PosValue;
        }

        private static bool checkPos(List<int> SelectAttribute, List<int> DecisionAttribute)
        {
            int i = SelectAttribute.Count - 1, j = DecisionAttribute.Count - 1;
            int cnt = 0;
            if (i > j)
                return false;
            for (i = 0; i < SelectAttribute.Count; i++)
            {
                bool check = false;
                for (j = 0; j < DecisionAttribute.Count; j++)
                    if (SelectAttribute[i] == DecisionAttribute[j])
                    {
                        check = true;
                        cnt++;
                        break;
                    }
                if (check == false)
                    return false;
            }
            if (cnt == SelectAttribute.Count)
                return true;
            else
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
                result = "unknown";
            }

            return result;
        }
   }
    
}
