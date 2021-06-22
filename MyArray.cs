using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lesson4
{
    class MyArray
    {
        int[] a;

        // Конструктор, создающий массив и заполняющий его заданным значением


        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }

        // Конструктор, создающий массив заданной размерности и 
        // заполняющий массив числами от начального значения с заданным шагом

        public MyArray(int n, int firstElement, int step)
        {
            a = new int[n];
            a[0] = firstElement;
            for (int i = 1; i < n; i++)
                a[i] = a[i - 1] + step;
        }

        // Конструктор, считывающий массив из файла

        public MyArray(string filename)
        {
            if (File.Exists(filename))
            {
                string[] ss = File.ReadAllLines(filename);
                a = new int[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Error load file");
        }

        // Свойство, возвращает максимальный элемент массива
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }

        // Cвойство возвращаем сумму элементов массива
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                    sum += a[i];
                return sum;
            }
        }

        // Метод меняет знаки у всех элементов массива
        public int Inverse
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                    a[i] = a[i] * -1;
            }
        }

        // Метод умножает каждый элемент массива на определенное число
        public int Multi
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                    a[i] = a[i] * value;
            }
        }

        // Свойство, возвращает минимальный элемент массива
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }

        // Свойство, возвращает число положительных элементов массива
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }


        // Свойство возвращает количество максимальных элементов
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) count++;
                return count;
            }
        }

        // Метод, возвращающий строковое представление массива

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }

        // Метод, записывающий массив в файл

        public void saveIntoFile(string filename)
        {
            StreamWriter wr = new StreamWriter(filename);
            for (int i = 0; i < a.Length; i++)
            {
                wr.WriteLine(a[i]);
            }
            wr.Close();
        }

        // Метод, загружающий массив из файла

        public void loadFromFile(string filename)
        {

            StreamReader sr = new StreamReader(filename);
            int N = 0;
            while (sr.ReadLine() != null) { N++; }

            a = new int[N];
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            for (int i = 0; i < N; i++)
            {
                a[i] = int.Parse(sr.ReadLine());
            }
            sr.Close();
        }

    }
}
