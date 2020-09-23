using System;
using System.Threading;

namespace Lab5
{
    class Program
    {
        static void CosMatr()
        {
            int thredId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Поток {0}, Создание массива...", thredId);
            int N = 10;
            int M = 10;
            double[,] mas = new double[N, M];

            Console.WriteLine("Поток {0}, Инициализация элементов матрицы...", thredId);
            Random rnd = new Random(thredId);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = rnd.Next(10);
                }

            }
         
            Console.WriteLine("Поток {0}. Замена элементов на их косинусы ..", thredId);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Math.Round(Math.Cos(mas[i, j]), 3);
                }

            }
            Console.WriteLine("Поток {0}, Вывод матрицы...", thredId);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            Action mathod = CosMatr;
            Thread[] tmas = new Thread[10];
            for (int i = 0; i < tmas.Length; i++)
            {
                tmas[i] = new Thread(CosMatr);
                tmas[i].Start();
            }

        }
    }
}
