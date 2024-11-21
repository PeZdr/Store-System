using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_System
{
    internal class Program
    {
        static string[,] Products = new string[100, 4];
        static string[,] Sellings = new string[100, 3];
        static int count = 0;
        static int countSell = 0;
        static void Main(string[] args)
        {
            Execute();
        }
        static void Execute()
        {
            int option = -1;
            while (option != 0)
            {
                option = Menu();
                Console.Clear();
                switch (option) 
                { 
                    case 0:
                        break;
                    case 1:
                        RegisterProduct(Products, count);
                        count++;
                        Console.Clear();
                        break;
                    case 2:
                        Sell(Products, Sellings);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        PrintMatrixProducts(Products);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
             
            }
        }

        static int Menu()
        {
            int optionMenu = -1;
            while (optionMenu < 0 || optionMenu > 5)
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Register product");
                Console.WriteLine("2 - Sell");
                Console.WriteLine("3 - Selling report");
                Console.WriteLine("4 - Selling report by employee");
                Console.WriteLine("5 - Show matrix");
                Console.WriteLine("0 - Exit");
                optionMenu = int.Parse(Console.ReadLine());
            }
            return optionMenu;
        }
        
        static void RegisterProduct(string[,] matrix, int count)
        {
            int l = count;
            
                Console.Write("Type a code for the new product: ");
                matrix[l, 0] = Console.ReadLine();
                Console.Write("Write a description for the product: ");
                matrix[l, 1] = Console.ReadLine();
                Console.Write("Type the value of the product: ");
                matrix[l, 2] = Console.ReadLine();
                Console.Write("Type the amount of the product: ");
                matrix[l, 3] = Console.ReadLine();
       
        }

        static void PrintMatrixProducts(string[,] matrix)
        {
            Console.Write("CodProd\t\tDescription\t\tValue\t\tAmount\n");
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (c < 2)
                    {
                        Console.Write($"{matrix[l, c]}\t\t");
                    }
                    else
                    {
                        Console.Write($"\t{matrix[l, c]}\t");
                    }
                    
                }
                Console.WriteLine();
            }
        }
        static bool ExistCode(string[,] matrix, int code)
        {
            for (int l = 0; l < 100; l++)
            {
                if (matrix[l, 0] == code.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        static void Sell(string[,] matrixProducts, string[,] matrixSell)
        {
            bool end = false;
            while (end != true)
            {
                int code = 0;
                int amount = 0;
                Console.Write("Type a product code: ");
                code = int.Parse(Console.ReadLine());

                if (ExistCode(matrixProducts, code) == true)
                {
                    matrixSell[countSell, 0] = code.ToString();
                }
                else
                {
                    Console.WriteLine("Invalid code!");
                    break;
                }

                Console.Write("Write the employee code: ");
                matrixSell[countSell, 1] = Console.ReadLine();

                Console.Write("Type the amount you are selling: ");
                amount = int.Parse(Console.ReadLine());

                
                    if (int.Parse(matrixProducts[code,3]) >= amount)
                    {
                        matrixProducts[code, 3] = (int.Parse(matrixProducts[code, 3]) - amount).ToString();
                    matrixSell[countSell, 2] = amount.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount!");
                    }

                Console.Clear();
                

                end = true;
            }
            
        }
    }
}
