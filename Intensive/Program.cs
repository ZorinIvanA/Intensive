using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive
{
    delegate double AreaCount(int[] source);

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Файл
                //if (!File.Exists("source.txt"))
                //{
                //    Console.WriteLine("File not exists");
                //    return;
                //}
                //Читаем файл
                //var lines = File.ReadAllLines("source.txt");
                //var readArray = new int[lines.Length][];
                //for (var i = 0; i < lines.Length; i++)
                //{
                //    var items = lines[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //    readArray[i] = new int[items.Length];
                //    for (var j = 0; j < items.Length; j++)
                //    {
                //        readArray[i][j] = int.Parse(items[j]);
                //    }
                //}

                ////Нахождение максимального числа в каждой строке
                //var result = new int[lines.Length];
                //for (var i = 0; i < result.Length; i++)
                //{
                //    result[i] = readArray[i].Max();
                //}

                ////Запись результата в отдельный файл
                //var s = string.Empty;
                //foreach(var item in result)
                //{
                //    s += $"{item};";
                //}
                //File.WriteAllText("output.txt", s);
                #endregion

                #region Потоки
                //Console.WriteLine("Введите количество потоков");
                //var threadsCount = int.Parse(Console.ReadLine());

                //var tasks = new Task[threadsCount];
                //for (int threadNumber = 0; threadNumber < threadsCount; threadNumber++)
                //{
                //    tasks[threadNumber] = CreateAndWriteData(threadNumber);
                //}
                #endregion

                #region Фигуры
                ////Квадрат
                //Console.WriteLine(GetArea(new int[] { 10 }, (source) => { return Math.Pow(source[0], 2); }));

                ////Треугольник
                //Console.WriteLine(GetArea(
                //    new int[] { 10, 5, 10 },
                //    (source) =>
                //    {
                //        var p = (source[0] + source[1] + source[2]) / 2;
                //        return Math.Sqrt(p * (p - source[0]) * (p - source[1]) * (p - source[2]));
                //    }));

                ////Площадь круга
                //Console.WriteLine(GetArea(new int[] { 10 }, source =>
                //{
                //    return Math.Pow(source[0], 2) * Math.PI;
                //}));
                #endregion

                if (!File.Exists("source.txt"))
                {

                    Console.WriteLine("File not exists completely!!!! totally!!!");
                    return;
                }
                //Читаем файл
                var readArray = File.ReadAllLines("source.txt")
                    .Select(line =>
                        line
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(item => int.Parse(item)))
                    .OrderBy(line => line.Sum())
                    .Select(line => 
                    {
                        var s = string.Empty;
                        foreach (var item in line)
                        {
                            s += $"{item};";
                        }
                        return s;
                    });

                foreach (var line in readArray)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }

        private static double GetArea(int[] source, AreaCount function)
        {
            return function(source);
        }

        private static Task CreateAndWriteData(int threadNumber)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(threadNumber);
                var rnd = new Random(threadNumber);
                var array = new int[1000];
                for (var i = 0; i < 1000; i++)
                {
                    array[i] = rnd.Next();
                }

                Console.WriteLine($"Поток {threadNumber}, максимальный элемент {array.Max()}");
            });
        }

        private static void SwapNumbers(int[] intsArray, int i)
        {
            var temp = intsArray[i];
            intsArray[i] = intsArray[i + 1];
            intsArray[i + 1] = temp;
        }

        private static void WriteTwoDimensionsArray(int[,] intsArray3)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{intsArray3[j, i]}, ");
                }
                Console.WriteLine();
            }
        }

        private static void WriteArray(int[] intsArray)
        {
            foreach (var x in intsArray)
            {
                Console.Write($"{x}, ");
            }
            Console.WriteLine();
        }

        static int[] GetArray1()
        {
            var intsArray = new int[6];
            intsArray[0] = 12;
            intsArray[1] = 15;
            intsArray[2] = 9;
            intsArray[3] = 98;
            intsArray[4] = 54;
            intsArray[5] = 23;

            return intsArray;
        }
    }
}
