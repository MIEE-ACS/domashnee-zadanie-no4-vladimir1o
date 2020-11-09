using System;


namespace ConsoleApp1
{
    class Program1
    {
        static void Main()
        {
            Console.Write("Введите количество чисел: ");
            int N;
            Random rnd = new Random();

            try
            {
                N = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong data!");
                Console.Write("\nВведите количество чисел (числом): ");
                N = int.Parse(Console.ReadLine());
                Console.ReadKey();
            }


            if (N <= 0)
            {
                Console.WriteLine("Введены неправельные данные!");
                Console.ReadKey();
            }
            else
            {
                int[] nums = new int[N];
                int max = nums[0];
                int maxNum = 0;
                bool zeroinNums = false;

                //Заполняем массив и ищем максимальный элемент
                for (int i = 0; i < N; i++)
                {
                    nums[i] = rnd.Next(0, 10);
                    Console.Write($"{nums[i]} ");
                    if (nums[i] > max)
                    {
                        max = nums[i];
                        maxNum = i;
                    }
                    if (nums[i] == 0) {zeroinNums = true;}
                }

                Console.WriteLine($"\n\nМаксимальный элемент: {max}, находится на {maxNum + 1} позиции\n");

                // Считаем произведения элементов между нулями (либо между нулём и концом массива)
                if (zeroinNums)
                {
                    int firstZero = Array.IndexOf(nums, 0);
                    int i = firstZero;
                    int multiplication = 1;

                    if ((firstZero == N - 1) || (firstZero == N - 2 && (N - 1 == 0))) { multiplication = 0;}
                    else
                    {
                        while (i != N - 1)
                        {
                            i++;
                            if (nums[i] == 0) { break; }
                            multiplication = nums[i] * multiplication;
                        }
                    }                 
                    Console.WriteLine($"Произведение элементов массива, расположенных между первым и вторым нулевыми элементами: {multiplication}\n");
                }
                else { Console.WriteLine("Нулей в массиве нет!\n"); }

                //Сортируем массив
                //пытался всё сделать в 2 for, но не вышло тк для нечётных N 
                //нужно разное количество итераций для чётных и нечётных элементов

                Console.WriteLine("Отсортированный массив");

                int[] nums2 = new int[N];
                int med;
                if ((N % 2) == 0) { med = (N / 2); }
                else { med = ((N - 1) / 2) + 1;}

                for (int m = 0, j = 0; j < med; m += 2, j++) { nums2[j] = nums[m]; }
                
                for (int j = 0, k = 1; (med + j) < N; j++, k += 2) { nums2[med + j] = nums[k]; }

                for (int j = 0; j < N; j++) { Console.Write($"{nums2[j]} "); }

                Console.ReadKey();
            }
                
            
        }
    }
}
