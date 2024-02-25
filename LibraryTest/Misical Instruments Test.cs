using Musical_Instrument;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Сравнение разных способов создания объектов
        /// </summary>
        [Fact]
        public void CheckDifferentConstructions()
        {
            MusicalInstrument mi1 = new MusicalInstrument();
            MusicalInstrument mi2 = new MusicalInstrument("NoName", 1);
            Assert.Equal(mi1, mi2);
        }

        /// <summary>
        /// Проверка вывода
        /// </summary>
        [Fact]
        public void CheckShowMethod()
        {
            MusicalInstrument mi = new MusicalInstrument("Guitar", 10);
            Assert.Equal("id: 10. Guitar", mi.ToString());
        }

        /// <summary>
        /// Проверка метода Compare
        /// </summary>
        [Fact]
        public void CheckCompare()
        {
            MusicalInstrument mi1 = new MusicalInstrument();
            MusicalInstrument mi2 = new MusicalInstrument("NoName", 1);
            Assert.Equal(0, mi1.CompareTo(mi2));
        }

        /// <summary>
        /// Проверка метода Equals
        /// </summary>
        [Fact]
        public void CheckEquals()
        {
            MusicalInstrument mi1 = new MusicalInstrument();
            MusicalInstrument mi2 = new MusicalInstrument("Guitar", 1);
            Assert.False(mi1.Equals(mi2));
        }

        /// <summary>
        /// Проверка копирования
        /// </summary>
        [Fact]
        public void CheckCopy()
        {
            MusicalInstrument mi1 = new MusicalInstrument("Guitar", 1);
            MusicalInstrument mi2 = (MusicalInstrument)mi1.ShallowCopy();
            mi1.Id.Number = 10;
            Assert.Equal(mi1, mi2);
        }

        /// <summary>
        /// Проверка клонирования
        /// </summary>
        [Fact]
        public void CheckClone()
        {
            MusicalInstrument mi1 = new MusicalInstrument("Guitar", 1);
            MusicalInstrument mi2 = (MusicalInstrument)mi1.Clone();
            mi1.Name = "Piano";
            Assert.NotEqual(mi1, mi2);
        }

        /// <summary>
        /// Проверка клонирования
        /// </summary>
        [Fact]
        public void CheckID()
        {
            MusicalInstrument mi1 = new MusicalInstrument("Guitar", 10);
            MusicalInstrument mi2 = (MusicalInstrument)mi1.Clone();
            mi1.Id.Number = 5;
            Assert.False(mi1.Id.Equals(mi2.Id));
        }
    }
}