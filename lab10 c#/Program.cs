using Musical_Instrument;
using Musical_Instruments;
using System;
using System.Diagnostics;

namespace lab10
{
    public class Musical_Instrument
    {
        /// <summary>
        /// Основная функция
        /// </summary>
        static void Main()

        {
            MusicalInstrument m1 = new("   ", 10);
            MusicalInstrument m2 = new("", 10);
            MusicalInstrument m3 = new("   ", 10);
            string? n = null;
            MusicalInstrument m4 = new(n, 10);
            MusicalInstrument m5 = new("Electric Guitar", 10);
            m1.Show();
            m2.Show();
            m3.Show();
            m4.Show();
            m5.Show();

            //LabFirstAndSecondPart();
            LabThirdPart();
        }

        /// <summary>
        /// 1 и 2 часть лабораторной
        /// </summary>
        static void LabFirstAndSecondPart()
        {
            MusicalInstrument[] arrInstruments = new MusicalInstrument[15];
            for (int i = 0; i < 15; i += 3)
            {
                Guitar guitar = new();
                guitar.RandomInit();
                arrInstruments[i] = guitar;

                ElectricGuitar electricGuitar = new();
                electricGuitar.RandomInit();
                arrInstruments[i + 1] = electricGuitar;

                Piano piano = new();
                piano.RandomInit();
                arrInstruments[i + 2] = piano;
            }
            Console.WriteLine("Вывод информации о 15 объектах классов библиотеки с помощью обычных функций:");
            for (int i = 0; i < arrInstruments.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                arrInstruments[i].Show();
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadLine();
            Console.WriteLine("Вывод информации о 15 объектах классов библиотеки с помощью виртуальных функций:");
            for (int i = 0; i < arrInstruments.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                arrInstruments[i].ShowVirtualMethod();
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadLine();
            Console.WriteLine("Поиск пианино с наибольшим количеством клавиш:");
            GetPiano(arrInstruments).ShowVirtualMethod();
            
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadLine();
            Console.WriteLine("Дальше показана разница проверки операторов с помощью is и typeof.");
            Console.WriteLine("Сравнение на принадлежность классу Guitar с помощью is:");
            FindGuitars(arrInstruments);
            Console.WriteLine();
            Console.WriteLine("Сравнение на принадлежность классу Guitar с помощью typeof:");
            ElectricGuitars(arrInstruments);
        }
        /// <summary>
        /// 3я часть лабораторной работы
        /// </summary>
        static void LabThirdPart()
        {
            IInit[] arr = new IInit[10];
            for (int i = 0; i < arr.Length; i += 2)
            {
                arr[i] = new Student();
                arr[i].RandomInit();
                arr[i + 1] = new Guitar();
                arr[i + 1].RandomInit();
            }

            Console.WriteLine("Вывод объектов массива IInit");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }

            MusicalInstrument[] arrInstruments = new MusicalInstrument[15];
            for (int i = 0; i < 15; i += 3)
            {
                Guitar guitar = new();
                guitar.RandomInit();
                arrInstruments[i] = guitar;

                ElectricGuitar electricGuitar = new();
                electricGuitar.RandomInit();
                arrInstruments[i + 1] = electricGuitar;

                Piano piano = new();
                piano.RandomInit();
                arrInstruments[i + 2] = piano;
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("IComparable: Массив не отсортирован");
            for (int i = 0; i < arrInstruments.Length; i++)
            {
                Console.WriteLine($"{arrInstruments[i]}");
            }

            arrInstruments[2] = new Piano("Grand piano", 10, "Unknown", 1);
            arrInstruments[3] = new Piano("Royale", 10, "Unknown", 1);
            Array.Sort(arrInstruments);
            Console.WriteLine("Массив отсортирован по имени.");
            for (int i = 0; i < arrInstruments.Length; i++)
            {
                Console.WriteLine($"{arrInstruments[i]}");
            }
            Console.WriteLine("Позиция первого в списке человека");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");

            int pos = Array.BinarySearch(arrInstruments, new Piano("Royale", 10, "Unknown", 1));
            int posA = Array.BinarySearch(arrInstruments, new Piano("Grand piano", 10, "Unknown", 1));
            Console.WriteLine($"Позиция пианино ({new Piano("Royale", 10, "Unknown", 1)}): {pos}");
            Console.WriteLine($"Позиция пианино ({new Piano("Grand piano", 10, "Unknown", 1)}): {posA}");
            Console.WriteLine();
            Console.WriteLine("Сортировка по id");

            Piano grandPiano = new Piano("Piano", 10, "Unknown", 100);
            arrInstruments[10] = grandPiano;
            

            Array.Sort(arrInstruments, new SortById());
          
            for (int i = 0; i < arrInstruments.Length; i++)
            {
                Console.WriteLine($"{arrInstruments[i]}");
            }


            int pos2 = Array.BinarySearch(arrInstruments, grandPiano, new SortById());
            Console.WriteLine($"Позиция пианино ({grandPiano}): {pos2}");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadLine();

            Console.WriteLine("Копирование:");
            MusicalInstrument mi = new MusicalInstrument();
            mi.RandomInit();
            Console.WriteLine($"Исходный элемент {mi}");
            MusicalInstrument copy = (MusicalInstrument)mi.ShallowCopy();
            MusicalInstrument clone = (MusicalInstrument)mi.Clone();
            Console.WriteLine($"Копия: {copy}. Исходный: {mi}. Клон {clone}");
            mi.Id.Number = 101;
            Console.WriteLine($"Копия: {copy}. Исходный: {mi}. Клон {clone}");
        }
        /// <summary>
        /// Получить пианино с максимальным количеством клавиш
        /// </summary>
        /// <param name="mi">массив объектов</param>
        /// <returns>пианино с максимальным количеством клавиш</returns>
        static Piano GetPiano(MusicalInstrument[] mi)
        {
            Piano resPiano = new();
            foreach (var item in mi)
            {
                Piano? piano = item as Piano;
                if (piano != null)
                {
                    if (piano.CountButtons >= resPiano.CountButtons)
                    {
                        resPiano = piano;
                    }
                }
            }
            return resPiano;
        }
        /// <summary>
        /// Поиск всех гитар
        /// </summary>
        /// <param name="mi">массив объектов</param>
        static void FindGuitars(MusicalInstrument[] mi)
        {
            foreach (var item in mi)
            {
                if (item is Guitar)
                {
                    item.ShowVirtualMethod();
                }
            }
        }
        /// <summary>
        /// Поиск всех электрогитар
        /// </summary>
        /// <param name="mi">массив объектов</param>
        static void ElectricGuitars(MusicalInstrument[] mi)
        {
            foreach (var item in mi)
            {
                if (item.GetType() == typeof(Guitar))
                {
                    item.ShowVirtualMethod();
                }
            }
        }
    }
}