using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program
    {
        static int GetNumberOfPairs(int[] array, int length) // Задание 1
        {
            int amountOfPairs = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                {
                    amountOfPairs++;
                }
            }
            return amountOfPairs;
        }

        static int GetInt() // Задание 3
        {
            while (true)
                if (!int.TryParse(Console.ReadLine(), out int x))
                    Console.Write("Неверный ввод (требуется числовое значение).\nПожалуйста, повторите ввод: ");
                else return x;
        }


        struct Account // Задание 4
        {
            public string Login;
            public string Password;

            // Метод, считывающий логин и пароль из файла

            public void loadFromFile(string filename)
            {
                filename = "..\\..\\" + filename;
                StreamReader sr = new StreamReader(filename);

                Login = sr.ReadLine();

                Password = sr.ReadLine();

                sr.Close();
            }

        }

        // Метод поверяет корректность логина и пароля
        static bool CheckLogAndPass(Account toCheck)
        {
            if (toCheck.Login == "root" && toCheck.Password == "GeekBrains")
                return true;
            else
                return false;
        }

        static string RightTryWord(int x)
        {
            string s = "";
            // Попытка, когда заканчивается на один, кроме 11.
            if (x % 10 == 1 && x != 11) s += " попытка";
            else

                if ((x >= 2 && x <= 4) || (x >= 22 && x <= 24) || (x >= 32 && x <= 34) || (x > 41 && x < 45)) s += " попытки";
            else

                    if ((x == 11) || (x >= 5 && x <= 20) || (x >= 25 && x <= 30) || (x >= 35 && x < 41) || (x > 44 && x < 51)) s += " попыток";
            return s;
        }

        static void Main(string[] args)
        {
            #region Задание 1

            const int arrayLength = 20;
            int[] myArray = new int[arrayLength];
            Random random = new Random();
            int result;

            Console.WriteLine("Вас приветствует программа подсчёта пар элементов, в которых хотя бы одно число делится на 3.");
            Console.Write("\nВ следующем массиве [ ");
            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = random.Next(-10000, 10001);
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine("\b\b ]\n");

            result = GetNumberOfPairs(myArray, arrayLength);

            Console.WriteLine($"Количество пар: {result}");

            Console.ReadKey();

            #endregion

            #region Задание 3

            {
                Console.WriteLine("Вас приветствует программа демонстрации возможностей класса для работы с массивом");
                Console.Write("Введите желаемый размер массива: ");
                int size = GetInt();
                Console.Write("Введите первый элемент массива: ");
                int firstElement = GetInt();
                Console.Write("Введите шаг для добавления последующих элементов: ");
                int step = GetInt();

                MyArray a = new MyArray(size, firstElement, step); // MyArray - название текстового файла с массивом

                Console.WriteLine("\nСоздан массив: [ " + a.ToString() + " ]\n");

                Console.WriteLine("Сумма элементов массива: " + a.Sum);

                a.Inverse = -1;

                Console.WriteLine("Массив с изменёнными знаками: [ " + a.ToString() + " ]\n");

                Console.Write("Введите число, на которое будут умножены элементы массива: ");

                a.Multi = GetInt();

                Console.WriteLine("Массив, умноженный на число: [ " + a.ToString() + " ]\n");

                Console.WriteLine("Максимальный элемент массива: " + a.Max);

                Console.WriteLine("Количество максимальных элементов массива: " + a.MaxCount);

                Console.WriteLine("=============================================================");
                Console.WriteLine("Далее массив создаётся загрузкой данных из файла.");

                string fileName = "..\\..\\array.txt";
                MyArray myArray = new MyArray(fileName);

                Console.WriteLine("Создан следующий массив: [ " + myArray.ToString() + " ]\n");

                string fileName2 = "..\\..\\anotherArray.txt";

                Console.WriteLine("\nЗагрузим массив из файла при помощи метода.");

                myArray.loadFromFile(fileName2);

                Console.WriteLine("Загружен следующий массив: [ " + myArray.ToString() + " ]\n");

                Console.WriteLine("\nСохраним массив в файл " + fileName + " при помощи метода.");

                myArray.saveIntoFile(fileName);

                MyArray myArray2 = new MyArray(fileName);

                Console.WriteLine("Проверим содержимое файла, загрузив из него новый массив: [ " + myArray2.ToString() + " ]\n");

                Console.ReadKey();
            }

            #endregion

            #region Задание 4

            {
                Console.WriteLine("Вас приветствует программа проверки логина и пароля, считанных из файла.");
                int AmountOfTries = 3;

                string[] fileName = { "data.txt", "tryData.txt", "reallyTryData.txt" };

                Account account;
                account.Login = "";
                account.Password = "";

                int i = 0;

                do
                {
                    Console.WriteLine("\nЗагрузим файл: " + fileName[i]);
                    account.loadFromFile(fileName[i]);

                    Console.Write("Попытка авторизации: ");

                    if (CheckLogAndPass(account))
                    {

                        break;
                    }
                    else
                    {
                        AmountOfTries--;
                        Console.WriteLine("Неверный ввод логина или пароля." +
                            Environment.NewLine + "У Вас осталось " + AmountOfTries + RightTryWord(AmountOfTries));
                    }
                    i++;
                } while (AmountOfTries > 0);

                Console.Write("Авторизация успешна!");

                Console.ReadKey();

                #endregion
            }
        }
    }
}
