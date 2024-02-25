using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Musical_Instrument
{
    public class ElectricGuitar : Guitar
    {
        protected string[] arrSource = { "USB", "Батарейки", "Аккамуляторы" };
        /// <summary>
        /// Источник питания
        /// </summary>
        private string _EnetgySource;
        public string EnergySource
        {
            get => _EnetgySource;
            set
            {
                if (value is string && value != "")
                    _EnetgySource = value;
                else
                    _EnetgySource = "NoSource";
            }
        }

        /// <summary>
        /// Конструкторы без параметров
        /// </summary>
        public ElectricGuitar() : base("ElectricGuitar", -1, -1) => EnergySource = "NoSource";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public ElectricGuitar(string name, int countString, string source, int number) : base(name, countString, number) => EnergySource = source;

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Виртуальный метод вывода информации и объекте
        /// </summary>
        public override void ShowVirtualMethod()
        {
            base.ShowVirtualMethod();
            Console.WriteLine($"Источник питания гитары: {EnergySource}");
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Обычный метод вывода информации и объекте
        /// </summary>
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Источник питания гитары: {EnergySource}");
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Метод заполения параметров с кавиатуры
        /// </summary>
        public override void Init()
        {
            Console.WriteLine("Введите название инструмента:");
            Name = Console.ReadLine();

            Console.WriteLine("Введите название инструмента:");
            try
            {
                CountString = int.Parse(Console.ReadLine());
            }
            catch
            {
                CountString = -1;
            }

            Console.WriteLine("Введите источник питания клавиатуры:");
            EnergySource = Console.ReadLine();
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Метод заполения параметров рандомно
        /// </summary>
        public override void RandomInit()
        {
            Name = "ElectricGuitar";
            CountString = rand.Next(0, 100);
            EnergySource = arrSource[rand.Next(0, arrSource.Length)];
        }
        
        /// <summary>
        /// Переопределение equals
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is ElectricGuitar)
                return this.Name == ((ElectricGuitar)obj).Name && this.CountString == ((ElectricGuitar)obj).CountString && this.EnergySource == ((ElectricGuitar)obj).EnergySource;
            return false;
        }

        /// <summary>
        /// Переопределение tostring
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + $", Источник питания {EnergySource}";
        }

        /// <summary>
        /// Колонирование объекта
        /// </summary>
        public override object Clone()
        {
            return new ElectricGuitar(Name, CountString, EnergySource, Id.Number);
        }
    }
}
