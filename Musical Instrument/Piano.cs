using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instrument
{
    public class Piano : MusicalInstrument
    {
        protected string[] arrTypeKeys = { "Октавная", "Шкальная", "Дигитальная" };
        /// <summary>
        /// Количество клавиш
        /// </summary>
        private int _CountButtons;
        public int CountButtons
        {
            get => _CountButtons;
            set
            {
                if (value < 0)
                    _CountButtons = 0;
                else
                    _CountButtons = value;
            }
        }

        /// <summary>
        /// Раскладка клавиш
        /// </summary>
        private string _TypeKeys;
        public string TypeKeys
        {
            get => _TypeKeys;
            set
            {
                if (value is not null && value != "")
                    _TypeKeys = value;
                else
                    _TypeKeys = "Unknown";
            }
        }

        /// <summary>
        /// Конструкторы без параметров
        /// </summary>
        public Piano() : base("Piano", -1)
        {
            CountButtons = 0;
            TypeKeys = "Unknown";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Piano(string name, int countButtons, string typeKeys, int number) : base(name, number)
        {
            this.CountButtons = countButtons;
            this.TypeKeys = typeKeys;
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Виртуальный метод вывода информации и объекте
        /// </summary>
        public override void ShowVirtualMethod()
        {
            base.ShowVirtualMethod();
            Console.WriteLine($"Количество клавиш пианино: {CountButtons}. Тип клавиатуры: {TypeKeys}");
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Обычный метод вывода информации и объекте
        /// </summary>
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Количество клавиш пианино: {CountButtons}. Тип клавиатуры: {TypeKeys}");
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Метод заполения параметров с кавиатуры
        /// </summary>
        public override void Init()
        {
            base.Init();

            Console.WriteLine("Введите название инструмента:");
            try
            {
                CountButtons = int.Parse(Console.ReadLine());
            }
            catch
            {
                CountButtons = -1;
            }

            Console.WriteLine("Введите раскладку клавиатуры:");
            TypeKeys = Console.ReadLine();
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Метод заполения параметров рандомно
        /// </summary>
        public override void RandomInit()
        {
            Name = "Piano";
            CountButtons = rand.Next(0, 100);
            Id.Number = rand.Next(1, 100);
            TypeKeys = arrTypeKeys[rand.Next(0, arrTypeKeys.Length)];
        }

        /// <summary>
        /// Переопределение equals
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Piano)
                return this.Name == ((Piano)obj).Name && this.CountButtons == ((Piano)obj).CountButtons && this.TypeKeys == ((Piano)obj).TypeKeys;
            return false;
        }

        /// <summary>
        /// Переопределение tostring
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + $", Количество клавиш {CountButtons}, Тип клавиатуры {TypeKeys}";
        }

        /// <summary>
        /// Колонирование объекта
        /// </summary>
        public override object Clone()
        {
            return new Piano(Name, CountButtons, TypeKeys, Id.Number);
        }
    }
}
