using Musical_Instrument;

namespace Piano_Test
{
    public class UnitTest1
    {
        /// <summary>
        /// Сравнение разных способов создания объектов
        /// </summary>
        [Fact]
        public void CheckDifferentConstructions()
        {
            Piano piano1 = new Piano();
            Piano piano2 = new Piano("Piano", 0, "Unknown", -1);
            Assert.Equal(piano1, piano2);
        }

        /// <summary>
        /// Проверка метода Compare
        /// </summary>
        [Fact]
        public void CheckCompare()
        {
            Piano piano1 = new Piano();
            Piano piano2 = new Piano("Piano", 0, "Unknown", -1);
            Assert.Equal(0, piano1.CompareTo(piano2));
        }

        /// <summary>
        /// Проверка метода Equals
        /// </summary>
        [Fact]
        public void CheckEquals()
        {
            Piano piano1 = new Piano();
            Piano piano2 = new Piano("Piano", 0, "Unknown", -1);
            Assert.True(piano1.Equals(piano2));
        }

        /// <summary>
        /// Проверка копирования
        /// </summary>
        [Fact]
        public void CheckCopy()
        {
            Piano piano1 = new Piano("Piano", 5, "Октавная", 6);
            Piano piano2 = (Piano)piano1.ShallowCopy();
            piano1.Id.Number = 2;
            Assert.Equal(piano1, piano2);
        }

        /// <summary>
        /// Проверка клонирования
        /// </summary>
        [Fact]
        public void CheckClone()
        {
            Piano piano1 = new Piano("Piano", 5, "Октавная", 6);
            Piano piano2 = (Piano)piano1.Clone();
            piano1.Name = "Guitar";
            Assert.NotEqual(piano1, piano2);
        }

        /// <summary>
        /// Проверка свойств
        /// </summary>
        [Fact]
        public void SetCountString()
        {
            Piano piano = new Piano("Piano", 5, "Октавная", 6);
            piano.Id.Number = 10;
            piano.CountButtons = 15;
            piano.TypeKeys = "NoType";
            Assert.Equal(15, piano.CountButtons);
            Assert.Equal(10, piano.Id.Number);
            Assert.Equal("NoType", piano.TypeKeys);
        }

        /// <summary>
        /// Проверка на преобразование свойств
        /// </summary>
        [Fact]
        public void CheckCountStringArePositive()
        {
            Guitar guitar = new Guitar("Guitar", 0, -10);
            Assert.Equal(0, guitar.CountString);
        }
    }
}