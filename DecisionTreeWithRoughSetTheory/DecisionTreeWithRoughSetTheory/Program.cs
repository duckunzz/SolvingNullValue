using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DecisionTreeWithRoughSetTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowWidth = Console.LargestWindowWidth - 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DECISON TREE USING ID3 ALGORITHM");
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();

            do
            {
                DataTable data = new DataTable();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1 - Chọn dữ liệu từ file CSV");
                Console.WriteLine("2 - Kết thúc chương trình");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Mời nhập lựa chọn");
                Console.ResetColor();
                String input = ReadLineTrimmed();

                switch (input)
                {
                    // data will be imported from csv file
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nNhập đường dẫn của file .csv dữ liệu");
                        Console.ResetColor();
                        input = ReadLineTrimmed();

                        data = ImportCSVFile.ImportFromCsvFile(input);

                        if (data == null)
                        {
                            DisplayErrorMessage("Lỗi đọc file .csv. Nhấn nút bất kỳ để thoát chương trình!");
                            Console.ReadKey();
                            EndProgram();
                        }
                        else
                        {
                            CreateTreeAndHandleUserOperation(data);
                            for (int i = 0; i < data.Rows.Count; i++)
                            {
                                for (int j = 0; j < data.Columns.Count; j++)
                                    Console.Write(data.Rows[i][j].ToString() + " ");
                                Console.WriteLine();
                            }
                                    Tree.In(data);
                        }

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
            Console.WriteLine("\nID3 Decision được tạo!");
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
            Environment.Exit(0);
        }
        
    }
}
