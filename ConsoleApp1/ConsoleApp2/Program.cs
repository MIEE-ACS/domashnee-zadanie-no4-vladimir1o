using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Как заполним двумерный массив (8x8)?\n0-рандомно\n1-вручную\n2-возьмём готовый");
            int choise;
            int[][] arr = new int[8][];
            Random rnd = new Random();

            try
            {
                choise = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong data!");
                Console.WriteLine("\n0-рандомно\n1-вручную\n");
                choise = int.Parse(Console.ReadLine());
                Console.ReadKey();
            }

            if (choise == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int[] newarr = new int[8];
                    for (int j = 0; j < 8; j++)
                    {
                        newarr[j] = rnd.Next(-10, 10);
                    }
                    arr[i] = newarr;
                }
            }

            else if (choise == 1)
            {
                
                Console.WriteLine("Пример ввода значений: 1 2 3 4 5 6 7 8\nВ массиве первый элемент строки будет равен 1, второй 2 и т.д.");
                try
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.WriteLine($"Введите 8 элементов {i + 1} строки (через пробел!) ");
                        arr[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    }
                }
                catch
                {
                    Console.WriteLine("Проблема при вводе значений, перезапустите программу и попробуйте снова!");
                    Console.ReadKey();
                }
                
            }

            else if (choise == 2)
            {
                arr[0] = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
                arr[1] = new int[8] { 2, 2, 3, -5, 4, 6, -10, 8 };
                arr[2] = new int[8] { 3, 2, 3, 4, 5, 6, 7, 8 };
                arr[3] = new int[8] { 4, -5, 4, 4, 5, 6, 7, 8 };
                arr[4] = new int[8] { 5, 2, 3, 5, 5, 6, 7, 8 };
                arr[5] = new int[8] { 6, 2, 3, 6, 5, 6, 7, 8 };
                arr[6] = new int[8] { 7, 2, 3, 7, 5, 6, 7, 8 };
                arr[7] = new int[8] { 8, 2, 3, 8, 5, 6, 7, 8 };
            }

            try
            {
                foreach (int[] row in arr)
                {
                    foreach (int number in row)
                    {
                        Console.Write($"{number} \t");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Проблема при вводе значений, перезапустите программу и попробуйте снова!");
                Console.ReadKey();
            }

            try
            {
                for (int i = 0, l = 0; i < arr.Length; i++, l++)
                {
                    int match = 0;
                    for (int j = 0, m = 0; j < arr[i].Length; j++, m++)
                    {
                        if (arr[m][l] == arr[i][j]) { match++; }
                        if (match == 8) { Console.Write($"\n{i + 1} строка и {l + 1} столбец совпадают"); }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Проблема при поиске совпадений, это может говорить о том что в какой-то строке не 8 элементов." +
                    "\nПерезапустите программу и попробуйте снова!");
                Console.ReadKey();
            }

            bool isnegative, justonrnegative = false;
            int sum;

            for (int i = 0; i < arr.Length; i++)
            {
                isnegative = false;
                sum = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < 0) 
                    { 
                        isnegative = true;
                        justonrnegative = true;
                        sum = arr[i].Sum();
                    }        
                }

                if (isnegative) { Console.WriteLine($"\nСумма элементов {i + 1} строки: {sum}"); }
            }
            if (justonrnegative == false) { Console.WriteLine("\nВ массиве нет строк с отрицательными элементами"); }

            Console.ReadKey();
        }
    }
}
